using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

using Shapoco.Common;
using Shapoco.Windows;

namespace Shapoco.ImeStatusToComPort
{
    public partial class MainForm : Form
    {
        private NotifyIcon _notifyIcon;
        private ImeStatusToComCore _core;
        private SerialPortFindMethod _lastPortFindMethod = SerialPortFindMethod.FullName;

        public MainForm()
        {
            InitializeComponent();

            var s = Settings.Instance;

            this.Text = Application.ProductName + " (" + Application.ProductVersion + ")";
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;
            this.FormClosed += MainForm_FormClosed;
            this.Resize += MainForm_Resize;

            chkRegisterToStartup.CheckedChanged += ChkRegisterToStartup_CheckedChanged;
            lnkStartupFolder.Click += LnkStartupFolder_Click;

            optPortFindMethod_PortName.CheckedChanged += OptPortFindMethod_CheckedChanged;
            optPortFindMethod_DeviceName.CheckedChanged += OptPortFindMethod_CheckedChanged;
            optPortFindMethod_FullName.CheckedChanged += OptPortFindMethod_CheckedChanged;
            cmbPortList.TextChanged += CmbPortList_TextChanged;
            lnkReloadPortList.Click += delegate { ReloadSerialPortList(); };
            chkAssignment_ImeOff_Dtr.CheckedChanged += ChkAssignment_CheckedChanged;
            chkAssignment_ImeOff_Rts.CheckedChanged += ChkAssignment_CheckedChanged;
            chkAssignment_ImeOn_Dtr.CheckedChanged += ChkAssignment_CheckedChanged;
            chkAssignment_ImeOn_Rts.CheckedChanged += ChkAssignment_CheckedChanged;
            chkAssignment_Error_Dtr.CheckedChanged += ChkAssignment_CheckedChanged;
            chkAssignment_Error_Rts.CheckedChanged += ChkAssignment_CheckedChanged;
            chkAssignment_Shutdown_Dtr.CheckedChanged += ChkAssignment_CheckedChanged;
            chkAssignment_Shutdown_Rts.CheckedChanged += ChkAssignment_CheckedChanged;
            lnkOpenAppDataFolder.Click += LnkOpenAppDataFolder_Click;

            for(int i = 0; i <= Settings.MaxBlinkCount; ++i) {
                var str = i == 0 ? "なし" : i + "回";
                cmbBlinkCount_ImeOn.Items.Add(str);
                cmbBlinkCount_ImeOff.Items.Add(str);
                cmbBlinkCount_Error.Items.Add(str);
            }
            cmbBlinkCount_ImeOff.SelectedIndexChanged += CmbBlinkCount_SelectedIndexChanged;
            cmbBlinkCount_ImeOn.SelectedIndexChanged += CmbBlinkCount_SelectedIndexChanged;
            cmbBlinkCount_Error.SelectedIndexChanged += CmbBlinkCount_SelectedIndexChanged;
            chkDontBlinkOnNormalToggle.CheckedChanged += ChkDontBlinkOnNormalToggle_CheckedChanged;

            cmnTrayMenu_Exit.Click += delegate { this.Close(); };
            cmnTrayMenu_Settings.Click += NotifyIcon_DoubleClick;

            _notifyIcon = new NotifyIcon {
                Icon = this.Icon,
                ContextMenuStrip = cmnTrayMenu,
                Text = this.Text
            };
            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // シリアルポートリストの読み込み
            ReloadSerialPortList();

            // 監視の開始
            ImeStatusIMonitor.LogReport += ImeStatusIMonitor_LogReport;
            _core = new ImeStatusToComCore(this);
            _core.LogReport += ImeStatusIMonitor_LogReport;

            // タスクトレイへ格納
            this.WindowState = FormWindowState.Minimized;

            // スタートアップへの登録状況を確認
            chkRegisterToStartup.Checked = ShortcutManager.CheckStartupRegistration();

            // 設定をウィンドウにロード
            ReloadSettings();
            Settings.Instance.Changed += delegate { ReloadSettings(); };
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this.WindowState != FormWindowState.Minimized) {
                var result = UniversalDialog<DialogResult>.ShowDialog(
                    "アプリケーションを終了しますか？", 
                    Application.ProductName, MessageBoxIcon.Exclamation,
                    new string[] { "終了する", "タスクトレイに格納する", "キャンセル" },
                    new DialogResult[] { DialogResult.Yes, DialogResult.No, DialogResult.Cancel });

                switch(result) {
                    case DialogResult.Yes:
                        // no action
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                        throw new NotImplementedException();

                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 通知アイコンの消去
            _notifyIcon.Visible = false;

            // 監視の終了
            _core.Dispose();
        }

        private void ReloadSettings()
        {
            var s = Settings.Instance;
            var core = _core;

            // シリアルポートの検索方法
            var portFindMethod = s.SerialPortFindingMethod;
            switch (portFindMethod) {
                case SerialPortFindMethod.PortName: optPortFindMethod_PortName.Checked = true; break;
                case SerialPortFindMethod.DeviceName: optPortFindMethod_DeviceName.Checked = true; break;
                case SerialPortFindMethod.FullName: optPortFindMethod_FullName.Checked = true; break;
                default: throw new NotImplementedException();
            }
            if (portFindMethod != _lastPortFindMethod) {
                ReloadSerialPortList();
                _lastPortFindMethod = portFindMethod;
            }

            // シリアルポートの検索名
            cmbPortList.Text = s.SerialPortFindingKeyword;

            // DTR/RTSの割り当て
            chkAssignment_ImeOff_Dtr.Checked = (s.Assignment_ImeOff & 0x1) != 0;
            chkAssignment_ImeOff_Rts.Checked = (s.Assignment_ImeOff & 0x2) != 0;
            chkAssignment_ImeOn_Dtr.Checked = (s.Assignment_ImeOn & 0x1) != 0;
            chkAssignment_ImeOn_Rts.Checked = (s.Assignment_ImeOn & 0x2) != 0;
            chkAssignment_Error_Dtr.Checked = (s.Assignment_Error & 0x1) != 0;
            chkAssignment_Error_Rts.Checked = (s.Assignment_Error & 0x2) != 0;
            chkAssignment_Shutdown_Dtr.Checked = (s.Assignment_Shutdown & 0x1) != 0;
            chkAssignment_Shutdown_Rts.Checked = (s.Assignment_Shutdown & 0x2) != 0;

            // 点滅回数
            cmbBlinkCount_ImeOff.SelectedIndex = s.BlinkCount_ImeOff;
            cmbBlinkCount_ImeOn.SelectedIndex = s.BlinkCount_ImeOn;
            cmbBlinkCount_Error.SelectedIndex = s.BlinkCount_Error;

            // 点滅するのはフォーカス移動時とエラーのときだけ
            chkDontBlinkOnNormalToggle.Checked = s.DontBlinkOnLocalToggle;

            // シリアル接続実施
            if (SerialPortEnumerator.FindPort(
                s.SerialPortFindingKeyword, s.SerialPortFindingMethod, out SerialPortInfo portInfo)) {
                core.SerialPortName = portInfo.PortName;
                core.UpdateSerial();
            }
            else {
                core.SerialPortName = null;
            }
        }

        private void ChkRegisterToStartup_CheckedChanged(object sender, EventArgs e)
        {
            // スタートアップへの登録状態を設定
            ShortcutManager.SetStartupRegistration(chkRegisterToStartup.Checked);
        }

        private void LnkStartupFolder_Click(object sender, EventArgs e)
        {
            // スタートアップフォルダを開く
            try { System.Diagnostics.Process.Start(ShortcutManager.StartupPath); }
            catch (Exception) { }
        }

        private void OptPortFindMethod_CheckedChanged(object sender, EventArgs e)
        {
            var optSender = ((RadioButton)sender);
            if (!optSender.Checked) return;

            var oldFindMethod = Settings.Instance.SerialPortFindingMethod;
            var newFindMethod = oldFindMethod;

            if (optSender == optPortFindMethod_PortName) {
                newFindMethod = SerialPortFindMethod.PortName;
            }
            else if (optSender == optPortFindMethod_DeviceName) {
                newFindMethod = SerialPortFindMethod.DeviceName;
            }
            else if (optSender == optPortFindMethod_FullName) {
                newFindMethod = SerialPortFindMethod.FullName;
            }
            else {
                throw new NotImplementedException();
            }

            // 新しい検索方法を適用
            Settings.Instance.SerialPortFindingMethod = newFindMethod;

            // 新しい検索方法に従ったポート名に更新する
            if (SerialPortEnumerator.FindPort(
                Settings.Instance.SerialPortFindingKeyword, oldFindMethod, out SerialPortInfo info)) {
                Settings.Instance.SerialPortFindingKeyword = info.GetBy(newFindMethod);
            }

        }

        private void CmbPortList_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.SerialPortFindingKeyword = cmbPortList.Text;
        }

