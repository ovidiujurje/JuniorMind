using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lunch
{
    [TestClass]
    public class LunchTests
    {
        [TestMethod]
        public void MeEverySixHimEveryFourDays()
        {
            Assert.AreEqual(12, CalculateInHowManyDaysYouWillMeetYourFriendAgain(6, 4));
        }
        int CalculateInHowManyDaysYouWillMeetYourFriendAgain (int myFrequency, int hisFrequency)
        {
            return (myFrequency / GreatestCommonDivisor(myFrequency, hisFrequency)) * hisFrequency;
        }
        int GreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            while (secondNumber != 0)
            {
                int third = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = third;
            }
            return firstNumber;
        }
    }
}
