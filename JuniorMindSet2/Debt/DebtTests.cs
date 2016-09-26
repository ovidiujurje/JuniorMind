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
        decimal CalculateTotalDebt(decimal rent, int daysLate)
        {
            decimal penalty = rent * 0.02m * daysLate;
            return rent +  penalty;
        }
    }
}
