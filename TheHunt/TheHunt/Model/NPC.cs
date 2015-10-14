using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Model
{
    class NPC : ResizableObject
    { 
        private ImageList imagelist = new ImageList();        
        public Point position;
        public Point speed;
        public int width = 1;
        public int height = 1;      
        public Type type;

        public enum Type
        {
            Enemy,
            Boss
        }

        public NPC()
        {            
            this.fillImages();
        }

        public void draw(Graphics g, Size screenSize)
        {
            float screenWidth = getOnScreenHeight(screenSize);
            float screenHeight = getOnScreenHeight(screenSize);

            g.DrawImage(imagelist.Images[0], this.position.x, this.position.y, screenWidth, screenHeight);
        }

        public float getPixelWidth(Size screenSize)
        {
            double getScreenRatio = screenSize.Width / screenSize.Height;
            float screenWidth = 32;
            float screenHeight = (float)(screenWidth * getScreenRatio);
            return this.width * this.getOnScreenHeight(screenSize);
        }

        public float getPixelHeight(Size screenSize)
        {
            return this.height * this.getOnScreenWidth(screenSize);
        }

        private void fillImages()
        {
            if (this.type == Type.Enemy)
            {
                this.imagelist.Images.Add(new Bitmap(TheHunt.Properties.Resources.Enemy));
            }
        }     

    }
}
