using System;
using static System.Console;

namespace Bme121.Q1
{
    static class Program
    {
		static double GhjForce(double length)
		{
			const double d1=51.748;
			const double d2=3.027;
			const double d3=1.601;
			const double d4=0.782;
			const double d5=5.872;
			const double f1=17.788;
			const double f2=1.958;
			
			if (length<d1)
			{
				return 0;
			}else if (length<(d1+d2))
			{
				return ((length-d1)*(f1/d2));
			} else if (length<(d1+d2+d3))
			{
				return (f1+((length-d1-d2)*(f2/d3)));
			} else if (length<(d1+d2+d3+d4))
			{
				return (f1+f2);
			} else if (length<d1+d2+d3+d4+d5)
			{
				return (f1+f2+((length-d1-d2-d3-d4)*((-f1-f2)/d5)));
			} else
			{
				return 0;
			}

		}
		static double GaussForce (double length)
		{
			const double d1=50.715;
			const double d2=15.321;
			const double c0=0.712;
			const double c1=20.94;
			const double c2=56.323; 
			const double c3=-4.336;
			const double c4=0.146;

			if (length<d1)
			{
				return 0;
			} else if (length<(d1+d2))
			{
				return (-c0+c1*Math.Pow(Math.E, -(Math.Pow(((length-c2)/(c3+(c4*length))), 2) )));
			} else
			{
				return 0;
			}
			
		}
        static void Main( )
        {
			for (double i=50.00; i<=66.00; i+=0.10)
			{
				double GhjF=GhjForce(i);
				double Gf=GaussForce(i);
			
				WriteLine("{0,-12}{1,-9}{2,-9}", $"{i:n2} mm,  ", $"{GhjF:n2} N, ", $"{Gf:n2} N");
			}
        }
    }
}

// The GHJ piecewise-linear model has d1=51.748, d2=3.027, d3=1.601, d4=0.782, d5=5.872, f1=17.788, and f2=1.958.

// The asymmetric Gaussian model has d1=50.715, d2=15.321, c0=0.712, c1=20.94, c2=56.323, c3=-4.336, and c4=0.146.
