using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count_down_test_1
{
    public enum TimerOption
    {
        Normal = 1, //  Default countdown timer.
        Cycle  = 2, //  Cycle countdown timer.
        Timing = 3, //  Timing timer.
        CycleCount = 4  //  Cycle countdown timer, also record the times.
    }

    public enum TimerDirection
    {
        Left = 1,
        Right = 2
    }

    public enum ChooseStyle
    {
        TimeSpan = 1,
        DateTime = 2
    }
}
