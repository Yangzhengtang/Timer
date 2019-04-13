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

        public IntervalCycleTimer(string path = "./TimerConfig.json")
        {
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
                Console.WriteLine("Read configure done\n Now building the timer...");
                CycleCount_TimerConfigure CCTC = Newtonsoft.Json.JsonConvert.DeserializeObject<CycleCount_TimerConfigure>(json);
                this.timerConfigure = CCTC;
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
                //this.interval = CCTC.interval;
                this.count = CCTC.count;
            }
        }

        public IntervalCycleTimer(System.DateTime EndTime, int Interval) : base(EndTime)
        {
            this.interval = Interval;
        }

        public IntervalCycleTimer(System.TimeSpan OriginTimeSpan, TimerOption timeroption, int Interval) : base(
            OriginTimeSpan, timeroption)
        {
            this.interval = Interval;
        }

        //  The update method is just the same as CycleTimer

        protected override void onCycleTurnOver()
        {
            base.onCycleTurnOver();
        }

        public override void dumpConfig(string path = "./TimerConfig.json")
        {
            Console.WriteLine("dumping");

            //this.timerConfigure = new CycleCount_TimerConfigure(this.startTime, this.endTime, this.currentTime, System.DateTime.Now,
                   //                                  this.diffTimeSpan, this.originTimeSpan, this.expire, this.alarm,
                      //                               this.endSig, this.pause, this.timerOption, this.limit, this.count);
            this.timerConfigure.dump(path);
        }

    }
}
