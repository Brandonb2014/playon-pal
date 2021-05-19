////////////////////////////////////////////////////////////////////////////////////
/// PlayonPal Uses the FFmpeg library to detect silence found in video recordings if you use the PlayOn TV Desktop version.
/// Then removes the silence from the beginning and end of the file.

/// Copyright (C) 2021 Brandon Birschbach (BrandonTech) brandon.birschbach@gmail.com

/// This library is free software; you can redistribute it and/or
/// modify it under the terms of the GNU Lesser General Public
/// License as published by the Free Software Foundation; either
/// version 2.1 of the License, or (at your option) any later version.

/// This library is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
/// Lesser General Public License for more details.

/// You should have received a copy of the GNU Lesser General Public
/// License along with this library; if not, write to the Free Software
/// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace BachFlixAudioAnalyzer
{
    public partial class Form1 : Form
    {
        private Settings mySettings = new Settings();
        private bool keepAnalyzing = true;
        private bool keepProcessing = true;
        private bool currentlyAnalyzing = false;
        private bool currentlyProcessing = false;
        private string _cleanedCount;

        public Form1()
        {
            InitializeComponent();
            ReadCleanCountFile();
            PopulateCleanedCount();
        }

        /// <summary>
        /// The action when the Open button is clicked.
        /// This button opens up the folder explorer for the user to pick a folder that has the videos they want analyzed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Open folder browser dialog.
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // Set path to textbox.
                    txtPath.Text = fbd.SelectedPath;
                    PopulatelvFilesToAnalyze(fbd.SelectedPath);
                }
            }
        }

        private void PopulatelvFilesToAnalyze(string directoryLocation)
        {
            // Clear all videos in the files to analyze listView, and the analyzed listBox.
            lvFilesToAnalyze.Items.Clear();
            gbCreateTimestamp.Visible = false;
            gbDetectedSilence.Visible = false;

            var files = Directory.GetFiles(directoryLocation);
            foreach (string item in files)
            {
                // For now, it's only looking for mp4 files. This may need to be expanded to include other formats.
                // However, this program is intended for PlayOn recordings which are only in mp4 format.
                if (Path.GetExtension(item) == ".mp4")
                {
                    FileInfo fi = new FileInfo(item);
                    lvFilesToAnalyze.Items.Add(fi.Name);
                }
            }

            // If the user selected a folder that had video files to process, then it will enable the following buttons.
            if (lvFilesToAnalyze.Items.Count > 0)
            {
                btnAnalyze.Enabled =
                btnReAnalyzeFiles.Enabled =
                btnRemoveSelectedWaitingFiles.Enabled =
                btnClearWaitingFiles.Enabled =
                btnGrabFilesFromChosenPath.Enabled =
                btnLeftArrow.Enabled =
                btnRightArrow.Enabled = true;
                UpdateFilesToAnalyzeCount();
            }
        }

        private void UpdateFilesToAnalyzeCount()
        {
            int count = lvFilesToAnalyze.Items.Count;
            string plural = (count == 1) ? " File " : " Files ";
            string text = "";
            string process = (btnProcessFiles.Enabled == true) ? " process." : " analyze.";


            if (count > 0)
            {
                text += count + plural + "waiting to" + process;
            } else
            {
                text += count + plural + "selected. Click 'Open' to add different files.";
                btnAnalyze.Enabled = false;
                btnReAnalyzeFiles.Enabled = false;
                btnRemoveSelectedWaitingFiles.Enabled = false;
                btnClearWaitingFiles.Enabled = false;
            }
            lblCurrentRunningProcess.Visible = true;
            lblCurrentRunningProcess.Text = text;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings settingsForm = new frmSettings();
            settingsForm.Show();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            checkFileForSilence(false);
        }
        private void btnReAnalyzeFiles_Click(object sender, EventArgs e)
        {
            checkFileForSilence(true);
        }

        private async void checkFileForSilence(bool reAnalyzeFile)
        {
            btnOpen.Enabled =
            btnSettings.Enabled =
            btnRemoveSelectedWaitingFiles.Enabled =
            btnClearWaitingFiles.Enabled =
            btnAnalyze.Enabled =
            btnReAnalyzeFiles.Enabled =
            btnProcessFiles.Enabled =
            btnGrabFilesFromChosenPath.Enabled = false;

            btnStopAnalyze.Visible =
            currentlyAnalyzing = true;

            ReadSettingsFile();
            lblCurrentRunningProcess.Visible = false;

            // First, step through each item and ensure the colors are black.
            for (var i = 0; i < lvFilesToAnalyze.Items.Count; i++)
            {
                lvFilesToAnalyze.Items[i].ForeColor = Color.White;
            }

            // Then, if the files are to be re-analyzed remove any existing timestamp txt files.
            if (reAnalyzeFile)
            {
                for (var i = 0; i < lvFilesToAnalyze.Items.Count; i++)
                {
                    string selectedFile = lvFilesToAnalyze.Items[i].Text.Substring(0, lvFilesToAnalyze.Items[i].Text.Length - 4);
                    string wd = Path.Combine(Application.StartupPath, "SilenceDetection");
                    string fn = selectedFile + "-timestamp.txt";

                    File.Delete(Path.Combine(wd, fn));
                }
            }

            Directory.CreateDirectory(Application.StartupPath + "\\SilenceDetection");

            for (var i = 0; i < lvFilesToAnalyze.Items.Count; i++)
            {
                if (keepAnalyzing)
                {
                    var file = lvFilesToAnalyze.Items[i].Text.ToString();
                    var fullPathToFile = Path.Combine(txtPath.Text, file);
                    var fileWithoutExtension = Path.GetFileNameWithoutExtension(file);
                    string textFile = Path.Combine(Application.StartupPath, "SilenceDetection", fileWithoutExtension + "-timestamp.txt");
                    lvFilesToAnalyze.Items[i].ForeColor = Color.DeepSkyBlue;

                    UpdateStatusLabel("Analyzing '" + file + "' for silence.");

                    if (!File.Exists(textFile) || reAnalyzeFile)
                    {
                        var command = "ffmpeg -y -nostats -i \"" + fullPathToFile + "\" -af silencedetect=n=" + mySettings.silenceDetection + ":d=" + mySettings.silenceDuration + " -f null - 2> SilenceDetection\\\"" + fileWithoutExtension + "\".txt";
                        await Task.Run(() =>
                        {
                            RunCommand(command);
                        });

                        CleanTextFile(fileWithoutExtension);
                    }

                    setListViewItemColor(lvFilesToAnalyze.Items[i].Text.ToString());

                    UpdateStatusLabel("Done.");


                    this.Refresh();
                }
            }
            btnOpen.Enabled =
            btnSettings.Enabled =
            btnRemoveSelectedWaitingFiles.Enabled =
            btnClearWaitingFiles.Enabled =
            btnAnalyze.Enabled =
            btnReAnalyzeFiles.Enabled =
            btnProcessFiles.Enabled =
            keepAnalyzing =
            btnStopAnalyze.Enabled =
            btnGrabFilesFromChosenPath.Enabled = true;

            btnStopAnalyze.Visible =
            lblStopProcessing.Visible =
            currentlyAnalyzing = false;

            UpdateFilesToAnalyzeCount();
            UpdateFilesAnalyzedCount();
        }

        private void setListViewItemColor(string file)
        {
            var numOfTimestamps = countTimestamps(Path.GetFileNameWithoutExtension(file));

            for (var i = 0; i < lvFilesToAnalyze.Items.Count; i++)
            {
                if (lvFilesToAnalyze.Items[i].Text.ToString() == file)
                {
                    if (numOfTimestamps == 2)
                    {
                        lvFilesToAnalyze.Items[i].ForeColor = Color.Green;
                    }
                    else
                    {
                        lvFilesToAnalyze.Items[i].ForeColor = Color.Yellow;
                    }
                }
            }
        }

        private int countTimestamps(string file)
        {
            try
            {
                List<string> lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "SilenceDetection", file + "-timestamp.txt")).ToList();

                if (lines.Count >= 0)
                {
                    return lines.Count;
                } else
                {
                    return -1;
                }

            }
            catch (Exception exc)
            {
                lblError.Visible = true;
                lblError.Text = exc.Message;
                throw;
            }
        }

        private void btnRefreshTimestamps_Click(object sender, EventArgs e)
        {
            var file = lblSelectedTimestamp.Text.ToString();
            var fileWithoutExtension = Path.GetFileNameWithoutExtension(file);
            string textFile = Path.Combine(Application.StartupPath, "SilenceDetection", fileWithoutExtension);

            if (File.Exists(textFile + ".txt"))
            {
                CleanTextFile(textFile);
                loadTimestamps(Path.Combine(Application.StartupPath, "SilenceDetection"), fileWithoutExtension + "-timestamp.txt");
            } else
            {

            }

        }

        /// <summary>
        /// Reads our settings.txt file to get the user's chosen settings.
        /// </summary>
        private void ReadSettingsFile()
        {
            // Read each line from the txt file into an array.
            List<string> lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "settings.txt")).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                switch (entries[0])
                {
                    case "silenceDetection":
                        mySettings.silenceDetection = entries[1];
                        break;
                    case "silenceDuration":
                        mySettings.silenceDuration = entries[1];
                        break;
                    case "vlcLocation":
                        mySettings.vlcLocation = entries[1];
                        break;
                    case "outputLocation":
                        mySettings.outputLocation = entries[1];
                        break;
                    case "deleteOriginal":
                        mySettings.deleteOriginal = entries[1];
                        break;
                    case "removeSplashScreens":
                        mySettings.removeSplashScreens = entries[1];
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Reads the cleanCount.txt file to get the user's chosen settings.
        /// </summary>
        private void ReadCleanCountFile()
        {
            // Read each line from the txt file into an array.
            List<string> lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "cleanCount.txt")).ToList();

            _cleanedCount = lines[0];
        }

        private void IncrementCleanedCount()
        {
            int count = int.Parse(_cleanedCount);
            count++;
            _cleanedCount = count.ToString();

            SaveCleanCountFile();
            PopulateCleanedCount();
        }

        private void SaveCleanCountFile()
        {
            try
            {
                // Create an arrayList to save to the cleanCount.txt file.
                List<string> arrlist = new List<string>();
                arrlist.Add(_cleanedCount);

                // Write the arrayList to the cleanCount.txt file.
                // Each line is a different setting.
                File.WriteAllLines(Path.Combine(Application.StartupPath, "cleanCount.txt"), arrlist);
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                throw;
            }
        }

        private void PopulateCleanedCount()
        {
            lblCleanedCount.Text = String.Format("{0:n0}", int.Parse(_cleanedCount));
        }
        
        /// <summary>
        /// Updates the text to the status label.
        /// </summary>
        /// <param name="text">The text to be written to the status label.</param>
        private void UpdateStatusLabel(string text)
        {
            lblCurrentRunningProcess.Visible = true;
            lblCurrentRunningProcess.Text = text;
            this.Refresh();
        }

        /// <summary>
        /// Takes the txt file that has just ran through silence detection and removes all the jargon to get just the silence_start, silence_end and silence_duration numbers.
        /// </summary>
        /// <param name="file">The name of the file without it's extension that was just analyzed.</param>
        private void CleanTextFile(string file)
        {
            try
            {
                List<string> arrlist = new List<string>();
                string text = "";
                string wd = Path.Combine(Application.StartupPath, "SilenceDetection");
                string i = file + ".txt";
                string o = file + "-timestamp.txt";
                List<string> lines = File.ReadAllLines(Path.Combine(wd, i)).ToList();
                int id = 1;
                string silenceStartText = "silence_start: ",
                        silenceEndText = "silence_end: ",
                        silenceDurationText = "silence_duration: ",
                        fileDurationText = "Duration: ",
                        silenceStart = "0",
                        silenceEnd = "0",
                        silenceDuration = "0",
                        fileDuration = "0";

                foreach (string line in lines)
                {
                    if (line.IndexOf(fileDurationText) > -1)
                    {
                        fileDuration = line.Substring(line.IndexOf(fileDurationText) + fileDurationText.Length, line.IndexOf(",") - (line.IndexOf(fileDurationText) + fileDurationText.Length));
                        string[] split = fileDuration.Split('.');
                        fileDuration = split[0];

                    }
                    if (line.IndexOf(silenceStartText) > -1)
                    {
                        silenceStart = line.Substring(line.IndexOf(silenceStartText) + silenceStartText.Length);
                    }
                    if (line.IndexOf(silenceEndText) > -1)
                    {
                        silenceEnd = line.Substring(line.IndexOf(silenceEndText) + silenceEndText.Length, line.IndexOf(" | ") - (line.IndexOf(silenceEndText) + silenceEndText.Length));
                        silenceDuration = line.Substring(line.IndexOf(silenceDurationText) + silenceDurationText.Length);

                        text = id + "," + ConvertSecondsToTime(double.Parse(silenceStart)) + "," + ConvertSecondsToTime(double.Parse(silenceEnd)) + "," + ConvertSecondsToTime(double.Parse(silenceDuration)) + "," + fileDuration;
                        arrlist.Add(text);
                        text = "";
                        id++;
                    }


                }

                if (arrlist.Count > 0)
                {
                    File.WriteAllLines(Path.Combine(wd, o), arrlist);
                }
                else
                {
                    arrlist.Add("1,0,0,0," + fileDuration);
                    File.WriteAllLines(Path.Combine(wd, o), arrlist);
                }
            }
            catch (Exception exc)
            {
                lblError.Visible = true;
                lblError.Text = exc.Message;
                throw;
            }
        }

        private void loadTimestamps(string wd, string fn)
        {
            lbTimestamps.Items.Clear();

            List<Timestamp> timestamps = new List<Timestamp>();

            // Read each line from the txt file into an array.
            List<string> lines = File.ReadAllLines(Path.Combine(wd, fn)).ToList();

            if (lines.Count > 0)
            {
                // Split the lines on the commas.
                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    lblFileDuration.Text = entries[4];

                    if (entries[3] != "0")
                    {
                        Timestamp newTimestamp = new Timestamp();

                        newTimestamp.lineId = entries[0];
                        newTimestamp.silenceStart = entries[1];
                        newTimestamp.silenceEnd = entries[2];
                        newTimestamp.silenceDuration = entries[3];

                        timestamps.Add(newTimestamp);
                    }

                }

                if (timestamps.Count > 0)
                {
                    // Display the data to the lbTimestamps.
                    foreach (var timestamp in timestamps)
                    {
                        lbTimestamps.Items.Add($"{timestamp.lineId }) { timestamp.silenceStart } - { timestamp.silenceEnd } => { timestamp.silenceDuration }");
                    }
                }
                else
                {
                    lbTimestamps.Items.Add("No silence found for this file.");
                    lbTimestamps.Items.Add("You may need to adjust the silence detection in Settings.");
                }
            }
            else
            {
                lbTimestamps.Items.Add("No silence found for this file.");
                lbTimestamps.Items.Add("You may need to adjust the silence detection in Settings.");
            }
        }

        // Convert the seconds time to hh:MM:ss format.
        private string ConvertSecondsToTime(double sec)
        {
            try
            {
                TimeSpan t = TimeSpan.FromSeconds(sec);
                string answer = "0";
                if (t.Hours > 0) answer += t.Hours + ":";
                if (t.Minutes > 0) answer += t.Minutes + ":"; else if (t.Hours > 0) answer += "00:";
                if (t.Seconds > 0) answer += t.Seconds; else if (t.Hours > 0 || t.Minutes > 0) answer += "00";
                //if (t.Milliseconds > 0) answer += t.Milliseconds; else if (t.Hours > 0 || t.Minutes > 0 || t.Seconds > 0) answer += "00";

                return t.ToString("hh\\:mm\\:ss\\.ff");
            }
            catch (Exception)
            {
                return sec.ToString();
            }
        }

        // Convert the seconds time to hh:MM:ss.xxx format.
        private string ConvertTimeToSeconds(string time)
        {
            try
            {
                float seconds = 0;
                string[] split = time.Split(':');

                if (split.Count() == 1)
                {
                    seconds = float.Parse(split[0]);
                }
                else if (split.Count() == 2)
                {
                    seconds = (float.Parse(split[0]) * 60) + float.Parse(split[1]);
                }
                else if (split.Count() == 3)
                {
                    seconds = (float.Parse(split[0]) * 3600) + (float.Parse(split[1]) * 60) + float.Parse(split[2]);
                }

                return seconds.ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (lvFilesToAnalyze.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < lvFilesToAnalyze.SelectedIndices.Count; i = 0)
                {
                    lvFilesToAnalyze.Items.RemoveAt(lvFilesToAnalyze.SelectedIndices[i]);
                }
                UpdateFilesToAnalyzeCount();
            }

            if (lvFilesToAnalyze.Items.Count > 0)
            {
                btnLeftArrow.Enabled =
                btnRightArrow.Enabled = true;
            }
            else
            {
                btnLeftArrow.Enabled =
                btnRightArrow.Enabled = false;
            }
        }

        private void lbTimestamps_DoubleClick(object sender, EventArgs e)
        {

            if (lbTimestamps.SelectedItems.Count > 0)
            {
                try
                {
                    lblSaveTimestampsStatus.Text = "Opening VLC, standby.";
                    lblSaveTimestampsStatus.Visible = true;
                    this.Refresh();

                    string timeStamps = lbTimestamps.SelectedItem.ToString().Substring(lbTimestamps.SelectedItem.ToString().IndexOf(")") + 1, lbTimestamps.SelectedItem.ToString().IndexOf("=") - 2).Trim();
                    string[] entries = timeStamps.Split('-');
                    string silenceStart = ConvertTimeToSeconds(entries[0].Trim());
                    string silenceEnd = ConvertTimeToSeconds(entries[1].Trim());
                    string fn = Path.Combine(txtPath.Text, lblSelectedTimestamp.Text);
                    string vlcPath = "";

                    silenceStart = AdjustTime(silenceStart, -1);
                    silenceEnd = AdjustTime(silenceEnd, 0.5);

                    if (Directory.Exists("C:\\Program Files\\VideoLAN\\VLC"))
                        vlcPath = @"C:\Program Files\VideoLAN\VLC";
                    else if (Directory.Exists("C:\\Program Files (x86)\\VideoLAN\\VLC"))
                        vlcPath = @"C:\Program Files (x86)\VideoLAN\VLC";
                    else
                        vlcPath = mySettings.vlcLocation;

                    if (vlcPath != "")
                    {
                        var playVideo = "start \"" + vlcPath + "\\vlc.exe\" vlc \"" + fn + "\" --start-time " + silenceStart + " --stop-time " + silenceEnd + " vlc://quit";
                        RunCommand(playVideo);
                    }
                    else
                    {
                        lblError.Text = "Path to Video Lan was not found. Go to Settings and fill in the path to the folder that holds the vlc.exe file.";
                        lblError.Visible = true;
                    }

                    lblSaveTimestampsStatus.Visible = false;
                    this.Refresh();
                }
                catch (Exception)
                {
                    lblSaveTimestampsStatus.Text = "Whoa, try again.";
                }
            }
        }

        private string AdjustTime(string time, double adjustAmount)
        {
            double newTime = double.Parse(time) + adjustAmount;
            return newTime.ToString();
        }

        private void btnClearWaitingFiles_Click(object sender, EventArgs e)
        {
            lvFilesToAnalyze.Items.Clear();
            btnLeftArrow.Enabled =
            btnRightArrow.Enabled = false;
            UpdateFilesToAnalyzeCount();
        }

        private void UpdateFilesAnalyzedCount()
        {
            if (lvFilesToAnalyze.Items.Count > 0)
            {
                btnRemoveSelectedWaitingFiles.Enabled =
                btnClearWaitingFiles.Enabled =
                btnAnalyze.Enabled =
                btnReAnalyzeFiles.Enabled =
                btnProcessFiles.Enabled = true;
            } else
            {
                btnRemoveSelectedWaitingFiles.Enabled =
                btnClearWaitingFiles.Enabled =
                btnAnalyze.Enabled =
                btnReAnalyzeFiles.Enabled =
                btnProcessFiles.Enabled =
                gbDetectedSilence.Visible = false;
            }

            //if (currentlyAnalyzing) btnProcessFiles.Enabled = false;
            //else btnProcessFiles.Enabled = true;
        }

        private void btnRemoveSelectedTimestamp_Click(object sender, EventArgs e)
        {
            if (lbTimestamps.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < lbTimestamps.SelectedIndices.Count; i = 0)
                {
                    lbTimestamps.Items.RemoveAt(lbTimestamps.SelectedIndices[i]);
                }
                lbTimestamps.SelectedItems.Clear();
            }
        }

        private void btnSaveTimestamps_Click(object sender, EventArgs e)
        {
            SaveTimestamps();
        }

        private void SaveTimestamps()
        {
            string wd = Path.Combine(Application.StartupPath, "SilenceDetection");
            string file = lblSelectedTimestamp.Text;
            string o = Path.GetFileNameWithoutExtension(file) + "-timestamp.txt";

            saveListToTimestampFile(wd, o);

            loadTimestamps(wd, o);

            setListViewItemColor(file);
        }

        private void saveListToTimestampFile(string wd, string o)
        {
            try
            {
                List<string> newTimestampsLineIdList = new List<string>();
                List<string> newTimestampsList = new List<string>();
                List<string> originalTimestamps = File.ReadAllLines(Path.Combine(wd, o)).ToList();
                int newId = 1;

                if (lbTimestamps.Items.Count > 0)
                {
                    // Step through the list box of timestamps and put the line id into a new array.
                    foreach (string line in lbTimestamps.Items)
                    {
                        string lineId = line.Substring(0, line.IndexOf(")"));
                        newTimestampsLineIdList.Add(lineId);
                    }

                    // Now step through the existing timestamps and add the chosen ones back to the newTimestampsList.
                    foreach (string timestamp in originalTimestamps)
                    {
                        string lineId = timestamp.Substring(0, timestamp.IndexOf(","));
                        if (newTimestampsLineIdList.Contains(lineId))
                        {
                            string newTimestamp = newId + timestamp.Substring(timestamp.IndexOf(","));
                            newTimestampsList.Add(newTimestamp);

                            newId++;
                        }
                    }

                    if (newTimestampsList.Count > 0)
                    {
                        File.WriteAllLines(Path.Combine(wd, o), newTimestampsList);
                    }
                    else
                    {
                        File.WriteAllText(Path.Combine(wd, o), "");
                    }
                }

                lblSaveTimestampsStatus.Visible = true;
                lblSaveTimestampsStatus.Text = "New timestamp list saved.";
            }
            catch (Exception exc)
            {
                lblSaveTimestampsStatus.Visible = true;
                lblSaveTimestampsStatus.Text = exc.Message;
                throw;
            }
        }

        private async void btnProcessFiles_Click(object sender, EventArgs e)
        {
            ReadSettingsFile();
            UpdateStatusLabel("Removing silence");

            // Clear the TimeStamps listbox.
            lbTimestamps.Items.Clear();

            // Hide the labels in the Silence Timestamps group box.
            lblSelectedTimestamp.Visible =
            lblFileDuration.Visible =
            lblSaveTimestampsStatus.Visible = false;

            // Disable the buttons in the Silence Timestamps group box.
            btnRemoveSelectedTimestamp.Enabled =
            btnSaveTimestamps.Enabled = false;

            // Hide the Silence Timestamps group box.
            gbDetectedSilence.Visible = false;

            // Hide the error message.
            lblError.Visible = false;

            // Disable the buttons in the Files group box.
            btnOpen.Enabled =
            btnSettings.Enabled =
            btnRemoveSelectedWaitingFiles.Enabled =
            btnClearWaitingFiles.Enabled =
            btnAnalyze.Enabled =
            btnReAnalyzeFiles.Enabled =
            btnProcessFiles.Enabled =
            btnGrabFilesFromChosenPath.Enabled = false;

            // Show the stop button.
            btnStopAnalyze.Visible = true;

            currentlyProcessing = true;


            // First, step through each item and ensure the colors are White.
            for (var i = 0; i < lvFilesToAnalyze.Items.Count; i++)
            {
                lvFilesToAnalyze.Items[i].ForeColor = Color.White;
            }

            // Create the directory that will hold the text files that have the silence timestamps.
            string sd = Path.Combine(Application.StartupPath, "SilenceDetection");
            Directory.CreateDirectory(sd);
            string wd = Path.Combine(Application.StartupPath, "FilesProcessing");
            Directory.CreateDirectory(wd);

            // Create the directory that will hold the cut video files while processing.
            FileInfo f = new FileInfo(txtPath.Text);
            string driveLetter = Path.GetPathRoot(f.FullName);
            string playonPalDirectory = Path.Combine(driveLetter, "PlayonPal Processes");
            Directory.CreateDirectory(playonPalDirectory);
            string processingDirectory = Path.Combine(playonPalDirectory, "Processing");
            Directory.CreateDirectory(processingDirectory);
            string saveDirectory = (mySettings.outputLocation == "") ? playonPalDirectory : mySettings.outputLocation;




            try
            {
                for (var i = 0; i < lvFilesToAnalyze.Items.Count; i++)
                {
                    if (keepProcessing)
                    {
                        lvFilesToAnalyze.Items[i].ForeColor = Color.DeepSkyBlue;

                        string selectedFile = lvFilesToAnalyze.Items[i].Text.Substring(0, lvFilesToAnalyze.Items[i].Text.Length - 4),
                                fileName = selectedFile + "-timestamp.txt",
                                file = Path.Combine(txtPath.Text, selectedFile);

                        if (File.Exists(Path.Combine(sd, fileName)))
                        {
                            // Read each line from the txt file into an array.
                            List<string> lines = File.ReadAllLines(Path.Combine(sd, fileName)).ToList();

                            // Create the array that holds the names of the video file parts so we can concatenate the files together later.
                            List<string> arrlist = new List<string>();

                            UpdateStatusLabel("Removing silence from: '" + selectedFile + "'");

                            if (lines.Count == 1)
                            {
                                ////////////////////////////////
                                ///          NOTE:
                                ///          This if is going to need some refactoring.
                                ///          Either we remove this single timestamp functionality entirely,
                                ///          or we just assume the file has splash screens and we need to preserve them.
                                ///          


                                // Split the lines on the commas.
                                string[] entries = lines[0].Split(',');

                                // Run the command to get the opening splash screen.
                                if (mySettings.removeSplashScreens.ToUpper() == "FALSE")
                                {
                                    await Task.Run(() =>
                                    {
                                        RunCommand("ffmpeg -y -i \"" + file + ".mp4\" -t 4 -c copy \"FilesProcessing\\splash.mp4\"");
                                    });
                                }

                                if (entries[1] == "00:00:00.00")
                                {
                                    // Run the command to remove the silence from the beginning of the file.
                                    await Task.Run(() =>
                                    {
                                        RunCommand("ffmpeg -y -ss " + entries[2] + " -i \"" + file + ".mp4\" -c copy \"FilesProcessing\\main.mp4\"");
                                    });

                                    // Push the files to the array list in this specific order.
                                    if (mySettings.removeSplashScreens.ToUpper() == "FALSE") arrlist.Add("file '" + wd + "\\splash.mp4'");
                                    arrlist.Add("file '" + wd + "\\main.mp4'");

                                    // Now write the array lines to the text file.
                                    File.WriteAllLines(Path.Combine(wd, "files.txt"), arrlist);

                                    // Finally, concat the files together to one.
                                    await Task.Run(() =>
                                    {
                                        RunCommand("ffmpeg -y -f concat -safe 0 -i \"FilesProcessing\\files.txt\" -c copy \"" + saveDirectory + "\\" + selectedFile + ".mp4\"");
                                    });
                                }
                                else
                                {
                                    // Run the command to remove the silence from the end of the file.
                                    await Task.Run(() =>
                                    {
                                        RunCommand("ffmpeg -y -i \"" + file + ".mp4\" -t " + entries[1] + " -c copy \"FilesProcessing\\main.mp4\"");
                                    });

                                    // Push the files to the array list in this specific order.
                                    arrlist.Add("file '" + wd + "\\main.mp4'");
                                    if (mySettings.removeSplashScreens.ToUpper() == "FALSE") arrlist.Add("file '" + wd + "\\splash.mp4'");

                                    // Now write the array lines to the text file.
                                    File.WriteAllLines(Path.Combine(wd, "files.txt"), arrlist);

                                    // Finally, concat the files together to one.
                                    await Task.Run(() =>
                                    {
                                        RunCommand("ffmpeg -y -f concat -safe 0 -i \"FilesProcessing\\files.txt\" -c copy \"" + saveDirectory + "\\" + selectedFile + ".mp4\"");
                                    });
                                }
                            }
                            else if (lines.Count > 1)
                            {
                                int taskCount = 1,
                                    tasks = 4;
                                if (mySettings.removeSplashScreens.ToUpper() == "TRUE")
                                {
                                    tasks = 2;
                                }
                                if (mySettings.deleteOriginal.ToUpper() == "TRUE")
                                {
                                    tasks++;
                                }
                                // Split the lines on the commas for both timestamps.
                                string[] split1 = lines[0].Split(',');
                                string[] split2 = lines.Last().Split(',');

                                // The beginningStamp is going to the silence_end time from the first line in the txt file.
                                TimeSpan beginningStamp = TimeSpan.Parse(split1[2]);
                                // The endingStamp is the silence_start of the second line in the txt file, but we need to subtract the beginning stamp from it so we take that removed time into account when getting the main video part.
                                TimeSpan endingStamp = TimeSpan.Parse(split2[1]) - beginningStamp;


                                if (mySettings.removeSplashScreens.ToUpper() == "FALSE")
                                    arrlist.Add("file '" + processingDirectory + "\\splash.mp4'");

                                arrlist.Add("file '" + processingDirectory + "\\main.mp4'");

                                if (mySettings.removeSplashScreens.ToUpper() == "FALSE")
                                    arrlist.Add("file '" + processingDirectory + "\\splash.mp4'");

                                File.WriteAllLines(Path.Combine(wd, "files.txt"), arrlist);

                                // Run the command to get the opening splash screen.
                                if (mySettings.removeSplashScreens.ToUpper() == "FALSE")
                                {
                                    UpdateStatusLabel(taskCount++ + " of " + tasks + " - Slicing the splash screen from the file.");
                                    await Task.Run(() =>
                                    {
                                        RunCommand("ffmpeg -y -i \"" + file + ".mp4\" -t 4 -c copy \"" + processingDirectory + "\\splash.mp4\"");
                                    });
                                }

                                UpdateStatusLabel(taskCount++ + " of " + tasks + " - Slicing the main content from the file.");
                                // Run the command to remove the silence from the beginning and end of the file.
                                await Task.Run(() =>
                                {
                                    RunCommand("ffmpeg -y -ss " + beginningStamp + " -i \"" + file + ".mp4\" -t " + endingStamp + " -c copy \"" + processingDirectory + "\\main.mp4\"");
                                });

                                // Now, concat the files together to one (If they requested to keep the splash screens).
                                if (mySettings.removeSplashScreens.ToUpper() == "FALSE")
                                {
                                    UpdateStatusLabel(taskCount++ + " of " + tasks + " - Concatenating the splash screens back onto the main file.");
                                    await Task.Run(() =>
                                    {
                                        RunCommand("ffmpeg -y -f concat -safe 0 -i \"FilesProcessing\\files.txt\" -c copy \"" + processingDirectory + "\\" + selectedFile + ".mp4\"");
                                    });
                                }

                                UpdateStatusLabel(taskCount++ + " of " + tasks + " - Moving the file to chosen directory.");
                                // Finally, move the finished file to the chosen directory.
                                if (File.Exists(processingDirectory + "\\" + selectedFile + ".mp4"))
                                {
                                    await Task.Run(() =>
                                    {
                                        File.Move(processingDirectory + "\\" + selectedFile + ".mp4", saveDirectory + "\\" + selectedFile + ".mp4");
                                    });

                                    File.Delete(processingDirectory + "\\main.mp4");
                                    File.Delete(processingDirectory + "\\splash.mp4");
                                }
                                else
                                {
                                    await Task.Run(() =>
                                    {
                                        File.Move(processingDirectory + "\\main.mp4", saveDirectory + "\\" + selectedFile + ".mp4");
                                    });
                                }

                            }
                            //else if (lines.Count > 2)
                            //{
                            //    lblError.Text = fileName + " has too many lines to read. We are not yet prepared to handle more than 2 timestamps.";
                            //    lblError.Visible = true;
                            //    break;
                            //}
                            else
                            {
                                lblError.Text = fileName + " has no lines to read.";
                                lblError.Visible = true;
                                break;
                            }

                            if (mySettings.deleteOriginal.ToUpper() == "TRUE")
                            {
                                UpdateStatusLabel("Deleting original file.");
                                File.Delete(file + ".mp4");
                            }
                            lvFilesToAnalyze.Items[i].ForeColor = Color.Green;

                            lvFilesToAnalyze.Items[i].Remove();
                            i--;
                            UpdateStatusLabel("Done.");
                        } else
                        {
                            lvFilesToAnalyze.Items[i].ForeColor = Color.Yellow;
                        }
                    }
                    IncrementCleanedCount();
                }
                UpdateStatusLabel("Done.");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                throw;
            }

            btnOpen.Enabled =
            btnSettings.Enabled =
            btnStopAnalyze.Enabled =
            keepProcessing = true;

            if (lvFilesToAnalyze.Items.Count > 0)
            {
                btnLeftArrow.Enabled =
                btnRightArrow.Enabled = true;
            } else
            {
                btnLeftArrow.Enabled =
                btnRightArrow.Enabled = false;
            }

            if (txtPath.Text != "")
            {
                btnGrabFilesFromChosenPath.Enabled = true;
            }

            currentlyProcessing =
            btnStopAnalyze.Visible =
            lblStopProcessing.Visible = false;

            UpdateFilesToAnalyzeCount();
            UpdateFilesAnalyzedCount();
        }

        private void RunCommand(string command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                ProcessStartInfo procStartInfo =
                    new ProcessStartInfo("cmd", "/c " + command)
                    {
                        // The following commands are needed to redirect the standard output.
                        // This means that it will be redirected to the Process.StandardOutput StreamReader.
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        // Do not create the black window.
                        CreateNoWindow = true
                    };
                // Now we create a process, assign its ProcessStartInfo and start it.
                Process proc = new Process
                {
                    StartInfo = procStartInfo
                };
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
            }
            catch (Exception exc)
            {
                lblError.Visible = true;
                lblError.Text = exc.Message;
                throw;
            }
        }
        private void btnCreateTimestamp_Click(object sender, EventArgs e)
        {
            gbCreateTimestamp.Visible = true;
            btnCreateTimestamp.Enabled = false;
        }

        private void btnSaveCustomTimestamp_Click(object sender, EventArgs e)
        {
            if (txtCustomTimestamp.Text != "")
            {
                try
                {
                    List<string> arrlist = new List<string>();
                    string wd = Path.Combine(Application.StartupPath, "SilenceDetection");
                    string file = lblSelectedTimestamp.Text;
                    string o = Path.GetFileNameWithoutExtension(file) + "-timestamp.txt";
                    List<string> lines = File.ReadAllLines(Path.Combine(wd, o)).ToList();
                    int newId = lines.Count + 1;
                    string[] entries = lines[0].Split(',');
                    string fileDur = entries[4];

                    string text = newId + "," + txtCustomTimestamp.Text + ",0,0," + fileDur;
                    arrlist.Add(text);
                    File.AppendAllLines(Path.Combine(wd, o), arrlist);

                    loadTimestamps(wd, o);

                    lblErrorCustomTimestamp.Visible = false;
                    btnCreateTimestamp.Enabled = true;
                    gbCreateTimestamp.Visible = false;
                }
                catch (Exception exc)
                {
                    lblError.Text = exc.Message;
                    lblError.Visible = true;
                }
            } else
            {
                lblErrorCustomTimestamp.Visible = true;
            }
        }

        private void btnCancelCustomTimestamp_Click(object sender, EventArgs e)
        {
            lblErrorCustomTimestamp.Visible = false;
            btnCreateTimestamp.Enabled = true;
            gbCreateTimestamp.Visible = false;
        }

        private void btnStopAnalyze_Click(object sender, EventArgs e)
        {
            lblStopProcessing.Visible = true;
            btnStopAnalyze.Enabled =
            keepAnalyzing =
            keepProcessing = false;
        }

        private void lvFilesToAnalyze_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFilesToAnalyze.SelectedIndices.Count > 0 && lvFilesToAnalyze.SelectedItems[0].Text != "")
            {
                string selectedFile = lvFilesToAnalyze.SelectedItems[0].Text.Substring(0, lvFilesToAnalyze.SelectedItems[0].Text.Length - 4);
                string wd = Path.Combine(Application.StartupPath, "SilenceDetection");
                string fn = selectedFile + "-timestamp.txt";

                gbDetectedSilence.Visible = true;
                lblSelectedTimestamp.Text = selectedFile + ".mp4";
                lblSelectedTimestamp.Visible = true;
                lblFileDuration.Visible = true;
                lblSaveTimestampsStatus.Visible = false;

                if (File.Exists(Path.Combine(wd, fn)))
                {
                    if (!currentlyAnalyzing || !currentlyProcessing)
                    {
                        btnRemoveSelectedTimestamp.Enabled =
                        btnSaveTimestamps.Enabled = true;
                    }
                    loadTimestamps(wd, fn);
                } else
                {
                    btnRemoveSelectedTimestamp.Enabled = false;
                    btnSaveTimestamps.Enabled = false;
                    lbTimestamps.Items.Clear();
                    lblFileDuration.Text = "N/A";
                    lbTimestamps.Items.Add("Looks like this file hasn't been analyzed.");
                    lbTimestamps.Items.Add("Click 'Analyze' in order to check the file for silence.");
                }
            } else
            {
                gbDetectedSilence.Visible = false;
            }
        }

        private void SelectPreviousItem()
        {
            if (lvFilesToAnalyze.SelectedItems.Count > 0)
            {
                var index = lvFilesToAnalyze.SelectedIndices[0];
                index = index - 1;

                if (index > -1)
                {
                    lvFilesToAnalyze.SelectedIndices.Clear();
                    lvFilesToAnalyze.Items[index].Selected = true;
                }
            }
            else
            {
                lvFilesToAnalyze.Items[0].Selected = true;
            }
        }

        private void SelectNextItem()
        {
            if (lvFilesToAnalyze.SelectedItems.Count > 0)
            {
                var index = lvFilesToAnalyze.SelectedIndices[0];
                index = index + 1;

                if (index < lvFilesToAnalyze.Items.Count)
                {
                    lvFilesToAnalyze.SelectedIndices.Clear();
                    lvFilesToAnalyze.Items[index].Selected = true;
                }
            }
            else
            {
                lvFilesToAnalyze.Items[0].Selected = true;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == ",")
            {
                SelectPreviousItem();
            }

            if (e.KeyChar.ToString() == ".")
            {
                SelectNextItem();
            }

            if (e.KeyChar.ToString() == "/")
            {
                if (lbTimestamps.SelectedIndices.Count > 0)
                {
                    for (int i = 0; i < lbTimestamps.SelectedIndices.Count; i = 0)
                    {
                        lbTimestamps.Items.RemoveAt(lbTimestamps.SelectedIndices[i]);
                    }
                }
            }

            if (e.KeyChar.ToString() == "m")
            {
                if (lbTimestamps.Visible)
                {
                    SaveTimestamps();
                }
            }
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            Credits creditsForm = new Credits();
            creditsForm.Show();
        }

        private void btnBuyMeAPizza_Click(object sender, EventArgs e)
        {
            NavigateToUrl(@"https://www.buymeacoffee.com/brandontech");
        }

        private void btnGrabFilesFromChosenPath_Click(object sender, EventArgs e)
        {
            if (txtPath.Text != "")
            {
                PopulatelvFilesToAnalyze(txtPath.Text);
            }
        }

        private void btnRightArrow_Click(object sender, EventArgs e)
        {
            SelectNextItem();
        }

        private void btnLeftArrow_Click(object sender, EventArgs e)
        {
            SelectPreviousItem();
        }
        private void NavigateToUrl(string Url)
        {
            try
            {
                var startInfo = new ProcessStartInfo("explorer.exe", Url);
                Process.Start(startInfo);
            }
            catch (Exception oops)
            {
                MessageBox.Show("Unable to open link " + oops.Message);
            }
        }

        private async void btnTrim4Seconds_Click(object sender, EventArgs e)
        {
            ReadSettingsFile();
            UpdateStatusLabel("Removing silence");

            // Clear the TimeStamps listbox.
            lbTimestamps.Items.Clear();

            // Hide the labels in the Silence Timestamps group box.
            lblSelectedTimestamp.Visible =
            lblFileDuration.Visible =
            lblSaveTimestampsStatus.Visible = false;

            // Disable the buttons in the Silence Timestamps group box.
            btnRemoveSelectedTimestamp.Enabled =
            btnSaveTimestamps.Enabled = false;

            // Hide the Silence Timestamps group box.
            gbDetectedSilence.Visible = false;

            // Hide the error message.
            lblError.Visible = false;

            // Disable the buttons in the Files group box.
            btnOpen.Enabled =
            btnSettings.Enabled =
            btnRemoveSelectedWaitingFiles.Enabled =
            btnClearWaitingFiles.Enabled =
            btnAnalyze.Enabled =
            btnReAnalyzeFiles.Enabled =
            btnProcessFiles.Enabled =
            btnGrabFilesFromChosenPath.Enabled = false;

            // Show the stop button.
            btnStopAnalyze.Visible = true;

            currentlyProcessing = true;


            // First, step through each item and ensure the colors are White.
            for (var i = 0; i < lvFilesToAnalyze.Items.Count; i++)
            {
                lvFilesToAnalyze.Items[i].ForeColor = Color.White;
            }

            // Create the directory that will hold the text files that have the silence timestamps.
            string sd = Path.Combine(Application.StartupPath, "SilenceDetection");
            Directory.CreateDirectory(sd);
            string wd = Path.Combine(Application.StartupPath, "FilesProcessing");
            Directory.CreateDirectory(wd);

            // Create the directory that will hold the cut video files while processing.
            FileInfo f = new FileInfo(txtPath.Text);
            string driveLetter = Path.GetPathRoot(f.FullName);
            string playonPalDirectory = Path.Combine(driveLetter, "PlayonPal Processes");
            Directory.CreateDirectory(playonPalDirectory);
            string processingDirectory = Path.Combine(playonPalDirectory, "Processing");
            Directory.CreateDirectory(processingDirectory);
            string saveDirectory = (mySettings.outputLocation == "") ? playonPalDirectory : mySettings.outputLocation;


            try
            {
                for (var i = 0; i < lvFilesToAnalyze.Items.Count; i++)
                {
                    if (keepProcessing)
                    {
                        lvFilesToAnalyze.Items[i].ForeColor = Color.DeepSkyBlue;

                        string selectedFile = lvFilesToAnalyze.Items[i].Text,
                                file = Path.Combine(txtPath.Text, selectedFile);

                        var player = new WindowsMediaPlayer();
                        var fileDuration = player.newMedia(file);
                        var fileDurationWithoutSplashes = TimeSpan.FromSeconds(fileDuration.duration - 8);

                        UpdateStatusLabel("Removing splash screens.");
                        // Run the command to remove the silence from the beginning and end of the file.
                        await Task.Run(() =>
                        {
                            RunCommand("ffmpeg -y -ss 4 -i \"" + file + "\" -t " + fileDurationWithoutSplashes + " -c copy \"" + processingDirectory + "\\" + selectedFile + "\"");
                        });

                        // Now, move the finished file to the chosen directory.
                        await Task.Run(() =>
                        {
                            File.Move(processingDirectory + "\\" + selectedFile, saveDirectory + "\\" + selectedFile);
                        });


                        if (mySettings.deleteOriginal.ToUpper() == "TRUE")
                        {
                            UpdateStatusLabel("Deleting original file.");
                            File.Delete(file + ".mp4");
                        }

                        lvFilesToAnalyze.Items[i].ForeColor = Color.Green;
                        lvFilesToAnalyze.Items[i].Remove();
                        i--;

                    }
                    IncrementCleanedCount();
                }
                UpdateStatusLabel("Done.");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                throw;
            }

            btnOpen.Enabled =
            btnSettings.Enabled =
            btnStopAnalyze.Enabled =
            keepProcessing = true;

            if (lvFilesToAnalyze.Items.Count > 0)
            {
                btnLeftArrow.Enabled =
                btnRightArrow.Enabled = true;
            }
            else
            {
                btnLeftArrow.Enabled =
                btnRightArrow.Enabled = false;
            }

            if (txtPath.Text != "")
            {
                btnGrabFilesFromChosenPath.Enabled = true;
            }

            currentlyProcessing =
            btnStopAnalyze.Visible =
            lblStopProcessing.Visible = false;

            UpdateFilesToAnalyzeCount();
            UpdateFilesAnalyzedCount();
        }
    }
}
