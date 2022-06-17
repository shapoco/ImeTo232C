using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapoco.ImeStatusToComPort
{
    struct SerialPortInfo
    {
        public string PortName;
        public string DeviceName;

        public string FullName {
            get {
                return DeviceName + " (" + PortName + ")";
            }
        }

        public string GetBy(SerialPortFindMethod mode)
        {
            switch (mode) {
                case SerialPortFindMethod.PortName: return PortName;
                case SerialPortFindMethod.DeviceName: return DeviceName;
                case SerialPortFindMethod.FullName: return FullName;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    enum SerialPortFindMethod
    {
        PortName,
        DeviceName,
        FullName
    }

    enum ImeState
    {
        ImeOff = 0,
        ImeOn = 1,
        Error = 2,
        Shutdown = 3
    }

    enum SerialSignal
    {
        Dtr = 0,
        Rts = 1
    }

}
