using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHunt.Model
{
    abstract class Item
    {
        public float getOnScreenWidth(Size screenSize)
        {
            return 32 * (screenSize.Width / 960);
        }

        public float getOnScreenHeight(Size screenSize)
        {
            return 32 * (screenSize.Height / 540);
        }
    }
}
