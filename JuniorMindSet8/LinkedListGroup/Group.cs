using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGroup
{
    public class Group<T>: IEnumerable<T>
    {
        private LinkedList<T> list;

        public Group(T[] array)
        {
            list = new LinkedList<T>(array);
        }

        public void AddFirst(T value)
        {
            list.AddFirst(value);
        }

        public void AddLast(T value)
        {
            list.AddLast(value);
        }

        public void Insert(T place, T value)
        {
            LinkedListNode<T> current = list.Find(place);
            list.AddBefore(current, value);
        }

        public void RemoveFirst()
        {
            list.RemoveFirst();
        }

        public void RemoveLast()
        {
            list.RemoveLast();
        }

        public void Remove(T value)
        {
            list.Remove(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }
    }
}