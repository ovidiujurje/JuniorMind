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
            char[] romanNr = { 'C', 'L', 'X', 'V', 'I' };
            string romanNumeral = string.Empty;
            OneHundred(ref number, romanNr, ref romanNumeral);
            NinetyOrGreater(ref number, romanNr, ref romanNumeral);
            FiftyOrGreater(ref number, romanNr, ref romanNumeral);
            FourtyOrGreater(ref number, romanNr, ref romanNumeral);
            TenOrGreater(ref number, romanNr, ref romanNumeral);
            NineOrGreater(ref number, romanNr, ref romanNumeral);
            FiveOrGreater(ref number, romanNr, ref romanNumeral);
            FourOrGreater(ref number, romanNr, ref romanNumeral);
            OneOrGreater(ref number, romanNr, ref romanNumeral);
            return romanNumeral;
        }

        private static void OneOrGreater(ref int number, char[] romanNr, ref string romanNumeral)
        {
            if (number >= 1)
            {
                romanNumeral += romanNr[4];
                number -= 1;
            }
        }

        private static void FourOrGreater(ref int number, char[] romanNr, ref string romanNumeral)
        {
            if (number >= 4)
            {
                romanNumeral += romanNr[4];
                romanNumeral += romanNr[3];
                number -= 4;
            }
        }

        private static void FiveOrGreater(ref int number, char[] romanNr, ref string romanNumeral)
        {
            if (number >= 5)
            {
                romanNumeral += romanNr[3];
                number -= 5;
            }
        }

        private static void NineOrGreater(ref int number, char[] romanNr, ref string romanNumeral)
        {
            if (number >= 9)
            {
                romanNumeral += romanNr[4];
                romanNumeral += romanNr[2];
                number -= 9;
            }
        }

        private static void TenOrGreater(ref int number, char[] romanNr, ref string romanNumeral)
        {
            if (number >= 10)
            {
                romanNumeral += romanNr[2];
                number -= 10;
            }
        }

        private static void FourtyOrGreater(ref int number, char[] romanNr, ref string romanNumeral)
        {
            if (number >= 40)
            {
                romanNumeral += romanNr[2];
                romanNumeral += romanNr[1];
                number -= 40;
            }
        }

        private static void FiftyOrGreater(ref int number, char[] romanNr, ref string romanNumeral)
        {
            if (number >= 50)
            {
                romanNumeral += romanNr[1];
                number -= 50;
            }
        }

        private static void NinetyOrGreater(ref int number, char[] romanNr, ref string romanNumeral)
        {
            if (number >= 90)
            {
                romanNumeral += romanNr[2];
                romanNumeral += romanNr[0];
                number -= 90;
            }
        }

        private static void OneHundred(ref int number, char[] romanNr, ref string romanNumeral)
        {
            if (number == 100)
            {
                romanNumeral += romanNr[0];
                number -= 100;
            }
        }
    }
}
