using System;
namespace KthToLast
{

    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data = default(T), LinkedListNode<T> next = null)
        {
            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }

    public class LinkedList<T> : IList<T>
    {
        public LinkedListNode<T> Head { get; set; }
        public LinkedListNode<T> Tail { get; set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        public T? First => IsEmpty ? default(T) : Head.Data;

        public T? Last => IsEmpty ? default(T) : Tail.Data;

        public bool IsEmpty => Head == null && Tail == null ? true : false;

        private int length = 0;
        public int Length => length;

        public void Append(T value)
        {

            var newNode = new LinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            length++;

        }

        public void Clear()
        {
            Head = null;
            Tail = null;

            length = 0;
        }

        public bool Contains(T value)
        {
            var currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(value))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public int FirstIndexOf(T value)
        {
            int index = 0;

            var currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(value))
                {
                    return index;
                }
                index++;
                currentNode = currentNode.Next;

            }

            return -1;
        }

        public T Get(int index)
        {
            var count = 0;
            var currentNode = Head;

            while (currentNode != null)
            {
                if (count == index)
                {
                    return currentNode.Data;
                }
                count++;
                currentNode = currentNode.Next;
            }

            throw new IndexOutOfRangeException();

        }

        public void InsertAfter(T newValue, T existingValue)
        {
            var value = new LinkedListNode<T>(newValue);
            var currentNode = Head;
            while (currentNode != null)
            {
                if (IsEmpty)
                {
                    Head = value;
                    Tail = value;
                    length++;
                }
                if (currentNode.Data.Equals(existingValue))
                {
                    if (currentNode == Tail)
                    {
                        currentNode.Next = value;
                        Tail = value;
                        length++;
                        return;
                    }

                    else
                    {
                        value.Next = currentNode.Next;
                        currentNode.Next = value;
                        length++;
                        return;
                    }

                }
                currentNode = currentNode.Next;
            }
            Append(newValue);
            length++;

        }


        public void InsertAt(T value, int index)
        {
            if (index > 0)
            {
                InsertAfter(value, Get(index - 1));
            }

            if (index == 0)
            {
                Prepend(value);
            }

            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }

        }

        public void Prepend(T value)
        {
            var newNode = new LinkedListNode<T>(value);
            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

            length++;
        }

        public void Remove(T value)
        {
            // If list is empty, we're done, son. 
            if (IsEmpty)
            {
                return;
            }

            // Remove head
            if (Head.Data.Equals(value))
            {
                // 1-element list
                if (Head == Tail)
                {
                    Tail = null;
                    Head = null;
                }
                else
                {
                    Head = Head.Next;
                }
                length--;

                return;
            }

            // Remove non-head node
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Next != null && currentNode.Next.Data.Equals(value))
                {
                    var nodeToDelete = currentNode.Next;
                    length--;

                    if (nodeToDelete == Tail)
                    {
                        currentNode.Next = null;
                        Tail = currentNode;
                    }
                    else
                    {
                        currentNode.Next = currentNode.Next.Next;
                        nodeToDelete.Next = null;
                    }

                    return;
                }

                currentNode = currentNode.Next;
            }

        }

        public void RemoveAt(int index)
        {

            // length--;

            Remove(Get(index));
        }

        public IList<T> Reverse()
        {
            IList<T> reversedList = new LinkedList<T>();
            var currentNode = Head;
            while (currentNode != null)
            {
                reversedList.Prepend(currentNode.Data);
                currentNode = currentNode.Next;
            }
            return reversedList;
        }

        public override string ToString()
        {
            string result = "[";

            for (var currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                result += currentNode.ToString();
                if (currentNode != Tail)
                {
                    result += ", ";
                }

            }
            result += "]";

            return result;

        }

        // get the 2nd to last element
        public T KthToLast(int k)
        {
            if (k == 0)
            {
                return Tail.Data;
            }

            IList<T> reversedList = Reverse();

            return reversedList.Get(k);
        }
    }
}

