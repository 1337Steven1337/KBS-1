using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TheHunt.Model
{
    class Score
    {
        private DateTime _dateTime = DateTime.UtcNow;
        private string _token;

        public string name;
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
            this.name = Properties.User.Default.name;
            this.score = score;
            this.world = world;
        }
    }
}
