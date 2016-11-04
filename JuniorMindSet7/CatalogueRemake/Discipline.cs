using System;
using System.Collections;

public class Discipline: IEnumerator
{
    private string id;
    private int[] grades;
    int position = -1;

    public bool MoveNext()
    {
        position++;
        return (position < grades.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public int Current
    {
        get
        {
            return grades[position];
        }
    }

    public Discipline(string inputId, int[] inputGrades)
    {
        id = inputId;
        grades = inputGrades;
    }

}
