using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Controller
{
    class Move
    {
        //character needs to be fieldobject
        public void Moven(KeyEventArgs k, Character c)
        {
            if (k.KeyCode == Keys.Down)
            {
                down(c);

            }
            else if (k.KeyCode == Keys.Up)
            {
                up(c);
            }

            else if (k.KeyCode == Keys.Right)
            {
                right(c);
            }
            else if (k.KeyCode == Keys.Left)
            {
                   left(c);
            }
        }
        public void Moven(Direction k, Character c)
        {
            if (k == Direction.down)
            {
                down(c);

            }
            else if (k == Direction.up)
            {
                up(c);
            }

            else if (k == Direction.right)
            {
                right(c);
            }
            else if (k == Direction.left)
            {
                left(c);
            }
        }
        public void up(Character c)
        {
            c.yPoint -= c.ySpeed;
        }

        public void down(Character c)
        {
            c.yPoint += c.ySpeed;
        }

        public void left(Character c)
        {
            c.xPoint -= c.xSpeed;
        }

        public void right(Character c)
        {
            c.xPoint += c.xSpeed;
        }

    }

}

