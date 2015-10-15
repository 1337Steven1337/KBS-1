using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TheHunt.Controller;

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
            this.optionBtn.Location = new Point((this.Size.Width / 2 - optionBtn.Width / 2), (this.Size.Height / 2 - optionBtn.Height / 2) + 1 * optionBtn.Height + 15);
            this.exitBtn.Location = new Point((this.Size.Width / 2 - exitBtn.Width / 2), (this.Size.Height / 2 - exitBtn.Height / 2) + 2 * exitBtn.Height + 30);

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
            }
            else
            {
                //Fullscreen deactiveren
                this.ClientSize = new Size(startRes.Width, startRes.Height);
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - startRes.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - startRes.Height) / 2);
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //initOptionsPanel();
            this.speelKlikGeluid(sender, e);
            this.Options();
            

        }

        private void Options()
        {
            PlayBtn.Visible = false;
            CreateLvlBtn.Visible = false;
            HighscoreBtn.Visible = false;
            optionBtn.Visible = false;
            exitBtn.Visible = false;

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
            PlayBtn.Visible = true;
            CreateLvlBtn.Visible = true;
            HighscoreBtn.Visible = true;
            optionBtn.Visible = true;
            exitBtn.Visible = true;
        }

        private void GaTerugnaarMenu()
        {
            PlayBtn.Visible = false;
            CreateLvlBtn.Visible = false;
            HighscoreBtn.Visible = false;
            optionBtn.Visible = false;
            exitBtn.Visible = false;

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
            PlayBtn.Visible = false;
            CreateLvlBtn.Visible = false;
            HighscoreBtn.Visible = false;
            optionBtn.Visible = false;
            exitBtn.Visible = false;

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
    }
}