        private void ChkAssignment_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSender = (CheckBox)sender;
            var args = chkSender.Name.Split('_');
            var state = (ImeState)Enum.Parse(typeof(ImeState), args[1]);
            var signal = (SerialSignal)Enum.Parse(typeof(SerialSignal), args[2]);
            Settings.Instance.SetAssignment(state, signal, chkSender.Checked);
        }

        private void CmbBlinkCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbSender = (ComboBox)sender;
            if (cmbSender.SelectedIndex < 0) return;
            var args = cmbSender.Name.Split('_');
            var state = (ImeState)Enum.Parse(typeof(ImeState), args[1]);
            Settings.Instance.SetBlinkCount(state, cmbSender.SelectedIndex);
        }

        private void ChkDontBlinkOnNormalToggle_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSender = (CheckBox)sender;
            Settings.Instance.DontBlinkOnLocalToggle = chkSender.Checked;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // ウィンドウの状態に応じてタスクバー/タスクトレイのアイコン表示状態を設定
            bool isMinimized = (this.WindowState == FormWindowState.Minimized);
            this.ShowInTaskbar = !isMinimized;
            _notifyIcon.Visible = isMinimized;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            // 通知アイコンをダブルクリックしたらウィンドウを再表示する
            if (this.WindowState == FormWindowState.Minimized) {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void LnkOpenAppDataFolder_Click(object sender, EventArgs e)
        {
            // 設定ファイルの場所を開く
            try { System.Diagnostics.Process.Start(AppDataManager.RoamingUserDataPath); }
            catch (Exception) { }
        }

        private void ReloadSerialPortList()
        {
            var findMethod = Settings.Instance.SerialPortFindingMethod;
            cmbPortList.Items.Clear();
            foreach (var info in SerialPortEnumerator.EnumSerialPortInfo()) {
                cmbPortList.Items.Add(info.GetBy(findMethod));
            }
        }

        // ログ表示
        private Queue<string> _logBuff = new Queue<string>();
        private void ImeStatusIMonitor_LogReport(object sender, LogReportEventArgs e)
        {
            var core = _core;
            var buff = _logBuff;
            var logMessage = e.ToString();
            Console.WriteLine(logMessage);
            buff.Enqueue(logMessage);
            while (buff.Count > 30) buff.Dequeue();
            var logText = string.Join("\r\n", buff);
            txtLog.Text = logText;
            txtLog.SelectionStart = logText.Length;
            txtLog.ScrollToCaret();

            var isOnline = core.IsOnline;
            lblStatus.Text = isOnline ? "接続済み" : "未接続";
            lblStatus.ForeColor = isOnline ? Color.Blue : Color.Red;
        }

    }
}
