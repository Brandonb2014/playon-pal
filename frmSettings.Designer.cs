namespace BachFlixAudioAnalyzer
{
    partial class frmSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSilenceDetectNoiseLevel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSaveStatus = new System.Windows.Forms.Label();
            this.txtSilenceDuration = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtVlcLocation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.chkbxDeleteOriginal = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkbxRemoveSplashScreens = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Silence Detect Noise Level:";
            this.toolTip1.SetToolTip(this.label1, "Adjust this number slightly if you are getting too many or too few silence detect" +
        "ions.");
            // 
            // txtSilenceDetectNoiseLevel
            // 
            this.txtSilenceDetectNoiseLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtSilenceDetectNoiseLevel.ForeColor = System.Drawing.Color.White;
            this.txtSilenceDetectNoiseLevel.Location = new System.Drawing.Point(250, 15);
            this.txtSilenceDetectNoiseLevel.Margin = new System.Windows.Forms.Padding(4);
            this.txtSilenceDetectNoiseLevel.Name = "txtSilenceDetectNoiseLevel";
            this.txtSilenceDetectNoiseLevel.Size = new System.Drawing.Size(88, 26);
            this.txtSilenceDetectNoiseLevel.TabIndex = 1;
            this.txtSilenceDetectNoiseLevel.Text = "0.001";
            this.toolTip1.SetToolTip(this.txtSilenceDetectNoiseLevel, "Adjust this number slightly if you are getting too many or too few silence detect" +
        "ions.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Silence Duration:";
            this.toolTip1.SetToolTip(this.label2, "Input how long of a silence duration you want to detect.");
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.Location = new System.Drawing.Point(10, 334);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSaveStatus
            // 
            this.lblSaveStatus.AutoSize = true;
            this.lblSaveStatus.Location = new System.Drawing.Point(117, 339);
            this.lblSaveStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaveStatus.Name = "lblSaveStatus";
            this.lblSaveStatus.Size = new System.Drawing.Size(107, 20);
            this.lblSaveStatus.TabIndex = 4;
            this.lblSaveStatus.Text = "lblSaveStatus";
            this.lblSaveStatus.Visible = false;
            // 
            // txtSilenceDuration
            // 
            this.txtSilenceDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtSilenceDuration.ForeColor = System.Drawing.Color.White;
            this.txtSilenceDuration.Location = new System.Drawing.Point(160, 47);
            this.txtSilenceDuration.Margin = new System.Windows.Forms.Padding(4);
            this.txtSilenceDuration.Name = "txtSilenceDuration";
            this.txtSilenceDuration.Size = new System.Drawing.Size(30, 26);
            this.txtSilenceDuration.TabIndex = 5;
            this.txtSilenceDuration.Text = "2";
            this.toolTip1.SetToolTip(this.txtSilenceDuration, "Input how long of a silence duration you want to detect.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(13, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "VLC Location:";
            this.toolTip1.SetToolTip(this.label4, "We use VLC to play the timestamps. Please input the folder location that holds yo" +
        "ur vlc.exe file.");
            // 
            // txtVlcLocation
            // 
            this.txtVlcLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtVlcLocation.ForeColor = System.Drawing.Color.White;
            this.txtVlcLocation.Location = new System.Drawing.Point(144, 81);
            this.txtVlcLocation.Name = "txtVlcLocation";
            this.txtVlcLocation.Size = new System.Drawing.Size(194, 26);
            this.txtVlcLocation.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtVlcLocation, "We use VLC to play the timestamps. Please input the folder location that holds yo" +
        "ur vlc.exe file.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(13, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Output Folder:";
            this.toolTip1.SetToolTip(this.label5, "Please insert the full path to the folder you would like your finished videos out" +
        "put to.");
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtOutputFolder.ForeColor = System.Drawing.Color.White;
            this.txtOutputFolder.Location = new System.Drawing.Point(144, 122);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(194, 26);
            this.txtOutputFolder.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtOutputFolder, "Please insert the full path to the folder you would like your finished videos out" +
        "put to.");
            // 
            // chkbxDeleteOriginal
            // 
            this.chkbxDeleteOriginal.AutoSize = true;
            this.chkbxDeleteOriginal.Location = new System.Drawing.Point(270, 167);
            this.chkbxDeleteOriginal.Name = "chkbxDeleteOriginal";
            this.chkbxDeleteOriginal.Size = new System.Drawing.Size(15, 14);
            this.chkbxDeleteOriginal.TabIndex = 12;
            this.toolTip1.SetToolTip(this.chkbxDeleteOriginal, "Delete the original file when done removing silence.");
            this.chkbxDeleteOriginal.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(13, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Delete original file when done:";
            this.toolTip1.SetToolTip(this.label6, "Delete the original file when done removing silence.");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(14, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(271, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Remove PlayOn Splash Screens:";
            this.toolTip1.SetToolTip(this.label7, "If the file is from a PlayOn recording, check this box to remove the splash scree" +
        "ns. Leave it unchecked to slice the splash screens back in after removing silenc" +
        "e.");
            // 
            // chkbxRemoveSplashScreens
            // 
            this.chkbxRemoveSplashScreens.AutoSize = true;
            this.chkbxRemoveSplashScreens.Location = new System.Drawing.Point(291, 209);
            this.chkbxRemoveSplashScreens.Name = "chkbxRemoveSplashScreens";
            this.chkbxRemoveSplashScreens.Size = new System.Drawing.Size(15, 14);
            this.chkbxRemoveSplashScreens.TabIndex = 14;
            this.toolTip1.SetToolTip(this.chkbxRemoveSplashScreens, "If the file is from a PlayOn recording, check this box to remove the splash scree" +
        "ns. Leave it unchecked to slice the splash screens back in after removing silenc" +
        "e.");
            this.chkbxRemoveSplashScreens.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "seconds";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(67)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(356, 377);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkbxRemoveSplashScreens);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkbxDeleteOriginal);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtVlcLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSilenceDuration);
            this.Controls.Add(this.lblSaveStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSilenceDetectNoiseLevel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtSilenceDetectNoiseLevel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSaveStatus;
        private System.Windows.Forms.TextBox txtSilenceDuration;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVlcLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.CheckBox chkbxDeleteOriginal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkbxRemoveSplashScreens;
    }
}