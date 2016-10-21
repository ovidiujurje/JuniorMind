using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void ShouldCalculateOperation1()
        {
            Assert.AreEqual(10, CalculateWithPrefixedOperations("+ * 2 3 - 10 6"));
        }
        [TestMethod]
        public void ShouldCalculateOperation2()
        {
            Assert.AreEqual(30, CalculateWithPrefixedOperations("+ / * + 55 45 2 8 - 8 3"));
        }
        [TestMethod]
        public void ShouldConvertStringToStringArray()
        {
            CollectionAssert.AreEqual(new string[] { "+", "*", "2", "3", "-", "10", "6" }, ConvertStringToStringArray("+ * 2 3 - 10 6"));
        }
        double CalculateWithPrefixedOperations(string operationString)
        {
            string[] operation = ConvertStringToStringArray(operationString);
            for (int i = 0; i < operation.Length; i++)
            {
                double result = 0;
                switch (operation[operation.Length - i - 1])
                {
                    case "+":
                        result = double.Parse(operation[operation.Length - i]) + double.Parse(operation[operation.Length - i + 1]);
                        ReplaceOperationWithItsResult(ref operation, result, i);
                        i = 0;
                        break;
                    case "-":
                        result = double.Parse(operation[operation.Length - i]) - double.Parse(operation[operation.Length - i + 1]);
                        ReplaceOperationWithItsResult(ref operation, result, i);
                        i = 0;
                        break;
                    case "*":
                        result = double.Parse(operation[operation.Length - i]) * double.Parse(operation[operation.Length - i + 1]);
                        ReplaceOperationWithItsResult(ref operation, result, i);
                        i = 0;
                        break;
                    case "/":
                        result = double.Parse(operation[operation.Length - i]) / double.Parse(operation[operation.Length - i + 1]);
                        ReplaceOperationWithItsResult(ref operation, result, i);
                        i = 0;
                        break;
                }
            }
            return double.Parse(operation[0]);
        }
        void ReplaceOperationWithItsResult(ref string[] operation, double result, int i)
        {
            string[] newOperation = operation;
            Array.Resize(ref newOperation, newOperation.Length - 2);
            newOperation[operation.Length - i - 1] = Convert.ToString(result);
            for (int j = 0; j < operation.Length - i - 1; j++)
            {
                newOperation[j] = operation[j];
            }
            for (int j = operation.Length - i + 2; j < operation.Length; j++)
            {
                newOperation[j - (operation.Length - newOperation.Length)] = operation[j];
            }
            operation = newOperation;
        }
        string[] ConvertStringToStringArray(string theString)
        {
            string[] stringArray = new string[0];
            int position = 0;
            int lastSpace = -1;
            for (int i = 0; i < theString.Length; i++)
            {
                if (i == theString.Length - 1)
                {
                    Array.Resize(ref stringArray,stringArray.Length + 1);
                    stringArray[position] = Substring(theString, lastSpace + 1, i);
                }
                if (theString[i] == ' ')
                {
                    Array.Resize(ref stringArray, stringArray.Length + 1);
                    stringArray[position] = Substring(theString, lastSpace + 1, i - 1);
                    position++;
                    lastSpace = i;
                }
            }
            return stringArray;
        }
        string Substring(string theString, int startPosition, int endPosition)
        {
            string newString = string.Empty;
            for (int i = startPosition; i <= endPosition; i++)
                newString += theString[i];
            return newString;
        }
    }
}
