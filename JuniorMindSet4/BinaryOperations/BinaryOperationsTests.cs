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
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(14, 2), Not(ConvertNumberFromDecimalToBinary(49, 2), 2));
        }
        [TestMethod]
        public void ImplementAnd()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(1, 2), And(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(3, 2)));
        }
        [TestMethod]
        public void ImplementOr()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(51, 2), Or(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(3, 2)));
        }
        [TestMethod]
        public void ImplementXOr()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(50, 2), XOr(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(3, 2)));
        }
        [TestMethod]
        public void ImplementShiftLeft()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary (88, 2), TrimZerosFromBeginning(ShiftLeft(ConvertNumberFromDecimalToBinary(11, 2), 3)));
        }
        [TestMethod]
        public void ImplementShiftRight()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(6, 2), TrimZerosFromBeginning(ShiftRight(ConvertNumberFromDecimalToBinary(49, 2), 3)));
        }
        [TestMethod]
        public void ImplementLessThan1()
        {
            Assert.AreEqual(true, LessThan(ConvertNumberFromDecimalToBinary(48, 2), ConvertNumberFromDecimalToBinary(49, 2)));
        }
        [TestMethod]
        public void ImplementLessThan2()
        {
            Assert.AreEqual(false, LessThan(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(47, 2)));
        }
        [TestMethod]
        public void ImplementLessThan3()
        {
            Assert.AreEqual(true, LessThan(ConvertNumberFromDecimalToBinary(5, 2), ConvertNumberFromDecimalToBinary(49, 2)));
        }
        [TestMethod]
        public void ImplementLessThan4()
        {
            Assert.AreEqual(false, LessThan(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(3, 2)));
        }
        [TestMethod]
        public void ImplementGreaterThan1()
        {
            Assert.AreEqual(false, GreaterThan(ConvertNumberFromDecimalToBinary(48, 2), ConvertNumberFromDecimalToBinary(49, 2)));
        }
        [TestMethod]
        public void ImplementGreaterThan2()
        {
            Assert.AreEqual(true, GreaterThan(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(3, 2)));
        }
        [TestMethod]
        public void ImplementEqual1()
        {
            Assert.AreEqual(true, Equal(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(49, 2)));
        }
        [TestMethod]
        public void ImplementEqual2()
        {
            Assert.AreEqual(false, Equal(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(48, 2)));
        }
        [TestMethod]
        public void ImplementNotEqual1()
        {
            Assert.AreEqual(false, NotEqual(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(49, 2)));
        }
        [TestMethod]
        public void ImplementNotEqual2()
        {
            Assert.AreEqual(true, NotEqual(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(48, 2)));
        }
        [TestMethod]
        public void ImplementAddition()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(19, 2), Addition(ConvertNumberFromDecimalToBinary(12, 2), ConvertNumberFromDecimalToBinary(7, 2), 2));
        }
        [TestMethod]
        public void ImplementAdditionBaseThree()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(19, 3), Addition(ConvertNumberFromDecimalToBinary(12, 3), ConvertNumberFromDecimalToBinary(7, 3), 3));
        }
        [TestMethod]
        public void ImplementAdditionBaseFour()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(110, 4), Addition(ConvertNumberFromDecimalToBinary(66, 4), ConvertNumberFromDecimalToBinary(44, 4), 4));
        }
        [TestMethod]
        public void ImplementSubtraction1()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(2, 2), Subtraction(ConvertNumberFromDecimalToBinary(5, 2), ConvertNumberFromDecimalToBinary(3, 2), 2));
        }
        [TestMethod]
        public void ImplementSubtraction2()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(46, 2), Subtraction(ConvertNumberFromDecimalToBinary(49, 2), ConvertNumberFromDecimalToBinary(3, 2), 2));
        }
        [TestMethod]
        public void ImplementSubtractionBaseThree()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(12, 3), Subtraction(ConvertNumberFromDecimalToBinary(19, 3), ConvertNumberFromDecimalToBinary(7, 3), 3));
        }
        [TestMethod]
        public void ImplementSubtractionBaseFour()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(22, 4), Subtraction(ConvertNumberFromDecimalToBinary(66, 4), ConvertNumberFromDecimalToBinary(44, 4), 4));
        }
        [TestMethod]
        public void ImplementMultiplication1()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(35, 2), Multiplication(ConvertNumberFromDecimalToBinary(7, 2), ConvertNumberFromDecimalToBinary(5, 2), 2));
        }
        [TestMethod]
        public void ImplementMultiplication2()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(15, 2), Multiplication(ConvertNumberFromDecimalToBinary(5, 2), ConvertNumberFromDecimalToBinary(3, 2), 2));
        }
        [TestMethod]
        public void ImplementMultiplicationBaseThree()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(30, 3), Multiplication(ConvertNumberFromDecimalToBinary(6, 3), ConvertNumberFromDecimalToBinary(5, 3), 3));
        }
        [TestMethod]
        public void ImplementMultiplicationBaseFour()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(55, 4), Multiplication(ConvertNumberFromDecimalToBinary(11, 4), ConvertNumberFromDecimalToBinary(5, 4), 4));
        }
        [TestMethod]
        public void ImplementDivision1()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(2, 2), Division(ConvertNumberFromDecimalToBinary(6, 2), ConvertNumberFromDecimalToBinary(3, 2), 2));
        }
        [TestMethod]
        public void ImplementDivision2()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(11, 2), Division(ConvertNumberFromDecimalToBinary(33, 2), ConvertNumberFromDecimalToBinary(3, 2), 2));
        }
        [TestMethod]
        public void ImplementDivisionBaseThree1()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(4, 3), Division(ConvertNumberFromDecimalToBinary(20, 3), ConvertNumberFromDecimalToBinary(5, 3), 3));
        }
        [TestMethod]
        public void ImplementDivisionBaseThree2()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(6, 3), Division(ConvertNumberFromDecimalToBinary(42, 3), ConvertNumberFromDecimalToBinary(7, 3), 3));
        }
        [TestMethod]
        public void ImplementDivisionBaseFour()
        {
            CollectionAssert.AreEqual(ConvertNumberFromDecimalToBinary(3, 4), Division(ConvertNumberFromDecimalToBinary(66, 4), ConvertNumberFromDecimalToBinary(22, 4), 4));
        }
        byte[] ConvertNumberFromDecimalToBinary(byte number, byte baseNumber)
        {
            byte[] binaryRepresenationOfNumber = new byte[0];
            if (number ==0)
                binaryRepresenationOfNumber = new byte[] { 0 };
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
        byte[] Not(byte[] binaryNumber, byte baseNumber)
        {
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                binaryNumber[i] =(byte)(baseNumber - 1 - binaryNumber[i]);
            }
            return TrimZerosFromBeginning(binaryNumber);
        }
        byte[] And(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            byte[] factor = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref otherBinaryNumber);
            byte[] and = AndOrXOrFunction(binaryNumber, factor, OperationType.And);
            return TrimZerosFromBeginning(and);
        }
        byte[] Or(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            byte[] factor = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref otherBinaryNumber);
            byte[] or = AndOrXOrFunction(binaryNumber, factor, OperationType.Or);
            return TrimZerosFromBeginning(or);
        }
        byte[] XOr(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            byte[] factor = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref otherBinaryNumber);
            byte[] xOr = AndOrXOrFunction(binaryNumber, factor, OperationType.XOr);
            return TrimZerosFromBeginning(xOr);
        }
        public enum OperationType { And, Or, XOr }
        private static byte[] AndOrXOrFunction(byte[] binaryNumber, byte[] factor, OperationType operation)
        {
            byte[] andOrXOr = new byte[binaryNumber.Length];
            for (int i = 0; i < binaryNumber.Length; i++)
                andOrXOr[i] = ExecuteOperation(binaryNumber[i], factor[i], operation);
            return andOrXOr;
        }

        private static byte ExecuteOperation(byte binaryNumber, byte factor, OperationType operation)
        {
            switch (operation)
            {
                case OperationType.And:
                    {
                        if (binaryNumber == 1 && factor == 1)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                case OperationType.Or:
                    {
                        if (binaryNumber == 0 && factor == 0)
                        {
                            return 0;
                        }
                        else
                        {
                            return 1;
                        }
                    }
            }
            if (binaryNumber == factor)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        byte[] ShiftLeft(byte[] binaryNumber, byte numberOfSpaces)
        {
            Array.Resize(ref binaryNumber, binaryNumber.Length + numberOfSpaces);
            return binaryNumber;
        }
        byte[] ShiftRight(byte[] binaryNumber, byte numberOfSpaces)
        {
            Array.Resize(ref binaryNumber, binaryNumber.Length - numberOfSpaces);
            return binaryNumber;
        }
        bool LessThan(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            bool less = false;
            int maxLength = Math.Max(binaryNumber.Length,otherBinaryNumber.Length);
            for (int i = 0; i < maxLength; i++)
            {
                if (UseZeroForPositionsGreaterThanLast(binaryNumber, i) < UseZeroForPositionsGreaterThanLast(otherBinaryNumber, i)) less = true;
                else
                if (UseZeroForPositionsGreaterThanLast(binaryNumber, i) > UseZeroForPositionsGreaterThanLast(otherBinaryNumber, i)) less = false;
            }
            return less;
        }
        bool GreaterThan(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            int maxLength = Math.Max(binaryNumber.Length, otherBinaryNumber.Length);
            if (LessThan(binaryNumber, otherBinaryNumber))
                return false;
            for (int i = 0; i < maxLength; i++)
            {
                if (UseZeroForPositionsGreaterThanLast(binaryNumber, i) != UseZeroForPositionsGreaterThanLast(otherBinaryNumber, i)) return true;
            }
            return false;
        }

        private static int UseZeroForPositionsGreaterThanLast(byte[] binary, int position)
        {
            int bit = 0;
            if (position < binary.Length) bit = binary[binary.Length - position - 1];
            return bit;
        }

        bool Equal(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            return !LessThan(binaryNumber, otherBinaryNumber) && !GreaterThan(binaryNumber, otherBinaryNumber);
        }
        bool NotEqual(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            return LessThan(binaryNumber, otherBinaryNumber) || GreaterThan(binaryNumber, otherBinaryNumber);
        }
        byte[] Addition(byte[] binaryNumber, byte[] otherBinaryNumber, byte baseNumber)
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
                int temp = binaryNumber[binaryNumber.Length - i - 1] + otherBinaryNumber[otherBinaryNumber.Length - i - 1] + hold;
                sum[i] = (byte)(temp % baseNumber);
                hold = (byte)(temp / baseNumber);
            }
            Array.Reverse(sum);
            sum = TrimZerosFromBeginning(sum);
            return sum;
        }
        byte[] Subtraction(byte[] binaryNumber, byte[] otherBinaryNumber, byte baseNumber)
        {
            otherBinaryNumber = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref otherBinaryNumber);
            byte[] difference = new byte[binaryNumber.Length + 1];
            otherBinaryNumber = Addition(Not(otherBinaryNumber, baseNumber), ConvertNumberFromDecimalToBinary(1, baseNumber), baseNumber);
            difference = Addition(binaryNumber, otherBinaryNumber, baseNumber);
            difference[0] = 0;
            return TrimZerosFromBeginning(difference);
        }
        byte[] Multiplication(byte[] binaryNumber, byte[] otherBinaryNumber, byte baseNumber)
        {
            byte[] result = { 0 };
            byte[] count = { 0 };
            while (LessThan(count, otherBinaryNumber) == true)
            {
                result = Addition(result, binaryNumber, baseNumber);
                count = Addition(count, new byte[] { 1 }, baseNumber);
            }
            return result;
        }
        byte[] Division(byte[] binaryNumber, byte[] otherBinaryNumber, byte baseNumber)
        {
            byte[] zero = { 0 };
            byte result = 0;
            while (GreaterThan(binaryNumber, zero))
            {
                binaryNumber = Subtraction(binaryNumber, otherBinaryNumber, baseNumber);
                result += 1;
            }
            return ConvertNumberFromDecimalToBinary(result, baseNumber);
        }
        byte[] TrimZerosFromBeginning(byte[] binary)
        {
            byte[] trimmedBinary = new byte[0];
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] > 0)
                {
                    Array.Resize(ref trimmedBinary, binary.Length - i);
                    for (int j = 0; j < trimmedBinary.Length; j++)
                    {
                        trimmedBinary[j] = binary[i + j];
                    }
                    break;
                }
            }
            return trimmedBinary;
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
