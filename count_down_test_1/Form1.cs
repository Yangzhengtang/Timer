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
            Thread t1 = new Thread(new ThreadStart(timer.onStart));
            t1.Start();
        }

        private void AlarmReceiver(object sender, EventArgs e)
        {
            Console.WriteLine("Get the alarm");
            textBox1.Clear();
            textBox1.AppendText("Alarming!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
