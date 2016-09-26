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
        string CalculateIfWatermelonCanBeDividedInTwoEvenNumbersOfKgs(int xMelonWeight)
        {
            return "DA";
        }
    }
}
