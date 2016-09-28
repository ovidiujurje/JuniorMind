using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PanagramTests
    {
        [TestMethod]
        public void CheckPanagram()
        {
            Assert.AreEqual("The phrase is a panagram", DetermineIfPhraseIsPanagram("The quick brown fox jumps over the lazy dog"));
        }
        [TestMethod]
        public void CheckNonPanagram()
        {
            Assert.AreEqual("The phrase is not a panagram", DetermineIfPhraseIsPanagram("Anna has apples"));
        }
        string DetermineIfPhraseIsPanagram(string phrase)
        {
            bool notAPanagram = false;
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            foreach (char letter in alphabet)
            {
                int este = phrase.IndexOf(letter);
                if (este == -1)
                {
                    notAPanagram = true;
                    break;
                }
            }
            return notAPanagram == false ? "The phrase is a panagram" : "The phrase is not a panagram";
        }
    }
}
