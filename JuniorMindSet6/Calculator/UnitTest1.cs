using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("10", CalculateWithPrefixedOperations(new string[] { "+", "*", "2", "3", "-", "10", "6" }));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("30", CalculateWithPrefixedOperations(new string[] { "+", "/", "*", "+", "55", "45", "2", "8", "-", "8", "3" }));
        }
        string CalculateWithPrefixedOperations(string[] operation)
        {
            for (int i = 0; i < operation.Length; i++)
            {
                double result = 0;
                switch (operation[operation.Length - i - 1])
                {
                    case "+":
                        result = double.Parse(operation[operation.Length - i]) + double.Parse(operation[operation.Length - i + 1]);
                        ReplaceOperationWithResult(ref operation, result, i);
                        i = 0;
                        break;
                    case "-":
                        result = double.Parse(operation[operation.Length - i]) - double.Parse(operation[operation.Length - i + 1]);
                        ReplaceOperationWithResult(ref operation, result, i);
                        i = 0;
                        break;
                    case "*":
                        result = double.Parse(operation[operation.Length - i]) * double.Parse(operation[operation.Length - i + 1]);
                        ReplaceOperationWithResult(ref operation, result, i);
                        i = 0;
                        break;
                    case "/":
                        result = double.Parse(operation[operation.Length - i]) / double.Parse(operation[operation.Length - i + 1]);
                        ReplaceOperationWithResult(ref operation, result, i);
                        i = 0;
                        break;
                }
            }
            return operation[0];
        }
        void ReplaceOperationWithResult(ref string[] operation, double result, int i)
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
    }
}
