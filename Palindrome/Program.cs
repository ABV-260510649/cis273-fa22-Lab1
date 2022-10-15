using System;

namespace Palindrome;
public class Program
{
    static void Main(string[] args)
    {
        LinkedList<String> doublyLinkedList = new LinkedList<String>();
        for (int i = 2; i < 51; i++)
        {
            if (i % 2 == 0)
            {
                doublyLinkedList.AddLast("one");
            }
            else
            {
                doublyLinkedList.AddLast("two");
            }
        }
        
        Console.WriteLine(IsPalindrome(doublyLinkedList));

    }

    public static bool IsPalindrome<T>(LinkedList<T> linkedList)
    {

        if (linkedList.Count == 1)
        {
            return true;
        }

        int count = 0;
        var currentNode = linkedList.First;
        var lastNode = linkedList.Last;
        while (currentNode.Value.Equals(lastNode.Value)){
            currentNode = currentNode.Next;
            lastNode = lastNode.Previous;
            count++;
            if (count == linkedList.Count / 2) {
                return true;
            }
        } return false;

    }
}

