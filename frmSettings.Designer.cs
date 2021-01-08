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
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Silence Detect Noise Level:";
            this.toolTip1.SetToolTip(this.label1, "Adjust this number slightly if you are getting too many or too few silence detect" +
        "ions.");
            // 
            // txtSilenceDetectNoiseLevel
            // 
            this.txtSilenceDetectNoiseLevel.Location = new System.Drawing.Point(230, 17);
            this.txtSilenceDetectNoiseLevel.Margin = new System.Windows.Forms.Padding(4);
            this.txtSilenceDetectNoiseLevel.Name = "txtSilenceDetectNoiseLevel";
            this.txtSilenceDetectNoiseLevel.Size = new System.Drawing.Size(88, 28);
            this.txtSilenceDetectNoiseLevel.TabIndex = 1;
            this.txtSilenceDetectNoiseLevel.Text = "0.001";
            this.toolTip1.SetToolTip(this.txtSilenceDetectNoiseLevel, "Adjust this number slightly if you are getting too many or too few silence detect" +
        "ions.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Silence Duration:";
            this.toolTip1.SetToolTip(this.label2, "Input how long of a silence duration you want to detect.");
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(13, 129);
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
            this.lblSaveStatus.Location = new System.Drawing.Point(117, 134);
            this.lblSaveStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaveStatus.Name = "lblSaveStatus";
            this.lblSaveStatus.Size = new System.Drawing.Size(93, 20);
            this.lblSaveStatus.TabIndex = 4;
            this.lblSaveStatus.Text = "lblSaveStatus";
            this.lblSaveStatus.Visible = false;
            // 
            // txtSilenceDuration
            // 
            this.txtSilenceDuration.Location = new System.Drawing.Point(157, 75);
            this.txtSilenceDuration.Margin = new System.Windows.Forms.Padding(4);
            this.txtSilenceDuration.Name = "txtSilenceDuration";
            this.txtSilenceDuration.Size = new System.Drawing.Size(30, 28);
            this.txtSilenceDuration.TabIndex = 5;
            this.txtSilenceDuration.Text = "2";
            this.toolTip1.SetToolTip(this.txtSilenceDuration, "Input how long of a silence duration you want to detect.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "seconds";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 169);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSilenceDuration);
            this.Controls.Add(this.lblSaveStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSilenceDetectNoiseLevel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
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
    }
}