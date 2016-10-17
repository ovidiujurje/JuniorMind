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
            string password = GeneratePassword(10, 2, 3, 1);
            char[] exceptions = { 'l', 'I', 'o', 'O' };
            char[] symbols = { '`', '-', '=', '!', '@', '#', '$', '%', '^', '&', '*', '_', '+', ':', '?' };
            int countLower = 0;
            int countUpper = 0;
            int countDigits = 0;
            int countSymbols = 0;
            int countExceptions = 0;
            foreach (char character in password)
            {
                if ((int)(character) >= 97 && (int)(character) <= 122)
                    countLower++;
                if ((int)(character) >= 65 && (int)(character) <= 90)
                    countUpper++;
                if ((int)(character) >= 50 && (int)(character) <= 57)
                    countDigits++;
                foreach (char symbol in symbols)
                    if (character == symbol)
                        countSymbols++;
                foreach (char exception in exceptions)
                    if (character == exception)
                        countExceptions++;
            }
            Assert.AreEqual(4, countLower);
            Assert.AreEqual(2, countUpper);
            Assert.AreEqual(3, countDigits);
            Assert.AreEqual(1, countSymbols);
            Assert.AreEqual(0, countExceptions);
        }
        string GeneratePassword(int passwordLength, int numberOfUpperCaseLetters, int numberOfDigits, int numberOfSymbols)
        {
            char[] exceptions = { 'l', 'I', 'o', 'O' };
            char[] symbols = { '`', '-', '=', '!', '@', '#', '$', '%', '^', '&', '*', '_', '+', ':', '?'};
            string password = string.Empty;
            char[] passwordCharacters = new char[passwordLength];
            int[] randomIndexes = new int[passwordLength];
            Random randomNumber = new Random();
            int[] characterCountArray = { passwordLength, numberOfSymbols, numberOfDigits, numberOfUpperCaseLetters };
            for (int i = 0; i < passwordLength; i++)
            {
                if (i < GetLimit(characterCountArray, 1))
                    passwordCharacters[i] = (char)(randomNumber.Next(97, 123));
                if (i >= GetLimit(characterCountArray, 1) && i < GetLimit(characterCountArray, 2))
                    passwordCharacters[i] = (char)(randomNumber.Next(65, 91));
                if (i >= GetLimit(characterCountArray, 2) && i < GetLimit(characterCountArray, 3))
                    passwordCharacters[i] = (char)(randomNumber.Next(50, 58));
                if (i >= GetLimit(characterCountArray, 3))
                    passwordCharacters[i] = symbols[randomNumber.Next(symbols.Length)];
                foreach (char exception in exceptions)
                    if (passwordCharacters[i] == exception)
                        passwordCharacters[i] = (char)(passwordCharacters[i] + 1);
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
        int GetLimit(int[] array, int number)
        {
            int limit = array[0];
            for (int i = 1; i <= 4 - number; i++)
            {
                limit -= array[i];
            }
            return limit;
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
