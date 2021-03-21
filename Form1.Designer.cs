namespace BachFlixAudioAnalyzer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Click \'Open\' to add files...");
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.gbFilesToProcess = new System.Windows.Forms.GroupBox();
            this.lblStopProcessing = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnProcessFiles = new System.Windows.Forms.Button();
            this.btnStopAnalyze = new System.Windows.Forms.Button();
            this.btnReAnalyzeFiles = new System.Windows.Forms.Button();
            this.lvFilesToAnalyze = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearWaitingFiles = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnRemoveSelectedWaitingFiles = new System.Windows.Forms.Button();
            this.lblCurrentRunningProcess = new System.Windows.Forms.Label();
            this.lbTimestamps = new System.Windows.Forms.ListBox();
            this.gbDetectedSilence = new System.Windows.Forms.GroupBox();
            this.btnRefreshTimestamps = new System.Windows.Forms.Button();
            this.btnCreateTimestamp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFileDuration = new System.Windows.Forms.Label();
            this.lblSaveTimestampsStatus = new System.Windows.Forms.Label();
            this.btnSaveTimestamps = new System.Windows.Forms.Button();
            this.lblSelectedTimestamp = new System.Windows.Forms.Label();
            this.btnRemoveSelectedTimestamp = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblError = new System.Windows.Forms.Label();
            this.gbCreateTimestamp = new System.Windows.Forms.GroupBox();
            this.lblErrorCustomTimestamp = new System.Windows.Forms.Label();
            this.btnCancelCustomTimestamp = new System.Windows.Forms.Button();
            this.btnSaveCustomTimestamp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomTimestamp = new System.Windows.Forms.TextBox();
            this.gbFilesToProcess.SuspendLayout();
            this.gbDetectedSilence.SuspendLayout();
            this.gbCreateTimestamp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpen.BackgroundImage")));
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Location = new System.Drawing.Point(707, 18);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(6);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Padding = new System.Windows.Forms.Padding(6);
            this.btnOpen.Size = new System.Drawing.Size(40, 40);
            this.btnOpen.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnOpen, "Open a folder to load files.");
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(76, 19);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(620, 26);
            this.txtPath.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtPath, "The path to the chosen folder.");
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPath.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPath.Location = new System.Drawing.Point(13, 19);
            this.lblPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(58, 25);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "Path:";
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.BackgroundImage")));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(757, 18);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(40, 40);
            this.btnSettings.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnSettings, "Settings");
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // gbFilesToProcess
            // 
            this.gbFilesToProcess.Controls.Add(this.lblStopProcessing);
            this.gbFilesToProcess.Controls.Add(this.label6);
            this.gbFilesToProcess.Controls.Add(this.btnProcessFiles);
            this.gbFilesToProcess.Controls.Add(this.btnStopAnalyze);
            this.gbFilesToProcess.Controls.Add(this.btnReAnalyzeFiles);
            this.gbFilesToProcess.Controls.Add(this.lvFilesToAnalyze);
            this.gbFilesToProcess.Controls.Add(this.label2);
            this.gbFilesToProcess.Controls.Add(this.btnClearWaitingFiles);
            this.gbFilesToProcess.Controls.Add(this.btnAnalyze);
            this.gbFilesToProcess.Controls.Add(this.btnRemoveSelectedWaitingFiles);
            this.gbFilesToProcess.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbFilesToProcess.Location = new System.Drawing.Point(13, 55);
            this.gbFilesToProcess.Margin = new System.Windows.Forms.Padding(4);
            this.gbFilesToProcess.MaximumSize = new System.Drawing.Size(820, 380);
            this.gbFilesToProcess.Name = "gbFilesToProcess";
            this.gbFilesToProcess.Padding = new System.Windows.Forms.Padding(4);
            this.gbFilesToProcess.Size = new System.Drawing.Size(820, 380);
            this.gbFilesToProcess.TabIndex = 8;
            this.gbFilesToProcess.TabStop = false;
            this.gbFilesToProcess.Text = "Files";
            // 
            // lblStopProcessing
            // 
            this.lblStopProcessing.AutoSize = true;
            this.lblStopProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStopProcessing.ForeColor = System.Drawing.Color.Red;
            this.lblStopProcessing.Location = new System.Drawing.Point(328, 332);
            this.lblStopProcessing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStopProcessing.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblStopProcessing.Name = "lblStopProcessing";
            this.lblStopProcessing.Size = new System.Drawing.Size(329, 20);
            this.lblStopProcessing.TabIndex = 21;
            this.lblStopProcessing.Text = "Stopping after the current process is finished!";
            this.lblStopProcessing.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(212, 324);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 30);
            this.label6.TabIndex = 25;
            this.label6.Text = "|";
            // 
            // btnProcessFiles
            // 
            this.btnProcessFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProcessFiles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcessFiles.BackgroundImage")));
            this.btnProcessFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProcessFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessFiles.Enabled = false;
            this.btnProcessFiles.FlatAppearance.BorderSize = 0;
            this.btnProcessFiles.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnProcessFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnProcessFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessFiles.Location = new System.Drawing.Point(234, 322);
            this.btnProcessFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcessFiles.Name = "btnProcessFiles";
            this.btnProcessFiles.Size = new System.Drawing.Size(40, 40);
            this.btnProcessFiles.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnProcessFiles, "Remove Silence - Remove the chosen silence from the files.");
            this.btnProcessFiles.UseVisualStyleBackColor = false;
            this.btnProcessFiles.Click += new System.EventHandler(this.btnProcessFiles_Click);
            // 
            // btnStopAnalyze
            // 
            this.btnStopAnalyze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStopAnalyze.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStopAnalyze.BackgroundImage")));
            this.btnStopAnalyze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStopAnalyze.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopAnalyze.FlatAppearance.BorderSize = 0;
            this.btnStopAnalyze.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnStopAnalyze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnStopAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopAnalyze.Location = new System.Drawing.Point(281, 322);
            this.btnStopAnalyze.Name = "btnStopAnalyze";
            this.btnStopAnalyze.Size = new System.Drawing.Size(40, 40);
            this.btnStopAnalyze.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btnStopAnalyze, "Stop Analyzing");
            this.btnStopAnalyze.UseVisualStyleBackColor = false;
            this.btnStopAnalyze.Visible = false;
            this.btnStopAnalyze.Click += new System.EventHandler(this.btnStopAnalyze_Click);
            // 
            // btnReAnalyzeFiles
            // 
            this.btnReAnalyzeFiles.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnReAnalyzeFiles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReAnalyzeFiles.BackgroundImage")));
            this.btnReAnalyzeFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReAnalyzeFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReAnalyzeFiles.Enabled = false;
            this.btnReAnalyzeFiles.FlatAppearance.BorderSize = 0;
            this.btnReAnalyzeFiles.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnReAnalyzeFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnReAnalyzeFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReAnalyzeFiles.Location = new System.Drawing.Point(169, 322);
            this.btnReAnalyzeFiles.Name = "btnReAnalyzeFiles";
            this.btnReAnalyzeFiles.Size = new System.Drawing.Size(40, 40);
            this.btnReAnalyzeFiles.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnReAnalyzeFiles, "Re-Analyze - Force a fresh analysis of the files.");
            this.btnReAnalyzeFiles.UseVisualStyleBackColor = false;
            this.btnReAnalyzeFiles.Click += new System.EventHandler(this.btnReAnalyzeFiles_Click);
            // 
            // lvFilesToAnalyze
            // 
            this.lvFilesToAnalyze.AllowDrop = true;
            this.lvFilesToAnalyze.BackColor = System.Drawing.Color.Black;
            this.lvFilesToAnalyze.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvFilesToAnalyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvFilesToAnalyze.ForeColor = System.Drawing.Color.White;
            this.lvFilesToAnalyze.HideSelection = false;
            this.lvFilesToAnalyze.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvFilesToAnalyze.LabelWrap = false;
            this.lvFilesToAnalyze.Location = new System.Drawing.Point(8, 29);
            this.lvFilesToAnalyze.Margin = new System.Windows.Forms.Padding(4);
            this.lvFilesToAnalyze.Name = "lvFilesToAnalyze";
            this.lvFilesToAnalyze.Size = new System.Drawing.Size(804, 290);
            this.lvFilesToAnalyze.TabIndex = 22;
            this.lvFilesToAnalyze.UseCompatibleStateImageBehavior = false;
            this.lvFilesToAnalyze.View = System.Windows.Forms.View.List;
            this.lvFilesToAnalyze.SelectedIndexChanged += new System.EventHandler(this.lvFilesToAnalyze_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(100, 324);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 30);
            this.label2.TabIndex = 16;
            this.label2.Text = "|";
            // 
            // btnClearWaitingFiles
            // 
            this.btnClearWaitingFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClearWaitingFiles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClearWaitingFiles.BackgroundImage")));
            this.btnClearWaitingFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearWaitingFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearWaitingFiles.Enabled = false;
            this.btnClearWaitingFiles.FlatAppearance.BorderSize = 0;
            this.btnClearWaitingFiles.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnClearWaitingFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnClearWaitingFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearWaitingFiles.Location = new System.Drawing.Point(56, 322);
            this.btnClearWaitingFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearWaitingFiles.Name = "btnClearWaitingFiles";
            this.btnClearWaitingFiles.Size = new System.Drawing.Size(40, 40);
            this.btnClearWaitingFiles.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btnClearWaitingFiles, "Refresh - Clear all files in the list.");
            this.btnClearWaitingFiles.UseVisualStyleBackColor = false;
            this.btnClearWaitingFiles.Click += new System.EventHandler(this.btnClearWaitingFiles_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAnalyze.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnalyze.BackgroundImage")));
            this.btnAnalyze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnalyze.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalyze.Enabled = false;
            this.btnAnalyze.FlatAppearance.BorderSize = 0;
            this.btnAnalyze.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnAnalyze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyze.Location = new System.Drawing.Point(122, 322);
            this.btnAnalyze.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(40, 40);
            this.btnAnalyze.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnAnalyze, "Analyze - Check the files for silence. (Note: This will not overwrite any previou" +
        "s analysis)");
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // btnRemoveSelectedWaitingFiles
            // 
            this.btnRemoveSelectedWaitingFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemoveSelectedWaitingFiles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveSelectedWaitingFiles.BackgroundImage")));
            this.btnRemoveSelectedWaitingFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveSelectedWaitingFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveSelectedWaitingFiles.Enabled = false;
            this.btnRemoveSelectedWaitingFiles.FlatAppearance.BorderSize = 0;
            this.btnRemoveSelectedWaitingFiles.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnRemoveSelectedWaitingFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnRemoveSelectedWaitingFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveSelectedWaitingFiles.Location = new System.Drawing.Point(8, 322);
            this.btnRemoveSelectedWaitingFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveSelectedWaitingFiles.Name = "btnRemoveSelectedWaitingFiles";
            this.btnRemoveSelectedWaitingFiles.Size = new System.Drawing.Size(40, 40);
            this.btnRemoveSelectedWaitingFiles.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btnRemoveSelectedWaitingFiles, "Remove Selected - Remove a selected file from the list.");
            this.btnRemoveSelectedWaitingFiles.UseVisualStyleBackColor = false;
            this.btnRemoveSelectedWaitingFiles.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // lblCurrentRunningProcess
            // 
            this.lblCurrentRunningProcess.AutoSize = true;
            this.lblCurrentRunningProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentRunningProcess.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblCurrentRunningProcess.Location = new System.Drawing.Point(13, 439);
            this.lblCurrentRunningProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentRunningProcess.Name = "lblCurrentRunningProcess";
            this.lblCurrentRunningProcess.Size = new System.Drawing.Size(218, 20);
            this.lblCurrentRunningProcess.TabIndex = 14;
            this.lblCurrentRunningProcess.Text = "lblCurrentRunningProcess";
            this.lblCurrentRunningProcess.Visible = false;
            // 
            // lbTimestamps
            // 
            this.lbTimestamps.BackColor = System.Drawing.SystemColors.ControlText;
            this.lbTimestamps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTimestamps.ForeColor = System.Drawing.Color.White;
            this.lbTimestamps.FormattingEnabled = true;
            this.lbTimestamps.HorizontalScrollbar = true;
            this.lbTimestamps.ItemHeight = 20;
            this.lbTimestamps.Location = new System.Drawing.Point(8, 109);
            this.lbTimestamps.Margin = new System.Windows.Forms.Padding(4);
            this.lbTimestamps.Name = "lbTimestamps";
            this.lbTimestamps.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbTimestamps.Size = new System.Drawing.Size(491, 204);
            this.lbTimestamps.TabIndex = 17;
            this.lbTimestamps.DoubleClick += new System.EventHandler(this.lbTimestamps_DoubleClick);
            // 
            // gbDetectedSilence
            // 
            this.gbDetectedSilence.Controls.Add(this.btnRefreshTimestamps);
            this.gbDetectedSilence.Controls.Add(this.btnCreateTimestamp);
            this.gbDetectedSilence.Controls.Add(this.label4);
            this.gbDetectedSilence.Controls.Add(this.label3);
            this.gbDetectedSilence.Controls.Add(this.lblFileDuration);
            this.gbDetectedSilence.Controls.Add(this.lblSaveTimestampsStatus);
            this.gbDetectedSilence.Controls.Add(this.btnSaveTimestamps);
            this.gbDetectedSilence.Controls.Add(this.lblSelectedTimestamp);
            this.gbDetectedSilence.Controls.Add(this.btnRemoveSelectedTimestamp);
            this.gbDetectedSilence.Controls.Add(this.lbTimestamps);
            this.gbDetectedSilence.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbDetectedSilence.Location = new System.Drawing.Point(841, 49);
            this.gbDetectedSilence.Margin = new System.Windows.Forms.Padding(4);
            this.gbDetectedSilence.Name = "gbDetectedSilence";
            this.gbDetectedSilence.Padding = new System.Windows.Forms.Padding(4);
            this.gbDetectedSilence.Size = new System.Drawing.Size(508, 368);
            this.gbDetectedSilence.TabIndex = 18;
            this.gbDetectedSilence.TabStop = false;
            this.gbDetectedSilence.Text = "Silence Timestamps";
            this.toolTip1.SetToolTip(this.gbDetectedSilence, "This lists the timestamps of silence found in this file.");
            this.gbDetectedSilence.Visible = false;
            // 
            // btnRefreshTimestamps
            // 
            this.btnRefreshTimestamps.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshTimestamps.BackgroundImage")));
            this.btnRefreshTimestamps.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshTimestamps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshTimestamps.FlatAppearance.BorderSize = 0;
            this.btnRefreshTimestamps.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnRefreshTimestamps.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnRefreshTimestamps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTimestamps.Location = new System.Drawing.Point(420, 63);
            this.btnRefreshTimestamps.Name = "btnRefreshTimestamps";
            this.btnRefreshTimestamps.Size = new System.Drawing.Size(40, 40);
            this.btnRefreshTimestamps.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btnRefreshTimestamps, "Restore original detected Timestamps");
            this.btnRefreshTimestamps.UseVisualStyleBackColor = true;
            this.btnRefreshTimestamps.Click += new System.EventHandler(this.btnRefreshTimestamps_Click);
            // 
            // btnCreateTimestamp
            // 
            this.btnCreateTimestamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateTimestamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateTimestamp.Location = new System.Drawing.Point(463, 62);
            this.btnCreateTimestamp.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreateTimestamp.Name = "btnCreateTimestamp";
            this.btnCreateTimestamp.Size = new System.Drawing.Size(36, 37);
            this.btnCreateTimestamp.TabIndex = 24;
            this.btnCreateTimestamp.Text = "+";
            this.toolTip1.SetToolTip(this.btnCreateTimestamp, "Insert Custom Timestamp.");
            this.btnCreateTimestamp.UseVisualStyleBackColor = true;
            this.btnCreateTimestamp.Visible = false;
            this.btnCreateTimestamp.Click += new System.EventHandler(this.btnCreateTimestamp_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(8, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Duration of video:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(19, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Silence Start - Silence End => Duration";
            // 
            // lblFileDuration
            // 
            this.lblFileDuration.AutoSize = true;
            this.lblFileDuration.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblFileDuration.Location = new System.Drawing.Point(158, 59);
            this.lblFileDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileDuration.Name = "lblFileDuration";
            this.lblFileDuration.Size = new System.Drawing.Size(110, 20);
            this.lblFileDuration.TabIndex = 21;
            this.lblFileDuration.Text = "lblFileDuration";
            this.lblFileDuration.Visible = false;
            // 
            // lblSaveTimestampsStatus
            // 
            this.lblSaveTimestampsStatus.AutoSize = true;
            this.lblSaveTimestampsStatus.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSaveTimestampsStatus.Location = new System.Drawing.Point(271, 328);
            this.lblSaveTimestampsStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaveTimestampsStatus.Name = "lblSaveTimestampsStatus";
            this.lblSaveTimestampsStatus.Size = new System.Drawing.Size(193, 20);
            this.lblSaveTimestampsStatus.TabIndex = 20;
            this.lblSaveTimestampsStatus.Text = "lblSaveTimestampsStatus";
            this.lblSaveTimestampsStatus.Visible = false;
            // 
            // btnSaveTimestamps
            // 
            this.btnSaveTimestamps.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSaveTimestamps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveTimestamps.Enabled = false;
            this.btnSaveTimestamps.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveTimestamps.Location = new System.Drawing.Point(170, 322);
            this.btnSaveTimestamps.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveTimestamps.Name = "btnSaveTimestamps";
            this.btnSaveTimestamps.Size = new System.Drawing.Size(96, 31);
            this.btnSaveTimestamps.TabIndex = 0;
            this.btnSaveTimestamps.Text = "Save";
            this.btnSaveTimestamps.UseVisualStyleBackColor = false;
            this.btnSaveTimestamps.Click += new System.EventHandler(this.btnSaveTimestamps_Click);
            // 
            // lblSelectedTimestamp
            // 
            this.lblSelectedTimestamp.AutoSize = true;
            this.lblSelectedTimestamp.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSelectedTimestamp.Location = new System.Drawing.Point(8, 29);
            this.lblSelectedTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedTimestamp.Name = "lblSelectedTimestamp";
            this.lblSelectedTimestamp.Size = new System.Drawing.Size(165, 20);
            this.lblSelectedTimestamp.TabIndex = 19;
            this.lblSelectedTimestamp.Text = "lblSelectedTimestamp";
            this.lblSelectedTimestamp.Visible = false;
            // 
            // btnRemoveSelectedTimestamp
            // 
            this.btnRemoveSelectedTimestamp.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRemoveSelectedTimestamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveSelectedTimestamp.Enabled = false;
            this.btnRemoveSelectedTimestamp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemoveSelectedTimestamp.Location = new System.Drawing.Point(8, 322);
            this.btnRemoveSelectedTimestamp.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveSelectedTimestamp.Name = "btnRemoveSelectedTimestamp";
            this.btnRemoveSelectedTimestamp.Size = new System.Drawing.Size(154, 31);
            this.btnRemoveSelectedTimestamp.TabIndex = 18;
            this.btnRemoveSelectedTimestamp.Text = "Remove Selected";
            this.btnRemoveSelectedTimestamp.UseVisualStyleBackColor = false;
            this.btnRemoveSelectedTimestamp.Click += new System.EventHandler(this.btnRemoveSelectedTimestamp_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(13, 469);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(107, 20);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "errorMessage";
            this.lblError.Visible = false;
            // 
            // gbCreateTimestamp
            // 
            this.gbCreateTimestamp.Controls.Add(this.lblErrorCustomTimestamp);
            this.gbCreateTimestamp.Controls.Add(this.btnCancelCustomTimestamp);
            this.gbCreateTimestamp.Controls.Add(this.btnSaveCustomTimestamp);
            this.gbCreateTimestamp.Controls.Add(this.label5);
            this.gbCreateTimestamp.Controls.Add(this.txtCustomTimestamp);
            this.gbCreateTimestamp.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbCreateTimestamp.Location = new System.Drawing.Point(841, 424);
            this.gbCreateTimestamp.Name = "gbCreateTimestamp";
            this.gbCreateTimestamp.Size = new System.Drawing.Size(259, 135);
            this.gbCreateTimestamp.TabIndex = 22;
            this.gbCreateTimestamp.TabStop = false;
            this.gbCreateTimestamp.Text = "Create Custom Timestamp";
            this.gbCreateTimestamp.Visible = false;
            // 
            // lblErrorCustomTimestamp
            // 
            this.lblErrorCustomTimestamp.AutoSize = true;
            this.lblErrorCustomTimestamp.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCustomTimestamp.Location = new System.Drawing.Point(8, 72);
            this.lblErrorCustomTimestamp.Name = "lblErrorCustomTimestamp";
            this.lblErrorCustomTimestamp.Size = new System.Drawing.Size(174, 20);
            this.lblErrorCustomTimestamp.TabIndex = 4;
            this.lblErrorCustomTimestamp.Text = "You must input a value.";
            this.lblErrorCustomTimestamp.Visible = false;
            // 
            // btnCancelCustomTimestamp
            // 
            this.btnCancelCustomTimestamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelCustomTimestamp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnCancelCustomTimestamp.Location = new System.Drawing.Point(89, 100);
            this.btnCancelCustomTimestamp.Name = "btnCancelCustomTimestamp";
            this.btnCancelCustomTimestamp.Size = new System.Drawing.Size(75, 29);
            this.btnCancelCustomTimestamp.TabIndex = 3;
            this.btnCancelCustomTimestamp.Text = "Cancel";
            this.btnCancelCustomTimestamp.UseVisualStyleBackColor = true;
            this.btnCancelCustomTimestamp.Click += new System.EventHandler(this.btnCancelCustomTimestamp_Click);
            // 
            // btnSaveCustomTimestamp
            // 
            this.btnSaveCustomTimestamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveCustomTimestamp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnSaveCustomTimestamp.Location = new System.Drawing.Point(8, 100);
            this.btnSaveCustomTimestamp.Name = "btnSaveCustomTimestamp";
            this.btnSaveCustomTimestamp.Size = new System.Drawing.Size(75, 29);
            this.btnSaveCustomTimestamp.TabIndex = 2;
            this.btnSaveCustomTimestamp.Text = "Save";
            this.btnSaveCustomTimestamp.UseVisualStyleBackColor = true;
            this.btnSaveCustomTimestamp.Click += new System.EventHandler(this.btnSaveCustomTimestamp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Silence Start:";
            // 
            // txtCustomTimestamp
            // 
            this.txtCustomTimestamp.Location = new System.Drawing.Point(130, 27);
            this.txtCustomTimestamp.Name = "txtCustomTimestamp";
            this.txtCustomTimestamp.Size = new System.Drawing.Size(100, 26);
            this.txtCustomTimestamp.TabIndex = 0;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1591, 714);
            this.Controls.Add(this.gbCreateTimestamp);
            this.Controls.Add(this.gbDetectedSilence);
            this.Controls.Add(this.lblCurrentRunningProcess);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.gbFilesToProcess);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnOpen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "PlayOnPal";
            this.gbFilesToProcess.ResumeLayout(false);
            this.gbFilesToProcess.PerformLayout();
            this.gbDetectedSilence.ResumeLayout(false);
            this.gbDetectedSilence.PerformLayout();
            this.gbCreateTimestamp.ResumeLayout(false);
            this.gbCreateTimestamp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.GroupBox gbFilesToProcess;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label lblCurrentRunningProcess;
        private System.Windows.Forms.ListBox lbTimestamps;
        private System.Windows.Forms.GroupBox gbDetectedSilence;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnRemoveSelectedWaitingFiles;
        private System.Windows.Forms.Button btnClearWaitingFiles;
        private System.Windows.Forms.Button btnRemoveSelectedTimestamp;
        private System.Windows.Forms.Label lblSelectedTimestamp;
        private System.Windows.Forms.Button btnSaveTimestamps;
        private System.Windows.Forms.Label lblSaveTimestampsStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFileDuration;
        private System.Windows.Forms.Button btnProcessFiles;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblStopProcessing;
        private System.Windows.Forms.ListView lvFilesToAnalyze;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateTimestamp;
        private System.Windows.Forms.GroupBox gbCreateTimestamp;
        private System.Windows.Forms.Button btnSaveCustomTimestamp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomTimestamp;
        private System.Windows.Forms.Label lblErrorCustomTimestamp;
        private System.Windows.Forms.Button btnCancelCustomTimestamp;
        private System.Windows.Forms.Button btnReAnalyzeFiles;
        private System.Windows.Forms.Button btnStopAnalyze;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefreshTimestamps;
    }
}

