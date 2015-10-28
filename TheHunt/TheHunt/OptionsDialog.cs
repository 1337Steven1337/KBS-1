using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheHunt
{

    public partial class OptionsDialog : Form
    {

        private Boolean isClosed = false;
        private Boolean changeFullScreen = false;

        protected override void WndProc(ref Message message)
        {
            const int WM_NCHITTEST = 0x0084;

            if (message.Msg == WM_NCHITTEST)
                return;

            base.WndProc(ref message);
        }

        public OptionsDialog(Boolean inGame)
        {
            InitializeComponent();
            FullScreenText();
            //layoutfix(omslachtigerwijs)
            this.Size = new Size(982, 453);
            this.trackBarMasterVolume.Location = new System.Drawing.Point(164, 70);
            this.trackBarMasterVolume.Size = new System.Drawing.Size(200, 56);
            this.trackBarMusicVolume.Size = new System.Drawing.Size(200, 56);
            this.trackBarMusicVolume.Location = new System.Drawing.Point(164, 140);
            this.trackBarEffectsVolume.Location = new System.Drawing.Point(164, 210);
            this.trackBarEffectsVolume.Size = new System.Drawing.Size(200, 56);
            this.buttonFullScreen.Location = new System.Drawing.Point(12, 392);
            this.buttonFullScreen.Size = new System.Drawing.Size(200, 50);
            this.buttonBackToMenu.Location = new System.Drawing.Point(218, 392);
            this.buttonBackToMenu.Size = new System.Drawing.Size(200, 50);
            this.pictureBox1.Location = new System.Drawing.Point(421, 12);
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Size = new System.Drawing.Size(165, 46);
            this.labelMaster.Location = new System.Drawing.Point(17, 70);
            this.labelMaster.Size = new System.Drawing.Size(147, 20);
            this.labelMusic.Location = new System.Drawing.Point(17, 140);
            this.labelMusic.Size = new System.Drawing.Size(139, 20);
            this.labelEffects.Location = new System.Drawing.Point(17, 210);
            this.labelEffects.Size = new System.Drawing.Size(149, 20);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;

            if (inGame)
            {
                this.Controls.Remove(this.buttonFullScreen);
                this.Controls.Remove(this.showOnScreenControls);

                buttonFullScreen.Enabled = false;
            }
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            //Inladen laatst opgeslagen volumeopties
            trackBarMasterVolume.Value = (int)Properties.Sound.Default.master;
            trackBarMusicVolume.Value = (int)Properties.Sound.Default.music;
            trackBarEffectsVolume.Value = (int)Properties.Sound.Default.effects;
            
            this.displayEnemyInfo.Checked = Properties.Settings.Default.enemyInformation;
            this.displayEnemyInfo.CheckedChanged += displayEnemyInfo_CheckedChanged;

            this.showOnScreenControls.Checked = Properties.Settings.Default.onScreenControls;
            this.showOnScreenControls.CheckedChanged += showOnScreenControls_CheckedChanged;
        }

        //Geeft teken van afsluiten opties
        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            isClosed = true;
            this.Visible = false;
        }

        //Toggle FullScreen aan/uit na klikken Full Screen button
        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            Properties.Screen.Default.full = !Properties.Screen.Default.full;

            Console.WriteLine(Properties.Screen.Default.full);
            Properties.Screen.Default.Save();

            changeFullScreen = true;
            FullScreenText();


        }

        //Updaten knoptekst na veranderen FullScreen
        private void FullScreenText()
        {
            if (Properties.Screen.Default.full)
            {
                this.buttonFullScreen.Text = "Full Screen: On";
            }
            else
            {
                this.buttonFullScreen.Text = "Full Screen: Off";
            }
        }

        //Feedback geven aan hoofdscherm
        public Boolean getClosed()
        {
            return isClosed;
        }

        public Boolean getChangeFullScreen()
        {
            return changeFullScreen;
        }

        //Updaten volume n.a.v. verslepen van de trackbar(s)
        private void trackBarMasterVolume_Scroll(object sender, EventArgs e)
        {
            Properties.Sound.Default.master = trackBarMasterVolume.Value;
            Properties.Sound.Default.Save();
        }

        private void trackBarMusicVolume_Scroll(object sender, EventArgs e)
        {
            Properties.Sound.Default.music = trackBarMusicVolume.Value;
            Properties.Sound.Default.Save();
        }

        private void trackBarEffectsVolume_Scroll(object sender, EventArgs e)
        {
            Properties.Sound.Default.effects = trackBarEffectsVolume.Value;
            Properties.Sound.Default.Save();
        }

        private void displayEnemyInfo_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.enemyInformation = this.displayEnemyInfo.Checked;
            Properties.Settings.Default.Save();
        }

        private void showOnScreenControls_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.onScreenControls = this.showOnScreenControls.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
