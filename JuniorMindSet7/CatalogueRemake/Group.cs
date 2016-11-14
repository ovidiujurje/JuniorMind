using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Group<T>: IList<T>
{
    private T[] _array;
    private int _count;

    public Group()
    {
        _count = 0;
        _array = new T[10];
    }

    public T this[int index]
    {
        get
        {
            return _array[index];
        }

        set
        {
            _array[index] = value;
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
            return _array.Length;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return ((IList<T>)_array).IsReadOnly;
        }
    }

    public void Add(T item)
    {
        MakeSpace();
        _array[_count++] = item;
    }

    public void Clear()
    {
        _count = 0;
    }

    public bool Contains(T item)
    {
        return ((IList<T>)_array).Contains(item);
    }

    public void CopyTo(T[] newArray, int index)
    {
        int j = index;
        for (int i = 0; i < _count; i++)
        {
            newArray.SetValue(_array[i], j);
            j++;
        }
    }

    public int IndexOf(T item)
    {
        return ((IList<T>)_array).IndexOf(item);
    }

    public void Insert(int index, T value)
    {
        MakeSpace();
        ShiftElementsToRight(index);
        _array[index] = value;
        _count++;
    }

    private void MakeSpace()
    {
        if (_count >= _array.Length)
            Array.Resize(ref _array, 2 * _array.Length);
    }

    private void ShiftElementsToRight(int index)
    {
        for (int i = _count; i > index; i--)
            _array[i] = _array[i - 1];
    }

    public bool Remove(T value)
    {
        T[] newArray = new T[_array.Length];
        CopyAllElementsExceptValueToNewArray(value, newArray);
        _array = newArray;
        _count--;
        return true;
    }

    private void CopyAllElementsExceptValueToNewArray(T value, T[] newArray)
    {
        int position = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if ((object)(_array[i]) != (object)(value))
            {
                newArray[position] = _array[i];
                position++;
            }
            else
            {
                newArray[position] = _array[i + 1];
                position++;
                i++;
            }
        }
    }

    public void RemoveAt(int index)
    {
        T[] newArray = new T[_array.Length];
        CopyAllElementsExceptValueToNewArray(_array[index], newArray);
        _array = newArray;
        _count--;
    }

    public void SwapItemsAtIndexes(int firstIndex, int secondIndex)
    {
        T temp = _array[firstIndex];
        _array[firstIndex] = _array[secondIndex];
        _array[secondIndex] = temp;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
            yield return _array[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
