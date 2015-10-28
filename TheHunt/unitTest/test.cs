using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheHunt;

namespace unitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConnectieMBVOptellen()
        {
            int waarde = 3;
            int bijkomstig = 5;
            int verwacht = 8;

            Unittesttest test = new Unittesttest(waarde);

            // act
            test.optellen(bijkomstig);

            // assert
            int eigenlijk = test.getWaarde();
            Assert.AreEqual(verwacht, eigenlijk, 0.001, "Niet goed opgeteld!");
        }
    }
}
