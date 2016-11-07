using System;
using System.Collections;

public class Catalog
{
    private Group<Student> catalogue;
    public Catalog(Group<Student> students)
    {
        catalogue = students;
    }

    public IEnumerator GetEnumerator()
    {
        return catalogue.GetEnumerator();
    }

    public Group<Student> SortAlphabetically()
    {
        for (int k = 1; k < catalogue.Count; k++)
        {
            for (int i = 1; i < catalogue.Count; i++)
            {
                OrderCurrentAndPreviousStudentAlphabetically(i);
            }
        }
        return catalogue;
    }

    private void OrderCurrentAndPreviousStudentAlphabetically(int i)
    {
        if (((Student)(catalogue[i])).DetermineIfAlphabeticallyPrecedes((Student)(catalogue[i - 1])))
            catalogue.SwapItemsAtIndexes(i, i - 1);
    }

    public Group<Student> SortByGeneralMeanDescending()
    {
        for (int i = 0; i < catalogue.Count; i++)
        {
            catalogue.SwapItemsAtIndexes(i, MaxGeneralMeanIndex(i));
        }
        return catalogue;
    }

    public Group<Student> GetStudentsWithSpecificGeneralMean(double targetMean)
    {
        foreach (Student student in catalogue)
            if (student.GeneralMean() != targetMean) catalogue.Remove(student);
        return catalogue;
    }

    public Group<Student> GetStudentsWithGreatestNumberOfASpecificGrade(int inputGrade)
    {
        foreach (Student student in catalogue)
            if (student.Count(inputGrade) != MaxCountOfSpecificGrade(inputGrade)) catalogue.Remove(student);
        return catalogue;
    }

    public Group<Student> GetStudentsWithLowestGeneralMean()
    {
        foreach (Student student in catalogue)
            if (student.GeneralMean() != MinGeneralMean()) catalogue.Remove(student);
        return catalogue;
    }

    private int MaxGeneralMeanIndex(int startIndex)
    {
        int maxIndex = startIndex;
        double max = ((Student)(catalogue[startIndex])).GeneralMean();
        for (int i = startIndex + 1; i < catalogue.Count; i++)
        {
            if (((Student)(catalogue[i])).GeneralMean() > max) maxIndex = i;
        }
        return maxIndex;
    }

    private int MaxCountOfSpecificGrade(int grade)
    {
        int max = 0;
        for (int i = 0; i < catalogue.Count; i++)
        {
            if (((Student)(catalogue[i])).Count(grade) > max) max = ((Student)(catalogue[i])).Count(grade);
        }
        return max;
    }

    private double MinGeneralMean()
    {
        double min = 10;
        for (int i = 0; i < catalogue.Count; i++)
        {
            if (((Student)(catalogue[i])).GeneralMean() < min) min = ((Student)(catalogue[i])).GeneralMean();
        }
        return min;
    }
}
