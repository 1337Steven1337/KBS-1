using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt
{
    public partial class Map : Form
    {
        public int pointX = 0;
        public int pointY = 0;
        public static int mapWidth, mapHeight;        
        public List<Blok> blokken = new List<Blok>();

        public Map()
        {
            InitializeComponent();

            mapWidth = this.Width;
            mapHeight = this.Height;

            for (int j = 0; j < calcAantBlokkenHeight(); j++)
            {
                for (int i = 0; i < calcAantBlokkenWidth(); i++)
                {
                    blokken.Add(new Blok(j, i));
                }
            }                
        }


        public static int calcAantBlokkenWidth()
        {
            return mapWidth / 20;
        }

        public void Map_Load(object sender, EventArgs e)
        {
            MessageBox.Show("" + blokken[2]);
        }

        public static int calcAantBlokkenHeight()
        {
            return mapHeight / 20;
        }

        //public void DrawRect(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    SolidBrush brush = new SolidBrush(Color.Red);
        //    Rectangle rect = new Rectangle(pointX, pointY, 20, 20);

        //    pointX += 20;

        //    g.FillRectangle(brush, rect);
        //}        
    }

    public class Blok
    {
        private int xCoordinaat {get; set; }
        private int yCoordinaat {get; set; } 

        public Blok(int xCoordinaat, int yCoordinaat)
        {
            this.xCoordinaat = xCoordinaat;
            this.yCoordinaat = yCoordinaat;
        }
    }
}
