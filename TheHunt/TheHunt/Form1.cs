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
        SoundPlayer bgm = new SoundPlayer(Properties.Resources.bgm);
        public Form1()
        {
            InitializeComponent();
            bgm.PlayLooping();



            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox5.BackColor = System.Drawing.Color.Transparent;
            pictureBox3.BackColor = System.Drawing.Color.Transparent;


            //zet Schermgrootte
            this.Size = new Size(1280, 768);
            this.TopMost = true;
            this.Location = new Point(0, 0);
            //this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            //Bereken knoppen locaties
            this.pictureBox1.Location = new Point((this.Size.Width / 2 - pictureBox1.Width / 2), (this.Size.Height / 2 - pictureBox1.Height / 2) - 2 * pictureBox1.Height - this.Size.Height / 50);
            this.pictureBox2.Location = new Point((this.Size.Width / 2 - pictureBox2.Width / 2), (this.Size.Height / 2 - pictureBox2.Height / 2) - 1 * pictureBox2.Height);
            this.pictureBox3.Location = new Point((this.Size.Width / 2 - pictureBox3.Width / 2), (this.Size.Height / 2 - pictureBox3.Height / 2) + this.Size.Height / 50);

            this.pictureBox4.Location = new Point((this.Size.Width / 2 - pictureBox4.Width / 2), (this.Size.Height / 2 - pictureBox4.Height / 2) + 1 * pictureBox4.Height + (15));
            this.pictureBox5.Location = new Point((this.Size.Width / 2 - pictureBox5.Width / 2), (this.Size.Height / 2 - pictureBox5.Height / 2) + 2 * pictureBox5.Height + (30));


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           Application.Exit();
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

        public void speelKlikGeluid()
        {
            if (!isMuted)
            {
                MediaPlayer klikMP = new MediaPlayer();
                klikMP.Open(new Uri(@"" + Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav"));
                klikMP.Play();
            }
        }

        public void muteGeluid()
        {

            isMuted = !isMuted;
            if (isMuted)
            {
               bgm.Stop();
            }
            else
            {
               bgm.PlayLooping();
            }
        }

        private void btn_PlayGame(object sender, EventArgs e)
        {
            this.Hide();
            //Charactertestform map = new Charactertestform();
            Map map = new Map();
            map.Show();
            speelKlikGeluid();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/SFX"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/SFX");
            }

            try{
                MemoryStream memStream = new MemoryStream();
                Properties.Resources.klikgeluid.CopyTo(memStream);
                byte[] byteArray = memStream.ToArray();
                File.WriteAllBytes(Directory.GetCurrentDirectory() + "/SFX/klikgeluid.wav", byteArray);
                memStream.SetLength(0);

                Properties.Resources.bgm.CopyTo(memStream);
                byteArray = memStream.ToArray();
                File.WriteAllBytes(Directory.GetCurrentDirectory() + "/SFX/bgm.wav", byteArray);
                memStream.SetLength(0);



            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Er is nog geen SFX folder aangemaakt!");
            }   

            
        }

        private void buttonSnd_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            labelOptionsHeader.Visible = true;
            buttonSndEf.Visible = true;
            buttonSndMu.Visible = true;
            buttonFuSc.Visible = true;
            buttonContr.Visible = true;
            buttonMenu.Visible = true;
        }
    }
}
