using System;

public class Student
{
    private string name;
    private Discipline[] disciplines;
    public bool DetermineIfAlphabeticallyPrecedes(Student student)
    {
        for (int i = 0; i < name.Length; i++)
        {
            if (name[i] < student.name[i]) return true;
            if (name[i] > student.name[i]) return false;
        }
        return false;
    }
    public Double GeneralMean()
    {
        double meansSum = 0;
        foreach (Discipline discipline in disciplines)
        {
            meansSum += CalculateDisciplineMean(discipline);
        }
        double generalMean = meansSum / disciplines.Length;
        return generalMean;
    }

    private static double CalculateDisciplineMean( Discipline discipline)
    {
        double sum = 0;
        int gradeCount = 0;
        foreach (int grade in discipline)
        {
            sum += grade;
            gradeCount++;
        }
        double mean = sum / gradeCount;
        return mean;
    }

    public int Count(int inputGrade)
    {
        int count = 0;
        foreach (Discipline discipline in disciplines)
            foreach (int grade in discipline)
                if (grade == inputGrade) count ++;
        return count;
    }
    public Student(string inputName, Discipline[] inputDisciplines)
    {
        name = inputName;
        disciplines = inputDisciplines;
    }
}
