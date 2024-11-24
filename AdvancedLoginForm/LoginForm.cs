using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedLoginForm
{
    public partial class LoginForm : Form
    {
        public string AcceptedPassword { get; set; }
        private Timer timerClickedUpdate;
        private List<string> validPasswordsList = new List<string>();

        public LoginForm(string loginTitle, string enterPasswordText, string wrongPasswordMessage, List<string> validPasswords, string login, string cancel)
        {
            InitializeComponent();

            label1.Text = loginTitle;
            label3.Text = enterPasswordText;
            label2.Text = wrongPasswordMessage;
            validPasswordsList.AddRange(validPasswords);
            button1.Text = login;
            button2.Text = cancel;

            timerClickedUpdate = new Timer();
            timerClickedUpdate.Interval = 1000;
            timerClickedUpdate.Tick += new EventHandler(OnTimedEvent);
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            label2.Visible = false;
            timerClickedUpdate.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TryToLogin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            Button tmpButton = sender as Button;
            tmpButton.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            tmpButton.BackColor = Color.White;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button tmpButton = sender as Button;
            tmpButton.ForeColor = Color.White;
            tmpButton.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TryToLogin();
        }

        private void TryToLogin()
        {
            string inputPassword = textBox1.Text.Trim();
            if (inputPassword == String.Empty)
            {
                DisplayWrongPassword();
                return;
            }

            if (validPasswordsList.Contains(inputPassword))
            {
                this.AcceptedPassword = inputPassword;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DisplayWrongPassword();
            }
        }

        private void DisplayWrongPassword()
        {
            label2.Visible = true;
            timerClickedUpdate.Start();
            textBox1.Focus();
        }
    }
}
