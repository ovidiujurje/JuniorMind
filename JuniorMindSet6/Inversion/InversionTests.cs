using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inversion
{
    [TestClass]
    public class InversionTests
    {
        [TestMethod]
        public void InvertString()
        {
            Assert.AreEqual("dcba", InvertString("abcd"));
        }
        string InvertString(string givenString)
        {
            if (givenString.Length == 0) return givenString;
            return givenString[givenString.Length - 1] + InvertString(RemoveLastCharacterFromString(givenString));
        }
        string RemoveLastCharacterFromString(string theString)
        {
            string newString = string.Empty;
            for (int i = 0; i < theString.Length - 1; i++)
                newString += theString[i];
            return newString;
        }
    }
}
