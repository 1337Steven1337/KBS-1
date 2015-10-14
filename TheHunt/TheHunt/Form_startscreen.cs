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
using TheHunt.Controller;
using TheHunt.Designer;

namespace TheHunt
{
    public partial class form_startscreen : Form
    {
        public static Size startRes = new Size();
        private Sound sound = null;

        public form_startscreen()
        {
            InitializeComponent();
            this.sound = Sound.Instance;
            startRes.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.8);
            startRes.Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8);
            this.ClientSize = new Size(startRes.Width, startRes.Height);

            PlayBtn.BackColor = System.Drawing.Color.Transparent;
            CreateLvlBtn.BackColor = System.Drawing.Color.Transparent;
            optionBtn.BackColor = System.Drawing.Color.Transparent;
            exitBtn.BackColor = System.Drawing.Color.Transparent;
            HighscoreBtn.BackColor = System.Drawing.Color.Transparent;

            //Bereken knoppen locaties
            this.PlayBtn.Location = new Point((this.Size.Width / 2 - PlayBtn.Width / 2), (this.Size.Height / 2 - PlayBtn.Height / 2) - 2 * PlayBtn.Height - 30);
            this.CreateLvlBtn.Location = new Point((this.Size.Width / 2 - CreateLvlBtn.Width / 2), (this.Size.Height / 2 - CreateLvlBtn.Height / 2) - 1 * CreateLvlBtn.Height - 15);
            this.HighscoreBtn.Location = new Point((this.Size.Width / 2 - HighscoreBtn.Width / 2), (this.Size.Height / 2 - HighscoreBtn.Height / 2));
            this.optionBtn.Location = new Point((this.Size.Width / 2 - optionBtn.Width / 2), (this.Size.Height / 2 - optionBtn.Height / 2) + 1 * optionBtn.Height + (15));
            this.exitBtn.Location = new Point((this.Size.Width / 2 - exitBtn.Width / 2), (this.Size.Height / 2 - exitBtn.Height / 2) + 2 * exitBtn.Height + (30));

            Properties.Screen.Default.PropertyChanged += ScreenPropertyChanged;

