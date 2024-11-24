using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ReleaseNotes.ReleaseNotesForm;

namespace ReleaseNotes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<VersionInfo> versions = new List<VersionInfo>();
            VersionInfo versionInfo;
            versionInfo.versionNumber = "1.0.0";
            versionInfo.releaseDate = DateTime.Now;
            List<string> features = new List<string>();
            features.Add("Feature - 1");
            features.Add("Feature - 2");
            versionInfo.features = features;
            List<string> bugFixes = new List<string>();
            bugFixes.Add("Bug Fixed - 1");
            bugFixes.Add("Bug Fixed - 2");
            versionInfo.bugFixes = bugFixes;
            ReleaseNotesForm releaseNotesForm = new ReleaseNotesForm(versions, "Versions");
            releaseNotesForm.ShowDialog();
        }
    }
}
