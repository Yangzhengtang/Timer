using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace count_down_test_1
{
    class TimerConfigure
    {
        public System.DateTime startTime { get; set; }
        public System.DateTime endTime   { get; set; }
        public System.DateTime currentTime { get; set; }
        public System.DateTime pauseTime { get; set; }

        public System.TimeSpan diffTimeSpan{ get; set; }
        public System.TimeSpan originTimeSpan { get; set; }
        public bool expire  { get; set; }
        public bool alarm   { get; set; }
        public bool endSig  { get; set; }
        public bool pause   { get; set; }
        public TimerOption timerOption      { get; set; }

        public TimerConfigure()
        {
            ;
        }

        public TimerConfigure(string path)
        {
            this.load(path);
        }

        public TimerConfigure(System.DateTime StartTime, System.DateTime EndTime, System.DateTime CurrentTime, System.DateTime PauseTime,
                    System.TimeSpan DiffTimeSpan, System.TimeSpan OriginTimeSpan,
                    bool Expire, bool Alarm, bool EndSig, bool Pause, TimerOption TO)
        {
            startTime = StartTime;
            endTime = EndTime;
            currentTime = CurrentTime;
            pauseTime = PauseTime;
            diffTimeSpan = DiffTimeSpan;
            originTimeSpan = OriginTimeSpan;
            expire = Expire;
            alarm = Alarm;
            endSig = EndSig;
            pause = Pause;
            timerOption = TO;
        }

        public void dump(string path)
        {
            Console.WriteLine("Now dumping the configure to {0}",path);
            string json = JsonConvert.SerializeObject(this);
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path))
            {
                sw.Write(json);
                Console.WriteLine("Dump done.");
            }
        }

        //  Read the json file from the path and build from it.
        public virtual void load(string path)
        {
            TimerConfigure tc = new TimerConfigure();
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
                Console.WriteLine("Read configure done.");
                tc = JsonConvert.DeserializeObject<TimerConfigure>(json);
                this.startTime = tc.startTime;
                this.endTime = tc.endTime;
                this.originTimeSpan = tc.originTimeSpan;
                this.expire = tc.expire;
                this.endSig = false;
                this.alarm = tc.alarm;
                this.pause = true;
                this.timerOption = tc.timerOption;
                this.diffTimeSpan = tc.diffTimeSpan;
                this.pauseTime = tc.pauseTime;
            }
        }
    }

    class CycleCount_TimerConfigure: TimerConfigure
    {
        public int limit { get; set; }
        public int count { get; set; }

        public CycleCount_TimerConfigure(): base() {; }

        public CycleCount_TimerConfigure(string path): base(path){; }

        public CycleCount_TimerConfigure(System.DateTime StartTime, System.DateTime EndTime, System.DateTime CurrentTime, System.DateTime PauseTime,
                    System.TimeSpan DiffTimeSpan, System.TimeSpan OriginTimeSpan,
                    bool Expire, bool Alarm, bool EndSig, bool Pause, TimerOption TO, int Limit, int Count):
            base(StartTime, EndTime, CurrentTime, PauseTime,DiffTimeSpan, OriginTimeSpan, Expire, Alarm, EndSig, Pause, TO)
        {
            limit = Limit;
            count = Count;
        }

        public override void load(string path)
        {
            CycleCount_TimerConfigure cctc = new CycleCount_TimerConfigure();
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
                Console.WriteLine("Read configure done.");
                cctc = JsonConvert.DeserializeObject<CycleCount_TimerConfigure>(json);
                this.startTime = cctc.startTime;
                this.endTime = cctc.endTime;
                this.originTimeSpan = cctc.originTimeSpan;
                this.expire = cctc.expire;
                this.endSig = false;
                this.alarm = cctc.alarm;
                this.pause = true;
                this.timerOption = cctc.timerOption;
                this.diffTimeSpan = cctc.diffTimeSpan;
                this.pauseTime = cctc.pauseTime;
                this.limit = cctc.limit;
                this.count = cctc.count;
            }
        }
    }

}
