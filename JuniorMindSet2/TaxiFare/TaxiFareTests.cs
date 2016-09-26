using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaxiFare
{
    [TestClass]
    public class TaxiFareTests
    {
        [TestMethod]
        public void DaytimeFareForShortDistances()
        {
            decimal fare = CalculateTaxiFare(1, 8);
            Assert.AreEqual(5, fare);
        }
        decimal CalculateTaxiFare(int distanceInKm, int hour)
        {
            decimal pricePerKm = 5;
            return distanceInKm * pricePerKm;
        }
    }
}
