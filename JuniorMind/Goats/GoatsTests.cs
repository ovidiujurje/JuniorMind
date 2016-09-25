using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goats
{
    [TestClass]
    public class GoatsTests
    {
        [TestMethod]
        public void HayForTwoGoatsInTwoDays()
        {
            float hay = CalculateHayEatenByQGoatsInWDays(1, 2, 2, 2, 2);
            Assert.AreEqual(4, hay);
        }
        [TestMethod]
        public void HayForThreeGoatsInTwoDays()
        {
            float hay = CalculateHayEatenByQGoatsInWDays(8, 6, 40, 2, 3);
            Assert.AreEqual(5, hay);
        }
        float CalculateHayEatenByQGoatsInWDays(float xDays, uint yGoats, float zKgOfHay, float wDays, float qGoats)
        {
            float factorIncreaseInDays = wDays / xDays;
            float factorIncreaseInGoats = qGoats / yGoats;
            float factorIncreaseInHay = factorIncreaseInDays * factorIncreaseInGoats;
            return factorIncreaseInHay * zKgOfHay;
        }
    }
}
