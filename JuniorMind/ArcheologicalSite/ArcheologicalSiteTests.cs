using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcheologicalSite
{
    [TestClass]
    public class ArcheologicalSiteTests
    {
        [TestMethod]
        public void MinimumAreaCondition1()
        {
            double area = CalculateMinimumBuildingArea(1, 1, 2, 2, 3, 3);
            Assert.AreEqual(0, area);
        }
        [TestMethod]
        public void MinimumAreaCondition2()
        {
            double area = CalculateMinimumBuildingArea(1, 2, 1, 5, 5, 2);
            Assert.AreEqual(6, area);
        }
        double CalculateMinimumBuildingArea(float latitudeColumnA, float longitudeColumnA, float latitudeColumnB, float longitudeColumnB, float latitudeColumnC, float longitudeColumnC)
        {
            double distanceFromAToB = DistanceBetweenTwoPoints(latitudeColumnA, longitudeColumnA, latitudeColumnB, longitudeColumnB);
            double distanceFromBToC = DistanceBetweenTwoPoints(latitudeColumnB, longitudeColumnB, latitudeColumnC, longitudeColumnC);
            double distanceFromCtoA = DistanceBetweenTwoPoints(latitudeColumnA, longitudeColumnA, latitudeColumnC, longitudeColumnC);
            double semiPerimeter = (distanceFromAToB + distanceFromBToC + distanceFromCtoA) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - distanceFromAToB) * (semiPerimeter - distanceFromBToC) * (semiPerimeter - distanceFromCtoA));
        }
        double DistanceBetweenTwoPoints (float latitudeX, float longitudeX, float latitudeY, float longitudeY)
        {
            return Math.Sqrt((latitudeX - latitudeY) * (latitudeX - latitudeY) + (longitudeX - longitudeY) * (longitudeX - longitudeY));
        }
    }
}
