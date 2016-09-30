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
            Assert.AreEqual(true, DetermineIfPhraseIsPanagram("The quick brown fox jumps over the lazy dog"));
        }
        [TestMethod]
        public void CheckNonPanagram()
        {
            Assert.AreEqual(false, DetermineIfPhraseIsPanagram("Anna has apples"));
        }
        bool DetermineIfPhraseIsPanagram(string phrase)
        {
            bool isItAPanagram = true;
            for (char i = 'a'; i <= 'z'; i++)
            {
                int positionOfLetterInWord = phrase.IndexOf(i);
                if (positionOfLetterInWord == -1)
                {
                    isItAPanagram = false;
                    break;
                }
            }
            return isItAPanagram;
        }
    }
}
