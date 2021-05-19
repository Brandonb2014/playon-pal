using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Web;

namespace BachFlixAudioAnalyzer
{
    public partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();
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

        private void lnkFreepik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToUrl(@"https://www.freepik.com/");
        }

        private void lnkFlaticon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToUrl(@"https://www.flaticon.com/");
        }

        private void lnkPixelmeetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToUrl(@"https://www.flaticon.com/authors/pixelmeetup/");
        }

        private void lnkSrip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToUrl(@"https://www.flaticon.com/authors/srip");
        }

        private void lnkSmashicons_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToUrl(@"https://www.flaticon.com/authors/smashicons");
        }

        private void lnkAlfredoHernandez_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToUrl(@"https://www.flaticon.com/authors/alfredo-hernandez");
        }
    }
}
