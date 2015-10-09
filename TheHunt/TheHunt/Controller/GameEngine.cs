using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TheHunt.Controller;

namespace TheHunt
{
    class GameEngine
    {

        public event EventHandler<EventArgs> Timer;

        public Move move;
        public System.Timers.Timer timer;
       // private static Charactertestform ctfrm;


        public GameEngine()
        {
            timer = new System.Timers.Timer(100);
            move = new Move();

            timer.Elapsed += OnTimedEvent;

            timer.AutoReset = true;

            timer.Enabled = true;

        }

        public static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            //Doe iets
        }

        protected virtual void OnTimerOff()
        {
            if (Timer != null)
            {
                Timer(this, EventArgs.Empty);
            }
        }





    }
}