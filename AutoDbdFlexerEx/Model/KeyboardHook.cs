using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.Model
{
    public class KeyboardHook
    {
        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr hhk, int code, int wParam, ref keyBoardHookStruct lParam);
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LLKeyboardHook callback, IntPtr hInstance, uint theardID);
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        private delegate int LLKeyboardHook(int Code, int wParam, ref keyBoardHookStruct lParam);

        private struct keyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        private LLKeyboardHook llkh;

        private IntPtr hook = IntPtr.Zero;

        public event KeyEventHandler OnKeyDown;
        public event KeyEventHandler OnKeyUp;

        public KeyboardHook()
        {
            llkh = new LLKeyboardHook(HookProc);
        }
        ~KeyboardHook()
        { Unhook(); }

        public void Hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hook = SetWindowsHookEx(WH_KEYBOARD_LL, llkh, hInstance, 0);
        }

        public void Unhook()
        {
            UnhookWindowsHookEx(hook);
        }

        private int HookProc(int Code, int wParam, ref keyBoardHookStruct lParam)
        {
            if (Code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                KeyEventArgs kArg = new KeyEventArgs(key);
                if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (OnKeyDown != null))
                    OnKeyDown(this, kArg);
                else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (OnKeyUp != null))
                    OnKeyUp(this, kArg);
                if (kArg.Handled)
                    return 1;
            }
            return CallNextHookEx(hook, Code, wParam, ref lParam);
        }
    }
}