using InputSim.Hooks;
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
    /// Interaction logic for HookSavePage.xaml
    /// </summary>
    public partial class HookSavePage : Page
    {
        List<InputData> _inpSet = new List<InputData>();
        Hook h;
        IntPtr _hookID = IntPtr.Zero;
        uint scancodekey;
        public HookSavePage(List<InputData> hdl)
        {
            InitializeComponent();
            _inpSet = hdl;
            HdataListView.ItemsSource = _inpSet;

        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HdataListView.SelectedIndex < 0)
            {
                MessageBox.Show("Select a record from the list first and try again.");
                return;
            }
            else
            {
                _inpSet.RemoveAt(HdataListView.SelectedIndex);
                HdataListView.ItemsSource = null;
                HdataListView.ItemsSource = _inpSet;
                MessageBox.Show("Record Deleted Successfully");
            }
        }

        private void AssignKeyBtn_Click(object sender, RoutedEventArgs e)
        {
            AssignKeyIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CubeScan;
            AssignKeyText.Text = "Press a key to assign";

            h = new Hook(HookType.WH_KEYBOARD_LL, KeyBoardCallBack);
            _hookID = h.SetHook();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TagBox.Text))
            {
                MessageBox.Show("Enter a valid tag for the inputset","Tag missing");
            }
            else
            {
                InputSetData data = new InputSetData();
                data.HookedDataList = _inpSet;
                data.Tag = TagBox.Text;
                data.Desdescription = DescriptionBox.Text;
                data.AsignedKeySC = (ScanCodeKey)scancodekey;
                data.AsignedKeyName = AsignKeyStatusTxt.Text;
                data.DateText = DateTime.Now.Date.ToString();

                if (Int32.TryParse(LoopBox.Text, out int temp))
                {
                    data.Repeat = temp;
                }
                else
                {
                    data.Repeat = 0;
                }

                int i = BinaryserializerHelper.SerializeObj(data, "Records//" + data.Tag + ".dat");

                switch (i)
                {
                    case 1:
                        MessageBox.Show("InputSet successfully saved","Done");
                        this.NavigationService.Navigate(new Home());
                        break;
                    case 0:
                        MessageBox.Show("Something went wrong. failed to save the inputset.\n\ncheck all the data and the tag", "Failed");
                        break;
                    case -1:
                        MessageBox.Show("An inputset with the same tag already exists.\nplease use a unique tag for your inputset and try again.", "Failed");
                        break;
                }
                    
            }


        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("You will lose all the previously recorded inputset and changes.\nAre you sure want to go back home without saving the inputset?", "Confirm", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.NavigationService.Navigate(new Home());
                    break;
                case MessageBoxResult.No:
                    break;
            }

            
        }


        private IntPtr KeyBoardCallBack(int code, IntPtr wParam, IntPtr lParam)
        {
            KBDLLHOOKSTRUCT k = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

            if (wParam == (IntPtr)KeyBoardResponse.WM_KEYDOWN || wParam == (IntPtr)KeyBoardResponse.WM_SYSKEYDOWN)
            {
                scancodekey = k.scanCode;
                AsignKeyStatusTxt.Text = ((ScanCodeKey)scancodekey).ToString();
            }

            CallNextHookEx(_hookID, code, wParam, lParam);

            UnhookWindowsHookEx(_hookID);

            AssignKeyIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.GestureTapButton;
            AssignKeyText.Text = "Assign a new key";
            return IntPtr.Zero;
        }


        // dlls
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    }
}
