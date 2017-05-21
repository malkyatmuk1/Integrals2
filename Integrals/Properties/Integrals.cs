using System;
namespace secondIntegrals
{
	public class Integrals
	{
		int b,a,n,r,eps,h;
		public Integrals (int b,int a,int n, int r,int eps)
		{
			this.b=B;
			this.a=A;
			this.n=N;
			this.r=R;
			this.eps=Eps;
			this.h=H;
		}
		public int B{
			get{return b;}
			set{b=value;}
		}
		public int A{
			get{return a;}
			set{a=value;}
		}
		public int N{
			get{return n;}
			set{n=value;}
		}
		public int R{
			get{return r;}
			set{r=value;}
		}
		public int Eps{
			get{return epsilon;}
			set{epsilon=value;}
		}
		public int H{
			get{return (A-B)/N;}
			set{h=value;}
		}
		double f_minus(int t,double x,int r)
		{ 
			double f;
			f=x/2-1/8*pow(t,5)*pow((1+r),2);
			return f;
		}
			double f_plus(int t,double x,int r)
		{ 
			double f;
			f=x/2-1/8*pow(t,5)*pow((3-r),2);
			return f;
		}
			double g_minus(int t,int r)
		{ 
			double g;
			g=1/2*t*(1+r)-1/8*pow(t,5)*pow(1+r,2);
			return g;
		}
			double g_plus(int t,int r)
		{ 
			double g;
			g=1/2*t*(3-r)-1/8*pow(t,5)*pow(3-r,2);
			return g;
		}
	}
}
