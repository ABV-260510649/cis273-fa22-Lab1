namespace Polynomial;
class Program
{
    static void Main(string[] args)
    {
        Polynomial polynomial = new Polynomial();

        Polynomial polynomial2 = new Polynomial();

        Polynomial polynomialSum = Polynomial.Add(polynomial, polynomial2);
        Console.WriteLine( (0, polynomialSum.NumberOfTerms));
        Console.WriteLine( (0, polynomialSum.Degree));






    }
}

