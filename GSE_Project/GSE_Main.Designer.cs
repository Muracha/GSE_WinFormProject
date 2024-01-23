namespace GSE_Project
{
    partial class GSE_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GSE_Main));
            this.daylbl = new System.Windows.Forms.Label();
            this.messageVersionlbl = new System.Windows.Forms.Label();
            this.senderIdentificationlbl = new System.Windows.Forms.Label();
            this.subjectPartylbl = new System.Windows.Forms.Label();
            this.daydateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.messageVersiontxtBox = new System.Windows.Forms.TextBox();
            this.senderIdentificationtxtBox = new System.Windows.Forms.TextBox();
            this.subjectPartytxtBox = new System.Windows.Forms.TextBox();
            this.finalizeButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tradeRelationsbtn = new System.Windows.Forms.Button();
            this.TPS = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // daylbl
            // 
            this.daylbl.AccessibleDescription = "";
            this.daylbl.AutoSize = true;
            this.daylbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.daylbl.Location = new System.Drawing.Point(18, 148);
            this.daylbl.Name = "daylbl";
            this.daylbl.Size = new System.Drawing.Size(40, 23);
            this.daylbl.TabIndex = 0;
            this.daylbl.Text = "Day";
            // 
            // messageVersionlbl
            // 
            this.messageVersionlbl.AccessibleDescription = "";
            this.messageVersionlbl.AutoSize = true;
            this.messageVersionlbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.messageVersionlbl.Location = new System.Drawing.Point(18, 185);
            this.messageVersionlbl.Name = "messageVersionlbl";
            this.messageVersionlbl.Size = new System.Drawing.Size(138, 23);
            this.messageVersionlbl.TabIndex = 1;
            this.messageVersionlbl.Text = "Message Version";
            // 
            // senderIdentificationlbl
            // 
            this.senderIdentificationlbl.AccessibleDescription = "";
            this.senderIdentificationlbl.AutoSize = true;
            this.senderIdentificationlbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.senderIdentificationlbl.Location = new System.Drawing.Point(18, 223);
            this.senderIdentificationlbl.Name = "senderIdentificationlbl";
            this.senderIdentificationlbl.Size = new System.Drawing.Size(169, 23);
            this.senderIdentificationlbl.TabIndex = 2;
            this.senderIdentificationlbl.Text = "Sender Identification";
            // 
            // subjectPartylbl
            // 
            this.subjectPartylbl.AccessibleDescription = "";
            this.subjectPartylbl.AutoSize = true;
            this.subjectPartylbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.subjectPartylbl.Location = new System.Drawing.Point(18, 261);
            this.subjectPartylbl.Name = "subjectPartylbl";
            this.subjectPartylbl.Size = new System.Drawing.Size(111, 23);
            this.subjectPartylbl.TabIndex = 3;
            this.subjectPartylbl.Text = "Subject Party";
            // 
            // daydateTimePicker
            // 
            this.daydateTimePicker.AccessibleDescription = "Day";
            this.daydateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.daydateTimePicker.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.daydateTimePicker.Location = new System.Drawing.Point(217, 144);
            this.daydateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.daydateTimePicker.Name = "daydateTimePicker";
            this.daydateTimePicker.Size = new System.Drawing.Size(406, 27);
            this.daydateTimePicker.TabIndex = 4;
            // 
            // messageVersiontxtBox
            // 
            this.messageVersiontxtBox.AccessibleDescription = "MessageVersion";
            this.messageVersiontxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageVersiontxtBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.messageVersiontxtBox.Location = new System.Drawing.Point(217, 183);
            this.messageVersiontxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.messageVersiontxtBox.Name = "messageVersiontxtBox";
            this.messageVersiontxtBox.Size = new System.Drawing.Size(406, 27);
            this.messageVersiontxtBox.TabIndex = 5;
            this.messageVersiontxtBox.Text = "1";
            this.messageVersiontxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.messageVersiontxtBox_KeyPress);
            // 
            // senderIdentificationtxtBox
            // 
            this.senderIdentificationtxtBox.AccessibleDescription = "SenderIdentification";
            this.senderIdentificationtxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.senderIdentificationtxtBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.senderIdentificationtxtBox.Location = new System.Drawing.Point(217, 221);
            this.senderIdentificationtxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.senderIdentificationtxtBox.Name = "senderIdentificationtxtBox";
            this.senderIdentificationtxtBox.Size = new System.Drawing.Size(406, 27);
            this.senderIdentificationtxtBox.TabIndex = 6;
            this.senderIdentificationtxtBox.TextChanged += new System.EventHandler(this.senderIdentificationtxtBox_TextChanged_1);
            // 
            // subjectPartytxtBox
            // 
            this.subjectPartytxtBox.AccessibleDescription = "SubjectParty";
            this.subjectPartytxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectPartytxtBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.subjectPartytxtBox.Location = new System.Drawing.Point(217, 260);
            this.subjectPartytxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subjectPartytxtBox.Name = "subjectPartytxtBox";
            this.subjectPartytxtBox.Size = new System.Drawing.Size(406, 27);
            this.subjectPartytxtBox.TabIndex = 7;
            this.subjectPartytxtBox.TextChanged += new System.EventHandler(this.senderIdentificationtxtBox_TextChanged_1);
            // 
            // finalizeButton
            // 
            this.finalizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finalizeButton.BackColor = System.Drawing.Color.PeachPuff;
            this.finalizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.finalizeButton.FlatAppearance.BorderSize = 60;
            this.finalizeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.finalizeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.finalizeButton.Location = new System.Drawing.Point(471, 363);
            this.finalizeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.finalizeButton.Name = "finalizeButton";
            this.finalizeButton.Size = new System.Drawing.Size(129, 41);
            this.finalizeButton.TabIndex = 9;
            this.finalizeButton.Text = "Finalize";
            this.finalizeButton.UseVisualStyleBackColor = false;
            this.finalizeButton.Click += new System.EventHandler(this.finalizeButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buyToolStripMenuItem,
            this.advancedMenuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(914, 32);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // buyToolStripMenuItem
            // 
            this.buyToolStripMenuItem.Name = "buyToolStripMenuItem";
            this.buyToolStripMenuItem.Size = new System.Drawing.Size(60, 26);
            this.buyToolStripMenuItem.Text = "Trade";
            this.buyToolStripMenuItem.Click += new System.EventHandler(this.buyToolStripMenuItem_Click);
            // 
            // advancedMenuToolStripMenuItem
            // 
            this.advancedMenuToolStripMenuItem.Name = "advancedMenuToolStripMenuItem";
            this.advancedMenuToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.advancedMenuToolStripMenuItem.Text = "Advanced Menu";
            this.advancedMenuToolStripMenuItem.Click += new System.EventHandler(this.advancedMenuToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tradeRelationsbtn);
            this.panel1.Controls.Add(this.finalizeButton);
            this.panel1.Controls.Add(this.TPS);
            this.panel1.Controls.Add(this.daydateTimePicker);
            this.panel1.Controls.Add(this.daylbl);
            this.panel1.Controls.Add(this.subjectPartytxtBox);
            this.panel1.Controls.Add(this.messageVersionlbl);
            this.panel1.Controls.Add(this.senderIdentificationtxtBox);
            this.panel1.Controls.Add(this.senderIdentificationlbl);
            this.panel1.Controls.Add(this.messageVersiontxtBox);
            this.panel1.Controls.Add(this.subjectPartylbl);
            this.panel1.Location = new System.Drawing.Point(131, 73);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 447);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(193, 261);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 23);
            this.pictureBox1.TabIndex = 182;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(193, 223);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(18, 23);
            this.pictureBox4.TabIndex = 181;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(478, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "საბალანსო და დამხმარე მომსახურებების ბაზრის ოპერატორი ";
            // 
            // tradeRelationsbtn
            // 
            this.tradeRelationsbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tradeRelationsbtn.BackColor = System.Drawing.Color.PeachPuff;
            this.tradeRelationsbtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.tradeRelationsbtn.FlatAppearance.BorderSize = 60;
            this.tradeRelationsbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tradeRelationsbtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tradeRelationsbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tradeRelationsbtn.Location = new System.Drawing.Point(37, 363);
            this.tradeRelationsbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tradeRelationsbtn.Name = "tradeRelationsbtn";
            this.tradeRelationsbtn.Size = new System.Drawing.Size(139, 41);
            this.tradeRelationsbtn.TabIndex = 8;
            this.tradeRelationsbtn.Text = "Trade Relations";
            this.tradeRelationsbtn.UseVisualStyleBackColor = false;
            this.tradeRelationsbtn.Click += new System.EventHandler(this.tradeRelationsbtn_Click);
            // 
            // TPS
            // 
            this.TPS.AutoSize = true;
            this.TPS.BackColor = System.Drawing.Color.Transparent;
            this.TPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TPS.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TPS.ForeColor = System.Drawing.Color.Black;
            this.TPS.Location = new System.Drawing.Point(285, 29);
            this.TPS.Name = "TPS";
            this.TPS.Size = new System.Drawing.Size(119, 60);
            this.TPS.TabIndex = 19;
            this.TPS.Text = "T P S";
            // 
            // GSE_Main
            // 
            this.AcceptButton = this.finalizeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GSE_Project.Properties.Resources.GSE_ProjectIMG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "GSE_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPS Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GSE_Main_FormClosing);
            this.Load += new System.EventHandler(this.GSE_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label daylbl;
        private Label messageVersionlbl;
        private Label senderIdentificationlbl;
        private Label subjectPartylbl;
        private DateTimePicker daydateTimePicker;
        private TextBox messageVersiontxtBox;
        private TextBox senderIdentificationtxtBox;
        private TextBox subjectPartytxtBox;
        private Button finalizeButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem buyToolStripMenuItem;
        private ToolStripMenuItem advancedMenuToolStripMenuItem;
        private Panel panel1;
        private Label TPS;
        private Button tradeRelationsbtn;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
    }
}