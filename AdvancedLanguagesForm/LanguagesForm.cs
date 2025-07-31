using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedLanguagesForm
{
    public partial class LanguagesForm : Form
    {
        public enum LanguageType
        {
            None = -1,
            Turkish = 0,
            English = 1,
            Portuguese = 2,
            Chinese = 3,
            Indonesian = 4
        }

        private class LanguageObject
        {
            public PictureBox pictureBox;
            public Label label;
            public Image passiveImage;
            public Image activeImage;
        }

        private List<LanguageObject> languageObjects = new List<LanguageObject>();
        public LanguageType SelectedLanguage { get; set; }
        private LanguageType activeLanguage = LanguageType.None;

        public LanguagesForm(LanguageType activeLanguage)
        {
            InitializeComponent();

            this.activeLanguage = activeLanguage;
        }

        private void LanguagesForm_Load(object sender, EventArgs e)
        {
            int panelIndex = 0;
            foreach (Control languagePanel in flowLayoutPanel1.Controls)
            {
                languagePanel.MouseMove += Language_MouseMove;
                languagePanel.MouseLeave += Language_MouseLeave;
                languagePanel.Click += Language_Click;
                languagePanel.Cursor = Cursors.Hand;
                languagePanel.Tag = panelIndex;

                LanguageObject languageObject = new LanguageObject();
                foreach (Control item in languagePanel.Controls)
                {
                    if (item.GetType() == typeof(PictureBox))
                        languageObject.pictureBox = (PictureBox)item;
                    else if (item.GetType() == typeof(Label))
                        languageObject.label = (Label)item;
                }
                languageObjects.Add(languageObject);
                panelIndex++;
            }

            for (int i = 0; i < languageObjects.Count; i++)
            {
                languageObjects[i].pictureBox.Tag = i;
                languageObjects[i].pictureBox.Click += Language_Click;
                languageObjects[i].pictureBox.MouseMove += Language_MouseMove;
                languageObjects[i].pictureBox.MouseLeave += Language_MouseLeave;
                languageObjects[i].pictureBox.Cursor = Cursors.Hand;
                languageObjects[i].label.Tag = i;
                languageObjects[i].label.Click += Language_Click;
                languageObjects[i].label.MouseMove += Language_MouseMove;
                languageObjects[i].label.MouseLeave += Language_MouseLeave;
                languageObjects[i].label.Cursor = Cursors.Hand;
            }

            languageObjects[0].passiveImage = Properties.Resources.flag_turkey_passive;
            languageObjects[0].activeImage = Properties.Resources.flag_turkey_active;
            languageObjects[1].passiveImage = Properties.Resources.flag_usa_passive;
            languageObjects[1].activeImage = Properties.Resources.flag_usa_active;
            languageObjects[2].passiveImage = Properties.Resources.flag_brasil_passive;
            languageObjects[2].activeImage = Properties.Resources.flag_brasil_active;
            languageObjects[3].passiveImage = Properties.Resources.flag_china_passive;
            languageObjects[3].activeImage = Properties.Resources.flag_china_active;
            languageObjects[4].passiveImage = Properties.Resources.flag_indonesia_passive;
            languageObjects[4].activeImage = Properties.Resources.flag_indonesia_active;

            SetActiveLanguage(activeLanguage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.SelectedLanguage = LanguageType.None;
            this.Close();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Azure;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void SetActiveLanguage(LanguageType activeLanguage)
        {
            int activeLanguageIndex = Convert.ToInt32(activeLanguage);
            SelectedLanguage = activeLanguage;
            for (int i = 0; i < languageObjects.Count; i++)
                languageObjects[i].pictureBox.Image = activeLanguageIndex == i ? languageObjects[i].activeImage : languageObjects[i].passiveImage;
        }

        private void Language_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            int languageIndex = Convert.ToInt32(control.Tag.ToString());
            if (languageIndex != Convert.ToInt32(SelectedLanguage))
            {
                languageObjects[languageIndex].pictureBox.Image = languageObjects[languageIndex].passiveImage;
                languageObjects[languageIndex].label.ForeColor = Color.LightGray;
            }
        }

        private void Language_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            int languageIndex = Convert.ToInt32(control.Tag.ToString());
            languageObjects[languageIndex].pictureBox.Image = languageObjects[languageIndex].activeImage;
            languageObjects[languageIndex].label.ForeColor = Color.White;
        }

        private void Language_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            int selectedLanguageIndex = Convert.ToInt32(control.Tag.ToString());

            if (selectedLanguageIndex == (int)LanguageType.Turkish)
            {
                this.DialogResult = DialogResult.OK;
                this.SelectedLanguage = LanguageType.Turkish;
                this.Close();
            }
            else if (selectedLanguageIndex == (int)LanguageType.English)
            {
                this.DialogResult = DialogResult.OK;
                this.SelectedLanguage = LanguageType.English;
                this.Close();
            }
            else if (selectedLanguageIndex == (int)LanguageType.Portuguese)
            {
                this.DialogResult = DialogResult.OK;
                this.SelectedLanguage = LanguageType.Portuguese;
                this.Close();
            }
            else if (selectedLanguageIndex == (int)LanguageType.Chinese)
            {
                this.DialogResult = DialogResult.OK;
                this.SelectedLanguage = LanguageType.Chinese;
                this.Close();
            }
            else if (selectedLanguageIndex == (int)LanguageType.Indonesian)
            {
                this.DialogResult = DialogResult.OK;
                this.SelectedLanguage = LanguageType.Indonesian;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.SelectedLanguage = LanguageType.None;
                this.Close();
            }
        }
    }
}
