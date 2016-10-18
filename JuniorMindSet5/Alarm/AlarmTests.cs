using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alarm
{
    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void ShouldSetOffAlarm1()
        {
            Assert.AreEqual(true, DetermineIfAlarmShouldBeSetOff(6, 8, Days.Tuesday, 6));
        }
        [TestMethod]
        public void ShouldSetOffAlarm2()
        {
            Assert.AreEqual(true, DetermineIfAlarmShouldBeSetOff(6, 8, Days.Saturday, 8));
        }
        [TestMethod]
        public void ShouldNotSetOffAlarm1()
        {
            Assert.AreEqual(false, DetermineIfAlarmShouldBeSetOff(6, 8, Days.Friday, 11));
        }
        [TestMethod]
        public void ShouldNotSetOffAlarm2()
        {
            Assert.AreEqual(false, DetermineIfAlarmShouldBeSetOff(6, 8, Days.Sunday, 3));
        }
        [Flags]
        enum Days
        {
            Noday = 0x0,
            Sunday = 0x1,
            Monday = 0x2,
            Tuesday = 0x4,
            Wednesday = 0x8,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }
        bool DetermineIfAlarmShouldBeSetOff( int weekdayAlarmHour, int weekendAlarmHour,Days currentDay, int currentHour)
        {

            Days weekdays = Days.Monday | Days.Tuesday;
            weekdays = weekdays | Days.Wednesday;
            weekdays = weekdays | Days.Thursday;
            weekdays = weekdays | Days.Friday;
            Days weekend = Days.Saturday | Days.Sunday;
            if ((weekdays & currentDay) == currentDay && (currentHour == weekdayAlarmHour)) return true;
            if ((weekend & currentDay) == currentDay && (currentHour == weekendAlarmHour)) return true;
            return false;
        }
    }
}
