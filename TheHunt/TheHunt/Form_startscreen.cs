using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Windows.Media;
using System.Runtime.InteropServices;


namespace TheHunt
{
    public partial class Form_startscreen : Form
    {
        public static Size startRes = new Size();
        MediaPlayer bgm = new MediaPlayer();
        MediaPlayer klikMP = new MediaPlayer();

        public Form_startscreen()
        {
            InitializeComponent();
            startRes.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.8);
            startRes.Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8);
            this.ClientSize = new Size(startRes.Width, startRes.Height);
            bgm.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/bgm.wav"));
            bgm.MediaEnded += new EventHandler(bgmAfgelopen);
            bgm.Play();

            picturebox_play_game_btn.BackColor = System.Drawing.Color.Transparent;
            picturebox_create_level_btn.BackColor = System.Drawing.Color.Transparent;
            picturebox_options_btn.BackColor = System.Drawing.Color.Transparent;
            picturebox_exit_game.BackColor = System.Drawing.Color.Transparent;
            picturebox_highscore_btn.BackColor = System.Drawing.Color.Transparent;

            //Bereken knoppen locaties
            this.picturebox_play_game_btn.Location = new Point((this.Size.Width / 2 - picturebox_play_game_btn.Width / 2), (this.Size.Height / 2 - picturebox_play_game_btn.Height / 2) - 2 * picturebox_play_game_btn.Height - 30);
            this.picturebox_create_level_btn.Location = new Point((this.Size.Width / 2 - picturebox_create_level_btn.Width / 2), (this.Size.Height / 2 - picturebox_create_level_btn.Height / 2) - 1 * picturebox_create_level_btn.Height - 15);
            this.picturebox_highscore_btn.Location = new Point((this.Size.Width / 2 - picturebox_highscore_btn.Width / 2), (this.Size.Height / 2 - picturebox_highscore_btn.Height / 2));
            this.picturebox_options_btn.Location = new Point((this.Size.Width / 2 - picturebox_options_btn.Width / 2), (this.Size.Height / 2 - picturebox_options_btn.Height / 2) + 1 * picturebox_options_btn.Height + (15));
            this.picturebox_exit_game.Location = new Point((this.Size.Width / 2 - picturebox_exit_game.Width / 2), (this.Size.Height / 2 - picturebox_exit_game.Height / 2) + 2 * picturebox_exit_game.Height + (30));

            Properties.Screen.Default.PropertyChanged += ScreenPropertyChanged;
            Properties.Sound.Default.PropertyChanged += SoundPropertyChanged;

