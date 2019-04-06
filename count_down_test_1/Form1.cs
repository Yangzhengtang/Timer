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

namespace count_down_test_1
{
    public partial class Form1 : Form
    {
        private TimerDirection direction; //  Whether the timer grows to left or right
        private Timer timer;    //  The timer contained in this window.

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(CloseWindowsReceicer);
            this.timer = null;
        }

        public void register_receivers()
        {
            //  register all the receivers of the timer 
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
                
                this.textBox1.Clear();
                this.textBox1.AppendText(e.Pause ? "Paused " : "Running ");

                switch (this.timer.timerOption)
                {
                    case TimerOption.Timing:
                        this.textBox1.AppendText("Passed:" + e.Diff.ToString());
                        break;
                    default:
                        double percent = (e.Diff.TotalMilliseconds / e.Orig.TotalMilliseconds);
                        this.textBox1.AppendText(e.Expire ? "Expired: " : "Left: ");
                        this.textBox1.AppendText(percent.ToString());
                        this.refreshProgressBar(percent);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CloseWindowsReceicer(object sender, EventArgs e)
        {
            Console.WriteLine("/n/n/n/n/n/n/n/n/n");
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
                MessageBox.Show("Warning! The timer already exists.", "FBI WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else    // Create a timer and start running it.
            {  
                System.TimeSpan span = new TimeSpan(0, 5, 10);
                this.timer = new CycleTimer(span, Cycle);
                //this.timer = new TimingTimer(span, Timing);
                //this.timer = new Timer(span, Normal);
                //Timer timer = new Timer("./TimerConfig.json");
                this.direction = TimerDirection.Right;    
                this.register_receivers();

                Thread t1 = new Thread(new ThreadStart(timer.onStart));
                t1.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.timer == null)
            {
                Console.WriteLine("Warning! The timer is no runing.");
                MessageBox.Show("Warning! The timer is no runing.", "FBI WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                this.timer.onPauseResume();
            }          
        }

        private void refreshProgressBar(double per)
        {
            per = (this.direction == TimerDirection.Left) ? per : (1 - per);
            if (per > 1)
            {
                per = 1;
            }
            if (per < 0)
            {
                per = 0;
            }
            this.progressBar1.Value = Convert.ToInt32(per * 100);
        }

    }

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
}
