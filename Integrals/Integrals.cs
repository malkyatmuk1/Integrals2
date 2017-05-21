using System;

namespace secondIntegrals
{
	public class Integrals
	{
		
		public Integrals (double b,double a,int n, int r,int eps)
		{
			this.b=b;
			this.a=a;
			this.n=n;
			this.r=r;
			this.eps=eps;

		}
		public double a{get;set;}
		public double b{ get; set; }
		public int n { get; set; }
		public int r { get; set; }
		public int eps { get; set; }
		public double h { get { return (b-a) / n; } }

		public double f_minus(double t,double[,] x,int r,int i,int n)
		{ 
			double f;
			f=x[i,n]/2-1/8*Math.Pow(t,5)*Math.Pow((1+r),2);
			return f;
		}
		public	double f_plus(double t,double[,] x,int r,int i,int n)
		{ 
			double f;
			f=x[i,n]/2-1/8*Math.Pow(t,5)*Math.Pow((3-r),2);
			return f;
		}
			public double g_minus(double t,int r)
		{ 
			double g;
			g=1/2*t*(1+r)-1/8*Math.Pow(t,5)*Math.Pow(1+r,2);
			return g;
		}
			public double g_plus(double t,int r)
		{ 
			double g;
			g=1/2*t*(3-r)-1/8*Math.Pow(t,5)*Math.Pow(3-r,2);
			return g;
		}
		public double SumFirst(double t,double sum)
		{
			
			for (int j = 1; j <= n; j++)
			{
				double sj = a + h * (j - 0.5);
				sum = sum + sj * g_plus(sj, r);
				sum = sum * n * Math.Pow(h, 2);
			}


			return sum;
		}
		public double SumSecond(double t, double sum, double[,] x, int i,int n)
		{
			
			for (int j= 1; j <= n; j++)
			{
				double sj = a + h * (j - 0.5);
				sum = sum + sj * x[i, j];
				sum = sum * n * Math.Pow(h, 2);
			}

			return sum;
		}

	}
}
