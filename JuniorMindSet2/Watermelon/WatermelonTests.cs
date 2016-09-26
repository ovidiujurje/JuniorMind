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
            int melonRemainderAfterSplit = xMelonWeight % 2;
            return PossibleToSplitOrNot(melonRemainderAfterSplit);
        }

        private static string PossibleToSplitOrNot(int melonRemainderAfterSplit)
        {
            return melonRemainderAfterSplit == 0 ? "DA" : "NU";
        }
    }
}
