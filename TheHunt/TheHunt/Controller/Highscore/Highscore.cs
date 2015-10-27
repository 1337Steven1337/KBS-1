using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TheHunt.Model;

namespace TheHunt.Controller.Highscore
{
    class Highscore
    {
        private static Highscore instance = null;
        private List<Score> scores = null;

        private Highscore()
        {

        }

        private string createToken(int score, string name, string world)
        {
            byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(name + "#" + world + "#" + score);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public List<Score> getScores()
        {
            if (this.scores == null)
            {
                if (File.Exists("highscore.json"))
                {
                    StreamReader reader = new StreamReader("highscore.json");
                    List<Score> temp = JsonConvert.DeserializeObject<List<Score>>(reader.ReadToEnd());
                    reader.Close();

                    this.scores = temp.Where(s => (s.token == createToken(s.score, s.name, s.world))).ToList();
                }
                else
                {
                    this.scores = new List<Score>();
                }
            }

            return this.scores;
        }

        private void save()
        {
            string json = JsonConvert.SerializeObject(this.getScores(), Formatting.Indented);
            System.IO.File.WriteAllText("highscore.json", json);
        }

        public void add(int score, string world)
        {
            this.add(new Score(score, world));
        }

        public void add(Score score)
        {
            this.getScores().Add(score);
            this.save();
        }

        public static Highscore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Highscore();
                }

                return instance;
            }
        }
    }
}
