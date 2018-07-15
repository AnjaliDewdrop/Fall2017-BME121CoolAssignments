using System;
using static System.Console;
using System.IO; // You have to have this to use FILE I/O

namespace Bme121
{
	class subject
	{
		public int StudentID;
		public string Type;
		public int Time;
		
		public subject()
		{
			this.StudentID = 0;
			this.Type = "Standard";
			this.Time = 0;
		}
		
		public subject(string ID, string type, string time)
		{
			this.StudentID = int.Parse(ID);
			this.Type = type;
			this.Time = int.Parse(time);
		}
		
		public override string ToString( ) 
        {
			return ($"ID:{this.StudentID,-3}{this.Type,-10}{this.Time,-4}");
		}
	}
	
    static class Program
    {
        static void Main( )
        {
			//
			
			int numRecord = 0;	// store how many record in the file
			subject [] gameSubject; // store the records
			const char DELIM = ','; // the delimiter/separater for file
			
			// Please add your code here to read the prime numbers from file
			// To guide you, pseudo are provided
			// What you need to do now: 
			// a. Read the file and count how many record
			// b. Read the file again to fill the gameSubject array
			
			// 1. Create a FileStream to open a file. Use FileMode.Open to open the file
			// and FileAccess.Read to gain read access.
			FileStream inFile = new FileStream("games.csv", FileMode.Open, FileAccess.Read);
			
			// 2. Create a StreamReader linked to FileStream you created above
			StreamReader reader = new StreamReader(inFile);
			// 2b. Read and discard the first line as it is not a record
			reader.ReadLine();
			
			// 3. Use ReadLine to read the file
			while (!reader.EndOfStream)
			{
				reader.ReadLine();
				numRecord++;
			}
			
			// 4a. Reset the reading pointer to start of file: Given
			inFile.Seek(0,  SeekOrigin.Begin);
			// 4b. Read and discard the first line as it is not a record
			reader.ReadLine();
			
			// 5. Allocate an subject array to hold the prime number
			gameSubject = new subject [numRecord];
			string recordIn;
			string [] fields;
			
			for (int i=0;i<numRecord;i++)
			{
				recordIn = reader.ReadLine();
				fields = recordIn.Split(DELIM);
				gameSubject[i] = new subject(fields[0], fields[1], fields[2]);
			}
			
			// Display: Given
			WriteLine($"There are {numRecord} records in the file");
			WriteLine("{0,-6}{1,-10}{2,-4}","ID", "Type", "Time");
			for (int i=0;i<numRecord;i++)
			{
				if (gameSubject[i].Type=="Color")
				{
					WriteLine(gameSubject[i]);
				}
			}
				
			
			
			// 5. Dispose the StreamReader
			reader.Dispose();
			
			// 6. Dispose the FileStream
			inFile.Dispose();
		
		}
    }
}
