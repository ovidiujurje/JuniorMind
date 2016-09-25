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
        double CalculateMinimumBuildingArea(float latitudeColumnA, float longitudeColumnA, float latitudeColumnB, float longitudeColumnB, float latitudeColumnC, float longitudeColumnC)
        {
            double distanceFromAToB = Math.Sqrt((latitudeColumnA - latitudeColumnB) * (latitudeColumnA - latitudeColumnB) + (longitudeColumnA - longitudeColumnB) * (longitudeColumnA - longitudeColumnB));
            double distanceFromBToC = Math.Sqrt((latitudeColumnB - latitudeColumnC) * (latitudeColumnB - latitudeColumnC) + (longitudeColumnB - longitudeColumnC) * (longitudeColumnB - longitudeColumnC));
            double distanceFromCtoA = Math.Sqrt((latitudeColumnC - latitudeColumnA) * (latitudeColumnC - latitudeColumnA) + (longitudeColumnC - longitudeColumnA) * (longitudeColumnC - longitudeColumnA));
            double semiPerimeter = (distanceFromAToB + distanceFromBToC + distanceFromCtoA) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - distanceFromAToB) * (semiPerimeter - distanceFromBToC) * (semiPerimeter - distanceFromCtoA));
        }
    }
}
