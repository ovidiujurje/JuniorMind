using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Athlete
{
    [TestClass]
    public class AthleteTests
    {
        [TestMethod]
        public void TotalNumberOfRepetitionsForFiveRounds()
        {
            uint repetitions = CalculateTotalNumberOfRepetitions(5);
            Assert.AreEqual(25u, repetitions);
        }
        uint CalculateTotalNumberOfRepetitions(uint nRounds)
        {
            return nRounds * nRounds;
        }
    }
}
