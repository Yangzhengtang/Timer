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
using static MultiTimer.TimerOption;
using System.Runtime.InteropServices;

namespace MultiTimer
{
    public partial class TimerForm : Form
    {   
        //  UI Properties
        private TimerDirection direction;       //  Whether the timer grows to left or right
        private bool old;                       //  Whether the timer is loaded from dumpfile and run.
        private string alarmWords;              //  The words to show when alarming.
        private ThemeColors themeColors;        //  The color sets of the UI, which is controlled by theme.
        private Theme theme = Theme.Default;    //  The theme of the UI, controls the themeColor.

        //  Alarm form properties
        private AlarmOffStyle alarmOffStyle = AlarmOffStyle.Auto;       //  The style of closing the alarm form.
        private SoundConfigure soundconfigure=new SoundConfigure();     //  control the alarm 
        private int SoundPointer = 0;                                   //  Used to decide the sound file
        private AlarmRiseForm alarmRise;

        //  The properties sent from Timer choose form, used to build new timer.
        private ChooseStyle ChooseStyle { get; set; }
        private TimerOption option { get; set; }
        private TimeSpan duration { get; set; }
        private DateTime targetTime { get; set; }
        private int count_limit { get; set; }

        private Timer timer;                //  The timer contained in this window.

        //  Create a new one. Default constructor.
        public TimerForm()
        {
            this.themeColors = new ThemeColors();
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(CloseWindowsReceicer);
            this.timer = null;
            this.old = false;
            this.refreshProgressBar(1); //  For User Experience
            this.displayer.AppendText("00:00:00.000");
            this.button1.Text = "Start";
            this.soundconfigure.load();
        }

        //  Create a niew one, overload.
        public TimerForm(System.TimeSpan OriginTimeSpan, TimerOption timeroption, int CountLimit)
        {
            this.themeColors = new ThemeColors();
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(CloseWindowsReceicer);
            this.timer = null;
            this.old = false;
            //  To build the timer.
            this.option = timeroption;
            this.duration = OriginTimeSpan;
            this.ChooseStyle = ChooseStyle.TimeSpan;
            this.count_limit = CountLimit;
            this.refreshProgressBar(1); //  For User Experience
            this.displayer.AppendText(OriginTimeSpan.ToString("hh':'mm':'ss'.'fff"));
            this.button1.Text = "Start";
            this.soundconfigure.load();
        }

        //  Load an old one.
        public TimerForm(string path)
        {
            this.themeColors = new ThemeColors();
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(CloseWindowsReceicer);
            this.timer = TimerBuildSwitcher(path);
            this.old = true;
            this.register_receivers();
            this.timer.onUpdated();
            this.button1.Text = "Reset";
            this.button2.Text = "Resume";
            this.soundconfigure.load();
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
                this.TopMost = true;  //Window jump to the top when alarming.
                this.Show();
                this.alarmRise = new AlarmRiseForm(this.SoundPointer);//hope to save the SoundPointer in .json when chosen in the ContextMenuStrip1 in the future
                this.alarmRise.Show();
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
                if(this.alarmOffStyle == AlarmOffStyle.Auto)
                {
                    if (this.alarmRise != null)
                    {
                        this.alarmRise.Close();
                    }
                    else
                    {
                        Console.WriteLine("WTF!");
                    }
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

        //  Start
        private void button1_Click(object sender, EventArgs e)
        {
            if( this.timer != null)     //  The "Reset" button is pressed.
            {
                Console.WriteLine("The timer already exists.\n Now we are restarting it.");
                if(this.old == true)    //  If it's a new timer, it's not running yet.
                                        //  In this case, we should reset and restart.
                {
                    this.old = false;
                    this.timer.reset();
                    Thread t1 = new Thread(new ThreadStart(timer.onStart));
                    t1.Start();
                }
                else    //  Otherwise, we shall just reset it.
                {
                    this.timer.reset();
                }
                this.button2.Text = "Pause";    //  Once it's reset, the resume/pause button should also be reset.
            }
            else    //  The "Start" button is pressed
            {       //  Create a timer and start running it.
                Console.WriteLine("Now we are starting a new timer.");
                this.button1.Text = "Reset";
                this.button2.Text = "Pause";
                if (this.ChooseStyle == ChooseStyle.TimeSpan)
                {
                    this.timer = TimerBuildSwitcher(this.duration, this.option,this.count_limit);
                }
                //  初始化和开始没有分离，导致加载时可能无法显示界面(Fixed)

                /// <summary>   The origin test code
                /// System.TimeSpan span = new TimeSpan(0, 0, 10);
                /// this.timer = new CycleCountTimer(span, CycleCount, 5);
                /// this.timer = new CycleTimer(span, Cycle);
                /// this.timer = new TimingTimer(span, Timing);
                /// this.timer = new Timer(span, Normal);
                /// Timer timer = new Timer("./TimerConfig.json");
                /// </summary>

                this.register_receivers();
                this.direction = TimerDirection.Right;               
                Thread t1 = new Thread(new ThreadStart(timer.onStart));
                t1.Start();
            }
        }

        //  Pause/Resume
        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text == "Pause")
            {
                button2.Text = "Resume";
            }
            else
            {
                button2.Text = "Pause";
            }
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
                    Console.WriteLine("Warning! The timer is not runing.");
                    MessageBox.Show("Warning! The timer is not runing.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.timer.onPauseResume();
                }
            }
        }

