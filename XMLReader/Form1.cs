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

namespace XMLReader
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
            XmlReader xmlReader = XmlReader.Create("XMLFile.xml");
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Text)
                    listBox1.Items.Add(xmlReader.Value);
            }
            xmlReader.Close();
        }
    }
}
