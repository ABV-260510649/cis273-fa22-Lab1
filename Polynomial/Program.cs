﻿namespace Polynomial;
class Program
{
    static void Main(string[] args)
    {
        // AddTerm2
        Polynomial polynomial = new Polynomial();
        Term term1 = new Term(2, 0);
        polynomial.AddTerm(term1.Coefficient, term1.Power);
        Console.WriteLine( (1, polynomial.ToString().Length));


        // Divide
        /*Polynomial polynomial1 = new Polynomial();
        polynomial1.AddTerm(1, 4);
        polynomial1.AddTerm(-1, 3);
        polynomial1.AddTerm(1, 2);
        polynomial1.AddTerm(-1, 1);
        polynomial1.AddTerm(2, 0);

        Polynomial polynomial2 = new Polynomial();
        polynomial2.AddTerm(1, 1);
        polynomial2.AddTerm(-2, 0);

        Polynomial result = Polynomial.Divide(polynomial2, polynomial1);
        Console.WriteLine(result.ToString());*/

        // Negate with Add
        /*Polynomial polynomial = new Polynomial();
        Term term1 = new Term(0, 3);
        polynomial.AddTerm(term1.Coefficient, term1.Power);
        Term term2 = new Term(1, 3);
        polynomial.AddTerm(term2.Coefficient, term2.Power);

        //Polynomial polynomial2 = Polynomial.Negate(polynomial);

        Polynomial polynomialSum = Polynomial.Add(polynomial, Polynomial.Negate(polynomial));

        Console.WriteLine( (0, polynomialSum.NumberOfTerms));
        Console.WriteLine( (0, polynomialSum.Degree));
        Console.WriteLine( ("0", polynomialSum.ToString()));*/

    }
}

