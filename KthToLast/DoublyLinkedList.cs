using System;
namespace KthToLast
{

    public class DoublyLinkedListNode<T>
    {
        public T Data { get; set; }

        public DoublyLinkedListNode<T> Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }

        public DoublyLinkedListNode(T data = default(T), DoublyLinkedListNode<T>  prev = null, DoublyLinkedListNode<T> next = null)
        {
            Data = data;
            Prev = prev;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }

    public class DoublyLinkedList<T> : IList<T>

    // Look through every method to fix the arrows
    // Basically only have to do that if you're changing next

    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }

        public DoublyLinkedList()
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

            var newNode = new DoublyLinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
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
            var value = new DoublyLinkedListNode<T>(newValue);
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
                        value.Prev = Tail;
                        Tail = value;
                        length++;
                        return;
                    }

                    else
                    {
                        value.Next = currentNode.Next;
                        currentNode.Next.Prev = value;
                        currentNode.Next = value;
                        value.Prev = currentNode;
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
            var newNode = new DoublyLinkedListNode<T>(value);
            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Head.Prev = newNode;
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
                        currentNode.Prev = Tail;
                        Tail = currentNode;
                    }
                    else
                    {
                        currentNode.Next = currentNode.Next.Next;
                        currentNode.Next.Next.Prev = currentNode;
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
            IList<T> reversedList = new DoublyLinkedList<T>();
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

        public T KthToLast(int k)
        {
            var currentNode = Tail;
            for (int i=0; i<k; i++)
            {
                currentNode = currentNode.Prev;
            }

            return currentNode.Data;
        }
    }
}
