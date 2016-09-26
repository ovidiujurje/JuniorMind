﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void DoFizzForMultipleOfThree()
        {
            Assert.AreEqual("Fizz", DoFizzOrBuzzOrBoth(9));
        }
        [TestMethod]
        public void DoBuzzForMultipleOfFive()
        {
            Assert.AreEqual("Buzz", DoFizzOrBuzzOrBoth(20));
        }
        string DoFizzOrBuzzOrBoth(int number)
        {
            if (number % 3 == 0)
                return "Fizz";
            if (number % 5 == 0)
                return "Buzz";
            return "";
        }
    }
}
