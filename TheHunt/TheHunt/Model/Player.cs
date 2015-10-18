﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Model
{
    class Player : Item
    {
        public string img;
        public Positions positions;
        public Point speed;
        public Movement movement;
        public int sizeBreedte = Screen.PrimaryScreen.Bounds.Width / 40;
        public int sizeHoogte = Screen.PrimaryScreen.Bounds.Height / 20;

        public static Bitmap bitmap;
        public static List<Bitmap> PlayerSprites = new List<Bitmap>();

        public Player()
        {
            PlayerSprites.Add(null);
            PlayerSprites.Add(Properties.Resources.brockSprite1);
            PlayerSprites.Add(Properties.Resources.brockSprite2);
            PlayerSprites.Add(Properties.Resources.brockSprite3);
            PlayerSprites.Add(Properties.Resources.brockSprite4);
            PlayerSprites.Add(Properties.Resources.brockSprite5);
            PlayerSprites.Add(Properties.Resources.brockSprite6);
            PlayerSprites.Add(Properties.Resources.brockSprite7);
            PlayerSprites.Add(Properties.Resources.brockSprite8);
            PlayerSprites.Add(Properties.Resources.brockSprite9);
            PlayerSprites.Add(Properties.Resources.brockSprite10);
            PlayerSprites.Add(Properties.Resources.brockSprite11);
            PlayerSprites.Add(Properties.Resources.brockSprite12);

            bitmap = PlayerSprites[1];
        }


        public void draw(Graphics g, Size screenSize)
        {
            g.DrawImage(bitmap, this.positions.current_position.x, this.positions.current_position.y, sizeBreedte, sizeHoogte);
        }
    }
}
