using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TheHunt.Controller.Highscore;

namespace TheHunt.Model
{
    class Score
    {
        private DateTime _dateTime = DateTime.UtcNow;
        private string _token;
        private string _name;
        private int _start;

        public string name
        {
            get
            {
                if(this._name == null)
                {
                    if (Properties.User.Default.name == "Default")
                    {
                        Name name = new Name();
                        name.ShowDialog();
                    }
                    else
                    {
                        this._name = Properties.User.Default.name;
                    }
                }

                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        public string world;
        public string token
        {
            get
            {
                if(this._token == null)
                {
                    byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(this.name + "#" + this.world + "#" + this.score);
                    byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
                    this._token = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }

                return this._token;
            }
            set
            {
                this._token = value;
            }
        }
        public int score;
        private int maxScore;
        public DateTime dateTime
        {
            get
            {
                return this._dateTime;
            }
        }

        public Score()
        {

        }

        public Score(int score, string world)
        {
            this.score = score;
            this.maxScore = score;
            this.world = world;

            this._start = this.score;
        }

        public void add(int bonus)
        {
            if ((this.score += bonus) <= this.maxScore)
            {
                score += bonus;
            }
            else
            {
                score = maxScore;
            }
        }

        public void subtract(int amount)
        {
            if (this.score > 0)
            {
                this.score -= amount;

                //Console.WriteLine(this.score + "/" + this._start);
                //Console.WriteLine((this.score / this._start) * 100);
            }
            else
            {
                this.score = (this.score < 0) ? 0 : this.score;
            }
        }

        public void draw(Graphics g, Size size)
        {
            int scoreX = 79;
            int scoreY = size.Height - 61;
            int scoreWidth = 201;
            int scoreHeight = 31;

            Pen blackPen = new Pen(Color.Black);

            Rectangle backgroundHealthBar = new Rectangle(scoreX, scoreY, scoreWidth, scoreHeight);
            g.DrawRectangle(blackPen, backgroundHealthBar);
            Brush variableBrush = new SolidBrush(Color.Black);

            g.FillRectangle(variableBrush, backgroundHealthBar);

            float percentage = ((float)this.score / (float)this._start) * 100;

            if(percentage > 100)
            {
                percentage = 100;
            }

            if (percentage >= 75)
            {
                variableBrush = new SolidBrush(Color.Green);
            }
            else if (percentage >= 50 && percentage < 75)
            {
                variableBrush = new SolidBrush(Color.Yellow);
            }
            else if (percentage >= 25 && percentage < 50)
            {
                variableBrush = new SolidBrush(Color.Orange);
            }
            else if (percentage >= 0 && percentage < 25)
            {
                variableBrush = new SolidBrush(Color.Red);
            }

            g.FillRectangle(variableBrush, scoreX + 1, scoreY + 1, (scoreWidth - 1) - ((scoreWidth - 1) - ((percentage / 100) * (scoreWidth - 1))), scoreHeight - 1);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Font font = new Font("Microsoft Sans Serif", 10);
            SizeF stringSize = new SizeF();
            stringSize = g.MeasureString(this.score.ToString(), font, 200);


            RectangleF rectangle = new RectangleF((scoreX + (scoreWidth / 2)) - (stringSize.Width / 2), scoreY + ((scoreHeight / 2) - (stringSize.Height / 2)), stringSize.Width, stringSize.Height);
            g.DrawString(this.score.ToString(), font, Brushes.White, rectangle);
        }
    }
}
