using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumerals
{
    [TestClass]
    public class RomanNumeralsTests
    {
        [TestMethod]
        public void ConverteToRomanTwo()
        {
            Assert.AreEqual("II", ConvertNumberToRomanNumeral(2));
        }
        [TestMethod]
        public void ConvertToRomanSeven()
        {
            Assert.AreEqual("VII", ConvertNumberToRomanNumeral(7));
        }
        [TestMethod]
        public void ConverToRomanTwentyEight()
        {
            Assert.AreEqual("XXVIII", ConvertNumberToRomanNumeral(28));
        }
        [TestMethod]
        public void ConvertToRomanSeventySix()
        {
            Assert.AreEqual("LXXVI", ConvertNumberToRomanNumeral(76));
        }
        [TestMethod]
        public void ConvertToRomanOneHundred()
        {
            Assert.AreEqual("C", ConvertNumberToRomanNumeral(100));
        }
        string ConvertNumberToRomanNumeral(int number)
        {
            string romanNumeral = string.Empty;
            string[] thousands = { "", "M", "MM", "MMM" };
            string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            romanNumeral += thousands[(int)(number / 1000) % 10];
            romanNumeral += hundreds[(int)(number / 100) % 10];
            romanNumeral += tens[(int)(number / 10) % 10];
            romanNumeral += ones[number % 10];
            return romanNumeral;
        }
    }
}
