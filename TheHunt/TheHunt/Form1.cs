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
            //zet Schermgrootte
            this.Size = new Size(1280,720);

            //zet Knopgrootte startmenu
            this.button1.Size = new Size(this.Size.Width / 5, this.Size.Height / 10);
            this.button2.Size = new Size(this.Size.Width / 5, this.Size.Height / 10);
            this.button3.Size = new Size(this.Size.Width / 5, this.Size.Height / 10);
            this.button4.Size = new Size(this.Size.Width / 10, this.Size.Height / 10);
            this.button5.Size = new Size(this.Size.Width / 10, this.Size.Height / 10);

            //Bereken knoppen locaties
            this.button1.Location = new Point((this.Size.Width / 2 - button1.Width / 2), (this.Size.Height / 2 - button1.Height / 2) - 2 * button1.Height - this.Size.Height / 50);
            this.button2.Location = new Point((this.Size.Width / 2 - button2.Width / 2), (this.Size.Height / 2 - button2.Height / 2) - 1 * button2.Height);
            this.button3.Location = new Point((this.Size.Width / 2 - button3.Width / 2), (this.Size.Height / 2 - button3.Height / 2) + this.Size.Height / 50);

            this.button4.Location = new Point((this.Size.Width / 2 - button1.Width / 2), (this.Size.Height / 2 - button4.Height / 2) + 1 * button4.Height + 2* (this.Size.Height / 50));
            this.button5.Location = new Point( (this.Size.Width/2 - button1.Width / 2) + button5.Width, (this.Size.Height / 2 - button5.Height / 2 )+ 1 * button5.Height + 2 * (this.Size.Height / 50));


        }

        private void btn_StartGameClick(object sender, EventArgs e)
        {
           Map map = new Map();
           map.Show();
        }
    }
}
