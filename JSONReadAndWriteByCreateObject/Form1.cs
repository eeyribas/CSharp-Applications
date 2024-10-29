using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSONReadAndWriteByCreateObject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("-----");
            Shared.obj.Read();
            listBox1.Items.Add(Shared.obj.Value1.ToString());
            listBox1.Items.Add(Shared.obj.Value2.ToString());
            listBox1.Items.Add(Shared.obj.Value3.ToString());

            listBox1.Items.Add("-----");
            Shared.obj.Value1 = 11;
            Shared.obj.Value2 = 3.45;
            Shared.obj.Value3 = false;
            Shared.obj.Write();
            Shared.obj.Read();
            listBox1.Items.Add(Shared.obj.Value1.ToString());
            listBox1.Items.Add(Shared.obj.Value2.ToString());
            listBox1.Items.Add(Shared.obj.Value3.ToString());

            listBox1.Items.Add("-----");
        }
    }
}
