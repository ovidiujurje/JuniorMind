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
            Assert.AreNotEqual("abcde", GeneratePassword(5, 2));
        }
        string GeneratePassword(int passwordLength, int numberOfUpperCaseLetters)
        {
            char[] lowerCaseLetters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] upperCaseLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string password = string.Empty;
            char[] passwordCharacters = new char[passwordLength];
            char[] passwordRandomizedCharacters = new char[passwordLength];
            int[] randomIndexes = new int[passwordLength];
            Random randomNumber = new Random();
            for (int i = 0; i < passwordLength - numberOfUpperCaseLetters; i++)
            {
                passwordCharacters[i] = lowerCaseLetters[randomNumber.Next(25)];
            }
            for (int i = passwordLength - numberOfUpperCaseLetters; i < passwordLength; i++)
            {
                passwordCharacters[i] = upperCaseLetters[randomNumber.Next(25)];
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
