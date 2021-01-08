using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BachFlixAudioAnalyzer
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            // Read each line from the txt file into an array.
            List<string> lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "settings.txt")).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                switch (entries[0])
                {
                    case "silenceDetection":
                        txtSilenceDetectNoiseLevel.Text = entries[1];
                        break;
                    case "silenceDuration":
                        txtSilenceDuration.Text = entries[1];
                        break;
                    case "vlcLocation":
                        txtVlcLocation.Text = entries[1];
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an arrayList to save to the settings.txt file.
                List<string> arrlist = new List<string>();
                arrlist.Add("silenceDetection," + txtSilenceDetectNoiseLevel.Text);
                arrlist.Add("silenceDuration," + txtSilenceDuration.Text);

                // Write the arrayList to the settings.txt file.
                // Each line is a different setting.
                File.WriteAllLines(Path.Combine(Application.StartupPath, "settings.txt"), arrlist);

                // Show that the settings were saved successfully.
                lblSaveStatus.Visible = true;
                lblSaveStatus.Text = "Settings successfully saved.";
                lblSaveStatus.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                lblSaveStatus.Visible = true;
                lblSaveStatus.Text = ex.Message;
                lblSaveStatus.ForeColor = Color.Red;
                throw;
            }
        }
    }
}
