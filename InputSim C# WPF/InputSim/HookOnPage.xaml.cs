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
using System.Diagnostics;
using InputSim.Hooks;

namespace InputSim
{
    /// <summary>
    /// Interaction logic for HookOnPage.xaml
    /// </summary>
    public partial class HookOnPage : Page
    {
        // count of tracked input
        int count = 0;

        // list of inputs/ inputset
        List<InputData> HDList = new List<InputData>();

        //settings from home menu
        MouseHookSettings _hookSettingsMouse;

        // ver related to hook
        IntPtr _hookID1 = IntPtr.Zero, _hookID2 = IntPtr.Zero;
        Hook h1, h2;

        // to capture the time delay
        Stopwatch sw = new Stopwatch();
        TimeSpan ts;

        public HookOnPage(bool IsMouse, bool IsKeyboard, MouseHookSettings hks)
        {
            InitializeComponent();
            

            //initializing settings 
            _hookSettingsMouse = hks;

            // records time delay
            sw.Start();

            // setting hook
            if (IsMouse)
            {
                h1 = new Hook( HookType.WH_MOUSE_LL, MouseCallBack );
                _hookID1 = h1.SetHook();
            }

            if (IsKeyboard)
            {
                h2 = new Hook(HookType.WH_KEYBOARD_LL, KeyBoardCallBack);
                _hookID2 = h2.SetHook();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private IntPtr MouseCallBack(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0)
            {
                MSLLHOOKSTRUCT m = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));



                // For Mouse button down, we have to manually check for double click. as its not supported in LL hook
                if ( wParam == (IntPtr)MouseResponse.WM_LBUTTONDOWN 
                    && _hookSettingsMouse.LeftDown == true)
                {
                    HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Left Button Down", MouseEventIndex = 0, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper() , InputIndex = (uint)count});
                }
                else if (wParam == (IntPtr)MouseResponse.WM_LBUTTONUP
                    && _hookSettingsMouse.LeftUp == true)
                {

                    // check for left click
                    if (_hookSettingsMouse.LeftClick )
                    {
                        if (HDList.Count() > 0 && HDList[count-1].MouseEventIndex == 0)
                        {
                            POINT[] p = new POINT[] {
                              new POINT { X = HDList[count-1].MousePointX, Y = HDList[count-1].MousePointY },
                              new POINT { X = m.pt.X, Y = m.pt.Y }
                            };

                            if (HelperHook.IsClick(p))
                            {
                                long temp = HDList[count - 1].Timespan;

                                HDList.RemoveAt(count -1);
                                HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Left Click", MouseEventIndex = 11, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = temp, InputIndex = (uint)count  });
                            }
                            else
                            {
                                HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Left Button Up", MouseEventIndex = 1, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count });
                            }
                        }
                    }
                    else
                    {
                        HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Left Button Up", MouseEventIndex = 1, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count });
                    }


                }
                else if (wParam == (IntPtr)MouseResponse.WM_LBUTTONDBLCLK
                    && _hookSettingsMouse.LeftDouble == true)
                {
                    HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Left Button Double Click", MouseEventIndex = 2, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count  });
                }
                else if (wParam == (IntPtr)MouseResponse.WM_MBUTTONDBLCLK
                    && _hookSettingsMouse.MidDouble == true)
                {
                    HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Middle Button Double Click", MouseEventIndex = 3, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count  });
                }
                else if (wParam == (IntPtr)MouseResponse.WM_MBUTTONDOWN
                    && _hookSettingsMouse.MidDown == true)
                {
                    HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Middle Button Down", MouseEventIndex = 4, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count  });
                }
                else if (wParam == (IntPtr)MouseResponse.WM_MBUTTONUP
                    && _hookSettingsMouse.MidUp == true)
                {
                    HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Middle Button Up", MouseEventIndex = 5, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count  });
                }
                else if (wParam == (IntPtr)MouseResponse.WM_RBUTTONDOWN
                    && _hookSettingsMouse.RightDown == true)
                {
                    HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Right Button Down", MouseEventIndex = 6, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count  });
                }
                else if (wParam == (IntPtr)MouseResponse.WM_RBUTTONUP
                    && _hookSettingsMouse.RightUp == true)
                {

                    // check for left click
                    if (_hookSettingsMouse.LeftClick)
                    {
                        if (HDList.Count() > 0 && HDList[count - 1].MouseEventIndex == 6)
                        {
                            POINT[] p = new POINT[] {
                              new POINT { X = HDList[count-1].MousePointX, Y = HDList[count-1].MousePointY },
                              new POINT { X = m.pt.X, Y = m.pt.Y }
                            };

                            if (HelperHook.IsClick(p))
                            {
                                long temp = HDList[count - 1].Timespan;

                                HDList.RemoveAt(count - 1);
                                HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Right Click", MouseEventIndex = 12, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = temp, InputIndex = (uint)count  });
                            }
                            else
                            {
                                HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Right Button Up", MouseEventIndex = 7, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count  });
                            }
                        }
                    }
                    else
                    {
                        HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Right Button Up", MouseEventIndex = 7, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count  });
                    }


                    
                }
                else if (wParam == (IntPtr)MouseResponse.WM_RBUTTONDBLCLK
                    && _hookSettingsMouse.RightDouble == true)
                {
                    HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Right Button Double Click", MouseEventIndex = 8, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count  });
                }
                else if (wParam == (IntPtr)MouseResponse.WM_MOUSEWHEEL
                    && _hookSettingsMouse.Wheel == true)
                {
                    HDList.Add(new InputData { HookTypeName = "Mouse Input", HookTypeIndex = 0, MouseEventName = "Mouse Wheel", MouseEventIndex = 9, MousePointX = m.pt.X, MousePointY = m.pt.Y, WheelDelta = (short)(m.mouseData >> 16), KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count });
                }
                else if (wParam == (IntPtr)MouseResponse.WM_MOUSEMOVE
                    && _hookSettingsMouse.Movement == true)
                {
                    HDList.Add(new InputData { HookTypeName = "c", HookTypeIndex = 0, MouseEventName = "Cursor Movement", MouseEventIndex = 10, MousePointX = m.pt.X, MousePointY = m.pt.Y, KeyName = "N/A", KeyboardEventName = "N/A", Timespan = TimeSpanHelper(), InputIndex = (uint)count  });
                }

            }

