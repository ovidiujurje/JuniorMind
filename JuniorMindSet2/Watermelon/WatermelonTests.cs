using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Watermelon
{
    [TestClass]
    public class WatermelonTests
    {
        [TestMethod]
        public void DivisionPossibilityForEvenNumberOfKg()
        {
            Assert.AreEqual("DA" ,CalculateIfWatermelonCanBeDividedInTwoEvenNumbersOfKgs(2));
        }
        [TestMethod]
        public void DivisionPossibilityForOddNumberOfKg()
        {
            Assert.AreEqual("NU", CalculateIfWatermelonCanBeDividedInTwoEvenNumbersOfKgs(7));
        }

        string CalculateIfWatermelonCanBeDividedInTwoEvenNumbersOfKgs(int xMelonWeight)
        {
            return xMelonWeight % 2 == 0 ? "DA" : "NU";
        }
    }
}
