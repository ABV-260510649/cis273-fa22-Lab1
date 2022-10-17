﻿using System;
using System.Security;
using System.Security.Cryptography;

namespace Polynomial
{
	public class Polynomial
	{

		private LinkedList<Term> terms;

		public int NumberOfTerms => terms.Count;

        // public int Degree => NumberOfTerms == 0 ? 0: terms.First.Value.Power;
        public int Degree { get
			{
				if (NumberOfTerms == 0)
				{
					return 0;
				}
				return highestPower();				
			} 
		}

        public Polynomial()
		{
			terms = new LinkedList<Term>();

		}

        public void AddTerm(double coeff, int power)
		{
			Term termToAdd = new Term(power, coeff);
			terms.AddLast(termToAdd);

            var currentNode = terms.First;
			while (currentNode != terms.Last)
			{
				if (currentNode.Value.Power == terms.Last.Value.Power)
				{
					if (currentNode.Value.Coefficient > 0)
					{
                        currentNode.Value.Coefficient += terms.Last.Value.Coefficient;
                        terms.Remove(terms.Last);
                        return;
                    }

					else if (currentNode.Value.Coefficient < 0)
					{
                        currentNode.Value.Coefficient -= terms.Last.Value.Coefficient;
                        terms.Remove(terms.Last);
						return;
                    }
				}
                currentNode = currentNode.Next;
            }

        }

		public override string ToString()
		{
            sortByPower();

            string result = "";
			var currentNode = terms.First;
			while (currentNode != null)
			{
                result += currentNode.Value.ToString();
				if (currentNode.Next != null)
                {
					result += "+";
                }

				currentNode = currentNode.Next;
			}

            if (terms.Count == 0)
			{
				return "0";
			}

			else
			{
				return result;
			}
        }

        public static Polynomial Add(Polynomial p1, Polynomial p2)
		{
			var currentNode = p2.terms.First;
			while (currentNode != null)
			{
				p1.AddTerm(currentNode.Value.Coefficient, currentNode.Value.Power);
				currentNode = currentNode.Next;
			}
			if (p1.terms.Count > 0)
			{
                searchForZeroes(p1);
            }
            return p1;
		}
		public static Polynomial Subtract(Polynomial p1, Polynomial p2)
		{
            Add(p1, Negate(p2));

			return p1;
        }
		public static Polynomial Negate(Polynomial p)
		{
			var currentNode = p.terms.First;
			while (currentNode != null)
			{
				currentNode.Value.Coefficient *= -1;
                currentNode = currentNode.Next;
            }

            return p;
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
		public static Polynomial Divide(Polynomial p1, Polynomial p2)
		{
			return new Polynomial();
        }

		private int highestPower()
		{
			int highestPower = 0;
			foreach (Term term in terms)
			{
				if (term.Power > highestPower)
				{
					highestPower = term.Power;
				}
			}
			return highestPower;
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

