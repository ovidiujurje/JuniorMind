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
        float CalculateNumberOfRedMushrooms(uint nMushrooms, float xMoreRedThanWhiteMushrooms)
        {
            return xMoreRedThanWhiteMushrooms * nMushrooms / (xMoreRedThanWhiteMushrooms + 1);
        }
    }
}
