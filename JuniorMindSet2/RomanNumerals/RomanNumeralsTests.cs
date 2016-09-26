using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumerals
{
    [TestClass]
    public class RomanNumeralsTests
    {
        [TestMethod]
        public void ConvertFourtyFiveToRoman()
        {
            Assert.AreEqual("XLV", ConvertNumberToRomanNumeral(45));
        }
        string ConvertNumberToRomanNumeral(int number)
        {
            string romanNumeral = string.Empty;
            if (number == 100)
            {
                romanNumeral += "C";
                number -= 100;
            }
            if (number >= 90)
            {
                romanNumeral += "XC";
                number -= 90;
            }
            if (number >= 50)
            {
                romanNumeral += "L";
                number -= 50;
            }
            if (number >= 40)
            {
                romanNumeral += "XL";
                number -= 40;
            }
            if (number >= 10)
            {
                romanNumeral += "X";
                number -= 10;
            }
            if (number >= 9)
            {
                romanNumeral += "IX";
                number -= 9;
            }
            if (number >= 5)
            {
                romanNumeral += "V";
                number -= 5;
            }
            if (number >= 4)
            {
                romanNumeral += "IV";
                number -= 4;
            }
            if (number >= 1)
            {
                romanNumeral += "I";
                number -= 1;
            }
            return romanNumeral;
        }
    }
}
