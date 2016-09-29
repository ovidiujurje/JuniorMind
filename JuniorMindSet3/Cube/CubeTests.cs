using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cube
{
    [TestClass]
    public class CubeTests
    {
        [TestMethod]
        public void CalculateFirstNumber()
        {
            Assert.AreEqual(192, GetCubeEndingInEightEightEight(1));
        }
        [TestMethod]
        public void CalculateSecondNumber()
        {
            Assert.AreEqual(442, GetCubeEndingInEightEightEight(2));
        }
        [TestMethod]
        public void CalculateThirdNumber()
        {
            Assert.AreEqual(692, GetCubeEndingInEightEightEight(3));
        }
        decimal GetCubeEndingInEightEightEight(int k)
        {
            decimal sum = 0;
            decimal cube = 1;
            decimal i = 192;
            while (i > 0)
            {
                cube = i * i * i;
                decimal lastThree = cube % 1000;
                if (lastThree == 888)
                {
                    sum += lastThree;
                }
                if (sum / k == 888)
                {
                    break;
                }
                i = i + 1;
            }
            return i;
        }
    }
}
