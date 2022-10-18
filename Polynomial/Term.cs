using System;
namespace Polynomial
{
	public class Term
	{
		public int Power { get; set; }
		public double Coefficient { get; set; }

		public Term(int power, double coeffecient)
		{
			Power = power;
			Coefficient = coeffecient;
		}

		public override string ToString()
		{
			if (Power == 0 || Coefficient == 0)
			{
				return $"{Coefficient}";
			}
			return $"{Coefficient}x^{Power}";
		}

	}
}

