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
			Term termToAdd = new Term(power, coeff);
			if (coeff > 0)
			{
                terms.AddLast(termToAdd);
            }

			var currentNode = terms.First;
			if (terms.Count > 1)
			{
                while (currentNode.Value != terms.Last.Value)
                {
                    if (currentNode.Value.Power == terms.Last.Value.Power)
                    {
                        currentNode.Value.Coefficient += terms.Last.Value.Coefficient;
                        terms.Remove(terms.Last);
                        return;
                    }
                    currentNode = currentNode.Next;
                }
                sortByPower();
            }

        }

		public override string ToString()
		{
            foreach (Term t in terms)
            {
				return t.ToString();
            } 
			return "0";
        }

        public static Polynomial Add(Polynomial p1, Polynomial p2)
		{
			Polynomial result = new Polynomial();
			var currentNode = p1.terms.First;
			var secondPolyNode = p2.terms.First;
			while (currentNode != null || secondPolyNode != null)
			{
				result.AddTerm(currentNode.Value.Coefficient, currentNode.Value.Power);
				result.AddTerm(secondPolyNode.Value.Coefficient, secondPolyNode.Value.Power);
				currentNode = currentNode.Next;
				secondPolyNode = secondPolyNode.Next;
			}
			return result;
		}
		public static Polynomial Subtract(Polynomial p1, Polynomial p2)
		{
			return Add(p1, Negate(p2));
        }
		public static Polynomial Negate(Polynomial p)
		{
            foreach (Term term in p.terms)
            {
                term.Coefficient *= -1;
            }
			return p;
        }
		public static Polynomial Multiply(Polynomial p1, Polynomial p2)
        {
            var currentNode = p1.terms.First;
            var secondPolyNode = p2.terms.First;
            while (secondPolyNode != null)
            {
				while (currentNode != null)
				{
                    currentNode.Value.Coefficient *= secondPolyNode.Value.Coefficient;
					currentNode.Value.Power += secondPolyNode.Value.Power;
                    currentNode = currentNode.Next;
                }
                secondPolyNode = secondPolyNode.Next;
            }

            return p1;
        }

		// Bonus
		public static Polynomial Divide(Polynomial p1, Polynomial p2)
		{
			return new Polynomial();
        }

		private void sortByPower()
		{
			int highestPower = 0;
			var currentNode = terms.First;
			while (currentNode != null)
			{
				if (currentNode.Value.Power > highestPower)
				{
					terms.Remove(currentNode);
					terms.AddFirst(currentNode);
				}
				highestPower = currentNode.Value.Power;
				currentNode = currentNode.Next;
			}

			return;
		}
    }
}