            ResizeScreen();
            //SoundBars();
            GaTerugnaarMenu(this, null);
        }

        private void ScreenPropertyChanged(object sender, PropertyChangedEventArgs e)
        {            
            if(e.PropertyName == "full")
            {
                ResizeScreen();
                //initOptionsPanel();
                Validate();
            }
        }

        private void ResizeScreen()
        {

            if (Properties.Screen.Default.full)
            {
                //Fullscreen activeren
                this.WindowState = FormWindowState.Normal;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                buttonFuSc.Text = "Full Screen: On";
            }
            else
            {
                //Fullscreen deactiveren
                this.ClientSize = new Size(startRes.Width, startRes.Height);
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - startRes.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - startRes.Height) / 2);
                buttonFuSc.Text = "Full Screen: Off";
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


        public void openDesigner(object sender,EventArgs e)
        {
            Designer.Designer designwindow = new Designer.Designer(this);
        }

        public void speelKlikGeluid(object sender, EventArgs e)
        {
            sound.click();
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


            this.PlayBtn.Click += new System.EventHandler(this.speelKlikGeluid);
            this.optionBtn.Click += new System.EventHandler(this.speelKlikGeluid);
            this.CreateLvlBtn.Click += CreateLvlBtn_Click;
        }

        private void CreateLvlBtn_Click(object sender, EventArgs e)
        {
            Designer.Designer designer = new Designer.Designer(this);
            designer.Show();
            this.Hide();
        }

        private void Afsluiten(object sender, EventArgs e)
        {
            sound.click();

            Application.Exit();
            Close();
        }



        public void initOptionsPanel()
        {
            PlayBtn.Visible = false;
            CreateLvlBtn.Visible = false;
            HighscoreBtn.Visible = false;
            optionBtn.Visible = false;
            exitBtn.Visible = false;
            uitlegPictureBox.Visible = true;

            optionPanel.Width = (int)(this.Width * 0.85);
            optionPanel.Height = (int)(this.Height * 0.75);
            optionPanel.Location = new Point((int)(this.Width * 0.1), (int)(this.Height * 0.1));


            labelOptionsHeader.Location = new Point((int)(this.optionPanel.Location.X + this.optionPanel.Width / 4), (int)(this.optionPanel.Location.Y - 50));

            uitlegPictureBox.BackgroundImage = Properties.Resources.uitleg;
            uitlegPictureBox.BackColor = System.Drawing.Color.Transparent;
            uitlegPictureBox.Size = Properties.Resources.uitleg.Size;
            uitlegPictureBox.Location = new Point(optionPanel.Location.X + optionPanel.Width / 2, optionPanel.Location.Y);

            labelOptionsHeader.Visible = true;
            buttonFuSc.Visible = true;
            uitlegPictureBox.Visible = true;
            backBtn.Visible = true;

            MasterVolumeLabel.Visible = true;
            MusicVolumeLabel.Visible = true;
            EffectsVolumeLabel.Visible = true;

            MasterTrackBar.Visible = true;
            MusicTrackBar.Visible = true;
            EffectsTrackbar.Visible = true;


            optionPanel.Controls.Add(labelOptionsHeader);

            optionPanel.Controls.Add(buttonFuSc);

            optionPanel.Controls.Add(MasterVolumeLabel);
            optionPanel.Controls.Add(MusicVolumeLabel);
            optionPanel.Controls.Add(EffectsVolumeLabel);

            optionPanel.Controls.Add(uitlegPictureBox);

            optionPanel.Controls.Add(MasterTrackBar);
            optionPanel.Controls.Add(MusicTrackBar);
            optionPanel.Controls.Add(EffectsTrackbar);

            optionPanel.Visible = true;


            backBtn.Image = global::TheHunt.Properties.Resources.backBtn;
            backBtn.Location = new Point((int)(optionPanel.Location.X + (optionPanel.Width / 2) - PlayBtn.Width / 2), (int)(optionPanel.Location.Y + (optionPanel.Height) + 0.15 * PlayBtn.Height));
            this.backBtn.Click += new System.EventHandler(this.speelKlikGeluid);
            this.backBtn.Click += new System.EventHandler(this.GaTerugnaarMenu);


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //initOptionsPanel();
            this.speelKlikGeluid(sender, e);
            this.Options();
            

        }

        private void Options()
        {
            //PlayBtn.Visible = false;
            //CreateLvlBtn.Visible = false;
            //exitBtn.Visible = false;
            //optionBtn.Visible = false;
            //HighscoreBtn.Visible = false;
            OptionsDialog Options = new OptionsDialog(false);
            Options.ShowDialog();
            if (Options.getChangeFullScreen())
            {
                GaTerugnaarMenu();

                if (Options.getClosed())
                {
                    Options.Close();
                    Options = null;
                }

            }
            else if (Options.getClosed())
            {
                Options.Close();
                Options = null; 
            }
        }

        private void GaTerugnaarMenu()
        {
            buttonFuSc.Visible = false;
            labelOptionsHeader.Visible = false;
            uitlegPictureBox.Visible = false;
            backBtn.Visible = false;
            optionPanel.Visible = false;


            this.PlayBtn.Location = new Point((this.Size.Width / 2 - PlayBtn.Width / 2), (this.Size.Height / 2 - PlayBtn.Height / 2) - 2 * PlayBtn.Height - 30);
            this.CreateLvlBtn.Location = new Point((this.Size.Width / 2 - CreateLvlBtn.Width / 2), (this.Size.Height / 2 - CreateLvlBtn.Height / 2) - 1 * CreateLvlBtn.Height - 15);
            this.HighscoreBtn.Location = new Point((this.Size.Width / 2 - HighscoreBtn.Width / 2), (this.Size.Height / 2 - HighscoreBtn.Height / 2));
            this.optionBtn.Location = new Point((this.Size.Width / 2 - optionBtn.Width / 2), (this.Size.Height / 2 - optionBtn.Height / 2) + 1 * optionBtn.Height + 15);
            this.exitBtn.Location = new Point((this.Size.Width / 2 - exitBtn.Width / 2), (this.Size.Height / 2 - exitBtn.Height / 2) + 2 * exitBtn.Height + 30);


            PlayBtn.Visible = true;
            CreateLvlBtn.Visible = true;
            HighscoreBtn.Visible = true;
            optionBtn.Visible = true;
            exitBtn.Visible = true;
        }

        public void GaTerugnaarMenu(object sender, EventArgs e)
        {
            buttonFuSc.Visible = false;
            labelOptionsHeader.Visible = false;
            uitlegPictureBox.Visible = false;
            backBtn.Visible = false;
            optionPanel.Visible = false;


            this.PlayBtn.Location = new Point((this.Size.Width / 2 - PlayBtn.Width / 2), (this.Size.Height / 2 - PlayBtn.Height / 2) - 2 * PlayBtn.Height - 30);
            this.CreateLvlBtn.Location = new Point((this.Size.Width / 2 - CreateLvlBtn.Width / 2), (this.Size.Height / 2 - CreateLvlBtn.Height / 2) - 1 * CreateLvlBtn.Height - 15);
            this.HighscoreBtn.Location = new Point((this.Size.Width / 2 - HighscoreBtn.Width / 2), (this.Size.Height / 2 - HighscoreBtn.Height / 2));
            this.optionBtn.Location = new Point((this.Size.Width / 2 - optionBtn.Width / 2), (this.Size.Height / 2 - optionBtn.Height / 2) + 1 * optionBtn.Height + 15);
            this.exitBtn.Location = new Point((this.Size.Width / 2 - exitBtn.Width / 2), (this.Size.Height / 2 - exitBtn.Height / 2) + 2 * exitBtn.Height + 30);


            PlayBtn.Visible = true;
            CreateLvlBtn.Visible = true;
            HighscoreBtn.Visible = true;
            optionBtn.Visible = true;
            exitBtn.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            optionPanel.BackColor = System.Drawing.Color.FromArgb(95, System.Drawing.Color.Black);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Properties.Sound.Default.master = MasterTrackBar.Value;
            Properties.Sound.Default.Save();
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Properties.Sound.Default.music = MusicTrackBar.Value;
            Properties.Sound.Default.Save();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Properties.Sound.Default.effects = EffectsTrackbar.Value;
            Properties.Sound.Default.Save();
        }

        public void setButtonLocations()
        {
            this.Visible = false;

            buttonFuSc.Visible = false;
            labelOptionsHeader.Visible = false;
            uitlegPictureBox.Visible = false;
            backBtn.Visible = false;
            optionPanel.Visible = false;


            this.PlayBtn.Location = new Point((this.Size.Width / 2 - PlayBtn.Width / 2), (this.Size.Height / 2 - PlayBtn.Height / 2) - 2 * PlayBtn.Height - 30);
            this.CreateLvlBtn.Location = new Point((this.Size.Width / 2 - CreateLvlBtn.Width / 2), (this.Size.Height / 2 - CreateLvlBtn.Height / 2) - 1 * CreateLvlBtn.Height - 15);
            this.HighscoreBtn.Location = new Point((this.Size.Width / 2 - HighscoreBtn.Width / 2), (this.Size.Height / 2 - HighscoreBtn.Height / 2));
            this.optionBtn.Location = new Point((this.Size.Width / 2 - optionBtn.Width / 2), (this.Size.Height / 2 - optionBtn.Height / 2) + 1 * optionBtn.Height + 15);
            this.exitBtn.Location = new Point((this.Size.Width / 2 - exitBtn.Width / 2), (this.Size.Height / 2 - exitBtn.Height / 2) + 2 * exitBtn.Height + 30);


            PlayBtn.Visible = true;
            CreateLvlBtn.Visible = true;
            HighscoreBtn.Visible = true;
            optionBtn.Visible = true;
            exitBtn.Visible = true;

            Validate();
            //MessageBox.Show("Ok");

            Console.WriteLine("Q");
            this.Visible = true;
        }
    }
}
