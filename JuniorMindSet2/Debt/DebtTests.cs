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
        decimal CalculateTotalDebt(decimal rent, int daysLate)
        {
            decimal percentPenalty = daysLate > 10 ? 0.05m : 0.02m;
            decimal penalty = rent * percentPenalty * daysLate;
            return rent + penalty;
        }
    }
}
