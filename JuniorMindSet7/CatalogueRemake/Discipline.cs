using System;
using System.Collections;

public class Discipline: IEnumerable
{
    private string id;
    private int[] grades;

    public IEnumerator GetEnumerator()
    {
        return grades.GetEnumerator();
    }

    public Discipline(string inputId, int[] inputGrades)
    {
        id = inputId;
        grades = inputGrades;
    }

}
