using Microsoft.VisualStudio.TestTools.UnitTesting;
using Игра;

namespace UnitTestGame
{
    [TestClass]
    public class BasicTest
    {
        [TestMethod]
        public void BasicConstrictorTest()
        {
            // arrange
            int op = 3;

            // act
            Basic BasicElement = new Basic(op);

            // assert
            int objType = BasicElement.ObjectType;
            Assert.AreEqual(op, objType);
        }
    }
}
