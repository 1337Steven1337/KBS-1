using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt
{
    public partial class form_selectlevel : Form
    {
        public Form formulier;
        public form_selectlevel(Form form)
        {
            InitializeComponent();
            formulier = form;
            this.Location = form.Location;
            this.Size = form.Size;

            //Designer.Designer designwindow = new Designer.Designer(this);
        }

        private void form_selectlevel_Load(object sender, EventArgs e)
        {
            
        }
    }
}
