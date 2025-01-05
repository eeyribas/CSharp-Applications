using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelDocument
{
    public partial class Form1 : Form
    {
        private ExcelDoc excelDoc = new ExcelDoc();
        private string[] excelRowNames = { "Date", "Hour", "Value1", "Value2", "Value3", "Value4", "Value5", "Value6" };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            excelDoc.Write("Data", excelRowNames, textBox1.Text, textBox2.Text, Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text),
                           Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox6.Text));
        }
    }
}
