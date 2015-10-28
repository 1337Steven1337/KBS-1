using System;

namespace TheHunt
{
    public class Unittesttest
    {
        private int waarde;
        public Unittesttest(int waarde)
        {
            this.waarde = waarde;
        }

        public void optellen(int bijkomstig)
        {
            waarde += bijkomstig;
        }

        public int getWaarde()
        {
            return waarde;
        }
    }
}
