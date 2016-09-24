﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trains
{
    [TestClass]
    public class TrenuriTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            float distance = CalculateDistanceCoveredByBird(200);
            Assert.AreEqual(150, distance);
        }
        float CalculateDistanceCoveredByBird(float initialDistance)
        {
            return initialDistance - initialDistance / 4;
        }
    }
}
