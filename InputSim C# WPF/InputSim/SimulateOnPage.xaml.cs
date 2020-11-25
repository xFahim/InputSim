using InputSim.Hooks;
using InputSim.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InputSim
{
    /// <summary>
    /// Interaction logic for SimulateOnPage.xaml
    /// </summary>
    public partial class SimulateOnPage : Page
    {
        List<InputSetData> _INPSETLIST;
        Hook h;
        IntPtr _hookID = IntPtr.Zero;
        bool IsSimulationOnProcess = false;


        public SimulateOnPage()
        {
            InitializeComponent();

            _INPSETLIST = BinaryserializerHelper.GetAllSerializedData();

            h = new Hook(HookType.WH_KEYBOARD_LL, KeyBoardCallBack);
            _hookID = h.SetHook();
        }

        private IntPtr KeyBoardCallBack(int code, IntPtr wParam, IntPtr lParam)
        {
            KBDLLHOOKSTRUCT k = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

            if (wParam == (IntPtr)KeyBoardResponse.WM_KEYDOWN || wParam == (IntPtr)KeyBoardResponse.WM_SYSKEYDOWN)
            {
                CallBackHelper(k);
            }

            CallNextHookEx(_hookID, code, wParam, lParam);
            return IntPtr.Zero;
        }

        // Helper Method 
        private async void CallBackHelper(KBDLLHOOKSTRUCT k)
        {
            foreach (InputSetData d in _INPSETLIST)
            {
                if ((uint)d.AsignedKeySC == k.scanCode && IsSimulationOnProcess == false)
                {
                    // set to true to encounter Overlap of input simulation
                    IsSimulationOnProcess = true;

                    // perform the inputset
                    InputClass ic = new InputClass();
                    await ic.SendInputSet(d.HookedDataList, d.Repeat);

                    IsSimulationOnProcess = false;

                }
                else if (IsSimulationOnProcess == true && k.scanCode == (uint)ScanCodeKey.sc_escape)
                {
                    // work on it/ break simulation on Esc press
                }
            }
        }


        // dlls
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        private void StopSimBtn_Click(object sender, RoutedEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);

            this.NavigationService.Navigate(new Home());
        }
    }
}
