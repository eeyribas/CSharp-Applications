using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFApp
{
    public partial class Form1 : Form
    {
        private PDF pdf = new PDF();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            List<double> xList = new List<double>();
            List<double> yList = new List<double>();
            List<string> textList = new List<string>();
            double minValue = 0.0;
            double maxValue = 100.0;
            for (int i = 0; i < 100; i++)
            {
                xList.Add(Convert.ToDouble(i));
                yList.Add(minValue + (random.NextDouble() * (maxValue - minValue)));
            }
            textList.Add("Text - 1");
            textList.Add("Text - 2");
            textList.Add("Text - 3");

            pdf.Create(xList, yList, textList, 10, 90, maxValue, maxValue);
        }
    }
}
