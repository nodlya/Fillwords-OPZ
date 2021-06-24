using Microsoft.VisualStudio.TestTools.UnitTesting;
using OPZ.Library;
using System.Collections.Generic;

namespace OPZ.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sample = "2+ 2* 2  ";
            List<object> sampleResult = new List<object>() { "+", "*" };
            var result = new Calculation(sample).ParseToTokens(sample);
            Assert.AreEqual(sampleResult,result);
        }
    }
}
