using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SquaresOnChessBoard
{
    [TestClass]
    public class SquaresOnChessBoardTests
    {
        [TestMethod]
        public void NumberOfSquaresOnEightByEightBoard()
        {
            Assert.AreEqual(204, CalculateNumberOfSquares(8, 8));
        }
        [TestMethod]
        public void NumberOfSquaresOnDifferentLengthAndWidthBoard()
        {
            Assert.AreEqual(20, CalculateNumberOfSquares(4, 3));
        }

        int CalculateNumberOfSquares(int length, int width)
        {
            int numberOfPossibleSquares = 0;
            int i = length - width + 1;
            int j = 1;
            while (i <= length && j <= width)
            {
                numberOfPossibleSquares += i * j;
                i += 1;
                j += 1;
            }
            return numberOfPossibleSquares;
        }
    }
}

