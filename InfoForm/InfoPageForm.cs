using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoForm
{
    public partial class InfoPageForm : Form
    {
        public InfoPageForm(string title, string message, string buttonText)
        {
            InitializeComponent();

            label1.Text = title;
            label2.Text = message;
            button1.Text = buttonText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button tmpButton = sender as Button;
            tmpButton.BackColor = Color.FromArgb(64, 64, 64);
            tmpButton.ForeColor = Color.LightGray;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Button tmpButton = sender as Button;
            tmpButton.BackColor = Color.White;
            tmpButton.ForeColor = Color.DodgerBlue;
        }
    }
}
