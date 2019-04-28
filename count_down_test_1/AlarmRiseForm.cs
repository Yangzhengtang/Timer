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
        private Sound sound = new Sound();  //Use sound to get the path of a certain musci and play/stop/close it
        SoundConfigure soundconfigure = new SoundConfigure();//Manager the list of sound path and the default sound path

        public AlarmRiseForm(string showWords="Time is up!")
        {
            InitializeComponent();
            TopMost = true;
        }
        public AlarmRiseForm(int SoundPointer)
        {
            InitializeComponent();
            soundconfigure.load(); //load the configure from ....json
            soundconfigure.ChangePointer(SoundPointer); //SoundPointer is passed from TimerFrom's ContextMenuStrip1
            TopMost = true;//hope to save the SoundPointer in .json when chosen in the ContextMenuStrip1 in the future
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.sound.mciStop();
            this.sound.mciClose();//stop and close the music. If not closed, the path of music can't change, and you will play this music forever. 
            Close();//close the form  
        }

        private void AlarmRise_FormClosing(object sender, FormClosingEventArgs e)//close the current playing music when closing the window
        {
            this.sound.mciStop();
            this.sound.mciClose();
        }

        private void AlarmRise_Shown(object sender, System.EventArgs e)
        {
            TopMost = true;
            Application.DoEvents(); //to avoid block the main thread
            this.sound.ChangePath(System.Environment.CurrentDirectory + "\\" +
                   soundconfigure.SoundPathList[soundconfigure.DefaultSoundPointer]); //set path of sound
            Console.WriteLine(soundconfigure.SoundPathList[soundconfigure.DefaultSoundPointer]);
            this.sound.mciPlay();//play music
            for (; ; )   //shake the window
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
