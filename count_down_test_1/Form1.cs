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

namespace count_down_test_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.TimeSpan span = new TimeSpan(0, 0, 5);
            Timer timer = new Timer(span);
            timer.Alarm += new Timer.AlarmEventHandler(AlarmReceiver);  //  register the receiver
            timer.AfterAlarm += new Timer.AfterAlarmEventHandler(AfterAlarmReceiver);
            Thread t1 = new Thread(new ThreadStart(timer.onStart));
            t1.Start();
        }

        private void AlarmReceiver(object sender, EventArgs e)
        {
            Console.WriteLine("Get the alarm");
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
            Console.WriteLine("Get the alarm");
            Action DoAction = delegate ()
            {
                textBox1.Clear();
                //textBox1.AppendText("Not Alarming!");
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
