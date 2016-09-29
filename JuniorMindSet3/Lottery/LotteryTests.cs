using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lottery
{
    [TestClass]
    public class LotteryTests
    {
        [TestMethod]
        public void SixOutOfFourtyNine()
        {
            Assert.AreEqual(0.0000000715112384201851626194m, CalculateProbabilityToWin(6, 49));
        }
        [TestMethod]
        public void FiveOutOfFourtyNine()
        {
            Assert.AreEqual(0.0000005244157484146911925424m, CalculateProbabilityToWin(5, 49));
        }
        decimal CalculateProbabilityToWin(int pickedSet, int totalSet)
        {
            decimal probability = 1;
            for (decimal i = 1; i <= pickedSet; i++)
            {
                probability = probability * (i / totalSet);
                totalSet = totalSet - 1;
            }
            decimal q = probability + 1;
            return probability;
        }

    }
}
