namespace MultiTimer
{
    partial class TimerChooseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerChooseForm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.HourBox = new System.Windows.Forms.TextBox();
            this.MinBox = new System.Windows.Forms.TextBox();
            this.SecBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.CountBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Normal",
            "Cycle",
            "Timing",
            "CycleCount",
            "Interval"});
            this.comboBox1.Location = new System.Drawing.Point(243, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 26);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // HourBox
            // 
            this.HourBox.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.HourBox.Location = new System.Drawing.Point(12, 12);
            this.HourBox.Name = "HourBox";
            this.HourBox.Size = new System.Drawing.Size(48, 26);
            this.HourBox.TabIndex = 1;
            this.HourBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinBox
            // 
            this.MinBox.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.MinBox.Location = new System.Drawing.Point(102, 12);
            this.MinBox.Name = "MinBox";
            this.MinBox.Size = new System.Drawing.Size(48, 26);
            this.MinBox.TabIndex = 3;
            this.MinBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SecBox
            // 
            this.SecBox.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.SecBox.Location = new System.Drawing.Point(187, 12);
            this.SecBox.Name = "SecBox";
            this.SecBox.Size = new System.Drawing.Size(50, 26);
            this.SecBox.TabIndex = 4;
            this.SecBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label1.Location = new System.Drawing.Point(240, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "sec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label2.Location = new System.Drawing.Point(153, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "hour";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.button2.Location = new System.Drawing.Point(265, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 26);
            this.button2.TabIndex = 9;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CountBox
            // 
            this.CountBox.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.CountBox.Location = new System.Drawing.Point(121, 42);
            this.CountBox.Name = "CountBox";
            this.CountBox.Size = new System.Drawing.Size(60, 26);
            this.CountBox.TabIndex = 10;
            this.CountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Limit/Interval:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label5.Location = new System.Drawing.Point(185, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Type:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimerChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 83);
            this.Controls.Add(this.SecBox);
            this.Controls.Add(this.MinBox);
            this.Controls.Add(this.HourBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CountBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimerChooseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimerChooseForm";
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
        private System.Windows.Forms.TextBox CountBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}