using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcelColumns
{
    [TestClass]
    public class ExcelColumns
    {
        [TestMethod]
        public void OneLetter()
        {
            Assert.AreEqual("C", GetColumnCharacterCombination(3));
        }
        [TestMethod]
        public void TwoLetter()
        {
            Assert.AreEqual("CV", GetColumnCharacterCombination(100));
        }
        [TestMethod]
        public void ThreeLetter()
        {
            Assert.AreEqual("AFT", GetColumnCharacterCombination(852));
        }
        string GetColumnCharacterCombination(int columnNumber)
        {
            string columnLetters = string.Empty;
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int i = 0;
            while (columnNumber > 0)
            {
                i = (columnNumber - 1) % 26;
                columnLetters = alphabet[i] + columnLetters;
                columnNumber = ((columnNumber - i) / 26);
            }
            return columnLetters;
        }
    }
}
