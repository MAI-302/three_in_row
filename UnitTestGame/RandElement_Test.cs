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
            int TestColumns = 100, TestRows = 100;
            double sigma = 0.05;
            double basicCellChance = 0.6;

            // act
            bool count_flag = true;
            Board TestBoard = new Board(TestColumns, TestRows, 36, 36);
            TestBoard.Generate();
            int count = 0;
            double p;

            for (int i = 0; i < TestColumns; i++)
            {
                for (int j = 0; j < TestRows; j++)
                    if (TestBoard.Matrix[i, j] is Basic)
                        count++;
            }
            p = (double) count / (TestColumns * TestRows);
            if ((p >= basicCellChance - basicCellChance*(sigma)) &&
                (p <= basicCellChance + basicCellChance * (sigma)))
                count_flag = true;
            // assert
            Assert.AreEqual(true, count_flag);
        }
    }
}
