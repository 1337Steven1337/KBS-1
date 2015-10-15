using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using TheHunt.Controller;
using TheHunt.Designer;

namespace TheHunt
{ 

    public partial class  OptionsDialog : Form
    {

        private Boolean isClosed = false;
        private Boolean changeFullScreen = false;
         
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

            if (inGame)
            {
                buttonFullScreen.Enabled = false;
            }
            //this.Visible = true;
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            trackBarEffectsVolume.Value = (int)Properties.Sound.Default.master;
            trackBarMusicVolume.Value = (int)Properties.Sound.Default.music;
            trackBarEffectsVolume.Value = (int)Properties.Sound.Default.effects;
        }

        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            Properties.Screen.Default.full = !Properties.Screen.Default.full;

            Console.WriteLine(Properties.Screen.Default.full);
            Properties.Screen.Default.Save();

            changeFullScreen = true;
            FullScreenText();


        }

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

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            isClosed = true;
            this.Visible = false;
        }

        public Boolean getClosed()
        {
            return isClosed;
        }

        public Boolean getChangeFullScreen()
        {
            return changeFullScreen;
        }

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

        //this.testlabel

    }
}
