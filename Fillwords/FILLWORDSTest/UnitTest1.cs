using Microsoft.VisualStudio.TestTools.UnitTesting;
using FILLWORDS;

namespace FILLWORDSTest
{
    [TestClass]
    public class UnitTest1
    {
        private static Player player;
        [TestMethod]
        public void TestMethod1()
        {
            string name = "!nullName";
            player = new Player(name);
            int expected = 1;
            int actual = player.Level;
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            FieldGeneration fieldGeneration = new FieldGeneration(5);
            int expected = 25;
            int actual = FieldGeneration.Field.Length;
            Assert.AreEqual(expected,actual);
        }

    }
}
