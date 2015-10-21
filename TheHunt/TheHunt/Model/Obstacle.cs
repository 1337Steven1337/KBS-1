using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Model
{
    class Obstacle : Item
    {
        private Image image = null;

        public int x = 0;
        public int y = 0;
        public int height = 1;
        public int width = 1;
         
       public void draw(Graphics g, Size screenSize)
        {
                    float screenWidth = (float)(screenSize.Width/ 40.00);
                    float screenHeight = (float)(screenSize.Height / 20.00);
                    g.DrawImage(getImage(), this.x * screenWidth, this.y * screenHeight, screenWidth, screenHeight);
        }

        public float getPixelWidth(Size screenSize)
        {
            return this.width * screenSize.Width/40;
        }

        public float getPixelHeight(Size screenSize)
        {
            return this.height * screenSize.Height / 20;
        }

        public Image getImage()
        {
            if(this.image == null)
            {
                this.image = new Bitmap(TheHunt.Properties.Resources.wall);
            }
            return this.image;
        }

        public Obstacle clone()
        {
            return (Obstacle)this.MemberwiseClone();
        }
    }
}
