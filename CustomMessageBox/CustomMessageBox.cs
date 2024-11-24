using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMessageBox
{
    public partial class CustomMessageBox : Form
    {
        public enum MessageType
        {
            Success = 0,
            Fail = 1,
            Warning = 2
        }

        public CustomMessageBox(MessageType messageType, string title, string inputText, bool listBoxView = false)
        {
            InitializeComponent();

            label1.Text = title;
            label2.Text = inputText;
            listbox_message.Visible = false;

            if (listBoxView)
            {
                listbox_message.Visible = true;
                label2.Visible = false;
                string[] lines = SeperateString(inputText, "\n");
                foreach (var line in lines)
                    listbox_message.Items.Add(line);
            }

            if (messageType == MessageType.Success)
            {
                panel1.BackColor = Color.SeaGreen;
                label1.ForeColor = Color.White;
            }
            else if (messageType == MessageType.Fail)
            {
                panel1.BackColor = Color.DarkRed;
                label1.ForeColor = Color.White;
            }
            else if (messageType == MessageType.Warning)
            {
                panel1.BackColor = Color.Gold;
                label1.ForeColor = Color.Black;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = SystemColors.ControlDark;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = SystemColors.ScrollBar;
        }

        public string[] SeperateString(string text, string seperator)
        {
            if (text == null || text == String.Empty || seperator == String.Empty)
                return new string[1] { text };

            string[] input_seperator = new string[] { seperator };
            string[] result = text.Split(input_seperator, StringSplitOptions.None);

            return result;
        }
    }
}
