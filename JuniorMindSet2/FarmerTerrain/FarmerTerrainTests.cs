using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FarmerTerrain
{
    [TestClass]
    public class FarmerTerrainTests
    {
        [TestMethod]
        public void CorrectArea()
        {
            Assert.AreEqual(592900, CalculateAreaOfInitialTerrain(770000, 230));
        }
        double CalculateAreaOfInitialTerrain(double areaOfNewTerrain, double widthOfRectangle)
        {
            double delta = widthOfRectangle * widthOfRectangle - 4 * (-areaOfNewTerrain);
            double initialLength = (-widthOfRectangle + Math.Sqrt(delta)) / 2;
            return initialLength * initialLength;
        }
    }
}
