using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Text.RegularExpressions;

namespace Shapoco.ImeStatusToComPort
{
    static class SerialPortEnumerator
    {
        public static IEnumerable<SerialPortInfo> EnumSerialPortInfo()
        {
            return EnumSerialPortInfoInternal().OrderBy(p => p.PortName);
        }

        // 参考: C#でCOMポート番号とシリアル接続機器名を同時に取得する方法
        // http://truthfullscore.hatenablog.com/entry/2014/01/10/180608
        private static IEnumerable<SerialPortInfo> EnumSerialPortInfoInternal()
        {
            var existingPortNames = System.IO.Ports.SerialPort.GetPortNames();

            var comPortRegex = new Regex(@"^(.+) \((COM[1-9][0-9]{0,2})\)$");

            ManagementClass mcPnpEntity = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection mgmtObjCol = mcPnpEntity.GetInstances();

            var portDictionary = new Dictionary<string, string>();
            foreach (ManagementObject manageObj in mgmtObjCol) {
                var namePropertyValue = manageObj.GetPropertyValue("Name");
                if (namePropertyValue == null) continue;

                var match = comPortRegex.Match(namePropertyValue.ToString());
                if (!match.Success) continue;

                var info = new SerialPortInfo {
                    DeviceName = match.Groups[1].Value,
                    PortName = match.Groups[2].Value
                };
                if (!existingPortNames.Contains(info.PortName)) continue;

                yield return info;
            }
        }

        public static bool FindPort(string name, SerialPortFindMethod findMethod, out SerialPortInfo findResult)
        {
            foreach(var info in EnumSerialPortInfo()) {
                if (info.GetBy(findMethod) == name) {
                    findResult= info;
                    return true;
                }
            }
            findResult = new SerialPortInfo();
            return false;
        }
        
    }
}
