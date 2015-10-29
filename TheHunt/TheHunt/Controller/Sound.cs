﻿using System;
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
        private MediaPlayer SSBAA = new MediaPlayer();
        private MediaPlayer SSBEX = new MediaPlayer();
        public bool AADone = false;
        public bool EXDone = false;

        public Sound()
        {
            Properties.Sound.Default.PropertyChanged += SettingChanged;
            player_background.MediaEnded += LoopBackgroundMusic;
            player_background.MediaOpened += LoopBackgroundMusic;
            SSBAA.MediaEnded += delegate (object sender, EventArgs e) { this.AADone = true; playExplosionSound(sender, e); };
            SSBEX.MediaEnded += delegate (object sender, EventArgs e) { this.EXDone = true;};

            this.setBackgroundVolume();
            this.setEffectVolume();

            player_background.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/bgm.wav"));
            player_click.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav"));

        }

        private void LoopBackgroundMusic(object sender, EventArgs e)
        {
            player_background.Play();
        }


        public void playAA()
        {
            SSBAA.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/AA.wav"));
            SSBAA.Play();
        }


        private void playExplosionSound(object sender, EventArgs e)
        {
            SSBEX.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/explosion.wav"));
            SSBEX.Play();
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
            SSBAA.Volume = Properties.Sound.Default.effects / 100 * (Properties.Sound.Default.master / 100);
            SSBEX.Volume = Properties.Sound.Default.effects / 100 * (Properties.Sound.Default.master / 100);
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