        /// <summary>
        /// Show the percentage of the time gone.
        /// </summary>
        /// <param name="per"></param>
        public void refreshProgressBar(double per)
        {
            per = per < 0 ? 0 : per;
            per = per > 1 ? 1 : per;
            this.refreshTheme(per);

            ProgressBack.BackColor = this.themeColors.backColor;
            if(per <= 0.25)
            {
                if (per <= 0)
                {
                    ProgressFront.BackColor = this.themeColors.expireColor;
                    per = 0;
                }
                else
                {
                    ProgressFront.BackColor = this.themeColors.warnColar;
                }
            }
            else
            {
                ProgressFront.BackColor = this.themeColors.runColor;
            }

            if (per >= 1)
            {
                per = 1;
            }
            per = (this.direction == TimerDirection.Left) ? per : (1 - per);

            ProgressFront.Width = (int)(ProgressBack.Width * per);
            ProgressFront.Refresh();
            ProgressBack.Refresh();
        }

        //  A packed function to call before a timer is built.
        //  这里的switchbuilder有很大的问题，类的特性表现的比较差。应该改为Timer中统一的接口来处理。
        private static Timer TimerBuildSwitcher(string path)
        {
            TimerConfigure tc = new TimerConfigure(path);   //  The timer configure to build from
            Timer T = null; //  The timer to build
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
                case TimerOption.Interval:
                    T = new IntervalCycleTimer(path);
                    break;
                default:
                    Console.WriteLine("Timer type not chosen, it's set to default now.");
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
                    //  Fixed
                    T = new CycleCountTimer(OriginTimeSpan, timeroption, cycle_limit);
                    break;
                case TimerOption.Interval:
                    T = new IntervalCycleTimer(OriginTimeSpan, timeroption, cycle_limit);
                    break;
                default:
                    Console.WriteLine("Timer type not chosen, it's set to default now.");
                    T = new Timer(OriginTimeSpan, TimerOption.Normal); //  Build a default timer.
                    break;
            }
            return T;
        }

        /// <summary>
        ///     Refresh the theme, which is set in UI when left-clicked.
        ///     This method should be called before refresh progress bar.
        ///     This takes the percentage the time gone since some of the theme color 
        ///     might be decided by the percentage.(Like Gay theme)
        /// </summary>
        /// <param name="per"></param>
        public void refreshTheme(double per)
        {
            switch (this.theme)
            {
                case Theme.Default:
                    this.themeColors.backColor = Color.White;
                    this.themeColors.runColor = Color.Green;
                    this.themeColors.warnColar = Color.Yellow;
                    this.themeColors.expireColor = Color.Red;
                    break;
                case Theme.BlackAndWhile:
                    this.themeColors.backColor = Color.Black;
                    this.themeColors.runColor = Color.White;
                    this.themeColors.warnColar = Color.Red;
                    this.themeColors.expireColor = Color.Black;
                    break;
                case Theme.Gay:
                    System.Random rnd = new Random();
                    this.themeColors.backColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    this.themeColors.runColor = Color.FromArgb((int)(255*per), 255, 255);
                    this.themeColors.warnColar = Color.FromArgb((int)(255*per), 255, 255);
                    this.themeColors.expireColor = Color.FromArgb((int)(255*per), 255, 255);
                    break;
                default:
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.alarmWords = textBox2.Text;
        }

        private void autooffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.alarmOffStyle = AlarmOffStyle.Auto;
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.alarmOffStyle = AlarmOffStyle.Manual;
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.direction = TimerDirection.Left;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.direction = TimerDirection.Right;
        }

        private void blackWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.theme = Theme.BlackAndWhile;
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.theme = Theme.Default;
        }

        private void gayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.theme = Theme.Gay;
        }

        private void beepToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  this.soundconfigure.load();
          //  this.soundconfigure.init();
          //  this.soundconfigure.dump();
          // this.soundconfigure.load();
            this.soundconfigure.ChangePointer(0);
            this.SoundPointer = 0;
            this.soundconfigure.dump();
            Console.WriteLine(soundconfigure.DefaultSoundPath);
        }

        private void didiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // this.soundconfigure.load();
            this.soundconfigure.ChangePointer(1);
            this.soundconfigure.dump();
            this.SoundPointer = 1;
            Console.WriteLine(soundconfigure.DefaultSoundPath);
        }

        private void joyToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  this.soundconfigure.load();
            this.soundconfigure.ChangePointer(2);
            this.soundconfigure.dump();
            this.SoundPointer = 2;
            Console.WriteLine(soundconfigure.DefaultSoundPath);
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
