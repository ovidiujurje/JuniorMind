using System;
using System.Collections;

public class Group<T>: IList
{
    private T[] array;

    public Group (T[] arr)
    {
        array = arr;
    }

    public object this[int index]
    {
        get
        {
            return ((IList)array)[index];
        }

        set
        {
            ((IList)array)[index] = value;
        }
    }

    public int Count
    {
        get
        {
            return ((IList)array).Count;
        }
    }

    public bool IsFixedSize
    {
        get
        {
            return array.IsFixedSize;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return array.IsReadOnly;
        }
    }

    public bool IsSynchronized
    {
        get
        {
            return array.IsSynchronized;
        }
    }

    public object SyncRoot
    {
        get
        {
            return array.SyncRoot;
        }
    }

    public int Add(object value)
    {
        return ((IList)array).Add(value);
    }

    public void Clear()
    {
        array = new T[0];
    }

    public bool Contains(object value)
    {
        return ((IList)array).Contains(value);
    }

    public void CopyTo(System.Array array, int index)
    {
        this.array.CopyTo(array, index);
    }

    public IEnumerator GetEnumerator()
    {
        return array.GetEnumerator();
    }

    public int IndexOf(object value)
    {
        return ((IList)array).IndexOf(value);
    }

    public void Insert(int index, object value)
    {
        Array.Resize(ref array, array.Length + 1);
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

    public void Remove(object value)
    {
        T[] newArray = new T[0];
        foreach (object element in array)
            if (element != value) AddLastAr(ref newArray, (T)(element));
        array = newArray;
    }

    public void RemoveAt(int index)
    {
        T[] newArray = new T[0];
        for (int i = 0; i < array.Length; i++)
            if (i != index) AddLastAr(ref newArray, array[i]);
        array = newArray;
    }

    public void SwapItemsAtIndexes(int firstIndex, int secondIndex)
    {
        T temp = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = temp;
    }
}
