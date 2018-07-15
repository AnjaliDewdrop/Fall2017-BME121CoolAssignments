using System;
using static System.Console;
using static System.Math;

namespace Bme121
{
    
	static class Program
	{
		static void Swap(int[] first, int[] second)
		{
			if (first.Length>second.Length)
			{
				for (int i=0; i<second.Length; i++)
				{
					int temp = first[i];
					first[i]=second[i];
					second[i]=temp;
				}
			}else
			{
				for (int i=0; i<second.Length; i++)
				{
					int temp = first[i];
					first[i]=second[i];
					second[i]=temp;
				}
			}
		}
		static void Main()
		{   
			int[] first=new int[] {3, 4, 5};
			int[] second=new int[] {7,8,9};
			Swap(first, second);
			WriteLine("\n"+first[0]+first[1]+first[2]+"\n"+second[0]+second[1]+second[2]);
		}
	}
}

