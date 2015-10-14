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
            //changeFullScreen = false;
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

    }
}
