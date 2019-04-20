using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiTimer
{
    class IntervalCycleTimer: CycleTimer
    {
        private int interval;  //  The timer will end when the count reaches the limit.
        private int count;  //  Each overturn will add to the count.
        private System.TimeSpan intervalSpan;

        public IntervalCycleTimer(string path = "./TimerConfig.json")
        {
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
                Console.WriteLine("Read configure done\n Now building the timer...");
                IntervalCycle_TimerConfigure ICTC = Newtonsoft.Json.JsonConvert.
                                                        DeserializeObject<IntervalCycle_TimerConfigure>(json);
                this.timerConfigure = ICTC;
                this.startTime = this.timerConfigure.startTime;
                this.endTime = this.timerConfigure.endTime;
                this.originTimeSpan = this.timerConfigure.originTimeSpan;
                this.expire = this.timerConfigure.expire;
                this.endSig = false;
                this.alarm = this.timerConfigure.alarm;
                this.pause = true;
                this.timerOption = this.timerConfigure.timerOption;
                this.diffTimeSpan = this.timerConfigure.diffTimeSpan;
                this.currentTime = System.DateTime.Now;
                this.pauseTime = this.timerConfigure.pauseTime;
                this.interval = ICTC.interval;
                this.count = ICTC.count;
                this.intervalSpan = new System.TimeSpan(0,0,this.interval);
            }
        }

        public IntervalCycleTimer(System.DateTime EndTime, int Interval) : base(EndTime)
        {
            this.interval = Interval;
            this.intervalSpan = new System.TimeSpan(0, 0, this.interval);
        }

        public IntervalCycleTimer(System.TimeSpan OriginTimeSpan, TimerOption timeroption, int Interval) : base(
            OriginTimeSpan, timeroption)
        {
            this.interval = Interval;
            this.intervalSpan = new System.TimeSpan(0, 0, this.interval);
        }

        //  The update method is just the same as CycleTimer


        /// <summary>
        /// Only reset the timmer when it's been expired for a time period as interval.
        /// During the interval, the timer behaves just the same as an expired normal timer.
        /// </summary>
        protected override void update()
        {
            System.Threading.Thread.Sleep(20);
            currentTime = System.DateTime.Now;

            if (expire == false)   //  Not expired yet
            {
                if (currentTime.CompareTo(endTime) <= 0) // Still not expire
                {
                    diffTimeSpan = endTime.Subtract(currentTime);
                    if ((currentTime.Subtract(startTime)).TotalMilliseconds > 3000)
                    {
                        //  When alarming after turnover and lasts over 3 secs, stop it.
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

            else // Already expired
            {
                diffTimeSpan = currentTime.Subtract(endTime);
                if(diffTimeSpan.TotalMilliseconds > (this.interval * 1000)) //  After the interval, should turnover.
                {
                    startTime = startTime.Add(originTimeSpan).Add(intervalSpan);
                    endTime = endTime.Add(originTimeSpan).Add(intervalSpan);
                    diffTimeSpan = originTimeSpan;
                    expire = false;
                    alarm = false;
                    endSig = false;
                }
                else if (diffTimeSpan.TotalMilliseconds > 3000)    // Expired but not turn over, the time span over 3 secs, stop alarming
                {
                    expire = false;
                    this.alarm = false;
                    onAfterAlarm();
                }
                else
                {
                    //  Expired over 3 seconds, but not reached intervals end. Do nothing.
                }
            }

            this.onUpdated();

            Console.WriteLine("{0} - {1} = {2}, Alarm: {3}",
                endTime, currentTime, diffTimeSpan.ToString(),
                (alarm ? "Yes" : "No"));
        }

        public override void dumpConfig(string path = "./TimerConfig.json")
        {
            Console.WriteLine("dumping");

            this.timerConfigure = new IntervalCycle_TimerConfigure(this.startTime, this.endTime, this.currentTime, System.DateTime.Now,
                                                     this.diffTimeSpan, this.originTimeSpan, this.expire, this.alarm,
                                                     this.endSig, this.pause, this.timerOption, this.interval, this.count);
            this.timerConfigure.dump(path);
        }

    }
}
