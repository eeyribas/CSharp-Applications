using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemInformation
{
    public partial class Form1 : Form
    {
        private SystemInfo systemInfo = new SystemInfo();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> processIDs = systemInfo.ProcessID("SystemInformation");

            if (processIDs.Count > 0)
            {
                for (int i = 0; i < processIDs.Count; i++)
                    listBox1.Items.Add(processIDs[i].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = systemInfo.DriveUsagePercent("C:\\").ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = systemInfo.RamUsage().ToString();
        }
    }
}
