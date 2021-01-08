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
            this.lvFilesToAnalyze = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnProcessSelected = new System.Windows.Forms.Button();
            this.btnProcessFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearProcessed = new System.Windows.Forms.Button();
            this.btnRemoveSelectedProcessedFiles = new System.Windows.Forms.Button();
            this.lbAnalyzed = new System.Windows.Forms.ListBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.lblLoadedFiles = new System.Windows.Forms.Label();
            this.lblCurrentRunningProcess = new System.Windows.Forms.Label();
            this.lbTimestamps = new System.Windows.Forms.ListBox();
            this.gbDetectedSilence = new System.Windows.Forms.GroupBox();
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
            this.btnRemoveSelectedWaitingFiles = new System.Windows.Forms.Button();
            this.btnClearWaitingFiles = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblError = new System.Windows.Forms.Label();
            this.lblFinishedProcessing = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCreateTimestamp = new System.Windows.Forms.GroupBox();
            this.lblErrorCustomTimestamp = new System.Windows.Forms.Label();
            this.btnCancelCustomTimestamp = new System.Windows.Forms.Button();
            this.btnSaveCustomTimestamp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomTimestamp = new System.Windows.Forms.TextBox();
            this.gbFilesToProcess.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbDetectedSilence.SuspendLayout();
            this.gbCreateTimestamp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpen.BackgroundImage")));
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.Location = new System.Drawing.Point(707, 6);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(6);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Padding = new System.Windows.Forms.Padding(6);
            this.btnOpen.Size = new System.Drawing.Size(51, 54);
            this.btnOpen.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnOpen, "Open a folder to load video files.");
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(76, 19);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(620, 28);
            this.txtPath.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtPath, "The path to the chosen folder.");
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Tempus Sans ITC", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPath.Location = new System.Drawing.Point(13, 19);
            this.lblPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(55, 26);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "Path:";
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.BackgroundImage")));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Location = new System.Drawing.Point(764, 6);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(51, 54);
            this.btnSettings.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnSettings, "Settings");
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // gbFilesToProcess
            // 
            this.gbFilesToProcess.Controls.Add(this.lvFilesToAnalyze);
            this.gbFilesToProcess.Location = new System.Drawing.Point(13, 68);
            this.gbFilesToProcess.Margin = new System.Windows.Forms.Padding(4);
            this.gbFilesToProcess.Name = "gbFilesToProcess";
            this.gbFilesToProcess.Padding = new System.Windows.Forms.Padding(4);
            this.gbFilesToProcess.Size = new System.Drawing.Size(820, 329);
            this.gbFilesToProcess.TabIndex = 8;
            this.gbFilesToProcess.TabStop = false;
            this.gbFilesToProcess.Text = "Files to analyze";
            // 
            // lvFilesToAnalyze
            // 
            this.lvFilesToAnalyze.AllowDrop = true;
            this.lvFilesToAnalyze.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvFilesToAnalyze.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvFilesToAnalyze.HideSelection = false;
            this.lvFilesToAnalyze.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvFilesToAnalyze.Location = new System.Drawing.Point(8, 29);
            this.lvFilesToAnalyze.Margin = new System.Windows.Forms.Padding(4);
            this.lvFilesToAnalyze.Name = "lvFilesToAnalyze";
            this.lvFilesToAnalyze.Size = new System.Drawing.Size(804, 290);
            this.lvFilesToAnalyze.TabIndex = 22;
            this.lvFilesToAnalyze.UseCompatibleStateImageBehavior = false;
            this.lvFilesToAnalyze.View = System.Windows.Forms.View.List;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnProcessSelected);
            this.groupBox2.Controls.Add(this.btnProcessFiles);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnClearProcessed);
            this.groupBox2.Controls.Add(this.btnRemoveSelectedProcessedFiles);
            this.groupBox2.Controls.Add(this.lbAnalyzed);
            this.groupBox2.Location = new System.Drawing.Point(13, 480);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(667, 368);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Analyzed Files";
            // 
            // btnProcessSelected
            // 
            this.btnProcessSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessSelected.Enabled = false;
            this.btnProcessSelected.Location = new System.Drawing.Point(437, 324);
            this.btnProcessSelected.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcessSelected.Name = "btnProcessSelected";
            this.btnProcessSelected.Size = new System.Drawing.Size(154, 31);
            this.btnProcessSelected.TabIndex = 15;
            this.btnProcessSelected.Text = "Process Selected";
            this.btnProcessSelected.UseVisualStyleBackColor = true;
            // 
            // btnProcessFiles
            // 
            this.btnProcessFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessFiles.Enabled = false;
            this.btnProcessFiles.Location = new System.Drawing.Point(300, 324);
            this.btnProcessFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcessFiles.Name = "btnProcessFiles";
            this.btnProcessFiles.Size = new System.Drawing.Size(130, 31);
            this.btnProcessFiles.TabIndex = 14;
            this.btnProcessFiles.Text = "Process Files";
            this.btnProcessFiles.UseVisualStyleBackColor = true;
            this.btnProcessFiles.Click += new System.EventHandler(this.btnProcessFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(273, 324);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "|";
            // 
            // btnClearProcessed
            // 
            this.btnClearProcessed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearProcessed.Enabled = false;
            this.btnClearProcessed.Location = new System.Drawing.Point(170, 324);
            this.btnClearProcessed.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearProcessed.Name = "btnClearProcessed";
            this.btnClearProcessed.Size = new System.Drawing.Size(96, 31);
            this.btnClearProcessed.TabIndex = 12;
            this.btnClearProcessed.Text = "Clear All";
            this.btnClearProcessed.UseVisualStyleBackColor = true;
            this.btnClearProcessed.Click += new System.EventHandler(this.btnClearProcessed_Click);
            // 
            // btnRemoveSelectedProcessedFiles
            // 
            this.btnRemoveSelectedProcessedFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveSelectedProcessedFiles.Enabled = false;
            this.btnRemoveSelectedProcessedFiles.Location = new System.Drawing.Point(8, 324);
            this.btnRemoveSelectedProcessedFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveSelectedProcessedFiles.Name = "btnRemoveSelectedProcessedFiles";
            this.btnRemoveSelectedProcessedFiles.Size = new System.Drawing.Size(154, 31);
            this.btnRemoveSelectedProcessedFiles.TabIndex = 11;
            this.btnRemoveSelectedProcessedFiles.Text = "Remove Selected";
            this.btnRemoveSelectedProcessedFiles.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedProcessedFiles.Click += new System.EventHandler(this.btnRemoveSelectedProcessedFiles_Click);
            // 
            // lbAnalyzed
            // 
            this.lbAnalyzed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAnalyzed.FormattingEnabled = true;
            this.lbAnalyzed.HorizontalScrollbar = true;
            this.lbAnalyzed.ItemHeight = 20;
            this.lbAnalyzed.Location = new System.Drawing.Point(8, 29);
            this.lbAnalyzed.Margin = new System.Windows.Forms.Padding(4);
            this.lbAnalyzed.Name = "lbAnalyzed";
            this.lbAnalyzed.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAnalyzed.Size = new System.Drawing.Size(640, 284);
            this.lbAnalyzed.TabIndex = 10;
            this.toolTip1.SetToolTip(this.lbAnalyzed, "Click an analyzed file to view it\'s silence.");
            this.lbAnalyzed.Click += new System.EventHandler(this.lbAnalyzed_Click);
            this.lbAnalyzed.SelectedIndexChanged += new System.EventHandler(this.lbAnalyzed_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalyze.Enabled = false;
            this.btnAnalyze.Location = new System.Drawing.Point(303, 405);
            this.btnAnalyze.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(96, 31);
            this.btnAnalyze.TabIndex = 10;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // lblLoadedFiles
            // 
            this.lblLoadedFiles.AutoSize = true;
            this.lblLoadedFiles.Location = new System.Drawing.Point(407, 411);
            this.lblLoadedFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoadedFiles.Name = "lblLoadedFiles";
            this.lblLoadedFiles.Size = new System.Drawing.Size(100, 20);
            this.lblLoadedFiles.TabIndex = 12;
            this.lblLoadedFiles.Text = "lblLoadedFiles";
            this.lblLoadedFiles.Visible = false;
            // 
            // lblCurrentRunningProcess
            // 
            this.lblCurrentRunningProcess.AutoSize = true;
            this.lblCurrentRunningProcess.Font = new System.Drawing.Font("Tempus Sans ITC", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentRunningProcess.Location = new System.Drawing.Point(13, 450);
            this.lblCurrentRunningProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentRunningProcess.Name = "lblCurrentRunningProcess";
            this.lblCurrentRunningProcess.Size = new System.Drawing.Size(253, 26);
            this.lblCurrentRunningProcess.TabIndex = 14;
            this.lblCurrentRunningProcess.Text = "lblCurrentRunningProcess";
            this.lblCurrentRunningProcess.Visible = false;
            // 
            // lbTimestamps
            // 
            this.lbTimestamps.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.gbDetectedSilence.Controls.Add(this.btnCreateTimestamp);
            this.gbDetectedSilence.Controls.Add(this.label4);
            this.gbDetectedSilence.Controls.Add(this.label3);
            this.gbDetectedSilence.Controls.Add(this.lblFileDuration);
            this.gbDetectedSilence.Controls.Add(this.lblSaveTimestampsStatus);
            this.gbDetectedSilence.Controls.Add(this.btnSaveTimestamps);
            this.gbDetectedSilence.Controls.Add(this.lblSelectedTimestamp);
            this.gbDetectedSilence.Controls.Add(this.btnRemoveSelectedTimestamp);
            this.gbDetectedSilence.Controls.Add(this.lbTimestamps);
            this.gbDetectedSilence.Location = new System.Drawing.Point(688, 480);
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
            // btnCreateTimestamp
            // 
            this.btnCreateTimestamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateTimestamp.Font = new System.Drawing.Font("Tempus Sans ITC", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateTimestamp.Location = new System.Drawing.Point(463, 62);
            this.btnCreateTimestamp.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreateTimestamp.Name = "btnCreateTimestamp";
            this.btnCreateTimestamp.Size = new System.Drawing.Size(36, 37);
            this.btnCreateTimestamp.TabIndex = 24;
            this.btnCreateTimestamp.Text = "+";
            this.toolTip1.SetToolTip(this.btnCreateTimestamp, "Insert Custom Timestamp.");
            this.btnCreateTimestamp.UseVisualStyleBackColor = true;
            this.btnCreateTimestamp.Click += new System.EventHandler(this.btnCreateTimestamp_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(8, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Duration of video:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Silence Start - Silence End => Duration";
            // 
            // lblFileDuration
            // 
            this.lblFileDuration.AutoSize = true;
            this.lblFileDuration.Location = new System.Drawing.Point(158, 59);
            this.lblFileDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileDuration.Name = "lblFileDuration";
            this.lblFileDuration.Size = new System.Drawing.Size(108, 20);
            this.lblFileDuration.TabIndex = 21;
            this.lblFileDuration.Text = "lblFileDuration";
            this.lblFileDuration.Visible = false;
            // 
            // lblSaveTimestampsStatus
            // 
            this.lblSaveTimestampsStatus.AutoSize = true;
            this.lblSaveTimestampsStatus.Location = new System.Drawing.Point(271, 328);
            this.lblSaveTimestampsStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaveTimestampsStatus.Name = "lblSaveTimestampsStatus";
            this.lblSaveTimestampsStatus.Size = new System.Drawing.Size(172, 20);
            this.lblSaveTimestampsStatus.TabIndex = 20;
            this.lblSaveTimestampsStatus.Text = "lblSaveTimestampsStatus";
            this.lblSaveTimestampsStatus.Visible = false;
            // 
            // btnSaveTimestamps
            // 
            this.btnSaveTimestamps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveTimestamps.Enabled = false;
            this.btnSaveTimestamps.Location = new System.Drawing.Point(170, 322);
            this.btnSaveTimestamps.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveTimestamps.Name = "btnSaveTimestamps";
            this.btnSaveTimestamps.Size = new System.Drawing.Size(96, 31);
            this.btnSaveTimestamps.TabIndex = 0;
            this.btnSaveTimestamps.Text = "Save";
            this.btnSaveTimestamps.UseVisualStyleBackColor = true;
            this.btnSaveTimestamps.Click += new System.EventHandler(this.btnSaveTimestamps_Click);
            // 
            // lblSelectedTimestamp
            // 
            this.lblSelectedTimestamp.AutoSize = true;
            this.lblSelectedTimestamp.Location = new System.Drawing.Point(8, 29);
            this.lblSelectedTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedTimestamp.Name = "lblSelectedTimestamp";
            this.lblSelectedTimestamp.Size = new System.Drawing.Size(152, 20);
            this.lblSelectedTimestamp.TabIndex = 19;
            this.lblSelectedTimestamp.Text = "lblSelectedTimestamp";
            this.lblSelectedTimestamp.Visible = false;
            // 
            // btnRemoveSelectedTimestamp
            // 
            this.btnRemoveSelectedTimestamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveSelectedTimestamp.Enabled = false;
            this.btnRemoveSelectedTimestamp.Location = new System.Drawing.Point(8, 322);
            this.btnRemoveSelectedTimestamp.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveSelectedTimestamp.Name = "btnRemoveSelectedTimestamp";
            this.btnRemoveSelectedTimestamp.Size = new System.Drawing.Size(154, 31);
            this.btnRemoveSelectedTimestamp.TabIndex = 18;
            this.btnRemoveSelectedTimestamp.Text = "Remove Selected";
            this.btnRemoveSelectedTimestamp.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedTimestamp.Click += new System.EventHandler(this.btnRemoveSelectedTimestamp_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnRemoveSelectedWaitingFiles
            // 
            this.btnRemoveSelectedWaitingFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveSelectedWaitingFiles.Enabled = false;
            this.btnRemoveSelectedWaitingFiles.Location = new System.Drawing.Point(13, 405);
            this.btnRemoveSelectedWaitingFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveSelectedWaitingFiles.Name = "btnRemoveSelectedWaitingFiles";
            this.btnRemoveSelectedWaitingFiles.Size = new System.Drawing.Size(154, 31);
            this.btnRemoveSelectedWaitingFiles.TabIndex = 19;
            this.btnRemoveSelectedWaitingFiles.Text = "Remove Selected";
            this.toolTip1.SetToolTip(this.btnRemoveSelectedWaitingFiles, "Highlight a file waiting to process then click this button to remove it from the " +
        "queue.");
            this.btnRemoveSelectedWaitingFiles.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedWaitingFiles.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnClearWaitingFiles
            // 
            this.btnClearWaitingFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearWaitingFiles.Enabled = false;
            this.btnClearWaitingFiles.Location = new System.Drawing.Point(175, 405);
            this.btnClearWaitingFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearWaitingFiles.Name = "btnClearWaitingFiles";
            this.btnClearWaitingFiles.Size = new System.Drawing.Size(96, 31);
            this.btnClearWaitingFiles.TabIndex = 20;
            this.btnClearWaitingFiles.Text = "Clear All";
            this.btnClearWaitingFiles.UseVisualStyleBackColor = true;
            this.btnClearWaitingFiles.Click += new System.EventHandler(this.btnClearWaitingFiles_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(6, 948);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(93, 20);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "errorMessage";
            this.lblError.Visible = false;
            // 
            // lblFinishedProcessing
            // 
            this.lblFinishedProcessing.AutoSize = true;
            this.lblFinishedProcessing.Location = new System.Drawing.Point(13, 948);
            this.lblFinishedProcessing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinishedProcessing.Name = "lblFinishedProcessing";
            this.lblFinishedProcessing.Size = new System.Drawing.Size(147, 20);
            this.lblFinishedProcessing.TabIndex = 21;
            this.lblFinishedProcessing.Text = "lblFinishedProcessing";
            this.lblFinishedProcessing.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(276, 404);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 30);
            this.label2.TabIndex = 16;
            this.label2.Text = "|";
            // 
            // gbCreateTimestamp
            // 
            this.gbCreateTimestamp.Controls.Add(this.lblErrorCustomTimestamp);
            this.gbCreateTimestamp.Controls.Add(this.btnCancelCustomTimestamp);
            this.gbCreateTimestamp.Controls.Add(this.btnSaveCustomTimestamp);
            this.gbCreateTimestamp.Controls.Add(this.label5);
            this.gbCreateTimestamp.Controls.Add(this.txtCustomTimestamp);
            this.gbCreateTimestamp.Location = new System.Drawing.Point(937, 338);
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
            this.lblErrorCustomTimestamp.Size = new System.Drawing.Size(167, 20);
            this.lblErrorCustomTimestamp.TabIndex = 4;
            this.lblErrorCustomTimestamp.Text = "You must input a value.";
            this.lblErrorCustomTimestamp.Visible = false;
            // 
            // btnCancelCustomTimestamp
            // 
            this.btnCancelCustomTimestamp.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.label5.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Silence Start:";
            // 
            // txtCustomTimestamp
            // 
            this.txtCustomTimestamp.Location = new System.Drawing.Point(119, 27);
            this.txtCustomTimestamp.Name = "txtCustomTimestamp";
            this.txtCustomTimestamp.Size = new System.Drawing.Size(100, 28);
            this.txtCustomTimestamp.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1250, 1029);
            this.Controls.Add(this.gbCreateTimestamp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFinishedProcessing);
            this.Controls.Add(this.btnClearWaitingFiles);
            this.Controls.Add(this.btnRemoveSelectedWaitingFiles);
            this.Controls.Add(this.gbDetectedSilence);
            this.Controls.Add(this.lblCurrentRunningProcess);
            this.Controls.Add(this.lblLoadedFiles);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbFilesToProcess);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnOpen);
            this.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BachFlix Audio File Analyzer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbFilesToProcess.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbAnalyzed;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label lblLoadedFiles;
        private System.Windows.Forms.Label lblCurrentRunningProcess;
        private System.Windows.Forms.ListBox lbTimestamps;
        private System.Windows.Forms.GroupBox gbDetectedSilence;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnRemoveSelectedWaitingFiles;
        private System.Windows.Forms.Button btnClearWaitingFiles;
        private System.Windows.Forms.Button btnRemoveSelectedProcessedFiles;
        private System.Windows.Forms.Button btnClearProcessed;
        private System.Windows.Forms.Button btnRemoveSelectedTimestamp;
        private System.Windows.Forms.Label lblSelectedTimestamp;
        private System.Windows.Forms.Button btnSaveTimestamps;
        private System.Windows.Forms.Label lblSaveTimestampsStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFileDuration;
        private System.Windows.Forms.Button btnProcessFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProcessSelected;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblFinishedProcessing;
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
    }
}

