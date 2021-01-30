using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputSim.Hooks;

namespace InputSim
{
    public struct MouseHookSettings
    {
        public bool RightDown;
        public bool RightUp;
        public bool LeftDown;
        public bool LeftUp;
        public bool RightDouble;
        public bool LeftDouble;
        public bool Movement;
        public bool Wheel;
        public bool MidDouble;
        public bool MidUp;
        public bool MidDown;
        public bool LeftClick;
        public bool RightClick;
    }


    [Serializable]
    public class InputSetData
    {
        public List<InputData> HookedDataList { get; set; }

        // meta data
        public string Tag { get; set; }
        public ScanCodeKey  AsignedKeySC { get; set; }

        public string AsignedKeyName { get; set; }
        public string Desdescription { get; set; }
        public string DateText { get; set; }

        public int Repeat { get; set; }

    }


    [Serializable]
    public class InputData
    {
        public string HookTypeName { get; set; }
        public long Timespan { get; set; }
        public ushort RepeatSingular { get; set; } = 0;
        public uint InputIndex { get; set; }



        /// <summary>
        /// 0 - for Mouse Hook Event
        /// 1 -  for keyboard Hook Event
        /// </summary>
        public int HookTypeIndex { get; set; }

        // Mouse prop
        public string MouseEventName { get; set; }


        /// <summary>
        ///  0 - Left Button Down
        ///  1- Left Button UP
        ///  2 - Left Double Click
        ///  3 - Mid Double Click 
        ///  4 - Mid Down 
        ///  5 - Mid Up
        ///  6 - Right Down
        ///  7- Right Up
        ///  8 - Right Double 
        ///  9 - Mouse Wheel
        ///  10 - Mouse Movement
        ///  11 - Left Click
        ///  12 - Right Click
        /// </summary>
        public int MouseEventIndex { get; set; }


        public int MousePointX { get; set; }
        public int MousePointY { get; set; }
        public short WheelDelta { get; set; }


        // Keyboard Prop
        public ushort VkeyCode { get; set; }
        public ushort ScanCode { get; set; }
        public string KeyName { get; set; }
        public string KeyboardEventName { get; set; }
        public int KeyBoardEventIndex { get; set; }

    }


}
