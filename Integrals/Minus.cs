using System;
namespace Integrals
{
	public class Minus:BaseClass
	{
		public Minus(double b, double a, int n, double r,double eps):base(b,a,n,r,eps){
			nm = "X-";
		}
		public override double F(double t, double x)
		{
			return x / 2 - 0.125d*Math.Pow(t, 5)*Math.Pow(1+r,2);
		}
		public override  double G(double t)
		{
			return 0.5d *t*(1+r)-0.125d*Math.Pow(t,5)*Math.Pow(1+r,2);
		}
		public override double Xzvezda(double t)
		{
			return (1+r) * t;
		}
		public override void Printerr(double r, double e)
		{
			Console.WriteLine("r=" + r + " e(-)=" + e.ToString("0.##e+0"));
		}
	}
}
