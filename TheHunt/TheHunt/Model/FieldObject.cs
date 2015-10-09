﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHunt.Model
{
    class FieldObject
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
        public static bool rightCollision, leftCollision, upCollision, downCollision;

        public Type type = Type.Wall;

        public FieldObject(int x, int y, Type type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        public void draw(Graphics g)
        {
            for(int x = 0; x < this.getImageSizeWidth(); x+=32)
            {
                for(int y = 0; y < this.getImageSizeHeight(); y+=32)
                {
                    g.DrawImage(getImage(), this.x + x, this.y + y, 32, 32);
                }
            }
        }

        public bool collision(int x, int y, int width, int height)
        {
            if(x >= this.x && x <= this.x + this.getImageSizeWidth())
            {
                return rightCollision = true;
            }
            else if (x + width >= this.x && x + width <= this.x)
            {
                return leftCollision = true;
            }
            else if (y >= this.y && y <= this.y + this.getImageSizeHeight())
            {
                return upCollision = true;
            }
            else if (y + height >= this.y && y + height <= this.y)
            {
                return downCollision = true;
            }
            return (x >= this.x && x <= this.x + this.getImageSizeWidth()) || (x + width >= this.x && x + width <= this.x) ;
        }

        private int getImageSizeWidth()
        {
            return this.width * 32;
        }
        private int getImageSizeHeight()
        {
            return this.height * 32;
        }

        private Image getImage()
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
    }
}
