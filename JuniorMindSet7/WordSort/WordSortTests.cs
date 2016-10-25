using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordSort
{
    [TestClass]
    public class WordSortTests
    {
        [TestMethod]
        public void SortWordsAscendingByTheNumberOfAppearence()
        {
            CollectionAssert.AreEqual(new string[] { "one", "two", "three" }, SortWordsByNumberOfAppearences("three two three two three one"));
        }
        string[] SortWordsByNumberOfAppearences(string text)
        {
            string[] textAsArray = text.Split(' ');
            int[] count = new int[textAsArray.Length];
            string[] words = new string[0];
            int[] wordCount = new int[0];
            for (int i = 0; i < textAsArray.Length; i++)
            {
                if (textAsArray[i] != "")
                {
                    for (int j = i + 1; j < textAsArray.Length; j++)
                    {
                        if (textAsArray[i] == textAsArray[j])
                        {
                            count[i]++;
                            textAsArray[j] = "";
                        }
                    }
                }
            }
            int position = 0;
            for (int i = 0; i < textAsArray.Length; i++)
            {
                if (textAsArray[i] != "")
                {
                    Array.Resize(ref words,words.Length + 1);
                    words[position] = textAsArray[i];
                    Array.Resize(ref wordCount, wordCount.Length + 1);
                    wordCount[position] = count[i];
                    position++;
                }
            }
            for (int i = 1; i < words.Length; i++)
            {
                DoInsertion(ref words, ref wordCount, i, i - 1);
            }
            return words;
        }
        void DoInsertion(ref string[] words, ref int[] wordCount, int index, int previousIndex)
        {
            if (previousIndex < 0) return;
            if (wordCount[index] < wordCount[previousIndex])
            {
                SwapInt(ref wordCount[index], ref wordCount[previousIndex]);
                SwapString(ref words[index], ref words[previousIndex]);
                DoInsertion(ref words, ref wordCount, index - 1, previousIndex - 1);
            }
        }
        void SwapString(ref string first, ref string second)
        {
            string temp = first;
            first = second;
            second = temp;
        }
        void SwapInt(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }
}
