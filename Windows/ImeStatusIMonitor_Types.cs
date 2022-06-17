using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapoco.Windows
{
    struct ImeStatusInfo
    {
        public bool IsValidInfo;
        public bool ImeIsEnabled;
        public IntPtr ActiveWindowHandle;
        public IntPtr FocusedWindowHandle;

        public override string ToString()
        {
            return
                (IsValidInfo ? "[valid] \t" : "[INVALID]\t") +
                (ImeIsEnabled ? "ime=ON\t, " : "ime=OFF\t, ") +
                ("activeHWnd=0x" + ActiveWindowHandle.ToInt32().ToString("X") + "\t, ") +
                ("focusedHWnd=0x" + FocusedWindowHandle.ToInt32().ToString("X"));
        }
    }

    delegate void ImeStatusChangeEventHandler(object sender, ImeStatusInfo e);
}
