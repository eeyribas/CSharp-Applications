using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageForm
{
    public partial class LangForm : Form
    {
        public LangForm()
        {
            InitializeComponent();
        }

        private void LangForm_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();

                if (Shared.language.Selection == "TR")
                    pictureBox1.Image = Properties.Resources.turkeyActiveImage;
                else if (Shared.language.Selection == "EN")
                    pictureBox2.Image = Properties.Resources.USAActiveImage;
                else if (Shared.language.Selection == "BR")
                    pictureBox3.Image = Properties.Resources.brasilActiveImage;
                else if (Shared.language.Selection == "CN")
                    pictureBox4.Image = Properties.Resources.thailandActiveImage;
                else if (Shared.language.Selection == "ID")
                    pictureBox5.Image = Properties.Resources.indonesiaActiveImage;
            }
            catch (Exception ex)
            {
            }
        }

        private void Clear()
        {
            try
            {
                pictureBox1.Image = Properties.Resources.turkeyPassiveImage;
                pictureBox2.Image = Properties.Resources.USAPassiveImage;
                pictureBox3.Image = Properties.Resources.brasilPassiveImage;
                pictureBox4.Image = Properties.Resources.thailandPassiveImage;
                pictureBox5.Image = Properties.Resources.indonesiaPassiveImage;
            }
            catch (Exception ex)
            {
            }
        }

        private void LanguageChange_Click(object sender, EventArgs e)
        {
            try
            {
                PictureBox pictureBox = sender as PictureBox;

                if (pictureBox.Name == pictureBox1.Name)
                    Shared.language.Selection = "TR";
                else if (pictureBox.Name == pictureBox2.Name)
                    Shared.language.Selection = "EN";
                else if (pictureBox.Name == pictureBox3.Name)
                    Shared.language.Selection = "BR";
                else if (pictureBox.Name == pictureBox4.Name)
                    Shared.language.Selection = "CN";
                else if (pictureBox.Name == pictureBox5.Name)
                    Shared.language.Selection = "ID";

                Shared.language.Write();
                Shared.language.Read();

                this.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
