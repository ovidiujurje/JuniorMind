using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fibonacci
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void SeventhFibonacciNumber()
        {
            Assert.AreEqual(8, Fibonacci(7));
        }
        [TestMethod]
        public void NinethFibonacciNumber()
        {
            Assert.AreEqual(21, Fibonacci(9));
        }
        int Fibonacci(int k)
        {
            int previous = 0;
            Fibonacci(k, ref previous);
            return previous;
        }
        int Fibonacci(int k, ref int previous)
        {
            if (k < 2) return k;
            int beforePrevious = 0;
            previous = Fibonacci(k - 1, ref beforePrevious);
            return previous + beforePrevious;
        }
    }
}
