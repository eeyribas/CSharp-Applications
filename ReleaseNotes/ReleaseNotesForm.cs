using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReleaseNotes
{
    public partial class ReleaseNotesForm : Form
    {
        public struct VersionInfo
        {
            public string versionNumber;
            public DateTime releaseDate;
            public List<string> features;
            public List<string> bugFixes;
        }

        private List<VersionInfo> inputVersions = new List<VersionInfo>();

        public ReleaseNotesForm(List<VersionInfo> versions, string title)
        {
            InitializeComponent();

            inputVersions.AddRange(versions);
            this.Text = title;
        }

        private void ReleaseNotesForm_Load(object sender, EventArgs e)
        {
            if (inputVersions.Count > 0)
                LoadVersions(inputVersions);
        }

        private void LoadVersions(List<VersionInfo> versions)
        {
            int versionCount = versions.Count;
            for (int versionIndex = 0; versionIndex < versionCount; versionIndex++)
            {
                VersionInfo version = versions[versionIndex];
                AddNewVersion(version.versionNumber, version.releaseDate, version.features, version.bugFixes);
            }

            label2.Text = versions[versionCount - 1].versionNumber;

            ExpandLastNode();
        }

        private void AddNewVersion(string versionNumber, DateTime releaseDate, List<string> newFeatures, List<string> bugFixes)
        {
            TreeNode root = new TreeNode("▶ Version " + versionNumber + " --- Release Date: " + releaseDate.ToString("dd.MM.yyy"));
            root.Nodes.Add("▶ New Features");
            foreach (string item in newFeatures)
                root.Nodes[root.Nodes.Count - 1].Nodes.Add("✏ " + item);
            root.Nodes.Add("▶ Bug Fixes");
            foreach (string item in bugFixes)
                root.Nodes[root.Nodes.Count - 1].Nodes.Add("✏ " + item);

            treeView.Nodes.Add(root);
        }

        private void ExpandLastNode()
        {
            treeView.CollapseAll();
            if (treeView.Nodes.Count == 0)
                return;

            TreeNode lastNode = treeView.Nodes[treeView.Nodes.Count - 1];
            lastNode.ExpandAll();
        }
    }
}
