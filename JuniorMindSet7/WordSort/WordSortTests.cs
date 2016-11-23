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
            CollectionAssert.AreEqual(
                new Group[] { new Group("one", 1), new Group("two", 2), new Group("three", 3) }, 
                SortWordsByNumberOfAppearences("three two three two three one").ToArray()
                );
        }

        public struct Group
        {
            private string word;
            private int instances;

            public Group(string word, int instances)
            {
                this.word = word;
                this.instances = instances;
            }
        }

        IEnumerable<Group> SortWordsByNumberOfAppearences(string text)
        {
            return text.Split(' ').GroupBy(word => word)
                .OrderBy(instance => instance.Count())
                .Select(wordGroup => new Group(wordGroup.First(), wordGroup.Count()));
        }
    }
}
