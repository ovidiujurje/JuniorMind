using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Replacement
{
    [TestClass]
    public class ReplacementTests
    {
        [TestMethod]
        public void ReplaceCharacterWithString()
        {
            Assert.AreEqual("AreplacementBreplacementC", ReplaceCharacetrWithString("AxBxC", 'x', "replacement"));
        }
        string ReplaceCharacetrWithString(string givenString, char givenCharacter, string characterRepalcement)
        {
            for (int i = 0; i < givenString.Length; i++)
            {
                if (givenString[i] == givenCharacter)
                {
                    givenString = Substring(givenString, 0, i - 1) + characterRepalcement + Substring(givenString, i + 1, givenString.Length - 1);
                    i += characterRepalcement.Length - 1;
                }
            }

            return givenString;
        }
        string Substring(string theString, int startPosition, int endPosition)
        {
            string newString = string.Empty;
            for (int i = startPosition; i <= endPosition; i++)
                newString += theString[i];
            return newString;
        }
    }
}
