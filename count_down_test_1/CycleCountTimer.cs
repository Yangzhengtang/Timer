using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiTimer
{
    class CycleCountTimer: CycleTimer
    {
        private int limit;  //  The timer will end when the count reaches the limit.
        private int count;  //  Each overturn will add to the count.

        public CycleCountTimer(string path = "./TimerConfig.json")
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
                this.limit = CCTC.limit-1;
                this.count = CCTC.count;
            }
        }

        public CycleCountTimer(System.DateTime EndTime, int Limit) : base(EndTime) {
            this.limit = Limit;
            this.count = 0;
        }

        public CycleCountTimer(System.TimeSpan OriginTimeSpan, TimerOption timeroption,int Limit) : base(
            OriginTimeSpan, timeroption)
        {
            this.limit = Limit;
            this.count = 0;
        }

        //  The update method is just the same as CycleTimer

        public override void reset()
        {
            base.reset();
            this.count = 0;
            this.onUpdated();
        }

        protected override void onCycleTurnOver()
        {
            base.onCycleTurnOver();
            this.count += 1;
            Console.WriteLine("Now the count is {0}", this.count);
            if(this.count == this.limit)
            {
                this.endSig = true;
            }
        }

        public override void dumpConfig(string path = "./TimerConfig.json")
        {
            Console.WriteLine("dumping");

            this.timerConfigure = new CycleCount_TimerConfigure(this.startTime,this.endTime,this.currentTime,System.DateTime.Now,
                                                     this.diffTimeSpan,this.originTimeSpan,this.expire,this.alarm,
                                                     this.endSig,this.pause,this.timerOption,this.limit,this.count);
            this.timerConfigure.dump(path);
        }
    }
}
