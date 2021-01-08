using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BachFlixAudioAnalyzer
{
    public partial class Form1 : Form
    {
        private string silenceDetection;
        private string silenceDuration;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The action when the Open button is clicked.
        /// This button opens up the folder explorer for the user to pick a folder that has the videos they want analyzed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Clear all videos in the files to process listbox.
            lvFilesToAnalyze.Items.Clear();

            // Open folder browser dialog.
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    var files = Directory.GetFiles(fbd.SelectedPath);
                    // Set path to textbox.
                    txtPath.Text = fbd.SelectedPath;
                    foreach (string item in files)
                    {
                        // For now, it's only looking for mp4 files. This may need to be expanded to include other formats.
                        // However, this program is intended for PlayOn recordings which are only in mp4 format.
                        if(Path.GetExtension(item) == ".mp4")
                        {
                            FileInfo fi = new FileInfo(item);
                            lvFilesToAnalyze.Items.Add(fi.Name);
                        }
                    }

                    // If the user selected a folder that had video files to process, then it will enable the following buttons.
                    if (lvFilesToAnalyze.Items.Count > 0)
                    {
                        btnAnalyze.Enabled = true;
                        btnRemoveSelectedWaitingFiles.Enabled = true;
                        btnClearWaitingFiles.Enabled = true;
                        lblLoadedFiles.Visible = true;
                        UpdateFilesToAnalyzeCount();
                    }

                }
            }
        }

        private void UpdateFilesToAnalyzeCount()
        {
            int count = lvFilesToAnalyze.Items.Count;
            string plural = (count == 1) ? " File " : " Files ";
            string text = "";

            if (count > 0)
            {
                text += count + plural + "waiting for analysis. Now press 'Analyze' to detect silence.";
            } else
            {
                text += count + plural + "selected. Click 'Open' to add different files.";
                btnAnalyze.Enabled = false;
                btnRemoveSelectedWaitingFiles.Enabled = false;
                btnClearWaitingFiles.Enabled = false;
            }
            lblLoadedFiles.Text = text;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings settingsForm = new frmSettings();
            settingsForm.Show();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            readSettingsFile();
            lblLoadedFiles.Visible = false;

            Directory.CreateDirectory(Application.StartupPath + "\\SilenceDetection");
            for (var i = 0; i < lvFilesToAnalyze.Items.Count; i++)
            {
                var file = lvFilesToAnalyze.Items[i].Text.ToString();
                lvFilesToAnalyze.Items[i].ForeColor = Color.Blue;
                this.Refresh();

                UpdateStatusLabel("Analyzing '" + file + "' for silence.");
                DetectSilence(Path.Combine(txtPath.Text, file));

                lvFilesToAnalyze.Items[i].ForeColor = Color.Green;

                this.Refresh();
            }
            UpdateFilesToAnalyzeCount();
            UpdateFilesAnalyzedCount();
        }

        private void readSettingsFile()
        {
            // Read each line from the txt file into an array.
            List<string> lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "settings.txt")).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                switch (entries[0])
                {
                    case "silenceDetection":
                        silenceDetection = entries[1];
                        break;
                    case "silenceDuration":
                        silenceDuration = entries[1];
                        break;
                    default:
                        break;
                }
            }
        }
        
        private void UpdateStatusLabel(string text)
        {
            lblCurrentRunningProcess.Visible = true;
            lblCurrentRunningProcess.Text = text;
            this.Refresh();
        }

        private void DetectSilence(string file)
        {
            var fileName = Path.GetFileName(file);
            var fileWithoutExtension = Path.GetFileNameWithoutExtension(file);
            var command = "ffmpeg -y -nostats -i \"" + file + "\" -af silencedetect=n=" + silenceDetection + ":d=" + silenceDuration + " -f null - 2> SilenceDetection\\\"" + fileWithoutExtension + "\".txt";
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

                lbAnalyzed.Items.Add(Path.GetFileName(file));

                CleanTextFile(fileWithoutExtension);

                UpdateStatusLabel("Done.");
            }
            catch (Exception exc)
            {
                lblError.Visible = true;
                lblError.Text = exc.Message;
                throw;
            }

        }

        // Takes the txt file that has just ran through silence detection and removes all the jargon to get just the silence_start, silence_end and silence_duration numbers.
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
                        bool keepLooping = true;

                        do
                        {
                            if (fileDuration[0] == '0' && fileDuration[1] == '0')
                            {
                                fileDuration = fileDuration.Substring(3);
                            }
                            else keepLooping = false;
                        } while (keepLooping);
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
                 File.WriteAllLines(Path.Combine(wd, o), arrlist);
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

        private void lbAnalyzed_Click(object sender, EventArgs e)
        {
            if (lbAnalyzed.SelectedItem != null && lbAnalyzed.SelectedItem.ToString() != "")
            {
                gbDetectedSilence.Visible = true;
                string selectedFile = lbAnalyzed.SelectedItem.ToString().Substring(0, lbAnalyzed.SelectedItem.ToString().Length - 4);
                string wd = Path.Combine(Application.StartupPath, "SilenceDetection");
                string fn = selectedFile + "-timestamp.txt";
                lblSelectedTimestamp.Text = lbAnalyzed.SelectedItem.ToString();
                lblSelectedTimestamp.Visible = true;
                lblFileDuration.Visible = true;
                lblSaveTimestampsStatus.Visible = false;

                loadTimestamps(wd, fn);

                UpdateFilesAnalyzedCount();
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

                    if (entries[1] != "0" && entries[2] != "0" && entries[3] != "0")
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

        // Convert the seconds time to hh:MM:ss.xxx format.
        private string ConvertSecondsToTime(double sec)
        {
            try
            {
                TimeSpan t = TimeSpan.FromSeconds(sec);
                string answer = "";
                if (t.Hours > 0) answer += t.Hours + ":";
                if (t.Minutes > 0) answer += t.Minutes + ":"; else if (t.Hours > 0) answer += "00:";
                if (t.Seconds > 0) answer += t.Seconds + "."; else if (t.Hours > 0 || t.Minutes > 0) answer += "00.";
                if (t.Milliseconds > 0) answer += t.Milliseconds; else if (t.Hours > 0 || t.Minutes > 0 || t.Seconds > 0) answer += "00";

                return answer;
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

                // splitting 1:31:47.234 ==
                // split[0] = 1
                // split[1] = 31
                // split[2] = 47.234
                // which should give us - (1 * 3600) + (31 * 60) + 47.234 = 5,507.234

                // splitting 31:47.234 ==
                // split[0] = 31
                // split[1] = 47.234
                // which should give us - (31 * 60) + 47.234 = 1,907.234
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
        }

        private void lbTimestamps_DoubleClick(object sender, EventArgs e)
        {
            string timeStamps = lbTimestamps.SelectedItem.ToString().Substring(lbTimestamps.SelectedItem.ToString().IndexOf(")")+1, lbTimestamps.SelectedItem.ToString().IndexOf("=")-2).Trim();
            string[] entries = timeStamps.Split('-');
            string silenceStart = ConvertTimeToSeconds(entries[0].Trim());
            string silenceEnd = ConvertTimeToSeconds(entries[1].Trim());
            string fn = Path.Combine(txtPath.Text, lblSelectedTimestamp.Text);

            var playVideo = "start \"C:\\Program Files\\VideoLAN\\VLC\\vlc.exe\" vlc \"" + fn + "\" --start-time " + silenceStart + " --stop-time " + silenceEnd;
            RunCommand(playVideo);
        }

        private void btnClearWaitingFiles_Click(object sender, EventArgs e)
        {
            lvFilesToAnalyze.Items.Clear();
            UpdateFilesToAnalyzeCount();
        }

        private void btnRemoveSelectedProcessedFiles_Click(object sender, EventArgs e)
        {
            if (lbAnalyzed.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < lbAnalyzed.SelectedIndices.Count; i = 0)
                {
                    lbAnalyzed.Items.RemoveAt(lbAnalyzed.SelectedIndices[i]);
                }
                gbDetectedSilence.Visible = false;
                UpdateFilesAnalyzedCount();
            }
        }

        private void btnClearProcessed_Click(object sender, EventArgs e)
        {
            lbAnalyzed.Items.Clear();
            lbTimestamps.Items.Clear();
            gbCreateTimestamp.Visible = false;
            gbDetectedSilence.Visible = false;
            btnCreateTimestamp.Enabled = true;
            UpdateFilesAnalyzedCount();
        }

        private void UpdateFilesAnalyzedCount()
        {
            if (lbAnalyzed.Items.Count > 0)
            {
                btnRemoveSelectedProcessedFiles.Enabled = true;
                btnClearProcessed.Enabled = true;
                btnRemoveSelectedTimestamp.Enabled = true;
                btnSaveTimestamps.Enabled = true;
                btnProcessFiles.Enabled = true;
            } else
            {
                btnRemoveSelectedProcessedFiles.Enabled = false;
                btnClearProcessed.Enabled = false;
                btnRemoveSelectedTimestamp.Enabled = false;
                btnSaveTimestamps.Enabled = false;
                lblSelectedTimestamp.Visible = false;
                lblFileDuration.Visible = false;
                lblSaveTimestampsStatus.Visible = false;
                btnProcessFiles.Enabled = false;
                lbTimestamps.Items.Clear();
            }
        }

        private void btnRemoveSelectedTimestamp_Click(object sender, EventArgs e)
        {
            if (lbTimestamps.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < lbTimestamps.SelectedIndices.Count; i = 0)
                {
                    lbTimestamps.Items.RemoveAt(lbTimestamps.SelectedIndices[i]);
                }
            }
        }

        private void btnSaveTimestamps_Click(object sender, EventArgs e)
        {
                string wd = Path.Combine(Application.StartupPath, "SilenceDetection");
                string file = lblSelectedTimestamp.Text;
                string o = file + "-timestamp.txt";

                saveListToTimestampFile(wd, o);

                loadTimestamps(wd, o);
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
                lblSaveTimestampsStatus.Text = "New timestamp list saved";
            }
            catch (Exception exc)
            {
                lblSaveTimestampsStatus.Visible = true;
                lblSaveTimestampsStatus.Text = exc.Message;
                throw;
            }
        }

        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            // First, hide and clear out the necessary labels and list boxes.
            lbTimestamps.Items.Clear();
            lblSelectedTimestamp.Visible = false;
            lblFileDuration.Visible = false;
            lblSaveTimestampsStatus.Visible = false;
            btnRemoveSelectedTimestamp.Enabled = false;
            btnSaveTimestamps.Enabled = false;
            lblError.Visible = false;
            gbDetectedSilence.Visible = false;

            // Create the directory that will hold the cut video files while processing.
            Directory.CreateDirectory(Application.StartupPath + "\\FilesProcessing");
            string wd = Path.Combine(Application.StartupPath, "SilenceDetection");
        
            try
            {
                for (var i = 0; i < lbAnalyzed.Items.Count; i++)
                {
                    string selectedFile = lbAnalyzed.Items[i].ToString().Substring(0, lbAnalyzed.Items[i].ToString().Length - 4);
                    string fileName = selectedFile + "-timestamp.txt";

                    // Read each line from the txt file into an array.
                    List<string> lines = File.ReadAllLines(Path.Combine(wd, fileName)).ToList();

                    if (lines.Count == 1)
                    {
                        // Split the lines on the commas.
                        string[] entries = lines[0].Split(',');

                        RemoveSilence(Path.Combine(txtPath.Text, selectedFile), entries[1]);

                    }
                    else if (lines.Count > 1)
                    {
                        lblError.Text = fileName + " has too many lines to read. You probably didn't save the timestamps after removing them.";
                        lblError.Visible = true;
                        break;
                    }
                    else
                    {
                        lblError.Text = fileName + " has no lines to read.";
                        lblError.Visible = true;
                        break;
                    }


                    //lbAnalyzed.Items.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                throw;
            }
        }

        private void RemoveSilence(string file, string time)
        {
            // Create the text file that holds the names of the video file parts so we can concatenate the files together later.
            List<string> arrlist = new List<string>();
            var fileWithoutExtension = Path.GetFileNameWithoutExtension(file);
            string wd = Path.Combine(Application.StartupPath, "FilesProcessing");
            arrlist.Add("file '" + wd + "\\part2.mp4'");
            arrlist.Add("file '" + wd + "\\part1.mp4'");
            File.WriteAllLines(Path.Combine(wd, "files.txt"), arrlist);
            string sd = Path.GetPathRoot(txtPath.Text) + "PlayonPal Processes";
            Directory.CreateDirectory(sd);

            // Create the command to get the opening splash screen.
            var getPart1 = "ffmpeg -y -i \"" + file + ".mp4\" -t 4 -c copy \"FilesProcessing\\part1.mp4\"";
            RunCommand(getPart1);

            // Create the command to remove the trailing silence.
            var getPart2 = "ffmpeg -y -i \"" + file + ".mp4\" -t " + time + " -c copy \"FilesProcessing\\part2.mp4\"";
            RunCommand(getPart2);

            // Finally, concat the files together to one.
            var concatFilesCommand = "ffmpeg -y -f concat -safe 0 -i \"FilesProcessing\\files.txt\" -c copy \"" + sd + "\\" + fileWithoutExtension + ".mp4\"";
            RunCommand(concatFilesCommand);
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
                    string o = lblSelectedTimestamp.Text + "-timestamp.txt";
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
    }
}
