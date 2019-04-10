namespace count_down_test_1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.displayer = new System.Windows.Forms.RichTextBox();
            this.ProgressBack = new System.Windows.Forms.Label();
            this.ProgressFront = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beepingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bibiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.autooffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Baskerville Old Face", 13F);
            this.button1.Location = new System.Drawing.Point(417, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(511, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Baskerville Old Face", 13F);
            this.button2.Location = new System.Drawing.Point(417, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // displayer
            // 
            this.displayer.BackColor = System.Drawing.SystemColors.Window;
            this.displayer.Font = new System.Drawing.Font("Baskerville Old Face", 56.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayer.Location = new System.Drawing.Point(29, 45);
            this.displayer.Name = "displayer";
            this.displayer.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.displayer.Size = new System.Drawing.Size(480, 90);
            this.displayer.TabIndex = 5;
            this.displayer.Text = "";
            this.displayer.TextChanged += new System.EventHandler(this.displayer_TextChanged);
            // 
            // ProgressBack
            // 
            this.ProgressBack.BackColor = System.Drawing.Color.White;
            this.ProgressBack.Location = new System.Drawing.Point(0, 0);
            this.ProgressBack.Name = "ProgressBack";
            this.ProgressBack.Size = new System.Drawing.Size(547, 151);
            this.ProgressBack.TabIndex = 6;
            // 
            // ProgressFront
            // 
            this.ProgressFront.BackColor = System.Drawing.Color.White;
            this.ProgressFront.Location = new System.Drawing.Point(0, 0);
            this.ProgressFront.Name = "ProgressFront";
            this.ProgressFront.Size = new System.Drawing.Size(548, 152);
            this.ProgressFront.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(175, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(188, 22);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Timer";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bellToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.directionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // bellToolStripMenuItem
            // 
            this.bellToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beepingToolStripMenuItem,
            this.toolStripSeparator1,
            this.autooffToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.bellToolStripMenuItem.Name = "bellToolStripMenuItem";
            this.bellToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bellToolStripMenuItem.Text = "Bell";
            // 
            // beepingToolStripMenuItem
            // 
            this.beepingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beepToolStripMenuItem,
            this.bibiToolStripMenuItem,
            this.joyToolStripMenuItem});
            this.beepingToolStripMenuItem.Name = "beepingToolStripMenuItem";
            this.beepingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beepingToolStripMenuItem.Text = "beeping";
            // 
            // beepToolStripMenuItem
            // 
            this.beepToolStripMenuItem.Name = "beepToolStripMenuItem";
            this.beepToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beepToolStripMenuItem.Text = "beep";
            this.beepToolStripMenuItem.Click += new System.EventHandler(this.beepToolStripMenuItem_Click);
            // 
            // bibiToolStripMenuItem
            // 
            this.bibiToolStripMenuItem.Name = "bibiToolStripMenuItem";
            this.bibiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bibiToolStripMenuItem.Text = "didi";
            this.bibiToolStripMenuItem.Click += new System.EventHandler(this.didiToolStripMenuItem_Click);
            // 
            // joyToolStripMenuItem
            // 
            this.joyToolStripMenuItem.Name = "joyToolStripMenuItem";
            this.joyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.joyToolStripMenuItem.Text = "joy";
            this.joyToolStripMenuItem.Click += new System.EventHandler(this.joyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // autooffToolStripMenuItem
            // 
            this.autooffToolStripMenuItem.Name = "autooffToolStripMenuItem";
            this.autooffToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autooffToolStripMenuItem.Text = "Auto-off";
            this.autooffToolStripMenuItem.Click += new System.EventHandler(this.autooffToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.blackWhiteToolStripMenuItem,
            this.gayToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorToolStripMenuItem.Text = "Theme";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // blackWhiteToolStripMenuItem
            // 
            this.blackWhiteToolStripMenuItem.Name = "blackWhiteToolStripMenuItem";
            this.blackWhiteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.blackWhiteToolStripMenuItem.Text = "Black And White";
            this.blackWhiteToolStripMenuItem.Click += new System.EventHandler(this.blackWhiteToolStripMenuItem_Click);
            // 
            // gayToolStripMenuItem
            // 
            this.gayToolStripMenuItem.Name = "gayToolStripMenuItem";
            this.gayToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gayToolStripMenuItem.Text = "Gay";
            this.gayToolStripMenuItem.Click += new System.EventHandler(this.gayToolStripMenuItem_Click);
            // 
            // directionToolStripMenuItem
            // 
            this.directionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftToolStripMenuItem,
            this.rightToolStripMenuItem});
            this.directionToolStripMenuItem.Name = "directionToolStripMenuItem";
            this.directionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.directionToolStripMenuItem.Text = "Direction";
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.leftToolStripMenuItem.Text = "Left";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.leftToolStripMenuItem_Click);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.rightToolStripMenuItem.Text = "Right";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.rightToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 149);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.displayer);
            this.Controls.Add(this.ProgressFront);
            this.Controls.Add(this.ProgressBack);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Timer";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox displayer;
        private System.Windows.Forms.Label ProgressBack;
        private System.Windows.Forms.Label ProgressFront;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beepingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem autooffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bibiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joyToolStripMenuItem;
    }
}

