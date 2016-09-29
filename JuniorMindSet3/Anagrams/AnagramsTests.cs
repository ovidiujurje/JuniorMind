using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
    [TestClass]
    public class AnagramsTests
    {
        [TestMethod]
        public void CountAnagrams1()
        {
            Assert.AreEqual(3, NumberOfAnagrams("abb"));
        }
        [TestMethod]
        public void CountAnagrams2()
        {
            Assert.AreEqual(4, NumberOfAnagrams("abbb"));
        }
        [TestMethod]
        public void CountAnagrams3()
        {
            Assert.AreEqual(6, NumberOfAnagrams("aabb"));
        }

        int NumberOfAnagrams(string word)
        {
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int[] counter = new int[26];
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == alphabet[word[i] - 'a'])
                    counter[word[i] - 'a'] = counter[word[i] - 'a'] + 1;
            }
            return factorial(word.Length) / Multiplication(counter);
        }

        private int Multiplication(int[] counter)
        {
            int produce = 1;
            foreach (int nr in counter)
            {
                produce *= factorial(nr);
            }

            return produce;
        }

        int factorial(int n)
        {
            int m;
            int f = 1;
            for (m = 1; m <= n; m++)
            {
                f = f * m;
            }
            return f;
        }
    }
}
