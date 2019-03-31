using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count_down_test_1
{
    class Timer
   //   Timer class
    {
        public delegate void AlarmEventHandler(object sender, EventArgs e);
        public delegate void AfterAlarmEventHandler(object sender, EventArgs e);

        private System.DateTime startTime;
        private System.DateTime endTime;
        private System.DateTime currentTime;
        private System.TimeSpan diffTimeSpan;
        private bool expire;
        private bool alarm;
        
        public event AlarmEventHandler Alarm;
        public event AfterAlarmEventHandler AfterAlarm;


        //  Default constructor
        public  Timer()
        {
            startTime = new System.DateTime();
            endTime = new System.DateTime();
            currentTime = new System.DateTime();
            diffTimeSpan = new System.TimeSpan();
            expire = false;
            alarm = false;
        }

        //  construct from an end time
        public  Timer(System.DateTime EndTime)
        {
            endTime = EndTime;
            startTime = System.DateTime.Now;
            currentTime = startTime;
            if (currentTime.CompareTo(endTime) < 0)
            {
                diffTimeSpan = endTime.Subtract(currentTime);
            }
            else
            {
                throw (new ApplicationException(
                    "The end time is earlier than current time."));
            }
            expire = false;
            alarm = false;
        }

        //  construct fomr a time span
        public  Timer(System.TimeSpan DiffTimeSpan)
        {
            diffTimeSpan = DiffTimeSpan;
            startTime = System.DateTime.Now;
            endTime = startTime.Add(diffTimeSpan);
            currentTime = System.DateTime.Now;
            expire = false;
            alarm = false;
        }

        public void update()
        {
            System.Threading.Thread.Sleep(1);
            currentTime = System.DateTime.Now;

            if ( expire == false)   //  Not expired
            {
                if (currentTime.CompareTo(endTime) <= 0) //  not expire
                {
                    diffTimeSpan = endTime.Subtract(currentTime);
                    if(diffTimeSpan.TotalMilliseconds < 100)    // Turn to expired
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
                else   // expire
                {
                    expire = true;
                    diffTimeSpan = currentTime.Subtract(endTime);
                    onAlarm();
                }
            }

            else // expired
            {
                diffTimeSpan = currentTime.Subtract(endTime);
                if(diffTimeSpan.TotalMilliseconds > 100)    //  not alarming
                {
                    onAfterAlarm();
                }
            }

            Console.WriteLine(alarm ? "!!!!!":" ");
            Console.WriteLine("Expired: {0}", expire.ToString());
            Console.WriteLine("{0} - {1} = {2}", 
                endTime, currentTime, diffTimeSpan.ToString());
        }

        public void onStart()
        {
            while (true)
            {
                update();
            }
        }

        private void onAlarm()
        {
            Console.WriteLine("Alarming !!!");
            this.Alarm(this, new EventArgs());   //发出警报
        }

        private void onAfterAlarm()
        {
            Console.WriteLine("after alarming");
            this.AfterAlarm(this, new EventArgs());
        }

    }
}
