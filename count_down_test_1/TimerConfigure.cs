using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count_down_test_1
{
    class TimerConfigure
    {
        protected System.DateTime startTime;
        protected System.DateTime endTime;
        protected System.DateTime currentTime;
        protected System.TimeSpan diffTimeSpan;
        protected bool expire;
        protected bool alarm;
        protected bool endSig;    //  Sigal sent from UI
        protected TimerOption timerOption;
    }
}
