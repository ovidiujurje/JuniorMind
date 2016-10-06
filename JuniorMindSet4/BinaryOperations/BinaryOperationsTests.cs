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
        public void ImplementGreaterThan1()
        {
            Assert.AreEqual(false, GreaterThan(new byte[] { 1, 1, 0, 0, 0, 0 }, new byte[] { 1, 1, 0, 0, 0, 1 }));
        }
        [TestMethod]
        public void ImplementGreaterThan2()
        {
            Assert.AreEqual(true, GreaterThan(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 1 }));
        }
        [TestMethod]
        public void ImplementEqual1()
        {
            Assert.AreEqual(true, Equal(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 1, 0, 0, 0, 1 }));
        }
        [TestMethod]
        public void ImplementEqual2()
        {
            Assert.AreEqual(false, Equal(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 1, 0, 0, 0, 0 }));
        }
        [TestMethod]
        public void ImplementNotEqual1()
        {
            Assert.AreEqual(false, NotEqual(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 1, 0, 0, 0, 1 }));
        }
        [TestMethod]
        public void ImplementNotEqual2()
        {
            Assert.AreEqual(true, NotEqual(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 1, 0, 0, 0, 0 }));
        }
        [TestMethod]
        public void ImplementAddition()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0, 1, 1 }, Addition(new byte[] { 1, 1, 0, 0 }, new byte[] { 1, 1, 1 }, 2));
        }
        [TestMethod]
        public void ImplementAdditionBaseThree()
        {
            CollectionAssert.AreEqual(new byte[] { 2, 0, 1 }, Addition(new byte[] { 1, 1, 0 }, new byte[] { 2, 1 }, 3));
        }
        [TestMethod]
        public void ImplementAdditionBaseFour()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 2 }, Addition(new byte[] { 1, 0, 0, 2 }, new byte[] { 2, 3, 0 }, 4));
        }
        [TestMethod]
        public void ImplementSubtraction1()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0 }, Subtraction(new byte[] { 1, 0, 1 }, new byte[] { 1, 1 }, 2));
        }
        [TestMethod]
        public void ImplementSubtraction2()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1, 1, 1, 0 }, Subtraction(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 1 }, 2));
        }
        [TestMethod]
        public void ImplementSubtractionBaseThree()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0 }, Subtraction(new byte[] { 2, 0, 1 }, new byte[] { 2, 1 }, 3));
        }
        [TestMethod]
        public void ImplementSubtractionBaseFour()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 2 }, Subtraction(new byte[] { 1, 0, 0, 2 }, new byte[] { 2, 3, 0 }, 4));
        }
        [TestMethod]
        public void ImplementMultiplication1()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0, 0, 1, 1 }, Multiplication(new byte[] { 0, 1, 1, 1 }, new byte[] { 1, 0, 1 }, 2));
        }
        [TestMethod]
        public void ImplementMultiplication2()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 1 }, Multiplication(new byte[] { 1, 0, 1 }, new byte[] { 1, 1 }, 2));
        }
        [TestMethod]
        public void ImplementMultiplicationBaseThree()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1, 0 }, Multiplication(new byte[] { 2, 0 }, new byte[] { 1, 2 }, 3));
        }
        [TestMethod]
        public void ImplementMultiplicationBaseFour()
        {
            CollectionAssert.AreEqual(new byte[] { 3, 1, 3 }, Multiplication(new byte[] { 2, 3 }, new byte[] { 1, 1 }, 4));
        }
        [TestMethod]
        public void ImplementDivision1()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0 }, Division(new byte[] { 1, 1, 0 }, new byte[] { 1, 1 }, 2));
        }
        [TestMethod]
        public void ImplementDivision2()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1, 1 }, Division(new byte[] { 1, 0, 0, 0, 0, 1 }, new byte[] { 1, 1 }, 2));
        }
        [TestMethod]
        public void ImplementDivisionBaseThree1()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1 }, Division(new byte[] { 2, 0, 2 }, new byte[] { 1, 2 }, 3));
        }
        [TestMethod]
        public void ImplementDivisionBaseThree2()
        {
            CollectionAssert.AreEqual(new byte[] { 2, 0 }, Division(new byte[] { 1, 1, 2, 0 }, new byte[] { 2, 1 }, 3));
        }
        [TestMethod]
        public void ImplementDivisionBaseFour()
        {
            CollectionAssert.AreEqual(new byte[] { 3 }, Division(new byte[] { 1, 0, 0, 2 }, new byte[] { 1, 1, 2 }, 4));
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
        bool LessThan(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            if (binaryNumber.Length < otherBinaryNumber.Length)
                return true;
            if (binaryNumber.Length > otherBinaryNumber.Length)
                return false;
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] < otherBinaryNumber[i])
                    return true;
                if (binaryNumber[i] > otherBinaryNumber[i])
                    return false;
            }
            return false;
        }
        bool GreaterThan(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            if (binaryNumber.Length > otherBinaryNumber.Length)
                return true;
            if (binaryNumber.Length < otherBinaryNumber.Length)
                return false;
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] > otherBinaryNumber[i])
                    return true;
                if (binaryNumber[i] < otherBinaryNumber[i])
                    return false;
            }
            return false;
        }
        bool Equal(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            if (binaryNumber.Length != otherBinaryNumber.Length)
                return false;
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] != otherBinaryNumber[i])
                    return false;
            }
            return true;
        }
        bool NotEqual(byte[] binaryNumber, byte[] otherBinaryNumber)
        {
            if (binaryNumber.Length != otherBinaryNumber.Length)
                return true;
            if (Equal(binaryNumber, otherBinaryNumber) == false)
                return true;
            return false;
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
                sum[i] = (byte)((binaryNumber[binaryNumber.Length - i - 1] + otherBinaryNumber[otherBinaryNumber.Length - i - 1] + hold) % baseNumber);
                hold = (byte)((binaryNumber[binaryNumber.Length - i - 1] + otherBinaryNumber[otherBinaryNumber.Length - i - 1] + hold) / baseNumber);
            }
            Array.Reverse(sum);
            sum = TrimZerosFromBeginning(sum);
            return sum;
        }
        byte[] Subtraction(byte[] binaryNumber, byte[] otherBinaryNumber, byte baseNumber)
        {
            otherBinaryNumber = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref otherBinaryNumber);
            byte[] difference = new byte[binaryNumber.Length];
            byte[] binaryNumberClone = binaryNumber;
            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                if (binaryNumber[i] < otherBinaryNumber[i])
                {
                    binaryNumber[i] += baseNumber;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (binaryNumber[j] != 0)
                        {
                            binaryNumber[j] -= 1;
                            break;
                        }
                        binaryNumber[j] += (byte)(baseNumber - 1);
                    }
                }
                difference[i] = (byte)(binaryNumber[i] - otherBinaryNumber[i]);
            }
            difference = TrimZerosFromBeginning(difference);
            return difference;
        }
        byte[] Multiplication(byte[] binaryNumber, byte[] otherBinaryNumber, byte baseNumber)
        {
            byte[] result = new byte[binaryNumber.Length + otherBinaryNumber.Length + baseNumber - 1];
            binaryNumber = GeenrateBinaryOfSameLengthforOtherNumber(ref result, ref binaryNumber);
            byte[] tempBinaryNumber = new byte[binaryNumber.Length];
            for (int i = otherBinaryNumber.Length - 1; i >= 0; i--)
            {
                byte hold = 0;
                for (int j = tempBinaryNumber.Length - 1; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        binaryNumber[j] = hold;
                        break;
                    }
                    byte[] convertedProduce = ConvertNumberFromDecimalToBinary((byte)(binaryNumber[j] * otherBinaryNumber[i] + hold), baseNumber);
                    hold = 0;
                    tempBinaryNumber[j] = convertedProduce[convertedProduce.Length - 1];
                    for (int k = 0; k < convertedProduce.Length; k++)
                    {
                        if (k == convertedProduce.Length)
                            break;
                        hold += (byte)(convertedProduce[k] * Math.Pow(10, convertedProduce.Length - k - 2));
                    }
                }
                result = Addition(result, tempBinaryNumber, baseNumber);
                result = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref result);
                binaryNumber = ShiftLeft(binaryNumber, 1);
                Array.Clear(tempBinaryNumber, 0, tempBinaryNumber.Length);
            }
            result = TrimZerosFromBeginning(result);
            return result;
        }
        byte[] Division(byte[] binaryNumber, byte[] otherBinaryNumber, byte baseNumber)
        {
            byte[] zero = { 0 };
            byte[] quotient = { 0 };
            zero = GeenrateBinaryOfSameLengthforOtherNumber(ref binaryNumber, ref zero);
            while (otherBinaryNumber != zero)
            {
                if (LessThan(binaryNumber, otherBinaryNumber) == true)
                    break;
                binaryNumber = Subtraction(binaryNumber, otherBinaryNumber, baseNumber);
                quotient = Addition(quotient, new byte[] { 1 }, baseNumber);
            }
            quotient = TrimZerosFromBeginning(quotient);
            return quotient;
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
