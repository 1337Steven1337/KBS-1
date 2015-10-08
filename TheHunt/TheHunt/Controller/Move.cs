using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Windows.Input;

namespace TheHunt.Controller
{
    class Move
    {
        //character needs to be fieldobject
        public void Moven(System.Windows.Forms.KeyEventArgs k, Character c)
        {
            if (k.KeyCode == Keys.Down)
            {
                c.yPoint += c.ySpeed;

            }
            else if (k.KeyCode == Keys.Up)
            {
                c.yPoint -= c.ySpeed;
            }

            else if (k.KeyCode == Keys.Right)
            {
                c.xPoint += c.xSpeed;
            }
            else if (k.KeyCode == Keys.Left)
            {
                   left(c);
            }
        }
        public void Moven(Direction k, Character c)
        {
            {

            }

            if (k == Direction.down)
            {
                down(c);

            }
            }
                

        }

    }

