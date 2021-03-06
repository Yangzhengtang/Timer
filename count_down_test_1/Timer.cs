﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using static MultiTimer.TimerOption;

namespace MultiTimer
{
    class Timer
   //   Timer class
    {
        //  Delegations
        public delegate void AlarmEventHandler(object sender, EventArgs e);
        public delegate void AfterAlarmEventHandler(object sender, EventArgs e);
        public delegate void EndHandler(object sender, EventArgs e);
        public delegate void UpdateHandler(object sender, UpdateEventArgs e);

        //  Events
        public event AlarmEventHandler Alarm;
        public event AfterAlarmEventHandler AfterAlarm;
        public event EndHandler End;
        public event UpdateHandler Update;

        //  Properties
        //  protected string configPath = "./TimerConfig.json";
        protected System.DateTime startTime;
        protected System.DateTime endTime;
        protected System.DateTime currentTime;
        protected System.DateTime pauseTime;

        protected System.TimeSpan diffTimeSpan;     //  (currenttime - starttime)
        protected System.TimeSpan originTimeSpan;   //  The origin duration

        protected bool expire;      //  Whether the timer is expired
        protected bool alarm;       //  Whether the timer is alarming
        protected bool pause;       //  Whether the timer is pausd
        protected bool endSig;      //  End sigal sent from UI
        public TimerOption timerOption;
        protected TimerConfigure timerConfigure;
        
        
        //  Constructor: read cofigure from json file and build 
        public  Timer(string path="./TimerConfig.json")
        {
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
                Console.WriteLine("Read configure done\n Now building the timer...");
                this.timerConfigure = JsonConvert.DeserializeObject<TimerConfigure>(json);
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
            }
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
            pause = false;
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
            pause = false;
            timerOption = timeroption;
        }

        //  Dump this Timer to a configure file (json)
        public virtual void dumpConfig(string path = "./TimerConfig.json")
        {
            Console.WriteLine("dumping");

            this.timerConfigure = new TimerConfigure(this.startTime,
                                                     this.endTime,
                                                     this.currentTime,
                                                     System.DateTime.Now,
                                                     this.diffTimeSpan,
                                                     this.originTimeSpan,
                                                     this.expire,
                                                     this.alarm,
                                                     this.endSig,
                                                     this.pause,
                                                     this.timerOption);
            this.timerConfigure.dump(path);
            /*
            string json = JsonConvert.SerializeObject(this.timerConfigure);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(json);
                Console.WriteLine("Dump done");
            }   */
        }

        //  Update the information of the timer
        //  !!!!!!!!!!!!!!!!!!!!!!!! The timer duration is decided by the end time and current time !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        protected virtual void update()
        {
            System.Threading.Thread.Sleep(20);
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
                if(diffTimeSpan.TotalMilliseconds > 3000)    // Stop alarming
                {
                    if (this.alarm)
                    {
                        this.alarm = false;
                        onAfterAlarm();
                    }
                }
            }

            // Send the update event.
            if (this.pause == false)    //  There is a bug in the onUpdate thread... 
            {
                this.onUpdated();
            }

            Console.WriteLine("{0} - {1} = {2}, Alarm: {3}", 
                endTime, currentTime, diffTimeSpan.ToString(),
                (alarm ? "Yes" : "No"));    
        }

        public virtual void reset()
        {
            startTime = System.DateTime.Now;
            endTime = startTime.Add(originTimeSpan);
            expire = false;
            endSig = false;
            pause = false;
            pauseTime = System.DateTime.Now;
            diffTimeSpan = originTimeSpan;
            this.onUpdated();
        }

        /*  The update will be overridden in other class, 
            so the update event should be done in this seperated method.
            This method is to notify the UI and send the information.
        */
        public void onUpdated()  
        {
            UpdateEventArgs args = new UpdateEventArgs();
                args.Diff = this.diffTimeSpan;
                args.Orig = this.originTimeSpan;
                args.Expire = this.expire;
                args.Alarm = this.alarm;
                args.Pause = this.pause;
                args.End = this.endSig;
            this.Update(this, args);
        }

        //  Activate the timer.
        public void onStart()
        {
            while (true)
            {
                if(pause == false)
                {
                    update();
                }
         
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
        }

        //  After the alarm is expired.
        public void onAfterAlarm()
        {
            Console.WriteLine("after alarming");
            this.AfterAlarm(this, new EventArgs());
        }

        //  When a timer is ended.
        public void onEnd()
        {
            Console.WriteLine("Now ending");
            this.endSig = true;
            this.pause = true;
            this.dumpConfig();  //  When closing a timer, dump the configure file.
            this.End(this, new EventArgs());
        }

        //  Pause or resume
        public virtual void onPauseResume() 
        {
            if (pause == false)
            {
                Console.WriteLine("Now pausing...");
                this.pause = true;
                this.pauseTime = this.currentTime;
            }
            else
            {
                Console.WriteLine("Now resuming...");
                this.pause = false;
                this.currentTime = System.DateTime.Now;
                System.TimeSpan pauseDuration = this.currentTime.Subtract(this.pauseTime);

                switch (this.timerOption)
                //  Reset the end time or not, according to the type of timer.
                // Default: the timer countdown according to the given duration, not the deadline.
                {
                    case TimerOption.Normal:
                        this.endTime = endTime.Add(pauseDuration);  //  Defer the end time as it was stopped for [pauseDuration].
                        Console.WriteLine("Resumed, the endtime was reset.");
                        break;
                    case TimerOption.Cycle:
                        this.endTime = endTime.Add(pauseDuration);  //  Defer the end time as it was stopped for [pauseDuration].
                        Console.WriteLine("Resumed, the endtime was reset.");
                        break;
                    case TimerOption.Timing:
                        this.startTime = startTime.Add(pauseDuration);  //  Defer the start time.
                        Console.WriteLine("Resumed, the starttime wasnreset.");
                        break;
                    default:
                        break;
                }
            }
            this.onUpdated();
        }

        //  This class is used to communicate with UI.
        public class UpdateEventArgs : EventArgs
        {
            public System.TimeSpan Diff { get; set; }
            public System.TimeSpan Orig { get; set; }
            public bool Expire  { get; set; }
            public bool Alarm   { get; set; }
            public bool Pause   { get; set; }
            public bool End     { get; set; }
        }
    }
}
