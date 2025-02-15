using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOAFilter
{
    public partial class Form1 : Form
    {
        private DataFilters dataFilters = new DataFilters();
        private List<double> values = new List<double>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            values.Add(100.2);
            values.Add(99.5);
            values.Add(98.6);
            values.Add(95.3);
            values.Add(90.9);
            values.Add(88.5);
            values.Add(89.9);
            values.Add(93.4);
            values.Add(91.6);
            values.Add(90.7);
            values.Add(88.6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> normalData = dataFilters.Selection(values, (int)DataFilterType.Normal);
            for (int i = 0; i < normalData.Count; i++)
                listBox1.Items.Add(normalData[i].ToString());

            List<double> filterData = dataFilters.Selection(values, (int)DataFilterType.MOA);
            for (int i = 0; i < filterData.Count; i++)
                listBox2.Items.Add(filterData[i].ToString());
        }
    }
}
