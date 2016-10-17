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
            Assert.AreEqual(true, DetermineIfAlarmShouldBeSetOff(Days.Tuesday, Hours.sixAM));
        }
        [TestMethod]
        public void ShouldSetOffAlarm2()
        {
            Assert.AreEqual(true, DetermineIfAlarmShouldBeSetOff(Days.Saturday, Hours.eightAM));
        }
        [TestMethod]
        public void ShouldNotSetOffAlarm1()
        {
            Assert.AreEqual(false, DetermineIfAlarmShouldBeSetOff(Days.Friday, Hours.elevenAM));
        }
        [TestMethod]
        public void ShouldNotSetOffAlarm2()
        {
            Assert.AreEqual(false, DetermineIfAlarmShouldBeSetOff(Days.Sunday, Hours.threeAM));
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
        [Flags]
        enum Hours
        {
            twelveAM = 0x0,
            oneAM = 0x1,
            twoAM = 0x2,
            threeAM = 0x4,
            fourAM = 0x8,
            fiveAM = 0x10,
            sixAM = 0x20,
            sevenAM = 0x40,
            eightAM = 0x80 ,
            nineAM = 0x100,
            tenAM = 0x200,
            elevenAM = 0x400,
            twelvePM = 0x800,
            onePM = 0x1000,
            twoPM = 0x2000,
            threePM = 0x4000,
            fourPM = 0x8000,
            fivePM = 0x10000,
            sixPM = 0x20000,
            sevenPM = 0x40000,
            eightPM = 0x80000,
            ninePM = 0x100000,
            tenPM = 0x200000,
            elevenPM = 0x400000
        }
        bool DetermineIfAlarmShouldBeSetOff(Days day, Hours hour)
        {
            Days weekdays = Days.Monday | Days.Tuesday;
            weekdays = weekdays | Days.Wednesday;
            weekdays = weekdays | Days.Thursday;
            weekdays = weekdays | Days.Friday;
            Days weekend = Days.Saturday | Days.Sunday;
            Hours weekdayalarm = Hours.sixAM;
            Hours weekendalarm = Hours.eightAM;
            if ((weekdays & day) == day && (weekdayalarm & hour) == hour) return true;
            if ((weekend & day) == day && (weekendalarm & hour) == hour) return true;
            return false;
        }
    }
}
