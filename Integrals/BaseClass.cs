using System;
namespace Integrals
{
	abstract public class BaseClass
	{
		public  struct Xelement
		{
			public double D;
			public double value;
			public int Iteration;
		}

		public BaseClass(double b, double a, int n, double r, double eps)
		{
			this.b = b;
			this.a = a;
			this.n = n;
			this.r = r;
			this.eps = eps;
			this.xval = new Xelement[n+1];
			this.h = (b - a) / n;

		}
		public double a { get; }
		public double b { get; }
		public int n { get; }
		public double r { get; set; }
		public double eps { get; }
		public double h { get; }
		public string nm;
		public Xelement[] xval { get; set; }

		public abstract double F(double t, double x);
		public abstract double G(double t);
		public abstract double Xzvezda(double t);
		public abstract void Printerr(double r,double e);
		public bool NextX()
		{
			double t = a, newval, oldval;
			double sum = 0.0d;
			bool lampa = false;
			for (int i = 0; i <= n; i++)
			{
				//if (i == 0) Console.WriteLine(sum);
				oldval = xval[i].value;
				if (xval[i].D > eps)
					
				{
					newval = G(t) + F(t, oldval) + t * h * sum / 2;
					xval[i].D = Math.Abs(oldval - newval);
					xval[i].value = newval;
					xval[i].Iteration++;
					lampa = true;
				}
				if(i<n)sum = sum + t * Math.Pow(oldval, 2) + (t + h) * Math.Pow(xval[i + 1].value, 2);
				t = t + h;
			}
			return lampa;
		}
		public void InitX()
		{
			for (int i = 0; i <= n; i++)
			{
				xval[i].value = G(i * h + a);
				xval[i].Iteration = 0;
				xval[i].D = 2 * eps;
			}
		}
		double max = 0;
		public void Print()
		{
			double t=a;
			Console.WriteLine();
			for (int i = 0; i <= n; i++)
			{
				double e;
				e = Math.Abs(Xzvezda(t) - xval[i].value);
				if (e > max) max = e;
				//Console.WriteLine(Math.Abs(e).ToString("0.##e+0"));
				
				Console.WriteLine("t="+t.ToString("0.##e+0")+" "+nm+"="+xval[i].value.ToString("0.##e+0")+ " " + nm + "*=" + Xzvezda(t).ToString("0.##e+0") + " D= "+xval[i].D.ToString("0.##e+0")+" iter= "+xval[i].Iteration);
				t = t + h;
			}
			Printerr(r, max);

		}

		public Xelement X(double t)
		{
			int q =Convert.ToInt32(t / h);
			double s = t / h - q;
			if (Math.Abs(s) < eps) return xval[q];
			double sum = 0;
			double m=a;
			Xelement pr;
			double oldvalue;
			pr.value=G(t);
			pr.D = 2 * eps;
			pr.Iteration = 0;

			for (int i = 0; i < q; i++)
			{
				sum=sum + m * Math.Pow(xval[i].value, 2) + (m + h) * Math.Pow(xval[i + 1].value, 2);
				m = m + h;
			}
			sum = sum + (m + h) * Math.Pow(xval[q].value, 2);
			while (pr.D>eps)
			{
				pr.Iteration++;

				oldvalue = pr.value;
				pr.value=G(t) + F(t, oldvalue) + (t * h /2)*( sum + t  * Math.Pow(oldvalue, 2));
				pr.D = Math.Abs(pr.value-oldvalue);

			}

			return pr;
		}

	}
}

