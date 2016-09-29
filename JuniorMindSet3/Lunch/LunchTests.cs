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
            int numberOfDaysuntilWeMeet = 1;
            while (numberOfDaysuntilWeMeet >= 1)
            {
                if (numberOfDaysuntilWeMeet % myFrequency == 0 && numberOfDaysuntilWeMeet % hisFrequency == 0)
                {
                    break;
                }
                numberOfDaysuntilWeMeet = numberOfDaysuntilWeMeet + 1;
            }
            return numberOfDaysuntilWeMeet;
        }
    }
}
