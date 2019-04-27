using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTimer
{
    //  Different options of timers.
    public enum TimerOption
    {
        Normal = 1,         //  Default countdown timer.
        Cycle  = 2,         //  Cycle countdown timer.
        Timing = 3,         //  Timing timer.
        CycleCount = 4,     //  Cycle countdown timer.
        Interval = 5        //  Interval cycle timer.
    }

    //  Different directions of the growth of the progress bar. 
    public enum TimerDirection
    {
        Left = 1,
        Right = 2
    }

    //  Not used, later would be used if there are other ways to set up a timer.
    public enum ChooseStyle
    {
        TimeSpan = 1,
        DateTime = 2
    }

    //  Different style of the alarm being closed.
    public enum AlarmOffStyle
    {
        Auto = 1,       //  The alarm will be closed automatically.
        Manual = 2      //  The alarm has to be closed manually.
    }

    //  Different themes of the timer form.
    public enum Theme
    {
        Default = 1,
        BlackAndWhile = 2,
        Gay = 3
    }

    //  Different colors in the timer form.
    public class ThemeColors    
    {
        public Color runColor;
        public Color warnColar;
        public Color expireColor;
        public Color backColor;
    }
}
