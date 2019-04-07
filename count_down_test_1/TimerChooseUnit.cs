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
        private TimeSpan duration;
        private DateTime targetTime;
        private DateTime tempDateTime;  //  A var to calculate the duration. 
        private bool choseStyle;    //  The different choose style.
        public delegate void ChosenEventHandler(object sender, ChosenEventArgs e);
        public event ChosenEventHandler Chosen;

        public TimerChooseUnit()
        {
            InitializeComponent();
            this.duration = DateTime.Now.Subtract(DateTime.Now);    //  Clear the duration
            this.tempDateTime = DateTime.Now;   //  Give an initial temp time.
        }

        private void TimerChooseUnit_Load(object sender, EventArgs e)
        {

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
            this.tempDateTime = this.tempDateTime.AddHours(Convert.ToDouble(HourBox.Text));
            this.tempDateTime = this.tempDateTime.AddMinutes(Convert.ToDouble(MinBox.Text));
            this.tempDateTime = this.tempDateTime.AddSeconds(Convert.ToDouble(SecBox.Text));
            this.choseStyle = true;
            this.OnChosen();
        }

        public void OnChosen()
        {
            ChosenEventArgs args = new ChosenEventArgs();
            args.choseStyle = this.choseStyle;
            args.option = this.option;
            args.targetTime = this.targetTime;
            args.duration = this.duration;
            this.Chosen(this, args);
        }

        public class ChosenEventArgs : EventArgs
        {
            public bool choseStyle { get; set; }
            public TimerOption option { get; set; }
            public TimeSpan duration { get; set; }
            public DateTime targetTime { get; set; }
        }
    }
}
