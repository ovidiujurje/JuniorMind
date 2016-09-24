using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trains
{
    [TestClass]
    public class TrenuriTests
    {
        [TestMethod]
        public void DistanceForTwoHundred()
        {
            float distance = CalculateDistanceCoveredByBird(200);
            Assert.AreEqual(150, distance);
        }
        [TestMethod]
        public void DistanceforOneThousand()
        {
            float distance = CalculateDistanceCoveredByBird(1000);
            Assert.AreEqual(750, distance);
        }
            float CalculateDistanceCoveredByBird(float initialDistance)
        {
            float distanceCoveredByTrainsBeforeBirdStarts = initialDistance / 4;
            return initialDistance - distanceCoveredByTrainsBeforeBirdStarts;
        }
    }
}
