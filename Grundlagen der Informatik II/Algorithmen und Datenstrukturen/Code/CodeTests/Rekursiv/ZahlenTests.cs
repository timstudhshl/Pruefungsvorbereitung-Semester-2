using Code.Rekursiv;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeTests.Rekursiv
{
    [TestClass()]
    public class ZahlenTests
    {
        [TestMethod()]
        public void SummeTest_0()
        {
            Assert.AreEqual(0, Zahlen.Summe(0));
        }

        [TestMethod()]
        public void SummeTest_6()
        {
            Assert.AreEqual(21, Zahlen.Summe(6));
        }

        [TestMethod()]
        public void SummeTest_15()
        {
            Assert.AreEqual(120, Zahlen.Summe(15));
        }
    }
}