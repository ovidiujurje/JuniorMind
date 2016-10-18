using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void CountCharactersOfEachType()
        {
            int lower;
            int upper;
            int digits;
            int symbols;
            int exceptions;
            CountEachTypeOfCharacter("aTj67$l0Q<", out lower, out upper, out digits, out symbols, out exceptions);
            Assert.AreEqual(3, lower);
            Assert.AreEqual(2, upper);
            Assert.AreEqual(3, digits);
            Assert.AreEqual(2, symbols);
            Assert.AreEqual(3, exceptions);
        }
        [TestMethod]
        public void GenerateRandomPasswordWithAllOptionsActivated()
        {
            CharacterType selectedOptions = CharacterType.UpperCase | CharacterType.Digits;
            selectedOptions = selectedOptions | CharacterType.Symbols;
            selectedOptions = selectedOptions | CharacterType.excludeSimilar;
            selectedOptions = selectedOptions | CharacterType.excludeAmbiguous;
            int lower;
            int upper;
            int digits;
            int symbols;
            int exceptions;
            CountEachTypeOfCharacter(GeneratePassword(10, selectedOptions, 2, 3, 1), out lower, out upper, out digits, out symbols, out exceptions);
            Assert.AreEqual(4, lower);
            Assert.AreEqual(2, upper);
            Assert.AreEqual(3, digits);
            Assert.AreEqual(1, symbols);
            Assert.AreEqual(0, exceptions);
        }
        [TestMethod]
        public void GenerateRandomPasswordWithAllOptionsActivatedExceptSymbols()
        {
            CharacterType selectedOptions = CharacterType.UpperCase | CharacterType.Digits;
            selectedOptions = selectedOptions | CharacterType.excludeSimilar;
            selectedOptions = selectedOptions | CharacterType.excludeAmbiguous;
            int lower;
            int upper;
            int digits;
            int symbols;
            int exceptions;
            CountEachTypeOfCharacter(GeneratePassword(10, selectedOptions, 2, 3, 1), out lower, out upper, out digits, out symbols, out exceptions);
            Assert.AreEqual(5, lower);
            Assert.AreEqual(2, upper);
            Assert.AreEqual(3, digits);
            Assert.AreEqual(0, symbols);
            Assert.AreEqual(0, exceptions);
        }
        [TestMethod]
        public void GenerateRandomPasswordWithAllOptionsActivatedExceptDigits()
        {
            CharacterType selectedOptions = CharacterType.UpperCase | CharacterType.Symbols;
            selectedOptions = selectedOptions | CharacterType.excludeSimilar;
            selectedOptions = selectedOptions | CharacterType.excludeAmbiguous;
            int lower;
            int upper;
            int digits;
            int symbols;
            int exceptions;
            CountEachTypeOfCharacter(GeneratePassword(10, selectedOptions, 2, 3, 1), out lower, out upper, out digits, out symbols, out exceptions);
            Assert.AreEqual(7, lower);
            Assert.AreEqual(2, upper);
            Assert.AreEqual(0, digits);
            Assert.AreEqual(1, symbols);
            Assert.AreEqual(0, exceptions);
        }
        [Flags]
        public enum CharacterType
        {
            None = 0x0,
            UpperCase = 0x21,
            Digits = 0x2,
            Symbols = 0x4,
            excludeSimilar = 0x8,
            excludeAmbiguous = 0x10

        }
        string GeneratePassword(int passwordLength, CharacterType options, int numberOfUpperCaseLetters, int numberOfDigits, int numberOfSymbols)
        {
            char[] exceptionsSimilar = { 'l', 'I', 'o', 'O', '0', '1' };
            char[] exceptionsAmbiguous = { '~', '(', ')', '{', '}', '[', ']', ';', '|', '<', '>' };
            char[] nonExceptionsAmbiguous = { '`', '-', '=', '!', '@', '#', '$', '%', '^', '&', '*', '_', '+', ':', '?' };
            string password = string.Empty;
            char[] passwordCharacters = new char[passwordLength];
            Random randomNumber = new Random();
            for (int i = 0; i < passwordLength; i++)
            {
                    passwordCharacters[i] = (char)(randomNumber.Next('a', 'z' + 1));
            }
            if ((options & CharacterType.UpperCase) == CharacterType.UpperCase)
                passwordCharacters = IncludeCharacters(passwordCharacters, numberOfUpperCaseLetters, CharacterType.UpperCase);
            if ((options & CharacterType.Digits) == CharacterType.Digits)
                passwordCharacters = IncludeCharacters(passwordCharacters, numberOfDigits, CharacterType.Digits);
            if ((options & CharacterType.Symbols) == CharacterType.Symbols)
                passwordCharacters = IncludeCharacters(passwordCharacters, numberOfSymbols, CharacterType.Symbols);
            if ((options & CharacterType.excludeSimilar) == CharacterType.excludeSimilar)
                for (int i = 0; i < passwordLength; i++)
                {
                    foreach (char exception in exceptionsSimilar)
                        if (passwordCharacters[i] == exception)
                            passwordCharacters[i] = (char)(passwordCharacters[i] + randomNumber.Next(9));
                }
            if ((options & CharacterType.excludeAmbiguous) == CharacterType.excludeAmbiguous)
                for (int i = 0; i < passwordLength; i++)
                {
                    foreach (char exception in exceptionsAmbiguous)
                        if (passwordCharacters[i] == exception)
                            passwordCharacters[i] = nonExceptionsAmbiguous[randomNumber.Next(nonExceptionsAmbiguous.Length)];
                }
            foreach (char character in passwordCharacters)
                password += character;
            return password;
        }
        char[] IncludeCharacters(char[] passwordCharacters, int numberOfCharacters, CharacterType characterType)
        {
            Random randomNumber = new Random();
            int i = 0;
            while (i < numberOfCharacters)
            {
                char[] symbols = { '`', '-', '=', '!', '@', '#', '$', '%', '^', '&', '*', '_', '+', ':', '?', '~', '(', ')', '{', '}', '[', ']', ';', '|', '<', '>' };
                int randomPosition = randomNumber.Next(passwordCharacters.Length);
                if (passwordCharacters[randomPosition] >= 'a' && passwordCharacters[randomPosition] <= 'z')
                {
                    switch (characterType)
                    {
                        case CharacterType.UpperCase:
                            passwordCharacters[randomPosition] = (char)(randomNumber.Next('A', 'Z' + 1));
                            break;
                        case CharacterType.Digits:
                            passwordCharacters[randomPosition] = (char)(randomNumber.Next('0', '9' + 1));
                            break;
                        case CharacterType.Symbols:
                            passwordCharacters[randomPosition] = symbols[randomNumber.Next(symbols.Length)];
                            break;
                    }
                    i++;
                }
            }
            return passwordCharacters;
        }
        void CountEachTypeOfCharacter(string password, out int countLower, out int countUpper, out int countDigits, out int countSymbols, out int countExceptions)
        {
            char[] exceptions = { 'l', 'I', 'o', 'O', '0', '1', '~', '(', ')', '{', '}', '[', ']', ';', '|', '<', '>' };
            char[] symbols = { '`', '-', '=', '!', '@', '#', '$', '%', '^', '&', '*', '_', '+', ':', '?', '~', '(', ')', '{', '}', '[', ']', ';', '|', '<', '>' };
            countLower = 0;
            countUpper = 0;
            countDigits = 0;
            countSymbols = 0;
            countExceptions = 0;
            foreach (char character in password)
            {
                if ((int)(character) >= 'a' && (int)(character) <= 'z')
                    countLower++;
                if ((int)(character) >= 'A' && (int)(character) <= 'Z')
                    countUpper++;
                if ((int)(character) >= '0' && (int)(character) <= '9')
                    countDigits++;
                foreach (char symbol in symbols)
                    if (character == symbol)
                        countSymbols++;
                foreach (char exception in exceptions)
                    if (character == exception)
                        countExceptions++;
            }
        }
    }
}
