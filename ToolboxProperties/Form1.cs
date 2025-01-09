using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolboxProperties.ToolboxProperty;

namespace ToolboxProperties
{
    public partial class Form1 : Form
    {
        private ButtonMethods buttonMethods = new ButtonMethods();
        private ComboBoxMethods comboBoxMethods = new ComboBoxMethods();
        private KeyboardMethods keyboardMethods = new KeyboardMethods();
        private TextBoxMethods textBoxMethods = new TextBoxMethods();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonMethods.EnableAndBackColor(button1, true, Color.Red);
            textBox1.Text = comboBoxMethods.SelectedIndexValue(2, comboBox1.Items.Count).ToString();
            string text = "   test   test";
            textBox2.Text = textBoxMethods.TrimConvString(text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyboardMethods.InputOnlyNumbers(e);
        }
    }
}
