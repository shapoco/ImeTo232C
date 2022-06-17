using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shapoco.Windows;

namespace Shapoco.ImeStatusToComPort
{
    class Settings
    {
        private const string Filename = "Settings.cfg";
        public static readonly Settings Instance = new Settings();

        public const int MaxBlinkCount = 5;
        public const int BlinkPeriodMillis = 200;

        private System.Windows.Forms.Timer _saveDelayTimer = new System.Windows.Forms.Timer();
        private Settings()
        {
            AppDataManager.LoadPropertiesFromRoamingAppData(this, Filename);

            // ロードが終わってからイベントを登録すること。
            this.Changed += delegate { _saveDelayTimer.Start(); };
            _saveDelayTimer.Interval = 100;
            _saveDelayTimer.Tick += delegate {
                _saveDelayTimer.Stop();
                this.Save();
            };
        }
        
        public void Save()
        {
            AppDataManager.SavePropertiesToRoamingAppData(this, Filename);
        }

        public event EventHandler Changed;

        private string _serialPortFindingKeyword;
        public string SerialPortFindingKeyword {
            get { return _serialPortFindingKeyword; }
            set {
                if (value == _serialPortFindingKeyword) return;
                _serialPortFindingKeyword = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        private SerialPortFindMethod _serialPortFindingMethod = SerialPortFindMethod.FullName;
        public SerialPortFindMethod SerialPortFindingMethod {
            get { return _serialPortFindingMethod; }
            set {
                if (value == _serialPortFindingMethod) return;
                _serialPortFindingMethod = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        private int _assignment_ImeOff = 1;
        public int Assignment_ImeOff {
            get { return _assignment_ImeOff; }
            set {
                if (value == _assignment_ImeOff) return;
                _assignment_ImeOff = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        private int _assignment_ImeOn = 2;
        public int Assignment_ImeOn {
            get { return _assignment_ImeOn; }
            set {
                if (value == _assignment_ImeOn) return;
                _assignment_ImeOn = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        private int _assignment_Error = 3;
        public int Assignment_Error {
            get { return _assignment_Error; }
            set {
                if (value == _assignment_Error) return;
                _assignment_Error = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        private int _assignment_Shutdown = 3;
        public int Assignment_Shutdown {
            get { return _assignment_Shutdown; }
            set {
                if (value == _assignment_Shutdown) return;
                _assignment_Shutdown = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool GetAssignment(ImeState state, SerialSignal signal)
        {
            switch (state) {
                case ImeState.ImeOff: return 0 != (Assignment_ImeOff & (1 << (int)signal));
                case ImeState.ImeOn: return 0 != (Assignment_ImeOn & (1 << (int)signal));
                case ImeState.Error: return 0 != (Assignment_Error & (1 << (int)signal));
                case ImeState.Shutdown: return 0 != (Assignment_Shutdown & (1 << (int)signal));
                default: return false;
            }
        }

        public void SetAssignment(ImeState state, SerialSignal signal, bool value)
        {
            switch (state) {
                case ImeState.ImeOff: Assignment_ImeOff = ModifyFlagField(Assignment_ImeOff, (int)signal, value); break;
                case ImeState.ImeOn: Assignment_ImeOn = ModifyFlagField(Assignment_ImeOn, (int)signal, value); break;
                case ImeState.Error: Assignment_Error = ModifyFlagField(Assignment_Error, (int)signal, value); break;
                case ImeState.Shutdown: Assignment_Shutdown = ModifyFlagField(Assignment_Shutdown, (int)signal, value); break;
            }
        }

        private int _blinkCount_ImeOff = 0;
        public int BlinkCount_ImeOff {
            get { return _blinkCount_ImeOff; }
            set {
                if (value < 0) value = 0;
                else if (value > MaxBlinkCount) value = MaxBlinkCount;
                if (value == _blinkCount_ImeOff) return;
                _blinkCount_ImeOff = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        private int _blinkCount_ImeOn = 2;
        public int BlinkCount_ImeOn {
            get { return _blinkCount_ImeOn; }
            set {
                if (value < 0) value = 0;
                else if (value > MaxBlinkCount) value = MaxBlinkCount;
                if (value == _blinkCount_ImeOn) return;
                _blinkCount_ImeOn = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        private int _blinkCount_Error = 0;
        public int BlinkCount_Error {
            get { return _blinkCount_Error; }
            set {
                if (value < 0) value = 0;
                else if (value > MaxBlinkCount) value = MaxBlinkCount;
                if (value == _blinkCount_Error) return;
                _blinkCount_Error = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        public int GetBlinkCount(ImeState state)
        {
            switch (state) {
                case ImeState.ImeOff: return BlinkCount_ImeOff;
                case ImeState.ImeOn: return BlinkCount_ImeOn;
                case ImeState.Error: return BlinkCount_Error;
                default: return 0;
            }
        }

        public void SetBlinkCount(ImeState state, int value)
        {
            switch (state) {
                case ImeState.ImeOff: BlinkCount_ImeOff = value; break;
                case ImeState.ImeOn: BlinkCount_ImeOn = value; break;
                case ImeState.Error: BlinkCount_Error = value; break;
            }
        }

        private bool _dontBlinkOnLocalToggle = false;
        public bool DontBlinkOnLocalToggle {
            get { return _dontBlinkOnLocalToggle; }
            set {
                if (value == _dontBlinkOnLocalToggle) return;
                _dontBlinkOnLocalToggle = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        private int ModifyFlagField(int orig, int bit, bool value)
        {
            if (value) {
                return orig | (1 << bit);
            }
            else {
                return orig & ~(1 << bit);
            }
        }

    }
}
