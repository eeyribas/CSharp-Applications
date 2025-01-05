using DataLogger.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLogger
{
    public partial class Form1 : Form
    {
        private DataLog dataLog = new DataLog();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataLog.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataLog.AddLog((int)DataLogType.Info, "Info");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataLog.AddLog((int)DataLogType.Exception, "Exception");
        }
    }
}
