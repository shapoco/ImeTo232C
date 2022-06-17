using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;

using Shapoco.Common;

namespace Shapoco.Windows
{
    class ImeStatusIMonitor : IDisposable
    {
        public static event LogReportEventHandler LogReport;

        private BackgroundWorker _backgroundWorker;
        private bool _backgroundWorkerIsBusy = false;
        public System.Windows.Forms.Form SynchronizingObject { get; set; } = null;
        public event ImeStatusChangeEventHandler Change;
        public bool IsDisposed { get; private set; } = false;

        public ImeStatusIMonitor(System.Windows.Forms.Form syncObj = null)
        {
            this.SynchronizingObject = syncObj;

            var bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BackgroundWorker_DoWork;
            bgWorker.WorkerSupportsCancellation = true;
            this._backgroundWorker = bgWorker;

            this._backgroundWorkerIsBusy = true;
            bgWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var thisWorker = (BackgroundWorker)sender;
            var lastInfo = new ImeStatusInfo();
            var lastChangeTime = DateTime.MinValue;

            while (!thisWorker.CancellationPending) {
                var currInfo = GetImeStatus();
                var now = DateTime.Now;
                
                if (!currInfo.Equals(lastInfo)) {
                    Log("状態変化検出: " + 
                        (currInfo.IsValidInfo ? "取得成功, " : "取得失敗, " ) +
                        (currInfo.ImeIsEnabled ? "IME=ON" : "IME=OFF"));

                    // IMEの状態が変化したらイベントを発生させる
                    var syncObj = this.SynchronizingObject;
                    if (syncObj == null) {
                        Change?.Invoke(this, currInfo);
                    }
                    else if (!syncObj.IsDisposed) {
                        syncObj.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                            Change?.Invoke(this, currInfo);
                        }));
                    }

                    lastChangeTime = now;
                }

                if (now - lastChangeTime > new TimeSpan(0, 1, 0)) {
                    // 一定時間以上変化が無い場合は監視を怠ける
                    System.Threading.Thread.Sleep(1000);
                }
                else {
                    System.Threading.Thread.Sleep(100);
                }

