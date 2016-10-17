using System;
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
            Assert.AreEqual(120.00883936713009, CalculateTotalDistanceCovered(cyclists));
        }
        [TestMethod]
        public void ShouldGetFastestNameAndSecond()
        {
            var cyclists = new Cyclist[] { new Cyclist("Walter White", 0.6, new double[] { 1, 2, 3, 4, 5 }), new Cyclist("Thomas Thatch", 0.7, new double[] { 1, 2, 5, 5, 7 }), new Cyclist("Franklin Fane", 0.8, new double[] { 1, 2, 2, 8, 6 }) };
            double second;
            GetFastestSecondAndCyclistName(cyclists, out second);
            Assert.AreEqual("Franklin Fane", GetFastestSecondAndCyclistName(cyclists, out second));
            Assert.AreEqual(4, second);

        }
        [TestMethod]
        public void ShouldGetCyclistWithBestMeanSpeed()
        {
            var cyclists = new Cyclist[] { new Cyclist("Walter White", 0.6, new double[] { 1, 2, 3, 4, 5 }), new Cyclist("Thomas Thatch", 0.7, new double[] { 1, 2, 5, 5, 7 }), new Cyclist("Franklin Fane", 0.8, new double[] { 1, 2, 2, 8, 6 }) };
            Assert.AreEqual("Franklin Fane", GetCyclistWithBestMeanSpeed(cyclists));
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
            double totalDistance = 0;
            foreach (Cyclist cyclist in cyclists)
            {
                double circumference = Math.PI * cyclist.diameter;
                totalDistance += circumference * CalculateSum(cyclist);
            }
            return totalDistance;
        }
        string GetFastestSecondAndCyclistName(Cyclist[] cyclists, out double resultSecond)
        {
            resultSecond = 0;
            string resultCyclist = string.Empty;
            foreach (Cyclist cyclist in cyclists)
            {
                for (int i = 1; i < cyclist.rotationsEachSecond.Length; i++)
                {
                    if (cyclist.rotationsEachSecond[i] >= cyclist.rotationsEachSecond[i - 1])
                    {
                        resultSecond = i + 1;
                        resultCyclist = cyclist.name;
                    }
                }
            }
            return resultCyclist;
        }
        string GetCyclistWithBestMeanSpeed(Cyclist[] cyclists)
        {
            double[] meanSpeed = new double[cyclists.Length];
            int i = 0;
            foreach (Cyclist cyclist in cyclists)
            {
                double circumference = cyclist.diameter * Math.PI;
                double sumSpeed = CalculateSum(cyclist) * circumference;
                meanSpeed[i] = sumSpeed / cyclist.rotationsEachSecond.Length;
                i++;
            }
            int resultPosition = 0;
            for (int j = 1; j < meanSpeed.Length; j++)
            {
                if (meanSpeed[j] >= meanSpeed[j - 1])
                {
                    resultPosition = j;
                }
            }
            return cyclists[resultPosition].name;
        }
        private static double CalculateSum(Cyclist cyclist)
        {
            double sum = 0;
            foreach (double rotation in cyclist.rotationsEachSecond)
            {
                sum += rotation;
            }

            return sum;
        }
    }
}