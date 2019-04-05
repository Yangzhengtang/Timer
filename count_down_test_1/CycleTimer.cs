using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static count_down_test_1.TimerOption;

namespace count_down_test_1
{
    class CycleTimer: Timer
    {

        public CycleTimer(System.TimeSpan OriginTimeSpan, TimerOption timeroption) : base(
            OriginTimeSpan, timeroption)
        {; }

        protected override void update()
        {
            if(timerOption != Cycle)
            {
                Console.WriteLine("What the fuck?");
                this.onEnd();
                return;
            }

            System.Threading.Thread.Sleep(1);
            currentTime = System.DateTime.Now;

            if (expire == false)   //  Not expired yet
            {
                if (currentTime.CompareTo(endTime) <= 0) // Still not expire
                {
                    diffTimeSpan = endTime.Subtract(currentTime);
                    if (diffTimeSpan.TotalMilliseconds < 100)    // Ready to expire, still not expire yet.
                    {
                        expire = true;
                        alarm = true;
                        onAlarm();
                    }
                    else
                    {
                        ;
                    }
                }
                else   // Turn to expire, now it's already expired
                {
                    diffTimeSpan = currentTime.Subtract(endTime);
                    expire = true;
                    alarm = true;
                    onAlarm();

                    // Now reset the timer.
                    //onCycleTurnOver();
                }
            }

            else // Already expired, the time span between -100 and +100
            {
                diffTimeSpan = currentTime.Subtract(endTime);
                if (diffTimeSpan.TotalMilliseconds > 100)    //  not alarming
                {
                    onAfterAlarm();
                    onCycleTurnOver();
                }

                //onAfterAlarm();
                //  reset the timer
                //onCycleTurnOver();

            }

            this.onUpdated();

            Console.WriteLine("{0} - {1} = {2}, Alarm: {3}",
                endTime, currentTime, diffTimeSpan.ToString(),
                (alarm ? "Yes" : "No"));
        }
    
        private void onCycleTurnOver()
        {
            startTime = startTime.Add(originTimeSpan);
            endTime = endTime.Add(originTimeSpan);
            diffTimeSpan = originTimeSpan;
            expire = false;
            alarm = false;
            endSig = false;
        }
         
    }
}
