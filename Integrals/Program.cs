using System;
namespace Integrals
{
	class MainClass
	{
		
		public static void Main(string[] args)
		{
			int n;
			double a,b,r=0,eps;

			Console.Write("a:");
			a=double.Parse(Console.ReadLine());
			Console.Write("b:");
			b = double.Parse(Console.ReadLine());
			Console.Write("n:");
			n = int.Parse(Console.ReadLine());
			//r = double.Parse(Console.ReadLine());
			Console.Write("epsilon:");
			eps = double.Parse(Console.ReadLine());
			Console.Write("t:");
			double t = double.Parse(Console.ReadLine());
			Minus minusIntegral = new Minus(b, a, n, 0, eps);
			Plus plusIntegral = new Plus(b, a, n, 0, eps);

			for (r = 0; r <= 1; r=r+0.25)
			{
				BaseClass.Xelement xp, xm;

				minusIntegral.r = r;
				plusIntegral.r = r;

				minusIntegral.InitX();
				plusIntegral.InitX();
				while (minusIntegral.NextX()) { }
				while (plusIntegral.NextX()) { }

				minusIntegral.Print();
				xm = minusIntegral.X(t);
				Console.Write(String.Format("X-({0},{1})=", t, r));
				Console.WriteLine(xm.value.ToString("0.##e+0") + " on iteration " + xm.Iteration);

				plusIntegral.Print();
				xp = plusIntegral.X(t);
				Console.Write(String.Format("X+({0},{1})=", t,r));
				Console.WriteLine(xp.value.ToString("0.##e+0")+" on iteration "+xp.Iteration);
			}

		}
	}
}
