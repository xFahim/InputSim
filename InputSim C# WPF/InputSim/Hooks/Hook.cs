using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InputSim.Hooks
{
    public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
    public class Hook
    {
        HookType _hooktype;
        HookProc _hookProc;
        private IntPtr _hookID = IntPtr.Zero;
        public Hook(HookType htype, HookProc hproc)
        {
            _hooktype = htype;
            _hookProc = hproc;
        }

        public IntPtr SetHook()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return _hookID = SetWindowsHookEx((int)_hooktype, _hookProc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        

        // DLL IMPORT 
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

    }
}
