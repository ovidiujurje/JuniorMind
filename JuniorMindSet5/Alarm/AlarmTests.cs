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
            Days weekdays = Days.Monday | Days.Tuesday;
            weekdays = weekdays | Days.Wednesday;
            weekdays = weekdays | Days.Thursday;
            weekdays = weekdays | Days.Friday;
            Days weekend = Days.Saturday | Days.Sunday;
            Assert.AreEqual(true, DetermineIfAlarmShouldBeSetOff(weekdays, weekend, 6, 8, Days.Tuesday, 6));
        }
        [TestMethod]
        public void ShouldSetOffAlarm2()
        {
            Days weekdays = Days.Monday | Days.Tuesday;
            weekdays = weekdays | Days.Wednesday;
            weekdays = weekdays | Days.Thursday;
            weekdays = weekdays | Days.Friday;
            Days weekend = Days.Saturday | Days.Sunday;
            Assert.AreEqual(true, DetermineIfAlarmShouldBeSetOff(weekdays, weekend, 6, 8, Days.Saturday, 8));
        }
        [TestMethod]
        public void ShouldSetOffAlarm3()
        {
            Assert.AreEqual(true, DetermineIfAlarmShouldBeSetOff(Days.Monday, Days.Sunday, 7, 10, Days.Monday, 7));
        }
        [TestMethod]
        public void ShouldNotSetOffAlarm1()
        {
            Days weekdays = Days.Monday | Days.Tuesday;
            weekdays = weekdays | Days.Wednesday;
            weekdays = weekdays | Days.Thursday;
            weekdays = weekdays | Days.Friday;
            Days weekend = Days.Saturday | Days.Sunday;
            Assert.AreEqual(false, DetermineIfAlarmShouldBeSetOff(weekdays, weekend, 6, 8, Days.Friday, 11));
        }
        [TestMethod]
        public void ShouldNotSetOffAlarm2()
        {
            Days weekdays = Days.Monday | Days.Tuesday;
            weekdays = weekdays | Days.Wednesday;
            weekdays = weekdays | Days.Thursday;
            weekdays = weekdays | Days.Friday;
            Days weekend = Days.Saturday | Days.Sunday;
            Assert.AreEqual(false, DetermineIfAlarmShouldBeSetOff(weekdays, weekend, 6, 8, Days.Sunday, 3));
        }
        [TestMethod]
        public void ShouldNotSetOffAlarm3()
        {
            Assert.AreEqual(false, DetermineIfAlarmShouldBeSetOff(Days.Monday, Days.Sunday, 7, 10, Days.Saturday, 7));
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
        bool DetermineIfAlarmShouldBeSetOff( Days weekdayAlarm, Days weekendAlarm, int weekdayAlarmHour, int weekendAlarmHour,Days currentDay, int currentHour)
        {
            if ((weekdayAlarm & currentDay) == currentDay && (currentHour == weekdayAlarmHour)) return true;
            if ((weekendAlarm & currentDay) == currentDay && (currentHour == weekendAlarmHour)) return true;
            return false;
        }
    }
}
