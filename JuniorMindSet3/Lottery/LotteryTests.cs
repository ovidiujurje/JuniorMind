using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lottery
{
    [TestClass]
    public class LotteryTests
    {
        [TestMethod]
        public void SixOutOfFourtyNineCategoryOne()
        {
            Assert.AreEqual(0.0000000715112384201851626194m, CalculateProbabilityToWin(6, 6, 49));
        }
        [TestMethod]
        public void SixOutOfFourtyNineCategoryTwo()
        {
            Assert.AreEqual(0.0000184498995124077719558095m, CalculateProbabilityToWin(5, 6, 49));
        }
        [TestMethod]
        public void SixOutOfFourtyNineCategoryThree()
        {
            Assert.AreEqual(0.0009686197244014080276799981m, CalculateProbabilityToWin(4, 6, 49));
        }
        [TestMethod]
        public void FiveOutOfFourtyCategoryOne()
        {
            Assert.AreEqual(0.0000015197383618436250015197m, CalculateProbabilityToWin(5, 5, 40));
        }
        [TestMethod]
        public void FiveOutOfFourtyCategoryTwo()
        {
            Assert.AreEqual(0.0002659542133226343752659542m, CalculateProbabilityToWin(4, 5, 40));
        }
        [TestMethod]
        public void FiveOutOfFourtyCategoryThree()
        {
            Assert.AreEqual(0.0090424432529695687590424433m, CalculateProbabilityToWin(3, 5, 40));
        }
        decimal CalculateProbabilityToWin(int guessedSet, int pickedSet, int totalSet)
        {
            decimal denominator = 1;
            decimal numeratorOne = 1;
            decimal numeratorTwo = 1;
            decimal totalMinusPicked = totalSet - pickedSet;
            decimal pickedMinusGuessed = pickedSet - guessedSet;
            for (decimal i = 1; i <= pickedSet; i++)
            {
                denominator *= (totalSet / i);
                totalSet -= 1;
            }

            for (decimal j = 1; j <= guessedSet; j++)
            {
                numeratorOne *= (pickedSet / j);
                pickedSet -= 1;
            }
            for (decimal k = 1; k <= pickedMinusGuessed; k++)
            {
                numeratorTwo *= ((totalMinusPicked) / k);
                totalMinusPicked -= 1;
            }
            return numeratorOne * numeratorTwo / denominator;
        }

    }
}
