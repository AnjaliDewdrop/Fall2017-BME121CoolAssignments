using System;
using static System.Console;
using System.IO; // You have to have this to use FILE I/O

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
			int numPrime = 0;	// store how many prime number there are within the range
			int [] primeNumber; // store the prime numbers
			
			using (FileStream outFile=new FileStream ("primes.txt", FileMode.Open, FileAccess.Read))
			{
				using (StreamReader reader = new StreamReader(outFile))
				{
					while (!reader.EndOfStream)
					{
						string line = reader.ReadLine();
						numPrime++;
					}
					outFile.Seek(0,  SeekOrigin.Begin);
					primeNumber = new int [numPrime];
					int i=0;
					while (!reader.EndOfStream)
					{
						primeNumber[i]=int.Parse(reader.ReadLine());
						i++;
					}
				}
			}
			/*
			primeNumber = new int [numPrime];
			using (FileStream outFile=new FileStream ("primes.txt", FileMode.Open, FileAccess.Read))
			{
				using (StreamReader reader = new StreamReader(outFile))
				{
					int i=0;
					while (!reader.EndOfStream)
					{
						primeNumber[i]=int.Parse(reader.ReadLine());
						i++;
					}
				}
			}*/
			
			// Please add your code here to read the prime numbers from file
			// To guide you, pseudo are provided
			// What you need to do now: 
			// a. Read the file and count how many prime
			// b. Read the file again to store the prime
			
			// 1. Create a FileStream to open a file. Use FileMode.Open to open the file
			// and FileAccess.Read to gain read access.
			
			
			// 2. Create a StreamReader linked to FileStream you created above
			
			
			// 3. Use ReadLine to read the file
			// use reader.EndOfStream to check whether you have reached the end of file
			
			
			// 4. Reset the reading pointer to start of file; Given
			//inFile.Seek(0,  SeekOrigin.Begin);
			
			// 5. Create an integer array to hold the prime number

			
			// Display: Given
			WriteLine($"There are {numPrime} prime numbers in the file");
			for (int i=0;i<numPrime;i++)
			{
				WriteLine(primeNumber[i]);
				//WriteLine(numPrime);
			}
				
			
			
			// 5. Dispose the StreamReader

			
			// 6. Dispose the FileStream

		
		}
    }
}

