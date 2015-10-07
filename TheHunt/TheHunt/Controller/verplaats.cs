using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ObjectMoving
{
    public partial class verplaats : Form
    {
        enum Position
        {
            Left, Right, Up, Down
        }

        private int _x;
        private int _y;
        private Boolean piet;
        private Position _objPosition;


        public verplaats()
        {
            InitializeComponent();
            piet = true;
            _x = 50;
            _y = 50;

            _objPosition = Position.Down;
        }

        private void FormView_Paint(object sender, PaintEventArgs e)
        {
            if (piet == true) { e.Graphics.FillRectangle(Brushes.BlueViolet, _x, _y, 100, 100); }
            else { e.Graphics.FillRectangle(Brushes.Blue, _x, _y, 100, 100); }
            //  else { e.Graphics.DrawImage(new Bitmap("mushroom.png"), _x, _y, 32, 32); }
        }

        private void tmrMoving_Tick(object sender, EventArgs e)
        {
            this.tmrMoving.Enabled = true;
            if (_objPosition == Position.Right)
            {
                if (_x < Size.Width - 100)
                {
                    _x += 50;
                }
            }
            else if (_objPosition == Position.Left)
            {
                if (_x > 32)
                {
                    _x -= 50;
                }
            }
            else if (_objPosition == Position.Up)
            {
                if (_y > 32)
                {
                    _y -= 50;
                }
            }
            else if (_objPosition == Position.Down)
            {
                if (_y < Size.Height - 100)
                {
                    _y += 50;
                }
            }
            if (piet == true) { piet = false; }
            else { piet = true; }
            Invalidate();
            this.tmrMoving.Enabled = false;
        }

        private void FormView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _objPosition = Position.Left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                _objPosition = Position.Right;
            }
            else if (e.KeyCode == Keys.Up)
            {
                _objPosition = Position.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _objPosition = Position.Down;
            }
            this.tmrMoving.Enabled = true;
        }
    }
}
