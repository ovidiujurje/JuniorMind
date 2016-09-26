using System;
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
        [TestMethod]
        public void DoFizzBuzzForMultipleOfThreeAndFive()
        {
            Assert.AreEqual("FizzBuzz", DoFizzOrBuzzOrBoth(15));
        }
        string DoFizzOrBuzzOrBoth(int number)
        {
            int numberRemainderThree = number % 3;
            int numberRemainderFive = number % 5;
            if (numberRemainderThree == 0 && numberRemainderFive == 0)
                return "FizzBuzz";
            if (numberRemainderThree == 0)
                return "Fizz";
            if (numberRemainderFive == 0)
                return "Buzz";
            return "";
        }
    }
}
