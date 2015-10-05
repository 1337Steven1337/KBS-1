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
            this.Size = new Size(1280,720);
            this.button1.Location = new Point( (this.Size.Width/2 - button1.Width / 2) , (this.Size.Height / 2 - button1.Height / 2 ));
            //lol  
        }

        private void btn_StartGameClick(object sender, EventArgs e)
        {
           // Map map = new Map();
        }
    }
}
