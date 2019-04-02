﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using static count_down_test_1.TimerOption;

namespace count_down_test_1
{
    class Timer
   //   Timer class
    {
        //  Delegations
        public delegate void AlarmEventHandler(object sender, EventArgs e);
        public delegate void AfterAlarmEventHandler(object sender, EventArgs e);
        public delegate void EndHandler(object sender, EventArgs e);

        //  Events
        public event AlarmEventHandler Alarm;
        public event AfterAlarmEventHandler AfterAlarm;
        public event EndHandler End;

        //  Properties
        protected string configPath = "./TimerConfig.json";
        protected Newtonsoft.Json.JsonObjectAttribute config;
        protected System.DateTime startTime;
        protected System.DateTime endTime;
        protected System.DateTime currentTime;
        protected System.TimeSpan diffTimeSpan;
        protected System.TimeSpan originTimeSpan;
        protected bool expire;
        protected bool alarm;
        protected bool endSig;    //  Sigal sent from UI
        protected TimerOption timerOption;
        protected TimerConfigure timerConfigure;
        
        
        //  Default constructor
        public  Timer()
        {
            startTime = new System.DateTime();
            endTime = new System.DateTime();
            currentTime = new System.DateTime();
            originTimeSpan = new System.TimeSpan();
            diffTimeSpan = new System.TimeSpan();
            expire = false;
            alarm = false;
            endSig = false;
            timerOption = Normal;
        }
        

        //  construct from an end time
        public  Timer(System.DateTime EndTime)
        {
            endTime = EndTime;
            startTime = System.DateTime.Now;
            currentTime = startTime;
            if (currentTime.CompareTo(endTime) < 0)
            {
                originTimeSpan= endTime.Subtract(currentTime);
            }
            else
            {
                throw (new ApplicationException(
                    "The end time is earlier than current time."));
            }
            diffTimeSpan = originTimeSpan;
            expire = false;
            alarm = false;
            endSig = false;
        }

        //  construct fomr a time span
        public  Timer(System.TimeSpan OriginTimeSpan, TimerOption timeroption)
        {
            originTimeSpan = OriginTimeSpan;
            diffTimeSpan = originTimeSpan;
            startTime = System.DateTime.Now;
            endTime = startTime.Add(diffTimeSpan);
            currentTime = System.DateTime.Now;
            expire = false;
            alarm = false;
            endSig = false;
            timerOption = timeroption;
        }

        //  Dump this Timer to a configure file (json)
        public void dumpConfig(string path = null)
        {
            Console.WriteLine("dumping");
            if (path == null)
            {
                path = configPath;
            }
            string json = JsonConvert.SerializeObject(this);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(json);
                Console.WriteLine("Dump done");
            }
        }

        protected virtual void update()
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

            Console.WriteLine("{0} - {1} = {2}, Alarm: {3}", 
                endTime, currentTime, diffTimeSpan.ToString(),
                (alarm ? "Yes" : "No"));
        }

        public void onStart()
        {
            while (true)
            {
                update();
                if (endSig)
                {
                    Console.WriteLine("The timer's ended.");
                    break;
                }
            }
        }

        public void onAlarm()
        {
            Console.WriteLine("Alarming !!!");
            this.Alarm(this, new EventArgs());   //send Alarming event
            this.dumpConfig();
        }

        public void onAfterAlarm()
        {
            Console.WriteLine("after alarming");
            this.AfterAlarm(this, new EventArgs());
        }

        public void onEnd()
        {
            Console.WriteLine("Now ending");
            endSig = true;
            this.End(this, new EventArgs());
        }
    }
}
