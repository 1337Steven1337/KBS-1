using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Diagnostics;
using System.IO;

namespace TheHunt.View
{
    class Buttons
    {
        public void AddButton(Direction richting)
        {
            switch (richting)
            {
                case Direction.down:
                    downButton();
                    break;
                case Direction.left:
                    leftButton();
                    break;
                case Direction.up:
                    upButton();
                    break;
                case Direction.right:
                    rightButton();
                    break;

            }




        }



        public void downButton()
        {

            
            StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + "/../../Resources/pijl onder.png");


            
        }

        public void leftButton()
        {

        }

        public void upButton()
        {

        }

        public void rightButton()
        {

        }
    }
}
