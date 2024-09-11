using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLParameterSelection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("XMLFile.xml");
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/Values/Value");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                string value1 = xmlNode["Value1"].InnerText;
                string value2 = xmlNode["Value2"].InnerText;
                listBox1.Items.Add(value1);
                listBox1.Items.Add(value2);
            }
        }
    }
}
