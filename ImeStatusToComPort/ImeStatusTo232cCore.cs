using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Win32;

using Shapoco.Windows;
using Shapoco.Common;

namespace Shapoco.ImeStatusToComPort
{
    class ImeStatusToComCore : IDisposable
    {
        private ImeStatusIMonitor _imeStatusMonitor;
        private SerialPort _serialPortObject;
        private Timer _serialOpenRetryTimer;
        private Timer _blinkTimer;
        private IntPtr _currentWindowHandle = IntPtr.Zero;
        private ImeState _currentImeState = ImeState.Shutdown;
        private DateTimeOffset _blinkEndTime = DateTimeOffset.MinValue;

        public event LogReportEventHandler LogReport;
        
        public ImeStatusToComCore(Form syncObject)
        {
            // シリアルポートを開く
            var serial = new SerialPort();
            _serialPortObject = serial;
            TryOpen();

            // IME監視の開始
            var monitor = new ImeStatusIMonitor(syncObject);
            monitor.Change += Monitor_Changed;
            _imeStatusMonitor = monitor;

            // シリアルポート監視タイマ起動
            var retryTimer = new Timer();
            _serialOpenRetryTimer = retryTimer;
            retryTimer.Interval = 1000;
            retryTimer.Tick += Timer_Tick;
            retryTimer.Start();

            // 点滅用タイマ
            var flashTimer = new Timer();
            _blinkTimer = flashTimer;
            flashTimer.Interval = 20;
            flashTimer.Tick += delegate { UpdateSerialInternal(); };

            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

        }

        private string _serialPortName = "";
        public string SerialPortName {
            get { return _serialPortName; }
            set {
                var oldValue = _serialPortName;
                if (value == oldValue) return;
                _serialPortName = value;

                // 再接続
                TryOpen();
            }
        }

        public bool IsOnline { get { return _serialPortObject.IsOpen; } }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TryOpen();
        }

        private void Monitor_Changed(object sender, ImeStatusInfo e)
        {
            UpdateSerial(e);
        }

        public void UpdateSerial(bool shutdown = false, bool forceUpdate = false)
        {
            UpdateSerial(ImeStatusIMonitor.GetImeStatus(), shutdown, forceUpdate);
        }

        private void UpdateSerial(ImeStatusInfo info, bool shutdown = false, bool forceUpdate = false)
        {
            // IMEの状態を判定
            ImeState imeState;
            if (shutdown) imeState = ImeState.Shutdown;
            else if (!info.IsValidInfo) imeState = ImeState.Error;
            else if (info.ImeIsEnabled) imeState = ImeState.ImeOn;
            else imeState = ImeState.ImeOff;

            // 状態変化を検出
            var lastImeState = _currentImeState;
            var imeStateChanged = (imeState != lastImeState);
            _currentImeState = imeState;

            // フォーカスの移動を検出
            var lastWindowHandle = _currentWindowHandle;
            var focusMoved = info.FocusedWindowHandle != lastWindowHandle;
            _currentWindowHandle = info.FocusedWindowHandle;

            // 何も変化が無い場合は何もしない
            if (!imeStateChanged && !focusMoved && !forceUpdate) {
                return;
            }

            // フォーカス移動を伴わない通常のIMEトグルか否か
            var localToggle = !focusMoved && (
                (lastImeState == ImeState.ImeOff || imeState == ImeState.ImeOn) ||
                (lastImeState == ImeState.ImeOn || imeState == ImeState.ImeOff)
                );

            // 現在の設定を取得
            var s = Settings.Instance;

            // 設定に従って点滅回数を決定
            var blinkCount = s.GetBlinkCount(imeState);
            if (s.DontBlinkOnLocalToggle && localToggle) {
                // DontBlinkOnLocalToggleが設定されている場合で、通常トグルの場合は点滅しない
                blinkCount = 0;
            }

            // シリアルポートへ反映
            var blinkTimeSpanMillis = Settings.BlinkPeriodMillis * blinkCount;
            _blinkEndTime = DateTimeOffset.Now + TimeSpan.FromMilliseconds(blinkTimeSpanMillis);
            if (blinkTimeSpanMillis > 0) {
                // 点滅を行う場合は点滅用タイマをスタート
                _blinkTimer.Start();
            }

            // シリアルポートに反映
            UpdateSerialInternal();
        }

        private void UpdateSerialInternal()
        {
            // シリアルポートの準備
            TryOpen();
            var serial = _serialPortObject;
            if (!serial.IsOpen) return;

            // 現在の設定を取得
            var s = Settings.Instance;

            // IMEの状態を取得
            var imeState = _currentImeState;

            // 残り点滅時間を計算
            var remainingBlinkTimeMillis = (int)(_blinkEndTime - DateTimeOffset.Now).TotalMilliseconds;
            if (remainingBlinkTimeMillis <= 0) {
                // 点滅時間切れなら点滅用タイマを止める
                remainingBlinkTimeMillis = 0;
                _blinkTimer.Stop();
            }

            // 0:点灯 / 1:消灯
            var blinkState = 1 & (2 * remainingBlinkTimeMillis / Settings.BlinkPeriodMillis);
            if (blinkState == 0) {
                serial.DtrEnable = !s.GetAssignment(imeState, SerialSignal.Dtr);
                serial.RtsEnable = !s.GetAssignment(imeState, SerialSignal.Rts);
            }
            else {
                serial.DtrEnable = !s.GetAssignment(ImeState.Shutdown, SerialSignal.Dtr);
                serial.RtsEnable = !s.GetAssignment(ImeState.Shutdown, SerialSignal.Rts);
            }
        }

        private void TryOpen()
        {
            var portName = _serialPortName;
            var serial = _serialPortObject;

            if (string.IsNullOrEmpty(portName)) {
                // ポート名未指定
                if (serial.IsOpen) serial.Close();
                return ;
            }

            if (serial.PortName == portName && serial.IsOpen) {
                // 既に所望のポートを開けている場合は何もしない
                return ;
            }

            try {
                if (serial.IsOpen) serial.Close();
                serial.PortName = portName;
                serial.Open();
            }
            catch (Exception ex) {
                this.Log(ex);
            }

            if (serial.IsOpen) {
                this.Log("'" + serial.PortName + "' を開くことに成功しました。");
                UpdateSerial(forceUpdate: true);
            }
            else {
                this.Log("'" + serial.PortName + "' を開けません。リトライします...", LogLevel.Warning);
            }
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            switch (e.Mode) {
                case PowerModes.Suspend:
                    UpdateSerial(shutdown: true);
                    break;
                case PowerModes.Resume:
                    UpdateSerial();
                    break;
            }
        }

        public void Dispose()
        {
            _serialOpenRetryTimer.Stop();
            _blinkTimer.Stop();

            try {
                var monitor = _imeStatusMonitor;
                monitor.Dispose();
            }
            catch (Exception ex) {
                Log(ex);
            }

            try {
                var serial = _serialPortObject;
                serial.Close();
                serial.Dispose();
            }
            catch (Exception ex) {
                Log(ex);
            }
        }

        private void Log(string message, LogLevel level = LogLevel.Information)
        {
            LogReport?.Invoke(this, new LogReportEventArgs(message, level));
        }

        private void Log(Exception ex, LogLevel level = LogLevel.Error)
        {
            LogReport?.Invoke(this, new LogReportEventArgs(ex, level));
        }
    }
}
