namespace KthToLast;
public class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> linkedList = new LinkedList<int>();
        for (int i = 0; i <= 40; i++)
        {
            linkedList.Append(i);
        }

        for (int i = 0; i <= 40; i++)
        {
            Console.WriteLine( ((40 - i), linkedList.KthToLast(i)));
        }
    }
}

