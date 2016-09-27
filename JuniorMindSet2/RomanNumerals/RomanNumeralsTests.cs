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
            string[] romanNr = { "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] arabicNr = { 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string romanNumeral = string.Empty;
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 0);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 1);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 2);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 3);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 4);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 4);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 4);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 5);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 6);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 7);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 8);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 8);
            AddRomanSubtractFromNumber(ref number, romanNr, arabicNr, ref romanNumeral, 8);
            return romanNumeral;
        }

        private static void AddRomanSubtractFromNumber(ref int number, string[] romanNr, int[] arabicNr, ref string romanNumeral, int i)
        {
            if (number >= arabicNr[i])
            {
                romanNumeral += romanNr[i];
                number -= arabicNr[i];
            }
        }
    }
}
