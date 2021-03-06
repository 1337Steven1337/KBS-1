﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Model
{
    class Finish
    {
        public int sizeBreedte = Screen.PrimaryScreen.Bounds.Width / 40;
        public int sizeHoogte = Screen.PrimaryScreen.Bounds.Height / 20;

        public int x = 0;
        public int y = 0;
        public int height = 1;
        public int width = 1;

        private Image image = null;

        public void draw(Graphics g, Size screenSize, string drawMode)
        {
                float screenWidth = (float)(screenSize.Width / 40.00);
                float screenHeight = (float)(screenSize.Height / 20.00);
            if (drawMode == "Game")
            {
                g.DrawImage(getImage(), this.x, this.y, screenWidth, screenHeight);
            }
            else if (drawMode == "Designer")
            {
                g.DrawImage(getImage(), (int)(this.x * screenWidth), (int)(this.y * screenHeight), screenWidth, screenHeight);
            }
                
            
        }

        public float getPixelWidth(Size screenSize)
        {
            return this.width * screenSize.Width / 40;
        }

        public float getPixelHeight(Size screenSize)
        {
            return this.height * screenSize.Height / 20;
        }

        public Image getImage()
        {
            if (this.image == null)
            {
                this.image = new Bitmap(TheHunt.Properties.Resources.Finish);
            }
            return this.image;
        }

        public Finish clone()
        {
            return (Finish)this.MemberwiseClone();
        }
    }
}
