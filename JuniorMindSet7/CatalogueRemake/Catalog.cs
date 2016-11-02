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
                OrderCurrentAndPreviousStudentAlphabetically(i);
            }
        }
        return catalogue;
    }

    private void OrderCurrentAndPreviousStudentAlphabetically(int i)
    {
        if (catalogue[i].DetermineIfAlphabeticallyPrecedes(catalogue[i - 1]))
            Swap(ref catalogue[i], ref catalogue[i - 1]);
    }
    public Student[] SortByGeneralMeanDescending()
    {
        for (int i = 0; i < catalogue.Length; i++)
        {
            Swap(ref catalogue[i], ref catalogue[MaxGeneralMeanIndex(i)]);
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
            students = AddStudentToResultsIfNumberOfSpecificGradeIsTheHighest(inputGrade, students, student);
        }
        return students;
    }

    private Student[] AddStudentToResultsIfNumberOfSpecificGradeIsTheHighest(int inputGrade, Student[] students, Student student)
    {
        if (student.Count(inputGrade) == MaxCountOfSpecificGrade(inputGrade))
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
            students = AddStudentToResultsIfGeneralMeanIsTheLowest(students, student);
        }
        return students;
    }

    private Student[] AddStudentToResultsIfGeneralMeanIsTheLowest(Student[] students, Student student)
    {
        if (student.GeneralMean() == MinGeneralMean())
        {
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = student;
        }

        return students;
    }

    private int MaxGeneralMeanIndex(int startIndex)
    {
        int maxIndex = startIndex;
        double max = catalogue[startIndex].GeneralMean();
        for (int i = startIndex + 1; i < catalogue.Length; i++)
        {
            if (catalogue[i].GeneralMean() > max)
                maxIndex = i;
        }
        return maxIndex;
    }

    private int MaxCountOfSpecificGrade(int grade)
    {
        int max = 0;
        for (int i = 0; i < catalogue.Length; i++)
        {
            if (catalogue[i].Count(grade) > max)
                max = catalogue[i].Count(grade);
        }
        return max;
    }

    private double MinGeneralMean()
    {
        double min = 10;
        for (int i = 0; i < catalogue.Length; i++)
        {
            if (catalogue[i].GeneralMean() < min)
                min = catalogue[i].GeneralMean();
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
