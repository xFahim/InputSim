using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InputSim.Hooks
{
    public class HelperHook
    {

        [DllImport("user32.dll")]
        static extern uint GetDoubleClickTime();

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(int smIndex);

        public static bool IsClick(POINT[] p)
        {

            int dx = Math.Abs(p[0].X - p[1].X);
            int dy = Math.Abs(p[0].Y - p[1].Y);


            if (dx <= GetSystemMetrics(36) && dy <= GetSystemMetrics(37))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool IsDoubleClick(POINT[] p, long tspan)
        {
            //check time bound 
            // substract 40 as in between code execution time
            if (tspan > GetDoubleClickTime())
            {
                return false;
            }

            int dx =Math.Abs( p[0].X - p[1].X);
            int dy =Math.Abs( p[0].Y - p[1].Y);
            

            if (dx <= GetSystemMetrics(36) && dy <= GetSystemMetrics(37))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

