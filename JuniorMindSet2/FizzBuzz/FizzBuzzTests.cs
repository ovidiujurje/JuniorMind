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
            Assert.AreEqual("Fizz", DoFizzOrBuzzOrBoth(3));
        }
        string DoFizzOrBuzzOrBoth(int number)
        {
            return "Fizz";
        }
    }
}
