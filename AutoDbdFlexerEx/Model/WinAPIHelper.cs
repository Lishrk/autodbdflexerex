using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.Model
{
    public static class WinAPIHelper
    {
        private const int KEYEVENTF_KEYDOWN = 0x0000;
        private const int KEYEVENTF_KEYUP = 0x0002;

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
#if DEBUG
#warning WinAPIHelper.PressKey is disabled in Debug mode
        public static async Task PressKey(Keys key, int time)
        {
            await Task.Delay(time);
        }
#else
        public static async Task PressKey(Keys key, int time)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, 0);
            await Task.Delay(time);
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, 0);
        }
#endif
    }
}
