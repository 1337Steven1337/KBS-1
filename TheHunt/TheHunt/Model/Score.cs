using System;
using System.Collections.Generic;
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
        }
        public int score;
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
            this.world = world;
        }
    }
}
