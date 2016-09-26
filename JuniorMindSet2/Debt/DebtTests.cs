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
            decimal percentPenalty = 0.02m;
            if (IsVeryLate(daysLate))
                percentPenalty = 0.10m;
            else if (IsModeratelyLate(daysLate))
                percentPenalty = 0.05m;
            decimal penalty = rent * percentPenalty * daysLate;
            return rent + penalty;
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
