using System;
using System.Collections;
using System.Collections.Generic;

public class Group<T>: IList<T>
{
    private T[] array;
    private int _count;

    public Group (T[] arr)
    {
        _count = arr.Length;
        if (arr.Length < 10) Array.Resize(ref arr, 10);
        else Array.Resize(ref arr, 3 * ((arr.Length / 10) * 10));
        array = arr;
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
            return _count;
        }
    }

    public int ArrayLength
    {
        get
        {
            return array.Length;
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
        if (_count >= array.Length) Array.Resize(ref array, 3 * ((array.Length / 10) * 10));
            array[_count] = item;
            _count++;
    }

    public void Clear()
    {
        ((IList<T>)array).Clear();
    }

    public bool Contains(T item)
    {
        return ((IList<T>)array).Contains(item);
    }

    public void CopyTo(T[] newArray, int index)
    {
        int j = index;
        for (int i = 0; i < _count; i++)
        {
            newArray.SetValue(array[i], j);
            j++;
        }
    }

    public int IndexOf(T item)
    {
        return ((IList<T>)array).IndexOf(item);
    }

    public void Insert(int index, T value)
    {

        if (_count >= array.Length) Array.Resize(ref array, 3 * ((array.Length / 10) * 10));
        for (int i = _count; i > index; i--)
            array[i] = array[i - 1];
        array[index] = (T)(value);
        _count++;
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
        _count--;
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
        _count--;
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

    public IEnumerator<T> GetEnumerator()
    {
        return ((IList<T>)array).GetEnumerator();
    }
}
