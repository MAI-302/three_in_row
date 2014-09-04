using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Игра;

namespace UnitTestGame
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void BoardConstructorTest()
        {
            // arrange
            int TestColumns = 2, TestRows = 2;

            // act
            Board TestBoard = new Board(TestRows, TestColumns, 36, 36);

            // assert
            Assert.AreEqual(72, TestBoard.Width);
        }
    }
}
