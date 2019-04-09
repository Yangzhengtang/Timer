using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count_down_test_1
{
    class CycleTimer: Timer
    {

        public CycleTimer(string path = "./TimerConfig.json") : base(path) {; }

        public CycleTimer(System.DateTime EndTime) : base(EndTime) {; }

        public CycleTimer(System.TimeSpan OriginTimeSpan, TimerOption timeroption) : base(
            OriginTimeSpan, timeroption)
        {; }

        //  The overridden method.
        protected override void update()
        {
            /*
            if(timerOption != TimerOption.Cycle)
            {
                Console.WriteLine("What the fuck?");
                this.onEnd();
                return;
            }   */

            System.Threading.Thread.Sleep(20);
            currentTime = System.DateTime.Now;

            if (expire == false)   //  Not expired yet
            {
                if (currentTime.CompareTo(endTime) <= 0) // Still not expire
                {
                    diffTimeSpan = endTime.Subtract(currentTime);
                    if((currentTime.Subtract(startTime)).TotalMilliseconds > 3000)  //  Stop alarming, this may cause error.
                    {
                        if (this.alarm)
                        {
                            this.alarm = false;
                            onAfterAlarm();
                        }
                    }
                }
                else   // Turn to expire, now it's already expired
                {
                    diffTimeSpan = currentTime.Subtract(endTime);
                    expire = true;
                    alarm = true;
                    onAlarm();
                }
            }

            else // Already expired, the time span between -100 and +100
            {
                diffTimeSpan = currentTime.Subtract(endTime);
                if (diffTimeSpan.TotalMilliseconds > 100)    //  not alarming
                {
                    onCycleTurnOver();
                }
            }

            this.onUpdated();

            Console.WriteLine("{0} - {1} = {2}, Alarm: {3}",
                endTime, currentTime, diffTimeSpan.ToString(),
                (alarm ? "Yes" : "No"));
        }
    
        //  After expired, the cycle timer will turn over to the beginning.
        protected virtual void onCycleTurnOver()
        {
            startTime = startTime.Add(originTimeSpan);
            endTime = endTime.Add(originTimeSpan);
            diffTimeSpan = originTimeSpan;
            expire = false;
            alarm = true;
            endSig = false;
        }
    }
}
