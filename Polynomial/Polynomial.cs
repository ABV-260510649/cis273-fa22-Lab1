using System;
using System.Security;
using System.Security.Cryptography;

namespace Polynomial
{
	public class Polynomial
	{

		private LinkedList<Term> terms;

		public int NumberOfTerms => terms.Count;

        public int Degree => NumberOfTerms == 0 ? 0: terms.First.Value.Power;

        public Polynomial()
		{
			terms = new LinkedList<Term>();

		}

        public void AddTerm(double coeff, int power)
		{
            var currentNode = terms.First;
            while (currentNode != null)
            {
                if (power == currentNode.Value.Power)
                {
                    currentNode.Value.Coefficient += coeff;
                    return;
                }

                if (power > currentNode.Value.Power)
                {
                    var newNode = new Term(power, coeff);
                    terms.AddBefore(currentNode, newNode);
                    return;
                }
                currentNode = currentNode.Next;
            }
            terms.AddLast(new Term(power, coeff));
        }
        public override string ToString()
		{
            if (terms.Count == 0)
            {
                return "0";
            }
            string result = "";
            foreach (var term in terms)
            {
                result += term.ToString() + "+";
            }
            result = result.Remove(result.LastIndexOf('+'));
            return result;
   
        }

        public static Polynomial Add(Polynomial p1, Polynomial p2)
		{
            Polynomial sum = new Polynomial();
            foreach (var term in p1.terms)
            {
                sum.AddTerm(term.Coefficient, term.Power);
            }
            foreach (var term in p2.terms)
            {
                sum.AddTerm(term.Coefficient, term.Power);
            }
            if (sum.terms.Count > 0)
            {
                searchForZeroes(sum);
            }
            return sum;
		}
		public static Polynomial Subtract(Polynomial p1, Polynomial p2)
		{
            Polynomial dif = new Polynomial();
            foreach (var term in p2.terms)
            {
                dif.AddTerm(term.Coefficient * -1, term.Power);
            }

            foreach (var term in p1.terms)
            {
                dif.AddTerm(term.Coefficient, term.Power);
            }
            searchForZeroes(dif);

			return dif;
        }
		public static Polynomial Negate(Polynomial p)
		{
            Polynomial inverse = new Polynomial();
			foreach (var term in p.terms)
            {
                inverse.AddTerm(term.Coefficient * -1, term.Power);
            }
            return inverse;
        }
		public static Polynomial Multiply(Polynomial p1, Polynomial p2)
        {
			Polynomial result = new Polynomial();
			var currentNode = p1.terms.First;
			while (currentNode != null)
			{
				foreach (Term term in p2.terms)
				{
					result.AddTerm(currentNode.Value.Coefficient * term.Coefficient, currentNode.Value.Power + term.Power);
				}
				currentNode = currentNode.Next;
			}
			return result;
        }

		// Bonus
        // This only works if the divisor is a binomial and there are no missing terms
		public static Polynomial Divide(Polynomial p1, Polynomial p2)
		{
            var currentNode = p2.terms.First;
            var divisor = p1.terms.First;
            Polynomial result = new Polynomial();
             while (currentNode != null)
            { 
                double coeff = currentNode.Value.Coefficient / divisor.Value.Coefficient;
                int pow = currentNode.Value.Power - divisor.Value.Power;
                currentNode = currentNode.Next;
                Term numberToDivideBy = new Term(pow, coeff);
                result.AddTerm(numberToDivideBy.Coefficient, numberToDivideBy.Power);
                Polynomial multiply = Polynomial.Multiply(result, p1);
                Polynomial.Subtract(p2, multiply);
                if (currentNode.Value.Power == 0)
                {
                    return result;
                }

            }
            return result;
        }

		private static void searchForZeroes(Polynomial p)
		{
            var currentNode = p.terms.First;
            while (currentNode != null)
            {
                if (currentNode.Value.Coefficient == 0)
                {
                    p.terms.Remove(currentNode);
                }
                currentNode = currentNode.Next;
            }

            if (p.terms.Last.Value.Coefficient == 0)
            {
                p.terms.Remove(p.terms.Last);
            }
        }

    }
}

