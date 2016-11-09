using System;
using System.Collections;
using System.Collections.Generic;

public class Group<T>: IList<T>
{
    private T[] array;

    public Group (T[] arr)
    {
        if (arr.Length % 10 == 0 && (object)arr[arr.Length - 1] == (object)default(T))
        {
            array = arr;
        }
        else
        {
            if (arr.Length < 10) Array.Resize(ref arr, 10);
            else Array.Resize(ref arr, 3 * ((arr.Length / 10) * 10));
            array = arr;
        }
    }

    public T this[int index]
    {
        get
        {
            return ((IList<T>)array)[index];
        }

        set
        {
            ((IList<T>)array)[index] = value;
        }
    }

    public int Count
    {
        get
        {
            return ((IList<T>)array).Count;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return ((IList<T>)array).IsReadOnly;
        }
    }

    public void Add(T item)
    {
        ((IList<T>)array).Add(item);
    }

    public void Clear()
    {
        ((IList<T>)array).Clear();
    }

    public bool Contains(T item)
    {
        return ((IList<T>)array).Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ((IList<T>)this.array).CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IList<T>)array).GetEnumerator();
    }

    public int IndexOf(T item)
    {
        return ((IList<T>)array).IndexOf(item);
    }

    public void Insert(int index, T value)
    {
        for (int i = array.Length - 1; i > index; i--)
            array[i] = array[i - 1];
        array[index] = (T)(value);
    }

    public void AddLast(T value)
    {
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = value;
    }

    private void AddLastAr(ref T[] arr, T value)
    {
        Array.Resize(ref arr, arr.Length + 1);
        arr[arr.Length - 1] = value;
    }

    public bool Remove(T value)
    {
        T[] newArray = new T[array.Length];
        int position = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if ((object)(array[i]) != (object)(value))
            {
                newArray[position] = array[i];
                position++;
            }
            else
            {
                newArray[position] = array[i + 1];
                position ++;
                i++;
            }
        }
        array = newArray;
        return true;
    }

    public void RemoveAt(int index)
    {
        T[] newArray = new T[array.Length];
        int position = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                newArray[position] = array[i];
                position++;
            }
            else
            {
                newArray[position] = array[i + 1];
                position++;
                i++;
            }
        }
        array = newArray;
    }

    public void SwapItemsAtIndexes(int firstIndex, int secondIndex)
    {
        T temp = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = temp;
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IList<T>)array).GetEnumerator();
    }
}