            CallNextHookEx(_hookID1, code, wParam, lParam);

            CountTxt.Text = count.ToString();
            return IntPtr.Zero;
        }

        private long TimeSpanHelper()
        {
            sw.Stop();
            long t = sw.ElapsedMilliseconds;

            count++;
            sw.Restart();

            return t;
        }




        private IntPtr KeyBoardCallBack(int code, IntPtr wParam, IntPtr lParam)
        {
            KBDLLHOOKSTRUCT k = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

            if (wParam == (IntPtr)KeyBoardResponse.WM_KEYDOWN || wParam == (IntPtr)KeyBoardResponse.WM_SYSKEYDOWN)
            {
                HDList.Add(new InputData { HookTypeName = "Keyboard Input", HookTypeIndex = 1, KeyboardEventName = "Key Down", KeyBoardEventIndex = 0, ScanCode = (ushort)k.scanCode, VkeyCode = (ushort)k.vkCode, KeyName = ((ScanCodeKey)k.scanCode).ToString(), Timespan = TimeSpanHelper(), InputIndex = (uint)count, MouseEventName = "N/A" });
            }
            else if (wParam == (IntPtr)KeyBoardResponse.WM_KEYUP || wParam == (IntPtr)KeyBoardResponse.WM_SYSKEYUP)
            {
                HDList.Add(new InputData { HookTypeName = "Keyboard Input", HookTypeIndex = 1, KeyboardEventName = "Key Up", KeyBoardEventIndex = 1, ScanCode = (ushort)k.scanCode, VkeyCode = (ushort)k.vkCode, KeyName = ((ScanCodeKey)k.scanCode).ToString(), Timespan = TimeSpanHelper(), InputIndex = (uint)count, MouseEventName = "N/A" });
            }

            CountTxt.Text = count.ToString();

            CallNextHookEx(_hookID2, code, wParam, lParam);
            return IntPtr.Zero;
        }

        private void UnHookBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_hookID1 != null)
            {
                UnhookWindowsHookEx(_hookID1);
            }

            if (_hookID2 != null)
            {
                UnhookWindowsHookEx(_hookID2);
            }

            this.NavigationService.Navigate(new HookSavePage(HDList));
        }



        
        // dlls
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    }
}
