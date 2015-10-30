using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHunt.Model;

namespace TheHunt.Controller.Highscore
{
    public partial class Show : Form
    {
        public Show()
        {
            InitializeComponent();
        }

        private void Highscores_Load(object sender, EventArgs e)
        {
            dataGrid.DataSource = this.getDataTable();
        }

        private DataTable getDataTable()
        {
            DataTable data = new DataTable();
            data.Columns.Add("Score", typeof(int));
            data.Columns.Add("User", typeof(string));
            data.Columns.Add("Level", typeof(string));

            List<Score> list = Highscore.Instance.getScores().OrderByDescending(x => x.score).ToList<Score>();

            for (int i = 0; i < list.Count; i++)
            {
                List<object> d = new List<object>();
                d.Add(list[i].score);
                d.Add(list[i].name);
                d.Add(list[i].world);

                data.Rows.Add(list[i].score, list[i].name, list[i].world);
            }

            return data;
        }

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            Name name = new Controller.Highscore.Name();
            this.Hide();
            name.ShowDialog();
            this.Show();
        }
    }
}
