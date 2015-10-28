using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Model
{
    class Finish : Item
    {
        public int sizeBreedte = Screen.PrimaryScreen.Bounds.Width / 40;
        public int sizeHoogte = Screen.PrimaryScreen.Bounds.Height / 20;

        public int x = 0;
        public int y = 0;
        public int height = 1;
        public int width = 1;

        private Image image = null;

        public void draw(Graphics g, Size screenSize, bool isUsed)
        {
            if (isUsed == false)
            {
                float screenWidth = (float)(screenSize.Width / 40.00);
                float screenHeight = (float)(screenSize.Height / 20.00);
                g.DrawImage(getImage(), (int)(this.x * screenWidth), (int)(this.y * screenHeight), screenWidth, screenHeight);
            }
        }

        private Image getImage()
        {
            if (this.image == null)
            {
                this.image = new Bitmap(TheHunt.Properties.Resources.Finish);
            }
            return this.image;
        }
    }
}
