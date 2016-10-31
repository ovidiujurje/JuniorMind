using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogueRemake
{
    [TestClass]
    public class CatalogueRemakeTests
    {
        [TestMethod]
        public void SortStudentsAlphabetically()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
            CollectionAssert.AreEqual(new Student[] { two, three, one }, SortStudentsAlphabeticallyBubble(new Student[] { one, three, two }));

        }
        [TestMethod]
        public void SortStudentsbyGeneralMeanDescending()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
            CollectionAssert.AreEqual(new Student[] { three, one, two }, SortStudentsByGeneralMeanDescendingSelectionSort(new Student[] { one, three, two }));
        }
        [TestMethod]
        public void GetStudentsWithSpecificGeneralMean()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 9, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 10 }) });
            CollectionAssert.AreEqual(new Student[] { one, three }, GetStudentsWithSpecificGeneralMean(new Student[] { one, three, two }, 9.5));
        }
        [TestMethod]
        public void GetStudentsWithGreatestNumberOfTens()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 9, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 10 }) });
            CollectionAssert.AreEqual(new Student[] { one, three }, GetStudentsWithGreatestNumberOfASpecificGrade(new Student[] { one, three, two }, 10));
        }
        [TestMethod]
        public void GetStudentsWithLowestGeneralMean()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 9, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 10 }) });
            CollectionAssert.AreEqual(new Student[] { two }, GetStudentsWithLowestGeneralMean(new Student[] { one, three, two }));
        }
        public class Discipline
        {
            public string id;
            public int[] grades;
            public double Mean()
            {
                double sum = 0;
                foreach (int grade in grades)
                    sum += grade;
                double mean = sum / grades.Length;
                return mean;
            }
            public int Count (int inputGrade)
            {
                int count = 0;
                foreach (int grade in grades)
                    if (grade == inputGrade) count++;
                return count;
            }
            public Discipline(string inputId, int[] inputGrades)
            {
                id = inputId;
                grades = inputGrades;
            }
        }
        public class Student
        {
            public string name;
            public Discipline[] disciplines;
            public Double GeneralMean ()
            {
                double sum = 0;
                foreach (Discipline discipline in disciplines)
                    sum += discipline.Mean();
                double generalMean = sum / disciplines.Length;
                return generalMean;
            }
            public int Count (int inputGrade)
            {
                int count = 0;
                foreach (Discipline discipline in disciplines)
                    count += discipline.Count(inputGrade);
                return count;
            }
            public Student(string inputName, Discipline[] inputDisciplines)
            {
                name = inputName;
                disciplines = inputDisciplines;
            }
        }

        Student[] SortStudentsAlphabeticallyBubble(Student[] catalogue)
        {
            for (int k = 1; k < catalogue.Length; k++)
            {
                for (int i = 1; i < catalogue.Length; i++)
                {
                    OrderCurrentAndPreviousStudentAlphabetically(catalogue, i);
                }
            }
            return catalogue;
        }

        private void OrderCurrentAndPreviousStudentAlphabetically(Student[] catalogue, int i)
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

        Student[] SortStudentsByGeneralMeanDescendingSelectionSort(Student[] catalogue)
        {
            for (int i = 0; i < catalogue.Length; i++)
            {
                Swap(ref catalogue[i], ref catalogue[MaxValueIndex(catalogue, i)]);
            }
            return catalogue;
        }

        Student[] GetStudentsWithSpecificGeneralMean(Student[] catalogue, double targetMean)
        {
            Student[] students = new Student[0];
            foreach (Student student in catalogue)
            {
                students = AddStudentToResultsIfGeneralMeanIsEqualToTargetMean(targetMean, students, student);
            }
            return students;
        }

        private static Student[] AddStudentToResultsIfGeneralMeanIsEqualToTargetMean(double targetMean, Student[] students, Student student)
        {
            if (student.GeneralMean() == targetMean)
            {
                Array.Resize(ref students, students.Length + 1);
                students[students.Length - 1] = student;
            }

            return students;
        }

        Student[] GetStudentsWithGreatestNumberOfASpecificGrade(Student[] catalogue, int inputGrade)
        {
            Student[] students = new Student[0];
            foreach (Student student in catalogue)
            {
                students = AddStudentToResultsIfNumberOfSpecificGradeIsTheHighest(catalogue, inputGrade, students, student);
            }
            return students;
        }

        private Student[] AddStudentToResultsIfNumberOfSpecificGradeIsTheHighest(Student[] catalogue, int inputGrade, Student[] students, Student student)
        {
            if (student.Count(inputGrade) == MaxNumberOfSpecificGrade(catalogue, inputGrade))
            {
                Array.Resize(ref students, students.Length + 1);
                students[students.Length - 1] = student;
            }

            return students;
        }

        Student[] GetStudentsWithLowestGeneralMean(Student[] catalogue)
        {
            Student[] students = new Student[0];
            foreach (Student student in catalogue)
            {
                students = AddStudentToResultsIfGeneralMeanIsTheLowest(catalogue, students, student);
            }
            return students;
        }

        private Student[] AddStudentToResultsIfGeneralMeanIsTheLowest(Student[] catalogue, Student[] students, Student student)
        {
            if (student.GeneralMean() == MinValue(catalogue))
            {
                Array.Resize(ref students, students.Length + 1);
                students[students.Length - 1] = student;
            }

            return students;
        }

        public int MaxValueIndex(Student[] array, int startIndex)
        {
            int maxIndex = startIndex;
            double max = array[startIndex].GeneralMean();
            for (int i = startIndex + 1; i < array.Length; i++)
            {
                if (array[i].GeneralMean() > max)
                    maxIndex = i;
            }
            return maxIndex;
        }

        int MaxNumberOfSpecificGrade(Student[] array, int grade)
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Count(grade) > max)
                    max = array[i].Count(grade);
            }
            return max;
        }

        double MinValue(Student[] array)
        {
            double min = 10;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].GeneralMean() < min)
                    min = array[i].GeneralMean();
            }
            return min;
        }

        void Swap(ref Student first, ref Student second)
        {
            Student temp = first;
            first = second;
            second = temp;
        }
    }
}
