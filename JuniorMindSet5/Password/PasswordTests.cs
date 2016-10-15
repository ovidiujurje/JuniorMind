using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void GenerateRandomPasswordContainingLowerCaseLetters()
        {
            Assert.AreNotEqual("abcdefghij", GeneratePassword(10, 2, 3, 1));
        }
        string GeneratePassword(int passwordLength, int numberOfUpperCaseLetters, int numberOfDigits, int numberOfSymbols)
        {
            char[] lowerCaseLetters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] upperCaseLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] digits = { '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] symbols = { '`', '-', '=', '!', '@', '#', '$', '%', '^', '&', '*', '_', '+', ':', '?'};
            string password = string.Empty;
            char[] passwordCharacters = new char[passwordLength];
            int[] randomIndexes = new int[passwordLength];
            Random randomNumber = new Random();
            for (int i = 0; i < passwordLength - numberOfUpperCaseLetters - numberOfDigits - numberOfSymbols; i++)
            {
                passwordCharacters[i] = lowerCaseLetters[randomNumber.Next(lowerCaseLetters.Length)];
            }
            for (int i = passwordLength - numberOfUpperCaseLetters - numberOfDigits - numberOfSymbols; i < passwordLength - numberOfDigits - numberOfSymbols; i++)
            {
                passwordCharacters[i] = upperCaseLetters[randomNumber.Next(upperCaseLetters.Length)];
            }
            for (int i = passwordLength - numberOfDigits - numberOfSymbols; i < passwordLength - numberOfSymbols; i++)
            {
                passwordCharacters[i] = digits[randomNumber.Next(digits.Length)];
            }
            for (int i = passwordLength - numberOfSymbols; i < passwordLength; i++)
            {
                passwordCharacters[i] = symbols[randomNumber.Next(symbols.Length)];
            }
            for (int i = 0; i < passwordLength; i++)
            {
                int index = randomNumber.Next(1, passwordLength + 1);
                if (DoesItContain(randomIndexes, index))
                {
                    i -= 1;
                }
                else
                {
                    randomIndexes[i] = index;
                }
            }
            for (int i = 0; i < passwordLength; i++)
            {
                password += passwordCharacters[randomIndexes[i] - 1];
            }
            return password;
        }
        bool DoesItContain(int[] givenArray, int givenNumber)
        {
            foreach (int number in givenArray)
                if (number == givenNumber)
                    return true;
            return false;
        }
    }
}