                lastInfo = currInfo;
            }

            Log("モニタスレッドを終了します...");
            _backgroundWorkerIsBusy = false;
        }

        public static ImeStatusInfo GetImeStatus()
        {
            var resultInfo = new ImeStatusInfo() {
                IsValidInfo = false
            };

            try {
                var gti = new GUITHREADINFO();
                gti.cbSize = Marshal.SizeOf(gti);
                if (WinApi.GetGUIThreadInfo(0, ref gti) != 0) {
                    resultInfo.ActiveWindowHandle = gti.hwndActive;
                    resultInfo.FocusedWindowHandle = gti.hwndFocus;
                    IntPtr hWndIME = WinApi.ImmGetDefaultIMEWnd(gti.hwndFocus);
                    resultInfo.ImeIsEnabled = (WinApi.SendMessage(hWndIME, 0x283, 0x5, 0) != 0);
                    resultInfo.IsValidInfo = true;
                }
            }
            catch (Exception ex) {
                LogReport?.Invoke(null, new LogReportEventArgs(ex));
            }

            return resultInfo;
        }

        public void Dispose()
        {
            var bgWorker = _backgroundWorker;
            if (bgWorker != null) {
                try {
                    bgWorker.CancelAsync();
                    //while (bgWorker.IsBusy) {
                    for (int i = 0; i < 1000; ++i) {
                        // SynchronizingObjectが設定された状態で
                        // BackgroundWorkerがループを抜けるにはDoEventが必要
                        System.Windows.Forms.Application.DoEvents();
                        System.Threading.Thread.Sleep(1);
                        if (!_backgroundWorkerIsBusy) break;
                    }
                    _backgroundWorker.Dispose();
                    Log("モニタスレッドは正常に終了しました。");
                }
                catch (Exception ex) {
                    Log(ex);
                }
                finally {
                    _backgroundWorker = null;
                    IsDisposed = true;
                }
            }
        }

        private void Log(string message, LogLevel level = LogLevel.Information)
        {
            if (IsDisposed) return;

            var syncObj = SynchronizingObject;
            if (syncObj == null) {
                LogReport?.Invoke(this, new LogReportEventArgs(message, level));
            }
            else if (!syncObj.IsDisposed) {
                syncObj.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                    LogReport?.Invoke(this, new LogReportEventArgs(message, level));
                }));
            }
        }

        private void Log(Exception ex, LogLevel level = LogLevel.Error)
        {
            if (IsDisposed) return;

            var syncObj = SynchronizingObject;
            if (syncObj == null) {
                LogReport?.Invoke(this, new LogReportEventArgs(ex, level));
            }
            else if (!syncObj.IsDisposed) {
                syncObj.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                    LogReport?.Invoke(this, new LogReportEventArgs(ex, level));
                }));
            }
        }

        #region "WinAPIs"

        //GuiThredInfoの変数の型を定義
        struct GUITHREADINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hwndActive;
            public IntPtr hwndFocus;
            public IntPtr hwndCapture;
            public IntPtr hwndMenuOwner;
            public IntPtr hwndMoveSize;
            public IntPtr hwndCaret;
            public System.Drawing.Rectangle rcCaret;
        }
        //*GuiThredInfoの変数の型を定義

        // Win32API declarations for the window location calculation.
        struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        static class WinApi
        {
            public const int HWND_TOPMOST = -1;
            public const int SWP_NOSIZE = 0x0001;
            public const int SWP_NOMOVE = 0x0002;
            public const int SWP_NOACTIVATE = 0x0010;
            public const int SWP_SHOWWINDOW = 0x0040;
            public const int SWP_NOSENDCHANGING = 0x0400;

            public const int PROCESS_QUERY_INFORMATION = 0x400;
            public const int PROCESS_VM_READ = 0x10;

            public const int STRING_BUFFER_LENGTH = 1024;

            [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
            public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();

            [DllImport("user32")]
            public static extern int GetWindowRect(IntPtr hWnd, out RECT lpRect);

            [DllImport("User32.dll")]
            public static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, int lParam);

            [DllImport("imm32.dll")]
            public static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);

            [DllImport("user32.dll")]
            public static extern uint GetGUIThreadInfo(uint dwthreadid, ref GUITHREADINFO lpguithreadinfo);

            [DllImport("user32.dll")]
            public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
            [DllImport("user32.dll")]
            public static extern IntPtr GetFocus();
            [DllImport("user32.dll")]
            public extern static bool AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsWindowVisible(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern int GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

            [DllImport("kernel32.dll")]
            public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

            [DllImport("kernel32", SetLastError = true)]
            public static extern bool CloseHandle(IntPtr hObject);

            [DllImport("psapi.dll")]
            public static extern bool EnumProcessModules(IntPtr hProcess, out IntPtr lphModule, int cb, out int lpcbNeeded);

            [DllImport("psapi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, string lpBaseName, int nSize);

            public static System.Drawing.Rectangle GetWindowRect(IntPtr hWnd)
            {
                RECT rect;
                GetWindowRect(hWnd, out rect);
                return System.Drawing.Rectangle.FromLTRB(rect.left, rect.top, rect.right, rect.bottom);
            }

            public static string GetWindowText(IntPtr hWnd)
            {
                StringBuilder sb = new StringBuilder(256);
                GetWindowText(hWnd, sb, sb.Capacity);
                return sb.ToString();
            }

            public static string GetClassName(IntPtr hWnd)
            {
                StringBuilder sb = new StringBuilder(256);
                GetClassName(hWnd, sb, sb.Capacity);
                return sb.ToString();
            }

            // "ウィンドウハンドルから実行ファイル名を取得する"
            // http://d.hatena.ne.jp/yu-hr/20100323/1269356160
            public static string GetExecutableFileNameFromWindowHandle(IntPtr hWnd)
            {
                // プロセスID
                int processID = 0;
                GetWindowThreadProcessId(hWnd, out processID);

                // プロセスハンドル
                IntPtr hProcess = OpenProcess(
                    PROCESS_QUERY_INFORMATION | PROCESS_VM_READ, false, processID);
                if (hProcess == IntPtr.Zero)
                    throw new InvalidOperationException();

                try {
                    // モジュールハンドル
                    IntPtr hModule = IntPtr.Zero;
                    int dummy = 0;
                    if (!EnumProcessModules(hProcess, out hModule, Marshal.SizeOf(hModule), out dummy))
                        throw new InvalidOperationException();

                    // ファイル名(フルパス)
                    string dest = new string((char)0, STRING_BUFFER_LENGTH);
                    int len = GetModuleFileNameEx(hProcess, hModule, dest, STRING_BUFFER_LENGTH);
                    dest = (len > 0) ? (dest.Substring(0, len)) : (string.Empty);

                    return dest;
                }
                catch (Exception ex) {
                    throw ex;
                }
                finally {
                    CloseHandle(hProcess);
                    // hModuleは自分で閉じちゃいけない
                }
            }
        }
        #endregion
    }
}
