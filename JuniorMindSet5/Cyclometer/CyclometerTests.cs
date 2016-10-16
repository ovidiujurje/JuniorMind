﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cyclometer
{
    [TestClass]
    public class CyclometerTests
    {
        [TestMethod]
        public void ShouldCalculateTotalDistanceCovered()
        {
            var cyclists = new Cyclist[] { new Cyclist("Walter White", 0.6, new double[] { 1, 2, 3, 4, 5 }), new Cyclist("Thomas Thatch", 0.7, new double[] { 1, 2, 5, 5, 7 }), new Cyclist("Franklin Fane", 0.8, new double[] { 1, 2, 2, 8, 6 }) };
            Assert.AreEqual(38.2, CalculateTotalDistanceCovered(cyclists));
        }
        struct Cyclist
        {
            public string name;
            public double diameter;
            public double[] rotationsEachSecond;
            public Cyclist( string name, double diameter, double[] rotationsEachSecond)
            {
            this.name = name;
            this.diameter = diameter;
            this.rotationsEachSecond = rotationsEachSecond;
        }
        }

        double CalculateTotalDistanceCovered(Cyclist[] cyclists)
        {
            double result = 0;
            foreach (Cyclist cyclist in cyclists)
            {
                double sum = 0;
                foreach (double rotation in cyclist.rotationsEachSecond)
                {
                    sum += rotation;
                }
                result += cyclist.diameter * sum;
            }
            return result;
        }
    }
}
