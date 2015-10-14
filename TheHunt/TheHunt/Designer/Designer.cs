using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Designer
{
    public partial class Designer : Form
    {
        public Form startForm;
        public Designer(Form startform)
        {
            InitializeComponent();
            this.startForm = startform;
        }

        private void Designer_Load(object sender, EventArgs e)
        {

        }
    }
}
