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
    public partial class AlarmRiseForm : Form
    {
        private Sound sound = new Sound();
        // to be replaced by SoundManager
        SoundConfigure soundconfigure = new SoundConfigure();

        public AlarmRiseForm(string showWords="Time is up!")
        {
            InitializeComponent();
            //this.label1.Text = showWords;
            TopMost = true;
        }
        public AlarmRiseForm(int SoundPointer)
        {
            InitializeComponent();
            soundconfigure.load();
            soundconfigure.ChangePointer(SoundPointer);
            //this.label1.Text = showWords;
            TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.sound.mciStop();
            this.sound.mciClose();
            Close();//close the form
        }

        private void AlarmRise_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.sound.mciStop();
            this.sound.mciClose();
        }

        private void AlarmRise_Shown(object sender, System.EventArgs e)
        {
            TopMost = true;
            Application.DoEvents();
            //SoundConfigure soundconfigure = new SoundConfigure();
            this.sound.ChangePath(soundconfigure.SoundPathList[soundconfigure.DefaultSoundPointer]);
            Console.WriteLine(soundconfigure.SoundPathList[soundconfigure.DefaultSoundPointer]);
            this.sound.mciPlay();
            //System.Threading.Thread.Sleep(1000);
            //this.sound.mciStop();
            //this.sound.mciClose();
            //System.Threading.Thread.Sleep(1000);
            //Application.DoEvents(); //thread窗口无法显示
            //SoundConfigure soundConfigure = new SoundConfigure();
            //soundConfigure.load();
            //soundConfigure.dump();
            //sound.ChangePath(soundConfigure.DefaultSoundPath);
            //Console.WriteLine(soundConfigure.DefaultSoundPath);
            //Console.WriteLine(sound.SoundPath);
            //sound.mciPlay(sound.SoundPath);
            for (; ; )
            {
                int shake = 5;
                int sleep_time = 15;
                this.Left += shake;
                System.Threading.Thread.Sleep(sleep_time);
                this.Top += shake;
                System.Threading.Thread.Sleep(sleep_time);
                this.Left -= shake;
                System.Threading.Thread.Sleep(sleep_time);
                this.Top -= shake;
                System.Threading.Thread.Sleep(sleep_time);
                Application.DoEvents();
            }
        }
    }
}