            ResizeScreen();
            SoundBars();
            GaTerugnaarMenu(this, null);
        }

        private void SoundPropertyChanged(object sender, PropertyChangedEventArgs e)
        {            
            if(e.PropertyName == "music")
            {
                bgm.Volume = Properties.Sound.Default.music;
            }
            else if(e.PropertyName == "effects")
            {
                klikMP.Volume = Properties.Sound.Default.effects;
            }
        }

        //Values uit Properties Settings in trackbar laten zien
        private void SoundBars()
        {
            mastervol_trackbar.Value = (int)Properties.Sound.Default.master;
            musicvol_trackbar.Value = (int)Properties.Sound.Default.music;
            effectvol_trackbar.Value = (int)Properties.Sound.Default.effects;
        }

        private void ScreenPropertyChanged(object sender, PropertyChangedEventArgs e)
        {            
            if(e.PropertyName == "full")
            {
                ResizeScreen();
                initOptionsPanel();
            }
        }

        private void ResizeScreen()
        {

            if (Properties.Screen.Default.full)
            {
                //Fullscreen activeren
                this.WindowState = FormWindowState.Normal;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                fullscreen_btn.Text = "Full Screen: On";
            }
            else
            {
                //Fullscreen deactiveren
                this.ClientSize = new Size(startRes.Width, startRes.Height);
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - startRes.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - startRes.Height) / 2);
                fullscreen_btn.Text = "Full Screen: Off";
            }
        }

        /// <summary>
        /// ONDERSTAANDE IS EEN FIX OM ERGE FLICKERING TE VOORKOMEN
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;

            }
        }


        public void speelKlikGeluid(object sender, EventArgs e)
        {
                klikMP.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav"));
                klikMP.Play();  
        }


        private void btn_PlayGame(object sender, EventArgs e)
        {
            this.Hide();
            Player map = new Player(this);
            map.Show();
        }


        public void pauzeerGame(object sender, EventArgs e)
        {

        }

        private void bgmAfgelopen(object sender, EventArgs e)
        {
            bgm.Position = TimeSpan.Zero;
            bgm.Play();
        }



        private void buttonFuSc_Click(object sender, EventArgs e)
        {
            Properties.Screen.Default.full = !Properties.Screen.Default.full;

            Console.WriteLine(Properties.Screen.Default.full);
            Properties.Screen.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/SFX"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/SFX");
            }

            if (!File.Exists(Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav") || !File.Exists(Directory.GetCurrentDirectory() + "/SFX/bgm.wav"))
            {
                MemoryStream memStream = new MemoryStream();

                if (!File.Exists(Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav"))
                {

                Properties.Resources.klikgeluid.CopyTo(memStream);
                byte[] byteArray = memStream.ToArray();
                File.WriteAllBytes(Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav", byteArray);
                memStream.SetLength(0);
                }
                else if (!File.Exists(Directory.GetCurrentDirectory() + "/SFX/bgm.wav"))
                {
                Properties.Resources.bgm.CopyTo(memStream);
                    byte[] byteArray = memStream.ToArray();
                File.WriteAllBytes(Directory.GetCurrentDirectory() + "/SFX/bgm.wav", byteArray);
                memStream.SetLength(0);
                }
            }


            this.picturebox_play_game_btn.Click += new System.EventHandler(this.speelKlikGeluid);
            this.picturebox_options_btn.Click += new System.EventHandler(this.speelKlikGeluid);
        }

        private void Afsluiten(object sender, EventArgs e)
        {
            speelKlikGeluid(sender, e);
            klikMP.MediaEnded += new EventHandler(eindeAfsluiten);
        }

        private void eindeAfsluiten(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }

        public void initOptionsPanel()
        {
            picturebox_play_game_btn.Visible = false;
            picturebox_create_level_btn.Visible = false;
            picturebox_highscore_btn.Visible = false;
            picturebox_options_btn.Visible = false;
            picturebox_exit_game.Visible = false;
            picturebox_infotext.Visible = true;

            panel_options.Width = (int)(this.Width * 0.85);
            panel_options.Height = (int)(this.Height * 0.75);
            panel_options.Location = new Point((int)(this.Width * 0.1), (int)(this.Height * 0.1));


            label_options_header.Location = new Point((int)(this.panel_options.Location.X + this.panel_options.Width / 4), (int)(this.panel_options.Location.Y - 50));

            picturebox_infotext.BackgroundImage = Properties.Resources.uitleg;
            picturebox_infotext.BackColor = System.Drawing.Color.Transparent;
            picturebox_infotext.Size = Properties.Resources.uitleg.Size;
            picturebox_infotext.Location = new Point(panel_options.Location.X + panel_options.Width / 2, panel_options.Location.Y);

            label_options_header.Visible = true;
            fullscreen_btn.Visible = true;
            picturebox_infotext.Visible = true;
            picturebox_back_btn.Visible = true;

            label_master_volume.Visible = true;
            label_music_volume.Visible = true;
            label_effects_volume.Visible = true;

            mastervol_trackbar.Visible = true;
            musicvol_trackbar.Visible = true;
            effectvol_trackbar.Visible = true;


            panel_options.Controls.Add(label_options_header);

            panel_options.Controls.Add(fullscreen_btn);

            panel_options.Controls.Add(label_master_volume);
            panel_options.Controls.Add(label_music_volume);
            panel_options.Controls.Add(label_effects_volume);

            panel_options.Controls.Add(picturebox_infotext);

            panel_options.Controls.Add(mastervol_trackbar);
            panel_options.Controls.Add(musicvol_trackbar);
            panel_options.Controls.Add(effectvol_trackbar);

            panel_options.Visible = true;


            picturebox_back_btn.Image = global::TheHunt.Properties.Resources.backBtn;
            picturebox_back_btn.Location = new Point((int)(panel_options.Location.X + (panel_options.Width / 2) - picturebox_play_game_btn.Width / 2), (int)(panel_options.Location.Y + (panel_options.Height) + 0.15 * picturebox_play_game_btn.Height));
            this.picturebox_back_btn.Click += new System.EventHandler(this.speelKlikGeluid);
            this.picturebox_back_btn.Click += new System.EventHandler(this.GaTerugnaarMenu);


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            initOptionsPanel();

        }

        public void GaTerugnaarMenu(object sender, EventArgs e)
        {
            fullscreen_btn.Visible = false;
            label_options_header.Visible = false;
            picturebox_infotext.Visible = false;
            picturebox_back_btn.Visible = false;
            panel_options.Visible = false;


            this.picturebox_play_game_btn.Location = new Point((this.Size.Width / 2 - picturebox_play_game_btn.Width / 2), (this.Size.Height / 2 - picturebox_play_game_btn.Height / 2) - 2 * picturebox_play_game_btn.Height - 30);
            this.picturebox_create_level_btn.Location = new Point((this.Size.Width / 2 - picturebox_create_level_btn.Width / 2), (this.Size.Height / 2 - picturebox_create_level_btn.Height / 2) - 1 * picturebox_create_level_btn.Height - 15);
            this.picturebox_highscore_btn.Location = new Point((this.Size.Width / 2 - picturebox_highscore_btn.Width / 2), (this.Size.Height / 2 - picturebox_highscore_btn.Height / 2));
            this.picturebox_options_btn.Location = new Point((this.Size.Width / 2 - picturebox_options_btn.Width / 2), (this.Size.Height / 2 - picturebox_options_btn.Height / 2) + 1 * picturebox_options_btn.Height + 15);
            this.picturebox_exit_game.Location = new Point((this.Size.Width / 2 - picturebox_exit_game.Width / 2), (this.Size.Height / 2 - picturebox_exit_game.Height / 2) + 2 * picturebox_exit_game.Height + 30);

            picturebox_play_game_btn.Visible = true;
            picturebox_create_level_btn.Visible = true;
            picturebox_highscore_btn.Visible = true;
            picturebox_options_btn.Visible = true;
            picturebox_exit_game.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            panel_options.BackColor = System.Drawing.Color.FromArgb(95, System.Drawing.Color.Black);
        }

        private void mastervol_trackbar_Scroll(object sender, EventArgs e)
        {
            float master_vol = mastervol_trackbar.Value;
            float music_vol = musicvol_trackbar.Value;
            float effects_vol = effectvol_trackbar.Value;
            bgm.Volume = music_vol / 100 * (master_vol / 100);
            klikMP.Volume = effects_vol / 100 * (master_vol / 100);

            Properties.Sound.Default.master = master_vol;
            Properties.Sound.Default.Save();
        }


        private void musicvol_trackbar_Scroll(object sender, EventArgs e)
        {
            float master_vol = mastervol_trackbar.Value;
            float music_vol = musicvol_trackbar.Value;
            float effects_vol = effectvol_trackbar.Value;
            bgm.Volume = music_vol / 100 * (master_vol / 100);
            klikMP.Volume = effects_vol / 100 * (master_vol / 100);

            Properties.Sound.Default.music = music_vol;
            Properties.Sound.Default.Save();
        }

        private void effectsvol_trackbar_Scroll(object sender, EventArgs e)
        {
            float master_vol = mastervol_trackbar.Value;
            float music_vol = musicvol_trackbar.Value;
            float effects_vol = effectvol_trackbar.Value;
            bgm.Volume = music_vol / 100 * (master_vol / 100);
            klikMP.Volume = effects_vol / 100 * (master_vol / 100);

            Properties.Sound.Default.effects = effects_vol;
            Properties.Sound.Default.Save();
        }
    }
}
