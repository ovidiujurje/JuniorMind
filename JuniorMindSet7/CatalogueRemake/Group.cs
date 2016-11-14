using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        ShiftElementsToRight(index);
        array[index] = (T)(value);
        _count++;
    }

    private void ShiftElementsToRight(int index)
    {
        for (int i = _count; i > index; i--)
            array[i] = array[i - 1];
    }

    public bool Remove(T value)
    {
        T[] newArray = new T[array.Length];
        CopyAllElementsExceptValueToNewArray(value, newArray);
        array = newArray;
        _count--;
        return true;
    }

    private void CopyAllElementsExceptValueToNewArray(T value, T[] newArray)
    {
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
                position++;
                i++;
            }
        }
    }

    public void RemoveAt(int index)
    {
        T[] newArray = new T[array.Length];
        CopyAllElementsExceptValueToNewArray(array[index], newArray);
        array = newArray;
        _count--;
    }

    public void SwapItemsAtIndexes(int firstIndex, int secondIndex)
    {
        T temp = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = temp;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return (IEnumerator<T>)(new Group<T>(array));
    }

    private Enumerator<T> GetEnumerator1()
    {
        return (Enumerator<T>)GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator1();
    }
}

public class Enumerator<T>: IEnumerator<T>
{
    private T[] _collection;
    private int currentIndex;
    private T currentItem;


    public Enumerator(T[] collection)
    {
        _collection = collection;
        currentIndex = -1;
        currentItem = default(T);

    }

    public bool MoveNext()
    {
        if (++currentIndex >= _collection.ToArray().Length)
        {
            return false;
        }
        else
        {
            currentItem = _collection[currentIndex];
        }
        return true;
    }

    public void Reset() { currentIndex = -1; }

    void IDisposable.Dispose() { }

    public T Current
    {
        get { return currentItem; }
    }


    object IEnumerator.Current
    {
        get { return Current; }
    }
}
