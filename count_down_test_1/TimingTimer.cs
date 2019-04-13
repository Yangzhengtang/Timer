using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTimer
{
    class TimingTimer: Timer
    {
        /*  Only timing, don't need to compare end time and current time.
         *  The diffTime here has a different meaning !!!!!!!!!!!
         *  It means the time spent since the start time.
         */

        public TimingTimer(string path = "./TimerConfig.json") : base(path) {; }

        public TimingTimer(System.DateTime EndTime) : base(EndTime) {; }

        public TimingTimer(System.TimeSpan OriginTimeSpan, TimerOption timeroption) : base(
            OriginTimeSpan, timeroption){; }

        //  The overridden method.
        protected override void update()
        {
            if (timerOption != TimerOption.Timing)
            {
                Console.WriteLine("What the fuck?");
                this.onEnd();
                return;
            }

            System.Threading.Thread.Sleep(20);
            this.currentTime = System.DateTime.Now;
            this.diffTimeSpan = this.currentTime.Subtract(this.startTime);

            this.onUpdated();

            Console.WriteLine("{0} - {1} = {2}, Alarm: {3}",
                endTime, currentTime, diffTimeSpan.ToString(),
                (alarm ? "Yes" : "No"));
        }
    }
}
