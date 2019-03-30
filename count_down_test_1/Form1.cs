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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.TimeSpan span = new TimeSpan(0, 1, 0);
            Timer timer = new Timer(span);
            timer.onStart();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
