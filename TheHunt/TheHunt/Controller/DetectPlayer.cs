using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheHunt.Model;
using System.Threading.Tasks;

namespace TheHunt.Controller
{
    public class DetectPlayer
    {
        World world = null;

        public bool inRange(int range, int npcX, int npcY)
        {
            this.world = world;
            int width = world.player.sizeBreedte;
            int height = world.player.sizeHoogte;
            bool inrange = false;
            int PythagorasX;
            int Pythagorasy;
            int px = width / 2 + world.player.positions.current_position.x;
            int py = height / 2 + world.player.positions.current_position.y;
            
            int ex = npcX; //moet nog worden verandert als de xlocatie van enemy bekend is
            int ey = npcY; //moet nog worden verandert als de ylocatie van enemy bekend is

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
            //ultimate check
            if (compareNumber < compareToNumer)
            {
                inrange = true;
            }



            return inrange;
        }
        //wanneer player in range is:
        public int isInRange(int range)
        {
            range += 100;
            return range;
        }

    }
}
