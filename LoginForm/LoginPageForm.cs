using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class LoginPageForm : Form
    {
        private const string Password = "1234";

        public LoginPageForm()
        {
            InitializeComponent();
        }

        private void LoginPageForm_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConnectionForm()
        {
            try
            {
                if (textBox1.Text.Trim() == Password)
                {
                    label2.Text = "Doğru";
                    textBox1.Clear();
                    this.Close();
                }
                else
                {
                    label2.Text = "Hatalı";
                    textBox1.Clear();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ConnectionForm();
        }
    }
}
