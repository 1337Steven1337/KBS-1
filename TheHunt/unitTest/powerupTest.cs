using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheHunt;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHunt.Model;
using TheHunt.Controller.Highscore;

namespace unitTest
{
    [TestClass]
    public class powerupTest
    {
        private Game game;

        [TestMethod]
        public void testPowerupDuration()
        {
            //arrange

            //level
            string level = "{\"powerups\":[{\"x\":1,\"y\":1,\"height\":1,\"width\":1,\"type\":2}],\"player\":{\"img\":null,\"positions\":{\"current_position\":{\"x\":1,\"y\":1},\"last_position\":{\"x\":0,\"y\":0}},\"speed\":{\"x\":3,\"y\":3},\"movement\":{\"walk\":{\"x\":3,\"y\":3},\"run\":{\"x\":5,\"y\":5}},\"sizeBreedte\":34,\"sizeHoogte\":55}}";
            form_startscreen startscreen = new form_startscreen();

            this.game = new Game(startscreen, level);

            /*TheHunt.Model.Powerups powerupEmp = new TheHunt.Model.Powerups();
            powerupEmp.type = TheHunt.Model.Powerups.Type.Emp;
            powerupEmp.UsePowerup(game);*/

            Powerups powerUp = this.game.getWorld().powerups[0];
            powerUp.UsePowerup(this.game);
            /*
            Timer loop = new Timer();
            loop.Interval = 2000;
            loop.Elapsed += Loop_Elapsed;
            loop.Start();*/

            //act
            
            //assert

        }

        private void Loop_Elapsed(object sender, ElapsedEventArgs e)
        {
            Assert.IsFalse(this.game.emp, "You suck!");
        }

        public void loopTick(object sender, EventArgs e)
        {

        }
    }
}
