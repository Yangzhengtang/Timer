using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static count_down_test_1.TimerOption;
using System.Runtime.InteropServices;

namespace count_down_test_1
{
    public partial class Form1 : Form
    {   
        private TimerDirection direction; //  Whether the timer grows to left or right
        private Timer timer;    //  The timer contained in this window.
        private bool old;   //  Whether the timer is loaded from dumpfile.
        private AlarmRise alarmRise;

        //  The properties sent from choose unit.
        //  Used to build new timer.
        private ChooseStyle ChooseStyle { get; set; }
        private TimerOption option { get; set; }
        private TimeSpan duration { get; set; }
        private DateTime targetTime { get; set; }
        private int count_limit { get; set; }

        //  Create a new one. Default constructor.
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(CloseWindowsReceicer);
            this.timer = null;
            this.old = false;
        }

        //  Create a niew one, overload.
        public Form1(System.TimeSpan OriginTimeSpan, TimerOption timeroption, int CountLimit)
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(CloseWindowsReceicer);
            this.timer = null;
            this.old = false;
            //  To build the timer.
            this.option = timeroption;
            this.duration = OriginTimeSpan;
            this.ChooseStyle = ChooseStyle.TimeSpan;
            this.count_limit = CountLimit;
        }

        //  Load an old one.
        public Form1(string path)
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(CloseWindowsReceicer);
            this.timer = TimerBuildSwitcher(path);
            this.old = true;
            this.register_receivers();
            this.timer.onUpdated();
        }

        //  register all the receivers of the timer 
        public void register_receivers()
        {           
            timer.Alarm += new Timer.AlarmEventHandler(AlarmReceiver);  
            timer.AfterAlarm += new Timer.AfterAlarmEventHandler(AfterAlarmReceiver);
            timer.End += new Timer.EndHandler(EndReceiver);
            timer.Update += new Timer.UpdateHandler(UpdateReceiver);
        }

        private void AlarmReceiver(object sender, EventArgs e)
        {
            Console.WriteLine("Just on alarm.");
            Action DoAction = delegate ()
            {
                textBox1.Clear();
                textBox1.AppendText("Alarming!");
                TopMost = true;  //Window jump to the top when alarming.
                this.alarmRise = new AlarmRise();
                this.alarmRise.Show();
                //System.Threading.Thread.Sleep(10);
                //textBox1.Clear();
            };
            if (this.InvokeRequired)
            {
                ControlExtensions.UIThreadInvoke(this, delegate
                {
                    DoAction();
                });
            }
            else
            {
                DoAction();
            }
        }

        private void AfterAlarmReceiver(object sender, EventArgs e)
        {
            Console.WriteLine("Just after alarm.");
            Action DoAction = delegate ()
            {
                if(this.alarmRise != null)
                {
                    this.alarmRise.Close();
                    //Thread t = new Thread(new ThreadStart(this.alarmRise.Close_in_5_secs));
                }
                else
                {
                    Console.WriteLine("WTF!");
                }
                textBox1.Clear();
            };

            if (this.InvokeRequired)
            {
                ControlExtensions.UIThreadInvoke(this, delegate
                {
                    DoAction();
                });
            }
            else
            {
                DoAction();
            }
        }

        private void EndReceiver(object sender, EventArgs e)
        {
            Console.WriteLine("Just end the timer.");
            Action DoAction = delegate ()
            {
                this.textBox1.Clear();
                this.textBox1.AppendText("Now the Timer is ended!");
            };


            if (this.InvokeRequired)
            {
                ControlExtensions.UIThreadInvoke(this, delegate
                {
                    DoAction();
                });
            }
            else
            {
                DoAction();
            }
        }

        private void UpdateReceiver(object sender, Timer.UpdateEventArgs e)
        {
            Console.WriteLine("Just Update the timer.");
            Action DoAction = delegate ()
            {
                this.displayer.Clear();

                switch (this.timer.timerOption)
                {
                    case TimerOption.Timing:
                        this.displayer.AppendText(e.Diff.ToString("hh':'mm':'ss'.'fff"));
                        break;
                    default:
                        if (e.Expire)
                        {
                            this.refreshProgressBar(0);
                        }
                        else
                        {
                            double percent = (e.Diff.TotalMilliseconds / e.Orig.TotalMilliseconds);
                            this.refreshProgressBar(percent);
                        }
                        //  this.displayer.AppendText(e.Expire ? "Expired: " : "Left: ");
                        this.displayer.AppendText(e.Diff.ToString("hh':'mm':'ss'.'fff"));
                        break;
                }
                /*
                this.textBox1.Clear();

                switch (this.timer.timerOption)
                {
                    case TimerOption.Timing:
                        this.textBox1.AppendText(e.Diff.ToString("g"));
                        break;
                    default:
                        if (e.Expire)
                        {
                             this.refreshProgressBar(0);
                        }
                        else
                        {
                            double percent = (e.Diff.TotalMilliseconds / e.Orig.TotalMilliseconds);
                            this.refreshProgressBar(percent);
                        }
                        //  this.textBox1.AppendText(e.Expire ? "Expired: " : "Left: ");
                        this.textBox1.AppendText(e.Diff.ToString("hh'小时'mm'分钟'ss'秒'fff'毫秒'"));
                        break;
                }   */
            };
            if (this.InvokeRequired)
            {
                ControlExtensions.UIThreadInvoke(this, delegate
                {
                    DoAction();
                });
            }
            else
            {
                DoAction();
            }
        }

        private void CloseWindowsReceicer(object sender, EventArgs e)
        {
            Console.WriteLine("\n\n\n");
            if (this.timer != null)
            {
                this.timer.onEnd();
            }
        }

        //  Start the timer, the ENTRANCE
        private void button1_Click(object sender, EventArgs e)
        {
            if( this.timer != null) 
            {
                Console.WriteLine("Warning! The timer already exists.");
                //  MessageBox.Show("Warning! The timer already exists.", "FBI WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.timer.reset();
            }
            else    // Create a timer and start running it.
            {  
                if(this.ChooseStyle == ChooseStyle.TimeSpan)
                {
                    this.timer = TimerBuildSwitcher(this.duration, this.option,this.count_limit);
                }
                //  初始化和开始没有分离，导致加载时可能无法显示界面

                //  Origin test code: 
                //System.TimeSpan span = new TimeSpan(0, 0, 10);
                //this.timer = new CycleCountTimer(span, CycleCount, 5);
                //this.timer = new CycleTimer(span, Cycle);
                //this.timer = new TimingTimer(span, Timing);
                //this.timer = new Timer(span, Normal);
                //Timer timer = new Timer("./TimerConfig.json");
                this.register_receivers();
                this.direction = TimerDirection.Right;                
                Thread t1 = new Thread(new ThreadStart(timer.onStart));
                t1.Start();
            }
        }

        //  Pause/Continue,check whether the timer is loaded first. 
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.old == true)
            {
                this.old = false;
                this.direction = TimerDirection.Right;
                Thread t1 = new Thread(new ThreadStart(timer.onStart));
                this.timer.onPauseResume();
                t1.Start();              
            }
            else
            {
                if (this.timer == null)
                {
                    Console.WriteLine("Warning! The timer is no runing.");
                    MessageBox.Show("Warning! The timer is no runing.", "FBI WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.timer.onPauseResume();
                }
            }
        }

        public void refreshProgressBar(double per)
        {
            per = (this.direction == TimerDirection.Left) ? per : (1 - per);
            if(per >= 0.75)
            {
                if (per >= 1)
                {
                    this.progressBar1.SetState(2);
                    per = 1;
                }
                else
                {
                    this.progressBar1.SetState(3);
                }
            }
            else
            {
                this.progressBar1.SetState(1);
            }

            if (per < 0)
            {
                per = 0;
            }

            this.progressBar1.Value = Convert.ToInt32(per * 100);
            this.progressBar1.Refresh();
        }

        //  A packed function to call before a timer is built.
        private static Timer TimerBuildSwitcher(string path)
        {
            TimerConfigure tc = new TimerConfigure(path);
            Timer T = null;
            switch (tc.timerOption)
            {
                case TimerOption.Normal:
                    T = new Timer(path);
                    break;
                case TimerOption.Cycle:
                    T = new CycleTimer(path);
                    break;
                case TimerOption.Timing:
                    T = new TimingTimer(path);
                    break;
                case TimerOption.CycleCount:
                    T = new CycleCountTimer(path);
                    break;
                default:
                    Console.WriteLine("Something wrong.");
                    //  MessageBox.Show("未选择计时器种类，使用默认计时器", "FBI WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    T = new Timer(path); //  Build a default timer.
                    break;
            }
            return T;
        }

        //  Overload
        private static Timer TimerBuildSwitcher(System.TimeSpan OriginTimeSpan, TimerOption timeroption,int cycle_limit=0)
        {
            Timer T = null;
            switch (timeroption)
            {
                case TimerOption.Normal:
                    T = new Timer(OriginTimeSpan, timeroption);
                    break;
                case TimerOption.Cycle:
                    T = new CycleTimer(OriginTimeSpan, timeroption);
                    break;
                case TimerOption.Timing:
                    //  This might go wrong.
                    T = new TimingTimer(OriginTimeSpan, timeroption);
                    break;
                case TimerOption.CycleCount:
                    //  Here need to be modified, the limit should be sent from UI.
                    T = new CycleCountTimer(OriginTimeSpan, timeroption, cycle_limit);
                    break;
                default:
                    Console.WriteLine("Something wrong.");
                    //  MessageBox.Show("未选择计时器种类，使用默认计时器", "FBI WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    T = new Timer(OriginTimeSpan, TimerOption.Normal); //  Build a default timer.
                    break;
            }
            return T;
        }

        /*   EMPTY！
         * 
         */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void displayer_TextChanged(object sender, EventArgs e)
        {

        }
    }

    //  Kit used to execute cross-thread function.
    //  https://www.cnblogs.com/zhangguihua/p/9989376.html
    static class ControlExtensions
    {
        /// <summary>
        /// 同步执行 注：外层Try Catch语句不能捕获Code委托中的错误
        /// </summary>
        static public void UIThreadInvoke(this Control control, Action Code)
        {
            try
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(Code);
                    return;
                }
                Code.Invoke();
            }
            catch
            {
                /*仅捕获、不处理！*/
            }
        }

        /// <summary>
        /// 异步执行 注：外层Try Catch语句不能捕获Code委托中的错误
        /// </summary>
        static public void UIThreadBeginInvoke(this Control control, Action Code)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(Code);
                return;
            }
            Code.Invoke();
        }
    }

    //  ProgressBar beautify.
    //  https://stackoverflow.com/questions/778678/how-to-change-the-color-of-progressbar-in-c-sharp-net-3-5
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
