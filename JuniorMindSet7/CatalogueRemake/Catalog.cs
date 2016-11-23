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

    public struct StudCount
    {
        private Student student;
        private int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public Student Student
        {
            get
            {
                return student;
            }
        }

        public StudCount(Student student, int count)
        {
            this.student = student;
            this.count = count;
        }
    }

    public IEnumerable<Student> GetStudentsWithGreatestNumberOfASpecificGrade(int inputGrade)
    {
        var stud = catalogue.Select(student => new StudCount(student, student.Count(inputGrade)))
            .OrderBy(student => student.Count);

        return stud.Where(student =>  student.Count == stud.Last().Count).Select(student => student.Student);
    }

    public struct StudAv
    {
        private Student student;
        private double mean;

        public double Mean
        {
            get
            {
                return mean;
            }
        }

        public Student Student
        {
            get
            {
                return student;
            }
        }

        public StudAv(Student student, double mean)
        {
            this.student = student;
            this.mean = mean;
        }
    }

    public IEnumerable<Student> GetStudentsWithLowestGeneralMean()
    {
        var stud = catalogue.Select(student => new StudAv(student, student.Disciplines.Average(dis => dis.Grades.Average(gra => gra))))
            .OrderBy(student => student.Mean);
        return stud.Where(student => student.Mean == stud.First().Mean).Select(student => student.Student);
    }
}
