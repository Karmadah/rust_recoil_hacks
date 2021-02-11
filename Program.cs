using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

//my files
using recoil_helper;

namespace rust_recoil_script
{
    class Program
    {
        private const int KEY_PRESSED = 0x8000;

       

        #region dflags
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;
        #endregion dflags

        static void Main(string[] args)
        {
            if (is_key_pressed(vkeys_helper.vkeys.VK_LBUTTON))
            {
                // now start mouse_event bs
            }



        }

        public static bool is_key_pressed(vkeys_helper.vkeys key)
        {
            return Convert.ToBoolean(GetKeyState(key) & KEY_PRESSED);
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
        [DllImport("USER32.dll")]
        static extern short GetKeyState(recoil_helper.vkeys_helper.vkeys nVirtKey);
    }
}
