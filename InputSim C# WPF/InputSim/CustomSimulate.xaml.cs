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
    /// Interaction logic for CustomSimulate.xaml
    /// </summary>
    public partial class CustomSimulate : Page
    {

        List<InputData> AllInputs = new List<InputData>();
        InputData TempCustomData = new InputData();

        bool IsAssigned = false;

        Hook h;
        IntPtr _hookID = IntPtr.Zero;


        public CustomSimulate()
        {
            InitializeComponent();

            LoadCombo();
            HdataListView.ItemsSource = AllInputs;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Home());
        }

        private void KeyboardBtn_Click(object sender, RoutedEventArgs e)
        {
            AssignKeyIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CubeScan;
            AssignKeyText.Text = "Press a key to assign";

            h = new Hook(HookType.WH_KEYBOARD_LL, KeyBoardCallBack);
            _hookID = h.SetHook();
        }

        private void AddManualBtn_Click(object sender, RoutedEventArgs e)
        {

            // preset
            if (MI_CheckBox.IsChecked == true)
            {
                TempCustomData.HookTypeIndex = 0;
                TempCustomData.HookTypeName = "Mouse Input";
            }
            else
            {
                TempCustomData.HookTypeIndex = 1;
                TempCustomData.HookTypeName = "Keyboard Input";
            }


            if (TempCustomData.HookTypeIndex == 0) // load mouse data from boxes
            {
                try
                {
                    uint t = (uint)MouseEventComboBox.SelectedIndex;
                    TempCustomData.MouseEventIndex = (int)t;

                    if (string.IsNullOrEmpty((string)MouseEventComboBox.SelectedItem) || t < 0)
                    {
                        MessageBox.Show("Select a Mouse-Event first. And try again");
                        return;
                    }
                    TempCustomData.MouseEventName = (string)MouseEventComboBox.SelectedItem;
                    TempCustomData.MousePointX = Int32.Parse(XBox.Text);
                    TempCustomData.MousePointY = Int32.Parse(YBox.Text);
                    TempCustomData.MousePointX = Int32.Parse(XBox.Text);
                    TempCustomData.Timespan = Int32.Parse(TspanBox.Text);
                    
                    if (t == 9)
                    {
                        TempCustomData.WheelDelta = short.Parse(ExtraDataBox.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid InputSet.\n\nPlease Enter all the valid info for the input and try agian");
                    return;
                }
            }
            else if (TempCustomData.HookTypeIndex == 1) // for keyboard
            {
                try
                {
                    
                    uint t = (uint)KeyboardEventComboBox.SelectedIndex;
                    TempCustomData.KeyBoardEventIndex = (int)t;
                    TempCustomData.KeyboardEventName = KeyboardEventComboBox.SelectedItem.ToString();
                    TempCustomData.KeyName = ((ScanCodeKey)TempCustomData.ScanCode).ToString();
                    TempCustomData.Timespan = Int32.Parse(TspanBox.Text);

                    if (!IsAssigned)
                    {
                        MessageBox.Show("Assign a key first");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid InputSet.\n\nPlease Enter all the valid info for the input and try agian");
                    return;
                }
            }

            TempCustomData.InputIndex = (uint)AllInputs.Count()+1;

            AllInputs.Add(TempCustomData);
            TempCustomData = new InputData();

            KeyStatusTxt.Text = "Assigned Key: N/A";
            AssignKeyText.Text = "Select Key";

            HdataListView.ItemsSource = null;
            HdataListView.ItemsSource = AllInputs;

            MessageBox.Show("Successfully Added To The List");
        }

        private void AddFromTagBtn_Click(object sender, RoutedEventArgs e)
        {
            List<InputSetData> a = BinaryserializerHelper.GetAllSerializedData();

            if (a != null && !string.IsNullOrEmpty(TagBox.Text))
            {
                foreach(InputSetData i in a)
                {
                    if (i.Tag == TagBox.Text)
                    {
                        foreach (InputData id in i.HookedDataList)
                        {
                            AllInputs.Add(id);
                        }

                        HdataListView.ItemsSource = null;
                        HdataListView.ItemsSource = AllInputs;


                        MessageBox.Show("InputSet Successfully Added");
                        return;
                    }
                }


                MessageBox.Show("Invalid Tag \nPlease try again with correct spelling.");

            }
        }


        private void RemoveFromListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HdataListView.SelectedIndex >= 0)
            {
                AllInputs.RemoveAt(HdataListView.SelectedIndex);
                HdataListView.ItemsSource = null;
                HdataListView.ItemsSource = AllInputs;
            }
            else
            {
                MessageBox.Show("Select an Input-Record first.");
            }
        }

        private void RemoveAllListBtn_Click(object sender, RoutedEventArgs e)
        {
            AllInputs.Clear();
            HdataListView.ItemsSource = null;
            HdataListView.ItemsSource = AllInputs;

            MessageBox.Show("All Input-Records are removed successfully.");
        }


        private async void StartSimBtn_Click(object sender, RoutedEventArgs e)
        {

            // perform the inputset
            InputClass ic = new InputClass();
            await ic.SendInputSet(AllInputs, 0);
        }


        // helper method
        private void LoadCombo()
        {

            // Mouse- Event Combo
            MouseEventComboBox.Items.Add("Left Button Down");
            MouseEventComboBox.Items.Add("Left Button Up");
            MouseEventComboBox.Items.Add("Left Button Double Click");
            MouseEventComboBox.Items.Add("Middle Button Double Click");
            MouseEventComboBox.Items.Add("Middle Button Down");
            MouseEventComboBox.Items.Add("Middle Button Up");
            MouseEventComboBox.Items.Add("Right Button Down");
            MouseEventComboBox.Items.Add("Right Button Up");
            MouseEventComboBox.Items.Add("Right Button Double Click");
            MouseEventComboBox.Items.Add("MouseWheel");
            MouseEventComboBox.Items.Add("Cursor Movement");
            MouseEventComboBox.Items.Add("Left Click");
            MouseEventComboBox.Items.Add("Right Click");

            // Keyboard - Event - Combo
            KeyboardEventComboBox.Items.Add("Key Down");
            KeyboardEventComboBox.Items.Add("Key Up");
            KeyboardEventComboBox.Items.Add("Key Press");

            KeyboardEventComboBox.SelectedIndex = 2;

            MI_CheckBox.IsChecked = true;
        }

        private void MI_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TempCustomData.HookTypeIndex = 0;
            TempCustomData.HookTypeName = "Mouse Input";

            KeyboardInputBoxSetStack.IsEnabled = false;
            MouseInputBoxSetStack.IsEnabled = true;
        }

        private void KI_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TempCustomData.HookTypeIndex = 1;
            TempCustomData.HookTypeName = "Keyboard Input";

            MouseInputBoxSetStack.IsEnabled = false;
            KeyboardInputBoxSetStack.IsEnabled = true;

        }

        private void SaveListExpander_Expanded(object sender, RoutedEventArgs e)
        {
            ManualExpander.IsExpanded = false;
        }


        private IntPtr KeyBoardCallBack(int code, IntPtr wParam, IntPtr lParam)
        {
            KBDLLHOOKSTRUCT k = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

            if (wParam == (IntPtr)KeyBoardResponse.WM_KEYDOWN || wParam == (IntPtr)KeyBoardResponse.WM_SYSKEYDOWN)
            {
                TempCustomData.ScanCode = (ushort)k.scanCode;
                KeyStatusTxt.Text = "Assigned Key:" + "  " + ((ScanCodeKey)TempCustomData.ScanCode).ToString();
                IsAssigned = true;
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
