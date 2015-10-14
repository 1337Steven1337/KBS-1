using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TheHunt.Properties;

namespace TheHunt.Controller
{
    class Sound
    {
        private static Sound instance = null;

        private MediaPlayer player_background = new MediaPlayer();
        private MediaPlayer player_click = new MediaPlayer();

        private Sound()
        {
            Properties.Sound.Default.PropertyChanged += SettingChanged;
            player_background.MediaEnded += LoopBackgroundMusic;

            player_background.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/bgm.wav"));
            player_click.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav"));
        }

        private void LoopBackgroundMusic(object sender, EventArgs e)
        {
            player_background.Play();
        }

        private void SettingChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "master")
            {
                setBackgroundVolume();
                setEffectVolume();
            }
            else if (e.PropertyName == "effects")
            {
                setEffectVolume();
            }
            else if (e.PropertyName == "music")
            {
                setBackgroundVolume();
            }
        }

        private void setBackgroundVolume()
        {
            player_background.Volume = Properties.Sound.Default.music / 100 * (Properties.Sound.Default.master / 100);
        }

        private void setEffectVolume()
        {
            player_click.Volume = Properties.Sound.Default.effects / 100 * (Properties.Sound.Default.master / 100);
        }

        public void click()
        {
            player_click.Play();
            player_click.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav"));
        }

        public static Sound Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Sound();
                }

                return instance;
            }
        }
    }
}
