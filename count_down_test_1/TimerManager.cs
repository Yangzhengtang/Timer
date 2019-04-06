using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace count_down_test_1
{
    public partial class TimerManager : Form
    {
        public TimerManager()
        {
            InitializeComponent();
        }

        private List<Timer> TimerList;
        private List<string> ConfigurePathList;
        private int index;
        private static string SettingPath;
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
                
        }

        //  Construct a new timer.
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 T = new Form1();
            T.Show();
            //this.Close();
            //this.Hide();
            //Application.Run(new Program.MultiFormContext(new Form1(), new Form1()));
        }
        
        //  Load and Construct
        private void button1_Click(object sender, EventArgs e)
        {
            foreach(string configpath in ConfigurePathList)
            {
                Form1 f = new Form1(configpath);
                f.Show();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

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
