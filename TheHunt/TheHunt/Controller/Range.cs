using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHunt.Controller
{
    class DetectPlayer
    {
        
        public bool inRange(int range, Player player, int x, int y)
        {
            bool inrange = false;
            int PythagorasX;
            int Pythagorasy;
            int px = player.Width / 2 + player.playerX;
            int py = player.Height / 2 + player.playerY;
            int ex = x; //moet nog worden verandert als de xlocatie van enemy bekend is
            int ey = y; //moet nog worden verandert als de ylocatie van enemy bekend is
            
            //xcoordinaar bepalen
            if (px >= ex)
            {
                PythagorasX = px - ex;
            }
            else
            {
                PythagorasX = ex - px;
            }
            //ycoordinaat bepalen

            if (py >= ey)
            {
                Pythagorasy = py - ey;
            }
            else
            {
                Pythagorasy = ey - py;
            }

            //xkwadraat
            int PowerToX = PythagorasX * PythagorasX;
            //ykwadraat
            int PowerToY = Pythagorasy * Pythagorasy;
            //xkwadraat + ykwadraat
            int compareNumber = PowerToX + PowerToY;
            //ckwadraat
            int compareToNumer = range * range;

            if (compareNumber < compareToNumer)
            {
                inrange = true;
            }



            return inrange;
        }

    }
}
