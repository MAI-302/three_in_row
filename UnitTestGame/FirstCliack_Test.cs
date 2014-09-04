using System;
using Игра;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGame
{
    [TestClass]
    public class FirstCliack_Test
    {
        [TestMethod]
        public void FirstCliackMethod_Test()
        {
            // arrange
            int TestColumns = 2, TestRows = 2;
            int clickX = 1, clickY = 1;

            // act
            Board TestBoard = new Board(TestColumns, TestRows, 36, 36);
            TestBoard.Generate();
            TestBoard.Matrix[clickY, clickX] = new Bomb();

            // assert
            Assert.AreEqual(false, TestBoard.FirstClick(clickX,clickY));
        }
    }
}
