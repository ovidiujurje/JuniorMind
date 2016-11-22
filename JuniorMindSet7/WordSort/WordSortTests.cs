using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace WordSort
{
    [TestClass]
    public class WordSortTests
    {
        [TestMethod]
        public void SortWordsAscendingByTheNumberOfAppearence()
        {
            CollectionAssert.AreEqual(new string[] { "one", "two", "two", "three", "three", "three" }, SortWordsByNumberOfAppearences("three two three two three one"));
        }
        string[] SortWordsByNumberOfAppearences(string text)
        {
            var textArray = text.Split(' ');
            int count = 0;
            var grouped = textArray.GroupBy(t => t).OrderBy(g => g.Count());
            foreach (var group in grouped)
                foreach (var el in group)
                {
                    textArray[count] = el;
                    count++;
                }
            return textArray;
        }
    }
}
