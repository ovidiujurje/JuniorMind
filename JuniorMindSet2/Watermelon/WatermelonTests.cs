using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Watermelon
{
    [TestClass]
    public class WatermelonTests
    {
        [TestMethod]
        public void DivisionPossibilityForTwoKg()
        {
            Assert.AreEqual("NU" ,CalculateIfWatermelonCanBeDividedInTwoEvenNumbersOfKgs(2));
        }
        [TestMethod]
        public void DivisionPossibilityForOddNumberOfKg()
        {
            Assert.AreEqual("NU", CalculateIfWatermelonCanBeDividedInTwoEvenNumbersOfKgs(7));
        }
        [TestMethod]
        public void DivisionPossibilityForEvenNumberOfKg()
        {
            Assert.AreEqual("DA", CalculateIfWatermelonCanBeDividedInTwoEvenNumbersOfKgs(8));
        }
        string CalculateIfWatermelonCanBeDividedInTwoEvenNumbersOfKgs(int xMelonWeight)
        {
            int melonRemainderAfterSplit = xMelonWeight % 2;
            return melonRemainderAfterSplit == 0 && xMelonWeight > 2 ? "DA" : "NU";
        }
    }
}
