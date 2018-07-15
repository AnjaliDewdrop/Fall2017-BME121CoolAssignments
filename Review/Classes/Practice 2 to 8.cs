using System;
using static System.Console;
using static System.Math;

namespace Bme121
{
    class Complex
    {
		double x;
		double y;
		
		public Complex ()
		{
			this.x=0.0;
			this.y=0.0;
		}
		public Complex (double re, double im)
		{
			this.x=re;
			this.y=im;
		}
		public override string ToString()
		{
			return $"{x}+i{y}";
		}
		public double GetAbs()
		{
			return Sqrt(x*x+y*y);
		}
		public static double CalcAbs(Complex sample)
		{
			return Sqrt(sample.x*sample.x+sample.y*sample.y);
		}
	}
    static class Program
    {
		
        static void Main()
        {   
            Complex first = new Complex ();
            WriteLine(first);
            Complex second = new Complex (4.3, 8);
            WriteLine(second);
            WriteLine(first.GetAbs() +" "+Complex.CalcAbs(first));
            WriteLine(second.GetAbs()+" "+Complex.CalcAbs(second));
            
            Complex[] stored=new Complex[3];
            stored[0]=first;
            stored[1]=second;
            stored[2]=new Complex(3.4, 8.2);
            
            for (int i=0; i<stored.Length; i++)
            {
				WriteLine(stored[i]+" "+Complex.CalcAbs(stored[i]));
			}
        }
    }
}
