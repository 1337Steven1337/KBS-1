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

namespace TheHunt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            OptionsButton.BackColor = Color.Transparent;


            //zet Schermgrootte
            this.Size = new Size(1280, 720);

            //zet Knopgrootte startmenu
            //this.button1.Size = new Size(this.Size.Width / 5, this.Size.Height / 10);
            //this.button2.Size = new Size(this.Size.Width / 5, this.Size.Height / 10);
            //this.button3.Size = new Size(this.Size.Width / 5, this.Size.Height / 10);
            //this.button4.Size = new Size(this.Size.Width / 10, this.Size.Height / 10);
            //this.button5.Size = new Size(this.Size.Width / 10, this.Size.Height / 10);

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
           Map map = new Map();
           map.Show();
            Application.Exit();
        }
    }
}
