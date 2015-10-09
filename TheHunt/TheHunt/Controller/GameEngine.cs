using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TheHunt.Controller;

namespace TheHunt
{
    class GameEngine
    {

        public event EventHandler<EventArgs> Timer;
        static int i = 0;
        public Move move;
        public Timer timer;
        private static Charactertestform ctfrm;


        public GameEngine()
        {
            timer = new Timer(100);
            move = new Move();

            timer.Elapsed += OnTimedEvent;


            timer.AutoReset = true;

            timer.Enabled = true;

        }

        public static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            int x = 1;
            //Debug.WriteLine(string.Format("Test {0}", i));
            //ctfrm = new Charactertestform();
            i += x;
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