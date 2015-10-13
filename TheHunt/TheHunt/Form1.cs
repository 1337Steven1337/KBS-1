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
    public partial class Form1 : Form
    {
        public static Size startRes = new Size();
        MediaPlayer bgm = new MediaPlayer();
        MediaPlayer klikMP = new MediaPlayer();

        public Form1()
        {
            InitializeComponent();
            startRes.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.8);
            startRes.Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8);
            this.ClientSize = new Size(startRes.Width, startRes.Height);
            bgm.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/bgm.wav"));
            bgm.MediaEnded += new EventHandler(bgmAfgelopen);
            bgm.Play();

            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox5.BackColor = System.Drawing.Color.Transparent;
            pictureBox3.BackColor = System.Drawing.Color.Transparent;

            //Bereken knoppen locaties
            this.pictureBox1.Location = new Point((this.Size.Width / 2 - pictureBox1.Width / 2), (this.Size.Height / 2 - pictureBox1.Height / 2) - 2 * pictureBox1.Height - 30);
            this.pictureBox2.Location = new Point((this.Size.Width / 2 - pictureBox2.Width / 2), (this.Size.Height / 2 - pictureBox2.Height / 2) - 1 * pictureBox2.Height - 15);
            this.pictureBox3.Location = new Point((this.Size.Width / 2 - pictureBox3.Width / 2), (this.Size.Height / 2 - pictureBox3.Height / 2));
            this.pictureBox4.Location = new Point((this.Size.Width / 2 - pictureBox4.Width / 2), (this.Size.Height / 2 - pictureBox4.Height / 2) + 1 * pictureBox4.Height + (15));
            this.pictureBox5.Location = new Point((this.Size.Width / 2 - pictureBox5.Width / 2), (this.Size.Height / 2 - pictureBox5.Height / 2) + 2 * pictureBox5.Height + (30));

            Properties.Screen.Default.PropertyChanged += Default_PropertyChanged;

            ResizeScreen();
            GaTerugnaarMenu(this, null);
        }

        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
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


        public void speelKlikGeluid(object sender, EventArgs e)
        {
                klikMP.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav"));
                klikMP.Play();  
        }

        static int GCD(int a, int b)
        {
            int Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }

        private void btn_PlayGame(object sender, EventArgs e)
        {
            this.Hide();
            Player map = new Player(this);
            map.Show();
            MessageBox.Show(string.Format("{0}:{1}", this.Width / GCD(this.Width, this.Height), this.Height / GCD(this.Width, this.Height)));
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


            this.pictureBox1.Click += new System.EventHandler(this.speelKlikGeluid);
            this.pictureBox4.Click += new System.EventHandler(this.speelKlikGeluid);
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
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = true;

            panel1.Width = (int)(this.Width * 0.85);
            panel1.Height = (int)(this.Height * 0.75);
            panel1.Location = new Point((int)(this.Width * 0.1), (int)(this.Height * 0.1));


            labelOptionsHeader.Location = new Point((int)(this.panel1.Location.X + this.panel1.Width / 4), (int)(this.panel1.Location.Y - 50));

            pictureBox6.BackgroundImage = Properties.Resources.uitleg;
            pictureBox6.BackColor = System.Drawing.Color.Transparent;
            pictureBox6.Size = Properties.Resources.uitleg.Size;
            pictureBox6.Location = new Point(panel1.Location.X + panel1.Width / 2, panel1.Location.Y);

            labelOptionsHeader.Visible = true;
            buttonFuSc.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            trackBar1.Visible = true;
            trackBar2.Visible = true;
            trackBar3.Visible = true;


            panel1.Controls.Add(labelOptionsHeader);

            panel1.Controls.Add(buttonFuSc);

            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);

            panel1.Controls.Add(pictureBox6);

            panel1.Controls.Add(trackBar1);
            panel1.Controls.Add(trackBar2);
            panel1.Controls.Add(trackBar3);

            panel1.Visible = true;


            pictureBox7.Image = global::TheHunt.Properties.Resources.backBtn;
            pictureBox7.Location = new Point((int)(panel1.Location.X + (panel1.Width / 2) - pictureBox1.Width / 2), (int)(panel1.Location.Y + (panel1.Height) + 0.15 * pictureBox1.Height));
            this.pictureBox7.Click += new System.EventHandler(this.speelKlikGeluid);
            this.pictureBox7.Click += new System.EventHandler(this.GaTerugnaarMenu);


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            initOptionsPanel();

        }

        public void GaTerugnaarMenu(object sender, EventArgs e)
        {
            buttonFuSc.Visible = false;
            labelOptionsHeader.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            panel1.Visible = false;


            this.pictureBox1.Location = new Point((this.Size.Width / 2 - pictureBox1.Width / 2), (this.Size.Height / 2 - pictureBox1.Height / 2) - 2 * pictureBox1.Height - 30);
            this.pictureBox2.Location = new Point((this.Size.Width / 2 - pictureBox2.Width / 2), (this.Size.Height / 2 - pictureBox2.Height / 2) - 1 * pictureBox2.Height - 15);
            this.pictureBox3.Location = new Point((this.Size.Width / 2 - pictureBox3.Width / 2), (this.Size.Height / 2 - pictureBox3.Height / 2));
            this.pictureBox4.Location = new Point((this.Size.Width / 2 - pictureBox4.Width / 2), (this.Size.Height / 2 - pictureBox4.Height / 2) + 1 * pictureBox4.Height + 15);
            this.pictureBox5.Location = new Point((this.Size.Width / 2 - pictureBox5.Width / 2), (this.Size.Height / 2 - pictureBox5.Height / 2) + 2 * pictureBox5.Height + 30);


            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            panel1.BackColor = System.Drawing.Color.FromArgb(95, System.Drawing.Color.Black);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float percentage = trackBar1.Value;
            float value1 = trackBar2.Value;
            float value2 = trackBar3.Value;
            bgm.Volume = value1 / 100 * (percentage / 100);
            klikMP.Volume = value2 / 100 * (percentage / 100);
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            float percentage = trackBar1.Value;
            float value1 = trackBar2.Value;
            float value2 = trackBar3.Value;
            bgm.Volume = value1 / 100 * (percentage / 100);
            klikMP.Volume = value2 / 100 * (percentage / 100);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            float percentage = trackBar1.Value;
            float value1 = trackBar2.Value;
            float value2 = trackBar3.Value;
            bgm.Volume = value1 / 100 * (percentage / 100);
            klikMP.Volume = value2 / 100 * (percentage / 100);

        }
    }
}
