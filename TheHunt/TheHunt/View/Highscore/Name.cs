using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.View.Highscore
{
    public partial class Name : Form
    {
        public Name()
        {
            InitializeComponent();
        }

        private void Show_Load(object sender, EventArgs e)
        {
            this.txtName.Text = Properties.User.Default.name;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text != null && txtName.Text.Length > 1)
            {
                Properties.User.Default.name = txtName.Text;
                Properties.User.Default.Save();

                this.Close();
            }
        }
    }
}
