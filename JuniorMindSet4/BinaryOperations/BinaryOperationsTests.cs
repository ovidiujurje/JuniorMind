using System;
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
            CollectionAssert.AreEqual(new byte[] { 0, 0, 1, 1, 1, 0 }, Not(new byte[] { 1, 1, 0, 0, 0, 1 }));
        }
        [TestMethod]
        public void ImplementAnd()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 0, 1 }, And(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 1}));
        }
        [TestMethod]
        public void ImplementOr()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0, 1, 1 }, Or(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 1 }));
        }
        [TestMethod]
        public void ImplementXOr()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0, 1, 0 }, XOr(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 1 }));
        }
        [TestMethod]
        public void ImplementShiftLeft()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 1, 0, 0, 0 }, ShiftLeft(new byte[] { 1, 1, 0, 0, 0, 1 }, 3));
        }
        [TestMethod]
        public void ImplementShiftRight()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 1, 1, 0 }, ShiftRight(new byte[] { 1, 1, 0, 0, 0, 1 }, 3));
        }
        [TestMethod]
        public void ImplementLessThan1()
        {
            Assert.AreEqual(true, LessThan(new byte[] { 1, 1, 0, 0, 0, 0 }, new byte[] { 1, 1, 0, 0, 0, 1 }));
        }
        [TestMethod]
        public void ImplementLessThan2()
        {
            Assert.AreEqual(false, LessThan(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 0, 1, 1, 1, 1 }));
        }
        [TestMethod]
        public void ImplementLessThan3()
        {
            Assert.AreEqual(true, LessThan(new byte[] { 0, 0, 0, 1, 0, 1 }, new byte[] { 1, 1, 0, 0, 0, 1 }));
        }
        [TestMethod]
        public void ImplementLessThan4()
        {
            Assert.AreEqual(false, LessThan(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 1 }));
        }
        [TestMethod]
        public void ImplementAddition()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0, 1, 1 }, Addition(new byte[] { 1, 1, 0, 0 }, new byte[] { 1, 1, 1 }));
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
        byte[] Not(byte[] binaryNumber)
        {
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
        byte[] And(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            byte[] factor = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref otherBinaryNumber);
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
        byte[] Or(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            byte[] factor = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref otherBinaryNumber);
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
        byte[] XOr(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            byte[] factor = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref otherBinaryNumber);
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
        byte[] ShiftLeft(byte[] binaryNumber, byte numberOfSpaces)
        {
            for (int i = 0; i < binaryNumber.Length - numberOfSpaces; i++)
            {
                binaryNumber[i] = binaryNumber[i + numberOfSpaces];
                binaryNumber[i + numberOfSpaces] = 0;
            }
            return binaryNumber;
        }
        byte[] ShiftRight(byte[] binaryNumber, byte numberOfSpaces)
        {
            for (int i = 0; i < binaryNumber.Length - numberOfSpaces; i++)
            {
                binaryNumber[i + numberOfSpaces] = binaryNumber[i];
                binaryNumber[i] = 0;
            }
            return binaryNumber;
        }
        bool LessThan(byte[] firstBinary, byte[] secondBinary)
        {
            if (firstBinary.Length < secondBinary.Length)
                return true;
            if (firstBinary.Length > secondBinary.Length)
                return false;
            for (int i = 0; i < firstBinary.Length; i++)
            {
                if (firstBinary[i] < secondBinary[i])
                    return true;
                if (firstBinary[i] > secondBinary[i])
                    return false;
            }
            return false;
        }
        byte[] Addition(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            otherBinaryNumber = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref otherBinaryNumber);
            byte[] sum = new byte[binaryNumber.Length + 1];
            byte hold = 0;
            for (int i = 0; i < sum.Length; i++)
            {
                if (i == sum.Length - 1)
                {
                    sum[i] = hold;
                    break;
                }
                sum[i] = (byte)((binaryNumber[binaryNumber.Length - i - 1] + otherBinaryNumber[otherBinaryNumber.Length - i - 1] + hold) % 2);
                hold = (byte)((binaryNumber[binaryNumber.Length - i - 1] + otherBinaryNumber[otherBinaryNumber.Length - i - 1] + hold) / 2);
            }
            Array.Reverse(sum);
            return sum;
        }
        private byte[] GeenrateBinaryOfSameLengthforOtherNumber(ref byte[] binaryNumber, ref byte[] otherBinaryNumber)
        {
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
