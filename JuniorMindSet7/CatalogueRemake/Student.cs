using System;

public class Student
{
    private string name;
    public string Name
    {
        get
        {
            return name;
        }
    }
    private Discipline[] disciplines;
    public Discipline[] Disciplines
    {
        get
        {
            return disciplines;
        }
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
