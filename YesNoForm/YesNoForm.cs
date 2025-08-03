using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YesNoForm
{
    public partial class YesNoForm : Form
    {
        public string command;

        public YesNoForm()
        {
            InitializeComponent();
        }

        public YesNoForm(Form callingForm, string title, string message, 
                         string yesButtonText, string noButtonText, string yesCommand)
        {
            Form1 form1 = callingForm as Form1;
            InitializeComponent();

            label1.Text = title;
            label2.Text = message;
            button1.Text = yesButtonText;
            button2.Text = noButtonText;

            command = yesCommand;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (command == "Close Application")
                Application.Exit();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button tmpButton = sender as Button;
            tmpButton.BackColor = Color.FromArgb(64, 64, 64);
            tmpButton.ForeColor = Color.LightGray;
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            Button tmpButton = sender as Button;
            tmpButton.BackColor = Color.White;
            tmpButton.ForeColor = Color.DodgerBlue;
        }
    }
}
