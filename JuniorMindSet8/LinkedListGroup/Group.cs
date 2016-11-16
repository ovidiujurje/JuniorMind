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
        }

        public void AddLast(T value)
        {
            InsertBeforeNode(value, head);
            count++;
        }

        public void Add(T value)
        {
            AddLast(value);
        }

        public void InsertBefore(T v1, T v2)
        {
            Node<T> node = head.Next;
            while (node != head)
            {
                if ((object)node.Value == (object)v1)
                {
                    InsertBeforeNode(v2, node);
                    break;
                }
                node = node.Next;
            }
            count++;
        }

        public void InsertAfter(T v1, T v2)
        {
            Node<T> node = head.Next;
            while (node != head)
            {
                if ((object)node.Value == (object)v1)
                {
                    InsertAfterNode(v2, node);
                    break;
                }
                node = node.Next;
            }
            count++;
        }

        private static void InsertBeforeNode(T v2, Node<T> node)
        {
            Node<T> newNode = new Node<T>(node.Previous, node, v2);
            node.Previous.Next = newNode;
            node.Previous = newNode;
        }

        public void RemoveFirst()
        {
            if (head.Next != head)
            {
                head.Next.Next.Previous = head;
                head.Next = head.Next.Next;
            }
        }

        public void RemoveLast()
        {
            if (head.Previous != head)
            {
                head.Previous.Previous.Next = head;
                head.Previous = head.Previous.Previous;
            }
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