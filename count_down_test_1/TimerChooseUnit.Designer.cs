namespace count_down_test_1
{
    partial class TimerChooseUnit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerChooseUnit));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.HourBox = new System.Windows.Forms.TextBox();
            this.MinBox = new System.Windows.Forms.TextBox();
            this.SecBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Normal",
            "Cycle",
            "Timing",
            "CycleCount"});
            this.comboBox1.Location = new System.Drawing.Point(260, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // HourBox
            // 
            this.HourBox.Location = new System.Drawing.Point(12, 12);
            this.HourBox.Name = "HourBox";
            this.HourBox.Size = new System.Drawing.Size(59, 21);
            this.HourBox.TabIndex = 1;
            this.HourBox.TextChanged += new System.EventHandler(this.HourBox_TextChanged);
            // 
            // MinBox
            // 
            this.MinBox.Location = new System.Drawing.Point(112, 12);
            this.MinBox.Name = "MinBox";
            this.MinBox.Size = new System.Drawing.Size(63, 21);
            this.MinBox.TabIndex = 3;
            this.MinBox.TextChanged += new System.EventHandler(this.MinBox_TextChanged);
            // 
            // SecBox
            // 
            this.SecBox.Location = new System.Drawing.Point(212, 12);
            this.SecBox.Name = "SecBox";
            this.SecBox.Size = new System.Drawing.Size(64, 21);
            this.SecBox.TabIndex = 4;
            this.SecBox.TextChanged += new System.EventHandler(this.SecBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "秒";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "分钟";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "小时";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(305, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 21);
            this.button2.TabIndex = 9;
            this.button2.Text = "启动";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(87, 21);
            this.textBox1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "循环次数：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "计时器种类：";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // TimerChooseUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 83);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SecBox);
            this.Controls.Add(this.MinBox);
            this.Controls.Add(this.HourBox);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimerChooseUnit";
            this.Text = "TimerChooseUnit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TimerChooseUnit_FormClosed);
            this.Load += new System.EventHandler(this.TimerChooseUnit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox HourBox;
        private System.Windows.Forms.TextBox MinBox;
        private System.Windows.Forms.TextBox SecBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}