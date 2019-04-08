using System;
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
    public partial class AlarmRise : Form
    {
        private Sound sound = new Sound();
        // to be replaced by SoundManager

        public AlarmRise()
        {
            InitializeComponent();
            //string PathOfSound;
            TopMost = true;
            this.sound.mciPlay();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.sound.mciStop();
            Close();//close the form
        }

        private void AlarmRise_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.sound.mciStop();
        }
    }
}
