﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace count_down_test_1
{
    public partial class TimerChooseUnit : Form
    {
        private TimerOption option;
        private int Cycle_limit;    //  The property of the Cycle count timer.
        private TimeSpan duration;
        private DateTime targetTime;
        private DateTime tempDateTime_0;  //  A var to calculate the duration.
        private DateTime tempDateTime_1;  //  A var to calculate the duration.
        private ChooseStyle chooseStyle;    //  The different choose style.
        public delegate void ChosenEventHandler(object sender, ChosenEventArgs e);
        public event ChosenEventHandler Chosen;

        public TimerChooseUnit()
        {
            InitializeComponent();
            this.duration = DateTime.Now.Subtract(DateTime.Now);    //  Clear the duration
            this.tempDateTime_0 = DateTime.Now;   //  Give an initial temp time.
            this.tempDateTime_1 = this.tempDateTime_0;
        }

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

        private void HourBox_TextChanged(object sender, EventArgs e)
        {
            //this.tempDateTime.AddHours(Convert.ToInt32(HourBox.Text));            
        }

        private void MinBox_TextChanged(object sender, EventArgs e)
        {
            //this.tempDateTime.AddMinutes(Convert.ToInt32(MinBox.Text));
        }

        private void SecBox_TextChanged(object sender, EventArgs e)
        {
            //this.tempDateTime.AddSeconds(Convert.ToInt32(SecBox.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chooseStyle = ChooseStyle.TimeSpan;
            try
            {
                this.tempDateTime_1 = this.tempDateTime_1.AddHours(Convert.ToDouble(HourBox.Text));
                this.tempDateTime_1 = this.tempDateTime_1.AddMinutes(Convert.ToDouble(MinBox.Text));
                this.tempDateTime_1 = this.tempDateTime_1.AddSeconds(Convert.ToDouble(SecBox.Text));
                if(this.option == TimerOption.CycleCount) {this.Cycle_limit = Convert.ToInt32(CountBox.Text);}
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
                this.duration = new System.TimeSpan(0);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TimerChooseUnit_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
