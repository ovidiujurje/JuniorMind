using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalogue
{
    [TestClass]
    public class CatalogueTests
    {
        [TestMethod]
        public void SortStudentsAlphabeticallyUsingBubbleSort()
        {
            Student three = new Student("Chereches Voicu", new int[] { 10 }, new int[] { 10, 9 }, new int[] { 10 }, new int[] { 9, 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 });
            Student two = new Student("Brete Origen", new int[] { 5 }, new int[] { 6 }, new int[] { 5 }, new int[] { 5 }, new int[] { 6 }, new int[] { 6, 5 }, new int[] { 7 }, new int[] { 6 }, new int[] { 6 }, new int[] { 5 }, new int[] { 9 }, new int[] { 7 });
            Student one = new Student("Chira Iulia", new int[] { 9 }, new int[] { 9 }, new int[] { 9 }, new int[] { 9, 8, 7 }, new int[] { 9 }, new int[] { 6 }, new int[] { 8, 9 }, new int[] { 6 }, new int[] { 6 }, new int[] { 10 }, new int[] { 9 }, new int[] { 7 });
            CollectionAssert.AreEqual(new Student[] { two, three, one }, SortStudentsAlphabeticallyBubble(new Student[] { one, three, two }));
        }
        public struct Student
        {
            public string name;
            public int[] matterOne;
            public int[] matterTwo;
            public int[] matterThree;
            public int[] matterFour;
            public int[] matterFive;
            public int[] matterSix;
            public int[] matterSeven;
            public int[] matterEight;
            public int[] matterNine;
            public int[] matterTen;
            public int[] matterEleven;
            public int[] matterTwelve;
            public Student( string name, int[] matterOne, int[] matterTwo, int[] matterThree, int[] matterFour, int[] matterFive, int[] matterSix, int[] matterSeven, int[] matterEight, int[] matterNine, int[] matterTen, int[] matterEleven, int[] matterTwelve)
            {
                this.name = name;
                this.matterOne = matterOne;
                this.matterTwo = matterTwo;
                this.matterThree = matterThree;
                this.matterFour = matterFour;
                this.matterFive = matterFive;
                this.matterSix = matterSix;
                this.matterSeven = matterSeven;
                this.matterEight = matterEight;
                this.matterNine = matterNine;
                this.matterTen = matterTen;
                this.matterEleven = matterEleven;
                this.matterTwelve = matterTwelve;
            }
        }
        Student[] SortStudentsAlphabeticallyBubble(Student[] catalogue)
        {
            for (int k = 1; k < catalogue.Length; k++)
            {
                for (int i = 1; i < catalogue.Length; i++)
                {
                    for (int j = 0; j < catalogue[i].name.Length; j++)
                    {
                        if (catalogue[i].name[j] < catalogue[i - 1].name[j])
                        {
                            Swap(ref catalogue[i], ref catalogue[i - 1]);
                            break;
                        }
                        if (catalogue[i].name[j] > catalogue[i - 1].name[j]) break;
                    }
                }
            }
            return catalogue;
        }
        void Swap(ref Student first, ref Student second)
        {
            Student temp = first;
            first = second;
            second = temp;
        }
    }
}
