using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prefix
{
    [TestClass]
    public class PrefixTests
    {
        [TestMethod]
        public void ShortWord()
        {
            Assert.AreEqual("mag", GetPrefix("magenta", "magnific"));
        }
        [TestMethod]
        public void LongerWord()
        {
            Assert.AreEqual("abcdefgh", GetPrefix("abcdefghzhjb", "abcdefghweoriguweiogtu"));
        }
        string GetPrefix(string firstWord, string secondWord)
        {
            string prefix = string.Empty;
            for (int i = 1; i <= firstWord.Length && i <= secondWord.Length; i++)
            {
                if (firstWord.Substring(0, i) != secondWord.Substring(0, i))
                {
                    prefix += firstWord.Substring(0, i - 1);
                    break;
                }
            }
            return prefix;
        }
    }
}
