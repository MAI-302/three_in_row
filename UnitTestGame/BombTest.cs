using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Игра;

namespace UnitTestGame
{
    [TestClass]
    public class BombTest
    {
        [TestMethod]
        public void BombActivationTest()
        {
            // arrange
            int TestColumns = 2, TestRows = 2;
            Board TestBoard = new Board(TestRows, TestColumns, 36, 36);
            TestBoard.Generate();
            TestBoard.Matrix[0, 0] = new Bomb();

            // act
            bool flag = TestBoard.Matrix[0, 0].Activation(0, 0, TestBoard);

            // assert
            Assert.AreEqual(4, TestBoard.Score);
        }
    }
}
