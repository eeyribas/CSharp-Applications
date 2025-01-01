using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = NewSettings.Default.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewSettings.Default.Value = textBox1.Text;
            NewSettings.Default.Save();
            label1.Text = NewSettings.Default.Value;
        }
    }
}
