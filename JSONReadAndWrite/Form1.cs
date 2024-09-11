using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSONReadAndWrite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jsonIndexString = textBox1.Text.Trim();
            int jsonIndex = Convert.ToInt32(jsonIndexString);
            if (jsonIndex < 4)
                ControlParams.jsonProcess.ChangeJsonData(jsonIndex, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            object[] data = ControlParams.jsonProcess.JsonDataObjects();
            listBox1.Items.Add(ControlParams.jsonProcess.jsonId.ToString());
            for (int i = 0; i < 12; i++)
                listBox1.Items.Add(data[i].ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ControlParams.jsonProcess.SaveJsonFile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            ControlParams.jsonProcess.ReadJsonFile();

            object[] data = ControlParams.jsonProcess.JsonDataObjects();
            for (int i = 0; i < 12; i++)
                listBox2.Items.Add(data[i].ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ControlParams.jsonProcess.jsonId = Convert.ToInt32(textBox5.Text);
            textBox5.Clear();
        }
    }
}
