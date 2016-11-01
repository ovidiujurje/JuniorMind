using System;

public class Catalog
{
    private Student[] catalogue;
    public Catalog(Student[] students)
    {
        catalogue = students;
    }
    public Student[] SortAlphabetically()
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
        if (catalogue[i].DetermineIfAlphabeticallyPrecedes(catalogue[i - 1]))
            Swap(ref catalogue[i], ref catalogue[i - 1]);
    }
    public Student[] SortByGeneralMeanDescending()
    {
        for (int i = 0; i < catalogue.Length; i++)
        {
            Swap(ref catalogue[i], ref catalogue[MaxValueIndex(catalogue, i)]);
        }
        return catalogue;
    }

    public Student[] GetStudentsWithSpecificGeneralMean(double targetMean)
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

    public Student[] GetStudentsWithGreatestNumberOfASpecificGrade(int inputGrade)
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

    public Student[] GetStudentsWithLowestGeneralMean()
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

    private int MaxValueIndex(Student[] array, int startIndex)
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

    private int MaxNumberOfSpecificGrade(Student[] array, int grade)
    {
        int max = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Count(grade) > max)
                max = array[i].Count(grade);
        }
        return max;
    }

    private double MinValue(Student[] array)
    {
        double min = 10;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].GeneralMean() < min)
                min = array[i].GeneralMean();
        }
        return min;
    }

    private void Swap(ref Student first, ref Student second)
    {
        Student temp = first;
        first = second;
        second = temp;
    }
}
