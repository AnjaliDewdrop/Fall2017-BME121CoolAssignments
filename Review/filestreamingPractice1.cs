using System;
using static System.Console;
using System.IO; // You have to have this to use FILE I/O

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
			Write("Please enter the range of prime number you want to search:");
			int range = int.Parse( ReadLine() );
			int numPrime = 1;	// store how many prime number there are within the range
			int [] primeNumber = new int [range];
			primeNumber[0] = 2;
			for (int i=3;i<=range;i++)
			{
				// Define a flag to indicate the current number is a prime or not
				bool isPrime = true; // Assume the number is prime first
				for (int j=2;j<i;j++)
				{	// Confirm the number is prime or not
					if (i%j==0)
					{	// not prime
						isPrime = false;
						break;
					}
				}
				if (isPrime == true)
				{
					// store the prime number 
					primeNumber[numPrime] = i;
					numPrime++;
				}
			}
			
			// Please add your code here to write the prime numbers to file
			// To guide you, pseudo are provided
			// What you have right now: 
			// a. numPrime: number of prime number within the range
			// b. primeNumber: array holding the prime numbers
			
			// 1. Create a FileStream to open a file. Use FileMode.OpenOrCreate to create a new file
			// and FileAccess.Write to gain write access.
			using (FileStream outFile = new FileStream("primes.txt", FileMode.CreateNew, FileAccess.Write))
			{
				using (StreamWriter writer = new StreamWriter(outFile))
				{
					WriteLine("x");
				}
			}
			// 2. Create a StreamWriter linked to FileStream you created above
			
			
			// 3. Use WriteLine to write the number to file
			// P.S. cannot use foreach
			
			
			// 4. Dispose the StreamWriter
			
			
			// 5. Dispose the FileStream
			
		
		}
    }
}
