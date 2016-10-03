using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryOperations
{
    [TestClass]
    public class BinaryOperationsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1 }, ConvertNumberFromDecimalToBinary(3, 2));
        }
        [TestMethod]
        public void TestMethod2()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1 }, ConvertNumberFromDecimalToBinary(5, 2));
        }
        [TestMethod]
        public void TestMethod3()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0, 0, 1 }, ConvertNumberFromDecimalToBinary(49, 2));
        }
        byte[] ConvertNumberFromDecimalToBinary(byte number, byte baseNumber)
        {
            byte[] binaryRepresenationOfNumber = new byte[0];
            byte numberCopy = number;
            while (number > 0)
            {
                byte remainder = (byte)(numberCopy % baseNumber);
                Array.Resize(ref binaryRepresenationOfNumber, binaryRepresenationOfNumber.Length + 1);
                binaryRepresenationOfNumber[binaryRepresenationOfNumber.Length - 1] = remainder;
                numberCopy /= baseNumber;
                if (numberCopy == 0)
                {
                    break;
                }
            }
            Array.Reverse(binaryRepresenationOfNumber);
            byte operationsOne = (byte)(~(~number & 3) | 5 ^ 3);
            byte operationsTwo = (byte)(number >> 2 << 1);
            bool operationsThree = number < 100;
            byte operationsFour = (byte)(number + 5 - 3);
            byte operationsFive = (byte)(number * 3 / 2);
            bool operationsSix = number > 0;
            bool operationsSeven = number == 5;
            bool operationsEight = number != 6;
            return binaryRepresenationOfNumber;
        }
    }
}
