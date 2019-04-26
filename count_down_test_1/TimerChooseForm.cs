using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiTimer
{
    public partial class TimerChooseForm : Form
    {
        private TimerOption option;
        private int Cycle_limit;            //  The property of the Cycle count timer.
        private TimeSpan duration;          //  The timer duration
        private DateTime targetTime;        //  TO DO: build a timer from the target time given by user.
        private DateTime tempDateTime_0;    //  A temp var to calculate the duration.
        private DateTime tempDateTime_1;    //  A temp var to calculate the duration.
        private ChooseStyle chooseStyle;    //  The different choose style( Target time or Duration).
        public delegate void ChosenEventHandler(object sender, ChosenEventArgs e);
        public event ChosenEventHandler Chosen;

        public TimerChooseForm()
        {
            InitializeComponent();
            this.duration = DateTime.Now.Subtract(DateTime.Now);    //  Clear the duration
            this.tempDateTime_0 = DateTime.Now;   //  Give an initial temp time.
        }

        /// <summary>
        /// Default timer is initalized to show 00:03:00
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerChooseUnit_Load(object sender, EventArgs e)
        {
            this.HourBox.Text = "0";
            this.MinBox.Text = "3";
            this.SecBox.Text = "0";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.option = (TimerOption)(comboBox1.SelectedIndex + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.chooseStyle = ChooseStyle.TimeSpan;   
            try
            {
                this.tempDateTime_1 = this.tempDateTime_0;
                this.tempDateTime_1 = this.tempDateTime_1.AddHours(Convert.ToDouble(HourBox.Text));
                this.tempDateTime_1 = this.tempDateTime_1.AddMinutes(Convert.ToDouble(MinBox.Text));
                this.tempDateTime_1 = this.tempDateTime_1.AddSeconds(Convert.ToDouble(SecBox.Text));
                if(this.option == TimerOption.CycleCount || this.option == TimerOption.Interval)
                { this.Cycle_limit = Convert.ToInt32(CountBox.Text);}
                else { this.Cycle_limit = 0; }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Warning! Haven't input the duration yet.");
                MessageBox.Show("请输入正确格式", "FBI WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.duration = this.tempDateTime_1.Subtract(this.tempDateTime_0);
            if (this.option == TimerOption.Timing)
            {
                this.duration = new System.TimeSpan(0); //  If it is a timing timer, the duration should be cleared.
            }
            this.OnChosen();
        }

        public void OnChosen()
        {
            ChosenEventArgs args = new ChosenEventArgs();
            args.chooseStyle = this.chooseStyle;
            args.option = this.option;
            args.targetTime = this.targetTime;
            args.duration = this.duration;
            args.cycle_limit = this.Cycle_limit;
            this.Chosen(this, args);
        }

        public class ChosenEventArgs : EventArgs
        {
            public int cycle_limit { get; set; }
            public ChooseStyle chooseStyle { get; set; }
            public TimerOption option { get; set; }
            public TimeSpan duration { get; set; }
            public DateTime targetTime { get; set; }
        }
    }
}
