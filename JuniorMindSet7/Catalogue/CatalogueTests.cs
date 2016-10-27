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
            Student three = new Student("Chereches Voicu", 0, 0, new int[] { 10 }, new int[] { 10, 9 }, new int[] { 10 }, new int[] { 9, 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 });
            Student two = new Student("Brete Origen", 0, 0, new int[] { 5 }, new int[] { 6 }, new int[] { 5 }, new int[] { 5 }, new int[] { 6 }, new int[] { 6, 5 }, new int[] { 7 }, new int[] { 6 }, new int[] { 6 }, new int[] { 5 }, new int[] { 9 }, new int[] { 7 });
            Student one = new Student("Chira Iulia", 0, 0, new int[] { 9 }, new int[] { 9 }, new int[] { 9 }, new int[] { 9, 8, 7 }, new int[] { 9 }, new int[] { 6 }, new int[] { 8, 9 }, new int[] { 6 }, new int[] { 6 }, new int[] { 10 }, new int[] { 9 }, new int[] { 7 });
            CollectionAssert.AreEqual(new Student[] { two, three, one }, SortStudentsAlphabeticallyBubble(new Student[] { one, three, two }));
        }
        [TestMethod]
        public void ShouldCalculateGeneralMeans()
        {
            Student three = new Student("Chereches Voicu", 0, 0, new int[] { 10 }, new int[] { 10, 9 }, new int[] { 10 }, new int[] { 9, 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 });
            Student two = new Student("Brete Origen", 0, 0, new int[] { 5 }, new int[] { 6 }, new int[] { 5 }, new int[] { 5 }, new int[] { 6 }, new int[] { 6, 5 }, new int[] { 7 }, new int[] { 6 }, new int[] { 6 }, new int[] { 5 }, new int[] { 9 }, new int[] { 7 });
            Student one = new Student("Chira Iulia", 0, 0, new int[] { 9 }, new int[] { 9 }, new int[] { 9 }, new int[] { 9, 8, 7 }, new int[] { 9 }, new int[] { 6 }, new int[] { 8, 9 }, new int[] { 6 }, new int[] { 6 }, new int[] { 10 }, new int[] { 9 }, new int[] { 7 });
            Student[] students = { three, two, one };
            CalculateGeneralMeans(ref students);
            Assert.AreEqual(9.9166666666666661, students[0].mean);
            Assert.AreEqual(6.041666666666667, students[1].mean);
            Assert.AreEqual(8.0416666666666661, students[2].mean);
        }
        [TestMethod]
        public void SortStudentsByGeneralMeanDescendingSelectionSort()
        {
            Student three = new Student("Chereches Voicu", 0, 0, new int[] { 10 }, new int[] { 10, 9 }, new int[] { 10 }, new int[] { 9, 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 });
            Student two = new Student("Brete Origen", 0, 0, new int[] { 5 }, new int[] { 6 }, new int[] { 5 }, new int[] { 5 }, new int[] { 6 }, new int[] { 6, 5 }, new int[] { 7 }, new int[] { 6 }, new int[] { 6 }, new int[] { 5 }, new int[] { 9 }, new int[] { 7 });
            Student one = new Student("Chira Iulia", 0, 0, new int[] { 9 }, new int[] { 9 }, new int[] { 9 }, new int[] { 9, 8, 7 }, new int[] { 9 }, new int[] { 6 }, new int[] { 8, 9 }, new int[] { 6 }, new int[] { 6 }, new int[] { 10 }, new int[] { 9 }, new int[] { 7 });
            Student[] students = { three, one, two };
            CalculateGeneralMeans(ref students);
            CollectionAssert.AreEqual(students, SortStudentsByGeneralMeanDescendingSelectionSort(new Student[] { two, one, three }));
        }
        [TestMethod]
        public void FindStudentsWithSpecificGeneralMean()
        {
            Student three = new Student("Chereches Voicu", 0, 0, new int[] { 10 }, new int[] { 10, 9 }, new int[] { 10 }, new int[] { 9, 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 });
            Student two = new Student("Brete Origen", 0, 0, new int[] { 5 }, new int[] { 6 }, new int[] { 5 }, new int[] { 5 }, new int[] { 6 }, new int[] { 6, 5 }, new int[] { 7 }, new int[] { 6 }, new int[] { 6 }, new int[] { 5 }, new int[] { 9 }, new int[] { 7 });
            Student one = new Student("Chira Iulia", 0, 0, new int[] { 10 }, new int[] { 10, 9 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 9, 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 });
            Student[] students = { one, three };
            CalculateGeneralMeans(ref students);
            CollectionAssert.AreEqual(students, GetStudentsWithSpecificGeneralMean(new Student[] { two, one, three }, 9.9166666666666661));
        }
        [TestMethod]
        public void FindStudentsWithMostTens()
        {
            Student three = new Student("Chereches Voicu", 0, 0, new int[] { 10 }, new int[] { 10, 9 }, new int[] { 10 }, new int[] { 9, 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 });
            Student two = new Student("Brete Origen", 0, 0, new int[] { 5 }, new int[] { 6 }, new int[] { 5 }, new int[] { 5 }, new int[] { 6 }, new int[] { 6, 5 }, new int[] { 7 }, new int[] { 6 }, new int[] { 6 }, new int[] { 5 }, new int[] { 9 }, new int[] { 7 });
            Student one = new Student("Chira Iulia", 0, 0, new int[] { 10 }, new int[] { 10, 9 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 9, 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 });
            Student[] students = { one, three };
            CountNumberOfTensForEachStudent(ref students);
            CollectionAssert.AreEqual(students, GetStudentsWithTheMostTens(new Student[] { two, one, three }));
        }
        [TestMethod]
        public void FindStudentsWithLowestGeneralMean()
        {
            Student three = new Student("Chereches Voicu", 0, 0, new int[] { 10 }, new int[] { 10, 9 }, new int[] { 10 }, new int[] { 9, 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 });
            Student two = new Student("Brete Origen", 0, 0, new int[] { 5 }, new int[] { 6 }, new int[] { 5 }, new int[] { 5 }, new int[] { 6 }, new int[] { 6, 5 }, new int[] { 7 }, new int[] { 6 }, new int[] { 6 }, new int[] { 5 }, new int[] { 9 }, new int[] { 7 });
            Student one = new Student("Chira Iulia", 0, 0, new int[] { 10 }, new int[] { 10, 9 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 9, 10 }, new int[] { 10 }, new int[] { 10 }, new int[] { 10 });
            Student[] students = { two };
            CalculateGeneralMeans(ref students);
            CollectionAssert.AreEqual(students, GetStudentsWithLowestGeneralMean(new Student[] { one, two, three }));
        }
        public struct Student
        {
            public string name;
            public int tenCount;
            public double mean;
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
            public Student( string name, int tenCount, double mean, int[] matterOne, int[] matterTwo, int[] matterThree, int[] matterFour, int[] matterFive, int[] matterSix, int[] matterSeven, int[] matterEight, int[] matterNine, int[] matterTen, int[] matterEleven, int[] matterTwelve)
            {
                this.name = name;
                this.tenCount = tenCount;
                this.mean = mean;
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
        Student[] SortStudentsByGeneralMeanDescendingSelectionSort(Student[] catalogue)
        {
            CalculateGeneralMeans(ref catalogue);
            for (int i = 0; i < catalogue.Length; i++)
            {
                Swap(ref catalogue[i], ref catalogue[MaxValueIndex(catalogue, i)]);
            }
            return catalogue;
        }
        public enum GetCase { SpecificMean, MostTens, LowestMean }
        Student[] GetStudentsWithSpecificGeneralMean(Student[] catalogue, double targetMean)
        {
            CalculateGeneralMeans(ref catalogue);
            Student[] students = new Student[0];
            foreach (Student student in catalogue)
            {
                if (student.mean == targetMean)
                {
                    Array.Resize(ref students, students.Length + 1);
                    students[students.Length - 1] = student;
                }
            }
            return students;
        }
        Student[] GetStudentsWithTheMostTens(Student[] catalogue)
        {
            CountNumberOfTensForEachStudent(ref catalogue);
            Student[] students = new Student[0];
            foreach (Student student in catalogue)
            {
                if (student.tenCount == MaxValue(catalogue))
                {
                    Array.Resize(ref students, students.Length + 1);
                    students[students.Length - 1] = student;
                }
            }
            return students;
        }
        Student[] GetStudentsWithLowestGeneralMean(Student[] catalogue)
        {
            CalculateGeneralMeans(ref catalogue);
            Student[] students = new Student[0];
            foreach (Student student in catalogue)
            {
                if (student.mean == MinValue(catalogue))
                {
                    Array.Resize(ref students, students.Length + 1);
                    students[students.Length - 1] = student;
                }
            }
            return students;
        }
        void CountNumberOfTensForEachStudent(ref Student[] catalogue)
        {
            for (int i = 0; i < catalogue.Length; i++)
            {
                catalogue[i].tenCount = CountTensForEachMatter(catalogue[i].matterOne) + CountTensForEachMatter(catalogue[i].matterTwo) + CountTensForEachMatter(catalogue[i].matterThree) + CountTensForEachMatter(catalogue[i].matterFour) + CountTensForEachMatter(catalogue[i].matterFive) + CountTensForEachMatter(catalogue[i].matterSix) + CountTensForEachMatter(catalogue[i].matterSeven) + CountTensForEachMatter(catalogue[i].matterEight) + CountTensForEachMatter(catalogue[i].matterNine) + CountTensForEachMatter(catalogue[i].matterTen) + CountTensForEachMatter(catalogue[i].matterEleven) + CountTensForEachMatter(catalogue[i].matterTwelve);
            }
        }
        int CountTensForEachMatter(int[] array)
        {
            int sum = 0;
            foreach (int value in array)
                if (value == 10) sum += 1;
            return sum;
        }

        void CalculateGeneralMeans(ref Student[] catalogue)
        {
            for (int i = 0; i < catalogue.Length; i++)
            {
                catalogue[i].mean = (Mean(catalogue[i].matterOne) + Mean(catalogue[i].matterTwo) + Mean(catalogue[i].matterThree) + Mean(catalogue[i].matterFour) + Mean(catalogue[i].matterFive) + Mean(catalogue[i].matterSix) + Mean(catalogue[i].matterSeven) + Mean(catalogue[i].matterEight) + Mean(catalogue[i].matterNine) + Mean(catalogue[i].matterTen) + Mean(catalogue[i].matterEleven) + Mean(catalogue[i].matterTwelve)) / 12;
            }
        }
        double Mean(int[] array)
        {
            double sum = 0;
            foreach (int value in array)
                sum += value;
            double mean = sum / array.Length;
            return mean;
        }
        int MaxValue(Student[] array)
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].tenCount > max)
                    max = array[i].tenCount;
            }
            return max;
        }
        double MinValue(Student[] array)
        {
            double min = 10;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].mean < min)
                    min = array[i].mean;
            }
            return min;
        }
        int MaxValueIndex(Student[] array, int startIndex)
        {
            int maxIndex = startIndex;
            double max = array[startIndex].mean;
            for (int i = startIndex + 1; i < array.Length; i++)
            {
                if (array[i].mean > max)
                    maxIndex = i;
            }
            return maxIndex;
        }
        void Swap(ref Student first, ref Student second)
        {
            Student temp = first;
            first = second;
            second = temp;
        }
    }
}
