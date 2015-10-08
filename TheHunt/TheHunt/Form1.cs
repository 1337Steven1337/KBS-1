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
        public static Boolean isMuted = false;
        MediaPlayer bgm = new MediaPlayer();
        MediaPlayer klikMP = new MediaPlayer();
        public Form1()
        {
            InitializeComponent();
            bgm.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/bgm.wav"));
            bgm.MediaEnded += new EventHandler(bgmAfgelopen);
            bgm.Play();



            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox5.BackColor = System.Drawing.Color.Transparent;
            pictureBox3.BackColor = System.Drawing.Color.Transparent;



            //Bereken knoppen locaties
            this.pictureBox1.Location = new Point((this.Size.Width / 2 - pictureBox1.Width / 2), (this.Size.Height / 2 - pictureBox1.Height / 2) - 2 * pictureBox1.Height - this.Size.Height / 50);
            this.pictureBox2.Location = new Point((this.Size.Width / 2 - pictureBox2.Width / 2), (this.Size.Height / 2 - pictureBox2.Height / 2) - 1 * pictureBox2.Height);
            this.pictureBox3.Location = new Point((this.Size.Width / 2 - pictureBox3.Width / 2), (this.Size.Height / 2 - pictureBox3.Height / 2) + this.Size.Height / 50);
            this.pictureBox4.Location = new Point((this.Size.Width / 2 - pictureBox4.Width / 2), (this.Size.Height / 2 - pictureBox4.Height / 2) + 1 * pictureBox4.Height + (15));
            this.pictureBox5.Location = new Point((this.Size.Width / 2 - pictureBox5.Width / 2), (this.Size.Height / 2 - pictureBox5.Height / 2) + 2 * pictureBox5.Height + (30));

        }


        public static void CopyAudioToDisk(Stream input, Stream output)
        {
            byte[] buffer = new byte[8192];

            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }

        public void speelKlikGeluid(object sender, EventArgs e)
        {
            if (!isMuted)
            {
                klikMP.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav"));
                klikMP.Play();
            }
        }



        private void btn_PlayGame(object sender, EventArgs e)
        {
            this.Hide();
            //Charactertestform map = new Charactertestform();
            Player map = new Player();
            map.Show();
        }

        private void bgmAfgelopen(object sender, EventArgs e)
            {
            bgm.Position = TimeSpan.Zero;
            bgm.Play();
        }

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;

            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1440,900);


            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/SFX"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/SFX");
            }

            if (!File.Exists(Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav") || !File.Exists(Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav"))
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
                else if (!File.Exists(Directory.GetCurrentDirectory() + "/SFX/bgm.wav") && !File.Exists(Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav"))
                {
                    Properties.Resources.bgm.CopyTo(memStream);
                    byte[] byteArray = memStream.ToArray();
                    File.WriteAllBytes(Directory.GetCurrentDirectory() + "/SFX/bgm.wav", byteArray);
                    memStream.SetLength(0);

                    Properties.Resources.klikgeluid.CopyTo(memStream);
                    byteArray = memStream.ToArray();
                    File.WriteAllBytes(Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav", byteArray);
                    memStream.SetLength(0);

            }
                else
            {
                    //doe niks
            }   
            }

            this.pictureBox1.Click += new System.EventHandler(this.speelKlikGeluid);
        }

        private void Afsluiten(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Close();
        }

        public void initOptionsPanel()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;


            panel1.Width = (int)(this.Width * 0.8);
            panel1.Height = (int)(this.Height * 0.7);
            panel1.Location = new Point((int)(this.Width * 0.1), (int)(this.Height * 0.1));


            labelOptionsHeader.Location = new Point((int)(this.panel1.Location.X + this.panel1.Width / 4), (int)(this.panel1.Location.Y));

            labelOptionsHeader.Visible = true;
            buttonFuSc.Visible = true;
            buttonContr.Visible = true;

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            trackBar1.Visible = true;
            trackBar2.Visible = true;
            trackBar3.Visible = true;


            panel1.Controls.Add(labelOptionsHeader);

            panel1.Controls.Add(buttonFuSc);
            panel1.Controls.Add(buttonContr);

            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);

            panel1.Controls.Add(trackBar1);
            panel1.Controls.Add(trackBar2);
            panel1.Controls.Add(trackBar3);

            panel1.Visible = true;


            pictureBox5.Image = global::TheHunt.Properties.Resources.backBtn;
            pictureBox5.Location = new Point((int)(panel1.Location.X + (panel1.Width / 2) - pictureBox1.Width / 2), (int)(panel1.Location.Y + (panel1.Height) + 0.15 * pictureBox1.Height));
            this.pictureBox5.Click -= new System.EventHandler(this.Afsluiten);
            this.pictureBox5.Click += new System.EventHandler(this.speelKlikGeluid);
            this.pictureBox5.Click += new System.EventHandler(this.GaTerugnaarMenu);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            initOptionsPanel();

        }

        public void GaTerugnaarMenu(object sender, EventArgs e)
        {
            buttonFuSc.Visible = false;
            buttonContr.Visible = false;
            labelOptionsHeader.Visible = false;
            panel1.Visible = false;


            pictureBox5.Image = global::TheHunt.Properties.Resources.exitBtn;
            pictureBox5.Location = new Point((this.Size.Width / 2 - pictureBox5.Width / 2), (this.Size.Height / 2 - pictureBox5.Height / 2) + 2 * pictureBox5.Height + (30));
            this.pictureBox5.Click -= new System.EventHandler(this.GaTerugnaarMenu);
            this.pictureBox5.Click -= new System.EventHandler(this.speelKlikGeluid);
            this.pictureBox5.Click += new System.EventHandler(this.Afsluiten);

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
            float value = trackBar1.Value;
            bgm.Volume = value / 100;
            klikMP.Volume = value / 100;
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            float value = trackBar2.Value;
            if (value > trackBar1.Value)
            {
                value = trackBar1.Value;
            }
            bgm.Volume = value / 100;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            float value = trackBar3.Value;
            if (value > trackBar1.Value)
            {
                value = trackBar1.Value;
            }
            klikMP.Volume = value / 100;
        }
    }
}
