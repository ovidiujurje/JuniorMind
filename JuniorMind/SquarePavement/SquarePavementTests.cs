using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SquarePavement
{
    [TestClass]
    public class SquarePavementTests
    {
        [TestMethod]
        public void NumberOfFourByFourStonesRequiredForNineByEightSquare()
        {
            double stones = CalculateCubicStonesRequiredToPaveSquare(9, 8, 4);
            Assert.AreEqual(6, stones);
        }
        double CalculateCubicStonesRequiredToPaveSquare(float mSquareLength, float nSquareWidth, float aStoneLengthWidth)
        {
            double stonesRequiredLengthwise = Math.Ceiling(mSquareLength / aStoneLengthWidth);
            double stonesRequiredWidthwise = Math.Ceiling(nSquareWidth / aStoneLengthWidth);
            return stonesRequiredLengthwise * stonesRequiredWidthwise;
        }
    }
}
