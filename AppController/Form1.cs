using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppController
{
    public partial class Form1 : Form
    {
        private DateTime lastCheckedDateTime = new DateTime();

        public Form1()
        {
            InitializeComponent();

            lastCheckedDateTime = DateTime.Now;
            checkBox1.Checked = true;

            notifyIcon1.Visible = true;
            numericUpDown1.Value = 5000;
            timer1.Interval = (int)numericUpDown1.Value;
            timer1.Enabled = true;
            this.Opacity = 0.0f;
            this.ShowInTaskbar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Normal;
                this.Opacity = 1.0f;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Opacity = 0.0f;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                lastCheckedDateTime = DateTime.Now;
                List<KeyValuePair<string, string>> apps = new List<KeyValuePair<string, string>>();
                apps.Add(new KeyValuePair<string, string>(@"C:\Release", "APP"));

                for (int appIndex = 0; appIndex < apps.Count; appIndex++)
                {
                    List<int> processIDs = GetProcessID(apps[appIndex].Value);
                    label3.Text = "Message: " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss - ") + "Process is running : " + processIDs.Count.ToString();

                    if (processIDs.Count == 0)
                    {
                        string workingDirectory = apps[appIndex].Key;
                        string clientFilePath = Path.Combine(apps[appIndex].Key, apps[appIndex].Value + ".exe");

                        if (File.Exists(clientFilePath))
                        {
                            Process process = new Process();
                            process.StartInfo.WorkingDirectory = workingDirectory;
                            process.StartInfo.FileName = clientFilePath;
                            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

                            if (File.Exists(clientFilePath))
                                process.Start();
                            label3.Text = "Message: " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss - ") + apps[appIndex].Key + " was started.";
                        }
                        else
                        {
                            label3.Text = "Message: " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss - ") + "no such file or directory: " + clientFilePath;
                        }
                    }
                }
            }
            else
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(lastCheckedDateTime);
                if (timeSpan.TotalSeconds >= 5 * 60)
                    checkBox1.Checked = true;
            }
        }

        public List<int> GetProcessID(string appName)
        {
            List<int> processes = new List<int>();
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (process.ProcessName.StartsWith(appName))
                    processes.Add(process.Id);
            }

            return processes;
        }
    }
}
