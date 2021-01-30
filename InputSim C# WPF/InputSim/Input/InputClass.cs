using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using InputSim.Hooks;

namespace InputSim.Input
{
    public class InputClass
    {
        public async Task SendInputSet(List<InputData> _InpData, int repeat)
        {
            // Repetition for complete InputSet
            for (int c = 0; c <= repeat; c++)
            {
                if (HelperInputClass.ContinueSimProcess == false)
                    break;

                foreach (InputData i in _InpData)
                {
                    if (HelperInputClass.ContinueSimProcess == false)
                        break;

                    // Repetition for individual process
                    for (int j = 0; j <= i.RepeatSingular; j++)
                    {
                        //mouse input
                        if (i.HookTypeIndex == 0)
                        {

                            await Task.Delay((int)i.Timespan);
                            switch (i.MouseEventIndex)
                            {
                                case 0: // 0 MouseEventName -> Left Button Down
                                    SendSingleMouseInput(MOUSEEVENTF.LeftButtonDown | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                                case 1: // 1 MouseEventName -> Left Button Up
                                    SendSingleMouseInput(MOUSEEVENTF.LeftButtonUp | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                                case 2: // 2 MouseEventName -> Left Button Double Click
                                    SendDoubleClick(MOUSEEVENTF.LeftButtonDown | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, MOUSEEVENTF.LeftButtonUp | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                                case 3: // 3 MouseEventName -> Middle Button Double Click
                                    SendDoubleClick(MOUSEEVENTF.MiddleButtonDown | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, MOUSEEVENTF.MiddleButtonUp | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                                case 4: // 4 MouseEventName -> Middle Button Down
                                    SendSingleMouseInput(MOUSEEVENTF.MiddleButtonDown | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                                case 5: // 5 MouseEventName -> Middle Button Up
                                    SendSingleMouseInput(MOUSEEVENTF.MiddleButtonUp | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                                case 6: // 6 MouseEventName -> Right Button Down
                                    SendSingleMouseInput(MOUSEEVENTF.RightButtonDown | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                                case 7: // 7 MouseEventName -> Right Button Up
                                    SendSingleMouseInput(MOUSEEVENTF.RightButtonUp | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                                case 8: // 8 MouseEventName -> Right Button Double Click
                                    SendDoubleClick(MOUSEEVENTF.RightButtonDown | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, MOUSEEVENTF.RightButtonUp | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                                case 9: // 9 MouseEventName -> MouseWheel
                                    SendMouseWheel(i.WheelDelta, i.MousePointX, i.MousePointY);
                                    break;
                                case 10: // 10 MouseEventName -> Cursor Movement
                                    MoveMouse(i.MousePointX, i.MousePointY);
                                    break;
                                case 11: // 11 MouseEventName -> Left Click
                                    SendClick(MOUSEEVENTF.LeftButtonDown | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, MOUSEEVENTF.LeftButtonUp | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                                case 12: // 10 MouseEventName -> Right Click
                                    SendClick(MOUSEEVENTF.RightButtonDown | MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE, MOUSEEVENTF.RightButtonUp | MOUSEEVENTF.ABSOLUTE, i.MousePointX, i.MousePointY);
                                    break;
                            }


                        }
                        else if (i.HookTypeIndex == 1) //keyboard- input
                        {
                            await Task.Delay((int)i.Timespan);
                            switch (i.KeyBoardEventIndex)
                            {
                                case 0: // 0 KeyBoardEventName -> Key Down
                                    SendKeyboardInput(false, i.ScanCode, 0);
                                    break;
                                case 1: // 0 KeyBoardEventName -> Key Up
                                    SendKeyboardInput(false, i.ScanCode, 1);
                                    break;
                                case 2: // 0 KeyBoardEventName -> Key Press
                                    SendKeyboardInput(false, i.ScanCode, 2);
                                    break;
                            }
                        }
                    }

                    
                    
                }
            }
        }

        private void SendKeyboardInput(bool IsVkey, ushort value, int _eventIndex)
        {
            INPUT temp = new INPUT();

            temp.type = (uint)INPUT_TYPE.INPUT_KEYBOARD;
            temp.U.ki.time = 0;
            temp.U.ki.dwExtraInfo = UIntPtr.Zero;


            if (IsVkey)
            {
                temp.U.ki.wScan = 0;
                temp.U.ki.dwFlags = 0;
                temp.U.ki.wVk = value;
                
            }
            else
            {
                temp.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                temp.U.ki.wScan = value;
            }


            /// 
            /// Check which event
            //
            // key down
            if (_eventIndex == 0)
            {
                SendInput(1, new INPUT[] { temp }, INPUT.Size);
            }
            else if (_eventIndex == 1) // key up
            {
                temp.U.ki.dwFlags = KEYEVENTF.KEYUP;
                SendInput(1, new INPUT[] { temp }, INPUT.Size);
            }
            else if (_eventIndex == 2) // key press
            {
                SendInput(1, new INPUT[] { temp }, INPUT.Size);

                temp.U.ki.dwFlags = KEYEVENTF.KEYUP;
                SendInput(1, new INPUT[] { temp }, INPUT.Size);
            }
            
        }

        private void SendSingleMouseInput(MOUSEEVENTF m, int x, int y)
        {
            INPUT inp = new INPUT
            {
                type = (uint)INPUT_TYPE.INPUT_MOUSE
            };

            inp.U.mi.time = 0;
            inp.U.mi.dwExtraInfo = UIntPtr.Zero;

            inp.U.mi.dx = CalculateAbsoluteCoordinateX(x); 
            inp.U.mi.dy = CalculateAbsoluteCoordinateY(y); 
            inp.U.mi.dwFlags = m;

            SendInput(1, new INPUT[] { inp }, INPUT.Size);
        }


        /// <param name="m1">Event for KeyDown</param>
        /// <param name="m2">Event for KeyUp</param>
        private void SendClick(MOUSEEVENTF m1, MOUSEEVENTF m2, int x, int y)
        {
            INPUT inp = new INPUT();

            inp.type = (uint)INPUT_TYPE.INPUT_MOUSE;
            inp.U.mi.time = 0;
            inp.U.mi.dwExtraInfo = UIntPtr.Zero;


            inp.U.mi.dx = CalculateAbsoluteCoordinateX(x);
            inp.U.mi.dy = CalculateAbsoluteCoordinateY(y);

            //Key Down
            inp.U.mi.dwFlags = m1;
            SendInput(1, new INPUT[] { inp }, INPUT.Size);

            // Key Up
            inp.U.mi.dwFlags = m2;
            SendInput(1, new INPUT[] { inp }, INPUT.Size);
        }


        private void SendMouseWheel(short delta, int x, int y)
        {
            INPUT inp = new INPUT();

            inp.type = (uint)INPUT_TYPE.INPUT_MOUSE;
            inp.U.mi.time = 0;
            inp.U.mi.dwExtraInfo = UIntPtr.Zero;


            inp.U.mi.dx = CalculateAbsoluteCoordinateX(x);
            inp.U.mi.dy = CalculateAbsoluteCoordinateY(y);
            inp.U.mi.mouseData = delta;
            inp.U.mi.dwFlags = MOUSEEVENTF.WHEEL;

            SendInput(1, new INPUT[] { inp }, INPUT.Size);
        }

        private void MoveMouse(int x, int y)
        {
            INPUT inp = new INPUT();

            inp.type = (uint)INPUT_TYPE.INPUT_MOUSE;
            inp.U.mi.time = 0;
            inp.U.mi.dwExtraInfo = UIntPtr.Zero;


            inp.U.mi.dx = CalculateAbsoluteCoordinateX(x);
            inp.U.mi.dy = CalculateAbsoluteCoordinateY(y);
            inp.U.mi.dwFlags = MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE;

            SendInput(1, new INPUT[] { inp }, INPUT.Size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1">Event for KeyDown</param>
        /// <param name="m2">Event for KeyUp</param>
        private void SendDoubleClick(MOUSEEVENTF m1, MOUSEEVENTF m2, int x, int y )
        {
            INPUT inp = new INPUT();

            inp.type = (uint)INPUT_TYPE.INPUT_MOUSE;
            inp.U.mi.time = 0;
            inp.U.mi.dwExtraInfo = UIntPtr.Zero;


            inp.U.mi.dx = CalculateAbsoluteCoordinateX(x);
            inp.U.mi.dy = CalculateAbsoluteCoordinateY(y);

            // First Click
            //Key Down
            inp.U.mi.dwFlags = m1;
            SendInput(1, new INPUT[] { inp }, INPUT.Size);

            // Key Up
            inp.U.mi.dwFlags = m2;
            SendInput(1, new INPUT[] { inp }, INPUT.Size);

            // second click
            //Key Down
            inp.U.mi.dwFlags = m1;
            SendInput(1, new INPUT[] { inp }, INPUT.Size);

            // Key Up
            inp.U.mi.dwFlags = m2;
            SendInput(1, new INPUT[] { inp }, INPUT.Size);
        }


        enum SystemMetric
        {
            SM_CXSCREEN = 0,
            SM_CYSCREEN = 1,
        }

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(SystemMetric smIndex);

        int CalculateAbsoluteCoordinateX(int x)
        {
            return (x * 65536) / GetSystemMetrics(SystemMetric.SM_CXSCREEN);
        }

        int CalculateAbsoluteCoordinateY(int y)
        {
            return (y * 65536) / GetSystemMetrics(SystemMetric.SM_CYSCREEN);
        }


        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);


    }
}
