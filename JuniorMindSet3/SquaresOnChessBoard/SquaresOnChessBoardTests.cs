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
        int CalculateNumberOfSquares(int length, int width)
        {
            int numberOfPossibleSquares = 0;
            for (int i = 1; i <= length; i++)
            {
                numberOfPossibleSquares += i*i;
            }
            return numberOfPossibleSquares;
        }
    }
}
