using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] 
        static void Main()
        {             
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 frm = new Form1();
            GameEngine GE = new GameEngine(1280, 720, frm);
            GE.Run();
        }
    }
}
