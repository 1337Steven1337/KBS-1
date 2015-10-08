using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheHunt
{
    public partial class FormView : Form
    {

        enum Position
        {
            Left, Right, Up, Down
        }

        private int _x;
        private int _y;
        private int x_Speed;
        private int y_Speed;
        private Timer tmrMoving;
        private IContainer components;
        private Position _objPosition;


        public FormView(int x, int y, int x_Speed, int y_Speed)
        {
            InitializeComponent();
            this.x_Speed = x_Speed;
            this.y_Speed = y_Speed;
            _x = x;
            _y = y;


            _objPosition = Position.Down;
        }

        private void tmrMoving_Tick(object sender, EventArgs e)
        {
            this.tmrMoving.Enabled = true;
            if (_objPosition == Position.Right)
            {
                if (_x < Size.Width - 100)
                {
                    _x += x_Speed;
                }
            }
            else if (_objPosition == Position.Left)
            {
                if (_x > 32)
                {
                    _x -= x_Speed;
                }
            }
            else if (_objPosition == Position.Up)
            {
                if (_y > 32)
                {
                    _y -= y_Speed;
                }
            }
            else if (_objPosition == Position.Down)
            {
                if (_y < Size.Height - 100)
                {
                    _y += y_Speed;
                }
            }
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrMoving = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrMoving
            // 
            this.tmrMoving.Enabled = true;
            this.tmrMoving.Interval = 100;
            this.tmrMoving.Tick += new System.EventHandler(this.tmrMoving_Tick);
            // 
            // FormView
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "FormView";
            this.Text = "moven";
            this.ResumeLayout(false);

        }
    }
}