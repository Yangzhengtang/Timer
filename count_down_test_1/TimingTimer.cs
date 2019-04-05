using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count_down_test_1
{
    class TimingTimer: Timer
    {

        public TimingTimer(System.TimeSpan OriginTimeSpan, TimerOption timeroption) : base(
            OriginTimeSpan, timeroption){; }

    }
}
