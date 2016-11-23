using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Catalog
{
    private Student[] catalogue;
    public Catalog(Student[] students)
    {
        catalogue = students;
    }

    public IEnumerator GetEnumerator()
    {
        return catalogue.GetEnumerator();
    }

    public IEnumerable<Student> SortAlphabetically()
    {
        return catalogue.OrderBy(student => student.Name);
    }

    public IEnumerable<Student> SortByGeneralMeanDescending()
    {
        return catalogue.OrderByDescending(student => student.Disciplines.Average(dis => dis.Grades.Average(gra => gra)));
    }

    public IEnumerable<Student> GetStudentsWithSpecificGeneralMean(double targetMean)
    {
        return catalogue.Where(student => student.Disciplines.Average(dis => dis.Grades.Average(gra => gra)) == targetMean);
    }

    public IEnumerable<Student> GetStudentsWithGreatestNumberOfASpecificGrade(int inputGrade)
    {
        return catalogue
            .Where(student => student.Count(inputGrade) == catalogue.OrderBy(st => st.Count(inputGrade)).Last().Count(inputGrade));
    }

    public IEnumerable<Student> GetStudentsWithLowestGeneralMean()
    {
        return catalogue
            .Where(student => student.Disciplines.Average(dis => dis.Grades.Average(gra => gra)) == catalogue.OrderBy(st => st.Disciplines.Average(dis => dis.Grades.Average(gra => gra))).First().Disciplines.Average(dis => dis.Grades.Average(gra => gra)));
    }
}
