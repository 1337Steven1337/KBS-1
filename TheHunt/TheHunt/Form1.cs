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


namespace TheHunt
{
    public partial class Form1 : Form
    {
        public static Boolean isMuted = false;
        SoundPlayer bgm = new SoundPlayer(@"Sounds\bgm.wav");
        public Form1()
        {
            InitializeComponent();
            bgm.PlayLooping();



            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            OptionsButton.BackColor = Color.Transparent;


            //zet Schermgrootte
            this.Size = new Size(1280, 720);

            this.buttonSnd.Visible = false;

            //Bereken knoppen locaties
            this.pictureBox1.Location = new Point((this.Size.Width / 2 - pictureBox1.Width / 2), (this.Size.Height / 2 - pictureBox1.Height / 2) - 2 * pictureBox1.Height - this.Size.Height / 50);
            this.pictureBox2.Location = new Point((this.Size.Width / 2 - pictureBox2.Width / 2), (this.Size.Height / 2 - pictureBox2.Height / 2) - 1 * pictureBox2.Height);
            this.OptionsButton.Location = new Point((this.Size.Width / 2 - OptionsButton.Width / 2), (this.Size.Height / 2 - OptionsButton.Height / 2) + this.Size.Height / 50);

            this.pictureBox4.Location = new Point((this.Size.Width / 2 - pictureBox4.Width / 2), (this.Size.Height / 2 - pictureBox4.Height / 2) + 1 * pictureBox4.Height + (15));
            this.pictureBox5.Location = new Point((this.Size.Width / 2 - pictureBox5.Width / 2), (this.Size.Height / 2 - pictureBox5.Height / 2) + 2 * pictureBox5.Height + (30));


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        public void speelKlikGeluid()
        {
            if (!isMuted)
            {
                var klikgeluid = new WMPLib.WindowsMediaPlayer();
                klikgeluid.URL = @"C:\Users\Steven\Desktop\KBS1\KBS-1\TheHunt\TheHunt\bin\Debug\Sounds\klikgeluid.wav";
                klikgeluid.controls.play();
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
            Map map = new Map();
            map.Show();
            speelKlikGeluid();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSnd_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            muteGeluid();
        }
    }
}
