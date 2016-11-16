using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGroup
{
    public class Node<T>
    {
        private Node<T> previous;
        private Node<T> next;
        private T element;

        public T Value
        {
            get
            {
                return element;
            }
            set
            {
                element = value;
            }
        }
        public Node<T> Previous
        {
            get
            {
                return previous;
            }
            set
            {
                previous = value;
            }
        }
        public Node<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
        public Node(Node<T> PrevNode, Node<T> NextNode, T obj)
        {
            previous = PrevNode;
            next = NextNode;
            element = obj;
        }
    }

    public class LinkedList<T>: IEnumerable<T>
    {        
        private Node<T> head;
        private int count;

        public LinkedList()
        {
            head = new Node<T>(null, null, default(T));
            head.Next = head;
            head.Previous = head;
        }

        public int Count { get { return count; } }

        public void AddFirst(T value)
        {
            InsertAfterNode(value, head);
            count++;
        }

        private void InsertAfterNode(T value, Node<T> node)
        {
            Node<T> newNode = new Node<T>(node, node.Next, value);
            node.Next.Previous = newNode;
            node.Next = newNode;
            count++;
        }

        public void AddLast(T value)
        {
            InsertBeforeNode(value, head);
        }

        public void Add(T value)
        {
            AddLast(value);
        }

        public void InsertBefore(T v1, T v2)
        {
            var node = FindFirst(v1);
            InsertBeforeNode(v2, node);
        }

        public void InsertAfter(T v1, T v2)
        {
            var node = FindFirst(v1);
            InsertAfterNode(v2, node);
        }

        private void InsertBeforeNode(T v2, Node<T> node)
        {
            Node<T> newNode = new Node<T>(node.Previous, node, v2);
            node.Previous.Next = newNode;
            node.Previous = newNode;
            count++;
        }

        public void RemoveFirst()
        {
            if (head.Next != head)
            {
                head.Next.Next.Previous = head;
                head.Next = head.Next.Next;
                count--;
            }
        }

        public void RemoveLast()
        {
            if (head.Previous != head)
            {
                head.Previous.Previous.Next = head;
                head.Previous = head.Previous.Previous;
                count--;
            }
        }

        public void RemoveValue(T value)
        {
            var node = FindFirst(value);
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            count--;
        }

        public Node<T> FindFirst(T value)
        {
            for (Node<T> node = head.Next; node != head; node = node.Next)
            {
                if (node.Value.Equals(value))
                    return node;
            }
            throw new InvalidOperationException();
        }
        public Node<T> FindLast(T value)
        {
            for (Node<T> node = head.Previous; node != head; node = node.Previous)
            {
                if (node.Value.Equals(value))
                    return node;
            }
            throw new InvalidOperationException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = head.Next;
            while (node != head)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}