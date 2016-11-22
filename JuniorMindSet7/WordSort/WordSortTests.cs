using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace WordSort
{
    [TestClass]
    public class WordSortTests
    {
        [TestMethod]
        public void SortWordsAscendingByTheNumberOfAppearence()
        {
            CollectionAssert.AreEqual(new string[] { "one", "two", "three" }, SortWordsByNumberOfAppearences("three two three two three one").ToArray());
        }
        IEnumerable<string> SortWordsByNumberOfAppearences(string text)
        {
            return text.Split(' ').GroupBy(t => t).OrderBy(g => g.Count()).Select(gr => gr.First());
        }
    }
}
