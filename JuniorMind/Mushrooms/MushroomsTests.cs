using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mushrooms
{
    [TestClass]
    public class MushroomsTests
    {
        [TestMethod]
        public void RedMushroomsForThreeTotalAndTwiceAsManyRedThanWhite()
        {
            float redMushrooms = CalculateNumberOfRedMushrooms(3, 2);
            Assert.AreEqual(2, redMushrooms);
        }
        [TestMethod]
        public void RedMushroomsForTwelveTotalAndThreeTimesAsManyRedThanWhite()
        {
            float redMushrooms = CalculateNumberOfRedMushrooms(12, 3);
            Assert.AreEqual(9, redMushrooms);
        }

        float CalculateNumberOfRedMushrooms(uint nMushrooms, float xMoreRedThanWhiteMushrooms)
        {
            float factorForRedMushrooms = xMoreRedThanWhiteMushrooms / (xMoreRedThanWhiteMushrooms + 1);
            return factorForRedMushrooms * nMushrooms;
        }
    }
}
