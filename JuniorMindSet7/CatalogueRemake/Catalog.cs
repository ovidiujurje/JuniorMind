using System;
using System.Collections;

public class Catalog<T>
{
    private Group<T> catalogue;
    public Catalog(Group<T> students)
    {
        catalogue = students;
    }

    public IEnumerator GetEnumerator()
    {
        return catalogue.GetEnumerator();
    }

    public Group<T> SortAlphabetically()
    {
        for (int k = 1; k < catalogue.Count; k++)
        {
            for (int i = 1; i < catalogue.Count; i++)
            {
                if (catalogue[i] != null) OrderCurrentAndPreviousStudentAlphabetically(i);
            }
        }
        return catalogue;
    }

    private void OrderCurrentAndPreviousStudentAlphabetically(int i)
    {
        if (((Student)((object)catalogue[i])).DetermineIfAlphabeticallyPrecedes((Student)((object)catalogue[i - 1])))
            catalogue.SwapItemsAtIndexes(i, i - 1);
    }

    public Group<T> SortByGeneralMeanDescending()
    {
        for (int i = 0; i < catalogue.Count; i++)
        {
            if (catalogue[i] != null) catalogue.SwapItemsAtIndexes(i, MaxGeneralMeanIndex(i));
        }
        return catalogue;
    }

    public Group<T> GetStudentsWithSpecificGeneralMean(double targetMean)
    {
        foreach (T student in catalogue)
            if (student != null && ((Student)((object)student)).GeneralMean() != targetMean) catalogue.Remove(student);
        return catalogue;
    }

    public Group<T> GetStudentsWithGreatestNumberOfASpecificGrade(int inputGrade)
    {
        foreach (T student in catalogue)
            if (student != null && ((Student)((object)student)).Count(inputGrade) != MaxCountOfSpecificGrade(inputGrade)) catalogue.Remove(student);
        return catalogue;
    }

    public Group<T> GetStudentsWithLowestGeneralMean()
    {
        foreach (T student in catalogue)
            if (student != null && ((Student)((object)student)).GeneralMean() != MinGeneralMean()) catalogue.Remove(student);
        return catalogue;
    }

    private int MaxGeneralMeanIndex(int startIndex)
    {
        int maxIndex = startIndex;
        double max = ((Student)((object)catalogue[startIndex])).GeneralMean();
        for (int i = startIndex + 1; i < catalogue.Count; i++)
        {
            if (catalogue[i] != null)
                if (((Student)((object)catalogue[i])).GeneralMean() > max) maxIndex = i;
        }
        return maxIndex;
    }

    private int MaxCountOfSpecificGrade(int grade)
    {
        int max = 0;
        for (int i = 0; i < catalogue.Count; i++)
        {
            if (catalogue[i] != null && ((Student)((object)catalogue[i])).Count(grade) > max) max = ((Student)((object)catalogue[i])).Count(grade);
        }
        return max;
    }

    private double MinGeneralMean()
    {
        double min = 10;
        for (int i = 0; i < catalogue.Count; i++)
        {
            if (catalogue[i] != null && ((Student)((object)catalogue[i])).GeneralMean() < min) min = ((Student)((object)catalogue[i])).GeneralMean();
        }
        return min;
    }
}
