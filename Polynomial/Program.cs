namespace Polynomial;
class Program
{
    static void Main(string[] args)
    {
        Polynomial polynomial = new Polynomial();
        Term term1 = new Term(2, 3);
        polynomial.AddTerm(term1.Coefficient, term1.Power);
        Term term2 = new Term(1, 3);
        polynomial.AddTerm(term2.Coefficient, term2.Power);

        Polynomial polynomial2 = new Polynomial();
        Term term3 = new Term(0, 2);
        polynomial2.AddTerm(term3.Coefficient, term3.Power);
        Term term4 = new Term(4, 9);
        polynomial2.AddTerm(term4.Coefficient, term4.Power);

        Polynomial polynomialSum = Polynomial.Multiply(polynomial, polynomial2);
        Console.WriteLine(polynomialSum.ToString());
        Console.WriteLine((4, polynomialSum.NumberOfTerms));
        Console.WriteLine( (6, polynomialSum.Degree));

    }
}

