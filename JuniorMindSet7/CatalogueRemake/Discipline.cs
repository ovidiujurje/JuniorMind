using System;

public class Discipline
{
    private string id;
    private int[] grades;
    public double Mean()
    {
        double sum = 0;
        foreach (int grade in grades)
            sum += grade;
        double mean = sum / grades.Length;
        return mean;
    }
    public int Count(int inputGrade)
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
