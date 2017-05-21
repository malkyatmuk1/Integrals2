using System;
namespace Integrals
{
	public class Plus:BaseClass
	{
		public Plus(double b, double a, int n, double r, double eps):base(b,a,n,r,eps){
			nm = "X+";
		}
		public override double F(double t, double x)
		{
			return x / 2 - 0.125d * Math.Pow(t, 5) * Math.Pow(3- r, 2);
		}
		public override double G(double t)
		{
			return 0.5d * t * (3-r) - 0.125d * Math.Pow(t, 5) * Math.Pow(3- r, 2);
		}
		public override double Xzvezda(double t)
		{
			return (3 - r) * t;
		}
		public override void Printerr(double r, double e)
		{
			Console.WriteLine("r=" + r + " e(+)=" + e.ToString("0.##e+0"));
		}
	}
}
