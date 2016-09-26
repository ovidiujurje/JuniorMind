using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Debt
{
    [TestClass]
    public class DebtTests
    {
        [TestMethod]
        public void RentFiveDaysLate()
        {
            Assert.AreEqual(110, CalculateTotalDebt(100, 5));
        }
        [TestMethod]
        public void RentTwentyDaysLate()
        {
            Assert.AreEqual(200, CalculateTotalDebt(100, 20));
        }
        [TestMethod]
        public void RentThirtyFiveDaysLate()
        {
            Assert.AreEqual(450, CalculateTotalDebt(100, 35));
        }
        decimal CalculateTotalDebt(decimal rent, int daysLate)
        {
            decimal[] percentages = {0.02m, 0.05m, 0.10m};
            decimal percentPenalty = GivePercentPenalty(daysLate, percentages);
            decimal penalty = rent * percentPenalty * daysLate;
            return rent + penalty;
        }

        private decimal GivePercentPenalty(int daysLate, decimal[] percentages)
        {
            if (IsVeryLate(daysLate))
                return percentages[2];
            if (IsModeratelyLate(daysLate))
                return percentages[1];
            return percentages[0];
        }

        private bool IsVeryLate(int daysLate)
        {
            return daysLate > 30;
        }

        private static bool IsModeratelyLate(int daysLate)
        {
            return daysLate > 10;
        }
    }
}
