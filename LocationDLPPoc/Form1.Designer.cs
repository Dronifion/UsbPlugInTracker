namespace LocationDLPPoc
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tmrMonitor = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSSID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetPolicy = new System.Windows.Forms.Button();
            this.btnCancelPolicy = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSearchUSB = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb1 = new System.Windows.Forms.ListBox();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(441, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 22);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tmrMonitor
            // 
            this.tmrMonitor.Tick += new System.EventHandler(this.tmrMonitor_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(539, 365);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(531, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Step 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnCancelPolicy);
            this.tabPage2.Controls.Add(this.btnSetPolicy);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(531, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Step 1 - Define Security Policy (In the Server)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFilename);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtSSID);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(17, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 94);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Define Authorised Device Information";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(155, 54);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(319, 20);
            this.txtFilename.TabIndex = 12;
            this.txtFilename.Text = "USB DISK 2.0 USB Device";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Authorised USB Model:";
            // 
            // txtSSID
            // 
            this.txtSSID.Location = new System.Drawing.Point(155, 28);
            this.txtSSID.Name = "txtSSID";
            this.txtSSID.Size = new System.Drawing.Size(319, 20);
            this.txtSSID.TabIndex = 10;
            this.txtSSID.Text = "652233471";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Authorised USB Signature:";
            // 
            // btnSetPolicy
            // 
            this.btnSetPolicy.Location = new System.Drawing.Point(20, 48);
            this.btnSetPolicy.Name = "btnSetPolicy";
            this.btnSetPolicy.Size = new System.Drawing.Size(235, 23);
            this.btnSetPolicy.TabIndex = 3;
            this.btnSetPolicy.Text = "Click here to start the monitoring process";
            this.btnSetPolicy.UseVisualStyleBackColor = true;
            this.btnSetPolicy.Click += new System.EventHandler(this.btnSetPolicy_Click);
            // 
            // btnCancelPolicy
            // 
            this.btnCancelPolicy.Location = new System.Drawing.Point(264, 48);
            this.btnCancelPolicy.Name = "btnCancelPolicy";
            this.btnCancelPolicy.Size = new System.Drawing.Size(246, 23);
            this.btnCancelPolicy.TabIndex = 4;
            this.btnCancelPolicy.Text = "Click here to stop the monitoring process";
            this.btnCancelPolicy.UseVisualStyleBackColor = true;
            this.btnCancelPolicy.Click += new System.EventHandler(this.btnCancelPolicy_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSearchUSB);
            this.groupBox4.Location = new System.Drawing.Point(20, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(491, 81);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tool - Look for the information on the attached USB Device";
            // 
            // btnSearchUSB
            // 
            this.btnSearchUSB.Location = new System.Drawing.Point(16, 31);
            this.btnSearchUSB.Name = "btnSearchUSB";
            this.btnSearchUSB.Size = new System.Drawing.Size(455, 23);
            this.btnSearchUSB.TabIndex = 12;
            this.btnSearchUSB.Text = "Look for Attached USB Info";
            this.btnSearchUSB.UseVisualStyleBackColor = true;
            this.btnSearchUSB.Click += new System.EventHandler(this.btnSearchUSB_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Step 2 - Start the monitoring process. (At the endpoint)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb1);
            this.groupBox2.Controls.Add(this.lbInfo);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Location = new System.Drawing.Point(20, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 241);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "USB Activity Monitoring Status:";
            // 
            // lb1
            // 
            this.lb1.FormattingEnabled = true;
            this.lb1.Location = new System.Drawing.Point(190, 19);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(246, 147);
            this.lb1.TabIndex = 9;
            this.lb1.Visible = false;
            // 
            // lbInfo
            // 
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.Location = new System.Drawing.Point(21, 65);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(447, 160);
            this.lbInfo.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(18, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(450, 43);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 382);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DLP Agent Function (USB Tracking) POC";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrMonitor;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSearchUSB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSSID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lb1;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelPolicy;
        private System.Windows.Forms.Button btnSetPolicy;
    }
}

