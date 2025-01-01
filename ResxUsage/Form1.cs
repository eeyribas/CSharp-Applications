using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResxUsage
{
    public partial class Form1 : Form
    {
        private Resx resx = new Resx();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Resx.Read();
            label1.Text = Resx.value1;
            label2.Text = Resx.value2;
        }
    }
}
