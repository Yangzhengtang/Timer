﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MultiTimer
{
    public partial class TimerManager : Form
    {
        public TimerManager()
        {
            InitializeComponent();
        }

        private TimerChooseForm TCF;
        private List<Timer> TimerList;
        private List<string> ConfigurePathList;
        private int index;
        //  private static string SettingPath;
        //  private TimerManagerSetting setting;

        //  Initialize here.
        private void TimerManager_Load(object sender, EventArgs e)
        {
            this.index = 1;
            this.TimerList = new List<Timer>();
            this.ConfigurePathList = new List<string>();
            DirectoryInfo TheFolder = new DirectoryInfo("./");
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                if( (NextFile.Name.IndexOf("TimerConfig")>-1)&& (NextFile.Extension.Equals(".json")) ){
                    this.ConfigurePathList.Add(NextFile.FullName);
                    this.index += 1;
                }
            }
            this.TCF = null;
                
        }

        //  Construct a new ChooseUnit.
        private void createButton_Click(object sender, EventArgs e)
        {
            if(this.TCF != null)    //  There's already a choose unit open from this manager. Stop it.
            {
                Console.WriteLine("Warning! Already started a choose unit.");
                MessageBox.Show("请通过选项界面输入", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else    //  Otherwise, start a new choose unit.
            {
                this.TCF = new TimerChooseForm();
                this.TCF.Show();
                this.TCF.Chosen += new TimerChooseForm.ChosenEventHandler(ChosenReceiver);
                this.TCF.FormClosed += new FormClosedEventHandler(ClosedEventReceiver);
            }
        }
        
        //  Load and Construct
        private void loadButton_Click(object sender, EventArgs e)
        {
            foreach(string configpath in ConfigurePathList)
            {
                TimerForm f = new TimerForm(configpath);
                f.Show();
            }
        }

        //  Run when the choose unit is closed.
        private void ClosedEventReceiver(object sender, FormClosedEventArgs e)
        {
            Action DoAction = delegate ()
            {
                if (this.TCF != null)
                {
                    this.TCF = null;                  
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

        //  Receive the event when start a timer in the TimerChooseForm UI logic.
        private void ChosenReceiver(object sender, TimerChooseForm.ChosenEventArgs e)
        {
            Console.WriteLine("Just Selected and started the timer.");
            Action DoAction = delegate ()
            {
                TimerForm f = new TimerForm(e.duration, e.option, e.cycle_limit);
                f.Show();
                this.TCF.Close();
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

        //  https://blog.csdn.net/Eastmount/article/details/18604721 
        //  When closed by user, this main window will stay in the system tray.
        private void TimerManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        //  Show the windows from the system tray.
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        //  Hide the windows from the system tray.
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //  Exit the program from the system tray.
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出程序?", "安全提示",
               System.Windows.Forms.MessageBoxButtons.YesNo,
               System.Windows.Forms.MessageBoxIcon.Warning)
                == System.Windows.Forms.DialogResult.Yes)
            {
                notifyIcon1.Visible = false;   //设置图标不可见
                this.Close();                  //关闭窗体
                this.Dispose();                //释放资源
                //Application.Exit();            //关闭应用程序窗体
            }
        }
    }
}
