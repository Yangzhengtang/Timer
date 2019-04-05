using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace count_down_test_1
{
    class TimerConfigure
    {
        public System.DateTime startTime { get; set; }
        public System.DateTime endTime   { get; set; }
        public System.DateTime currentTime{ get; set; }
        public System.TimeSpan diffTimeSpan{ get; set; }
        public System.TimeSpan originTimerSpan { get; set; }
        public bool expire  { get; set; }
        public bool alarm   { get; set; }
        public bool endSig  { get; set; }
        public bool pause   { get; set; }
        public TimerOption timerOption      { get; set; }

        public TimerConfigure(System.DateTime StartTime, System.DateTime EndTime, System.DateTime CurrentTime,
                    System.TimeSpan DiffTimeSpan, System.TimeSpan OriginTimerSpan,
                    bool Expire, bool Alarm, bool EndSig, bool Pause, TimerOption TO)
        {
            startTime = StartTime;
            endTime = EndTime;
            currentTime = CurrentTime;
            diffTimeSpan = DiffTimeSpan;
            originTimerSpan = OriginTimerSpan;
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

        public void read(string path)
        {

        }
    }
}
