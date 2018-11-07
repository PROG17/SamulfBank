using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBank
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var expected = 5;
            var actual = 5;
            Assert.AreEqual(expected, actual);
        }
    }
}
