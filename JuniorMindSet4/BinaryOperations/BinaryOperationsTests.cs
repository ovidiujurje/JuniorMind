﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryOperations
{
    [TestClass]
    public class BinaryOperationsTests
    {
        [TestMethod]
        public void ConvertToBinary1()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1 }, ConvertNumberFromDecimalToBinary(3, 2));
        }
        [TestMethod]
        public void ConvertToBinary2()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1 }, ConvertNumberFromDecimalToBinary(5, 2));
        }
        [TestMethod]
        public void ConvertToBinary3()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0, 0, 1 }, ConvertNumberFromDecimalToBinary(49, 2));
        }
        [TestMethod]
        public void ImplementNot()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 1, 1, 1, 0 }, Not(49));
        }
        [TestMethod]
        public void ImplementAnd()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 0, 1 }, And(49, 3));
        }
        [TestMethod]
        public void ImplementOr()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0, 1, 1 }, Or(49, 3));
        }
        [TestMethod]
        public void ImplementXOr()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0, 1, 0 }, XOr(49, 3));
        }
        byte[] ConvertNumberFromDecimalToBinary(byte number, byte baseNumber)
        {
            byte[] binaryRepresenationOfNumber = new byte[0];
            while (number > 0)
            {
                byte remainder = (byte)(number % baseNumber);
                Array.Resize(ref binaryRepresenationOfNumber, binaryRepresenationOfNumber.Length + 1);
                binaryRepresenationOfNumber[binaryRepresenationOfNumber.Length - 1] = remainder;
                number /= baseNumber;
            }
            Array.Reverse(binaryRepresenationOfNumber);
            return binaryRepresenationOfNumber;
        }
        byte[] Not(byte number)
        {
            byte[] binaryNumber = ConvertNumberFromDecimalToBinary(number, 2);
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] == 0)
                {
                    binaryNumber[i] = 1;
                }
                else
                {
                    binaryNumber[i] = 0;
                }
            }
            return binaryNumber;
        }
        byte[] And(byte number, byte otherNumber)
        {
            byte[] binaryNumber = ConvertNumberFromDecimalToBinary(number, 2);
            byte[] factor = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, otherNumber);
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] == 1 && factor[i] == 1)
                {
                    binaryNumber[i] = 1;
                }
                else
                {
                    binaryNumber[i] = 0;
                }
            }
            return binaryNumber;
        }
        byte[] Or(byte number, byte otherNumber)
        {
            byte[] binaryNumber = ConvertNumberFromDecimalToBinary(number, 2);
            byte[] factor = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, otherNumber);
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] == 0 && factor[i] == 0)
                {
                    binaryNumber[i] = 0;
                }
                else
                {
                    binaryNumber[i] = 1;
                }
            }
            return binaryNumber;
        }
        byte[] XOr(byte number, byte otherNumber)
        {
            byte[] binaryNumber = ConvertNumberFromDecimalToBinary(number, 2);
            byte[] factor = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, otherNumber);
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] != factor[i])
                {
                    binaryNumber[i] = 1;
                }
                else
                {
                    binaryNumber[i] = 0;
                }
            }
            return binaryNumber;
        }
        private byte[] GeenrateBinaryOfSameLengthforOtherNumber(ref byte[] binaryNumber, byte otherNumber)
        {
            byte[] otherBinaryNumber = ConvertNumberFromDecimalToBinary(otherNumber, 2);
            if (binaryNumber.Length < otherBinaryNumber.Length)
            {
                Swap(ref binaryNumber, ref otherBinaryNumber);
            }
            byte[] factor = new byte[binaryNumber.Length];
            for (int i = binaryNumber.Length - otherBinaryNumber.Length; i < binaryNumber.Length; i++)
            {
                factor[i] = otherBinaryNumber[i - (binaryNumber.Length - otherBinaryNumber.Length)];
            }
            return factor;
        }
        void Swap (ref byte[] first, ref byte[] second)
        {
            byte[] temp = first;
            first = second;
            second = temp;
        }
    }
}
