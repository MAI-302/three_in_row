using System;
using Игра;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGame
{
    [TestClass]
    public class RandElement_Test
    {
        [TestMethod]
        public void RandElementMethod_Test()
        {
            // arrange
            int TestColumns = 2, TestRows = 2;

            // act
            bool count_flag = true;
            Board TestBoard = new Board(TestColumns, TestRows, 36, 36);
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                if (!(TestBoard.RandElement(ref count) is Basic))
                    count_flag = false;
            }

            // assert
            Assert.AreEqual(true, count_flag);
        }
    }
}
