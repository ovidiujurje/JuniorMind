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
        double sum = 0;
        foreach (Discipline discipline in disciplines)
            sum += discipline.Mean();
        double generalMean = sum / disciplines.Length;
        return generalMean;
    }
    public int Count(int inputGrade)
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
