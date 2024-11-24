using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YesNoQuestionForm
{
    public partial class YesNoQuestionForm : Form
    {
        public YesNoQuestionForm(string title, string message, string button1Text, string button2Text)
        {
            InitializeComponent();

            label1.Text = title;
            label2.Text = message;
            button1.Text = button1Text;
            button2.Text = button2Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            Button tmpButton = sender as Button;
            tmpButton.BackColor = Color.White;
            tmpButton.ForeColor = Color.DodgerBlue;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button tmpButton = sender as Button;
            tmpButton.BackColor = Color.FromArgb(64, 64, 64);
            tmpButton.ForeColor = Color.LightGray;
        }
    }
}
