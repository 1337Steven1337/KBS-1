﻿using System;
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
    class FieldObject : ResizableObject
    {
        private Image image = null;


        public enum Type
        {
            Wall,
            Enemy,
            Boss
        }

        public int x = 0;
        public int y = 0;
        public int height = 0;
        public int width = 0;

        public Type type; 
 
       public void draw(Graphics g, Size screenSize)
        {
                 for (int x = 0; x < this.width; x++)
            {
                    for (int y = 0; y < this.height; y++)
                {
                    float screenWidth = screenSize.Width/ 40;
                    float screenHeight = screenSize.Height / 20;
                    g.DrawImage(getImage(), this.x + (screenWidth * x), this.y + (screenHeight * y), screenWidth, screenHeight);
                }
            }
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
                if (this.type == Type.Wall)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.wall);
                }
                else if (this.type == Type.Enemy)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.Enemy);
                }
            }


            return this.image;

        }

        public FieldObject clone()
        {
            return (FieldObject)this.MemberwiseClone();
        }
    }
}
