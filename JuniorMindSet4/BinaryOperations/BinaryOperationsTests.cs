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
            CollectionAssert.AreEqual(new byte[] { 1, 1 }, ConvertNumberFromDecimalToBinary(3));
        }
        [TestMethod]
        public void TestMethod2()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1 }, ConvertNumberFromDecimalToBinary(5));
        }
        [TestMethod]
        public void TestMethod3()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0, 0, 1 }, ConvertNumberFromDecimalToBinary(49));
        }
        byte[] ConvertNumberFromDecimalToBinary(byte number)
        {
            byte[] binaryRepresenationOfNumber = new byte[0];
            byte numberCopy = number;
            while (number > 0)
            {
                byte remainder = (byte)(numberCopy % 2);
                Array.Resize(ref binaryRepresenationOfNumber, binaryRepresenationOfNumber.Length + 1);
                binaryRepresenationOfNumber[binaryRepresenationOfNumber.Length - 1] = remainder;
                numberCopy /= 2;
                if (numberCopy == 0)
                {
                    break;
                }
            }
            Array.Reverse(binaryRepresenationOfNumber);
            return binaryRepresenationOfNumber;
        }
    }
}
