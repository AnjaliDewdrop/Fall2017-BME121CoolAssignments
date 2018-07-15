using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace Bme121.Q3
{
    class BabyName
    {
		string year;
		public string Year
		{
			get
			{
				return year;
			}
		}
		
		string name;
		public string Name
		{
			get
			{
				return name;
			}
		}
		string sex;
		public string Sex
		{
			get
			{
				return sex;
			}
		}
		string count;
		public string Count
		{
			get
			{
				return count;
			}
		}
		
		public BabyName(string year, string name, string sex, string count)
		{
			this.year=year;
			this.name=name;
			this.sex=sex;
			this.count=count;
		}
		
    }
    
    static class Program
    {
        static void Main( )
        {
			//
			const char DELIM=',';
			List< BabyName > babyNames = new List< BabyName >( );
            
            string path = "Baby_Names__Trending_by_Name__Beginning_2007.csv";
            
            
			using (FileStream file =  new FileStream (path, FileMode.Open, FileAccess.Read))
			{
				using(StreamReader reader = new StreamReader(file))
				{
					string line = reader.ReadLine();
					
					while (!reader.EndOfStream)
					{
						string recordIn=reader.ReadLine();
						string [] field= recordIn.Split(DELIM);
						
						BabyName recent = new BabyName(field[0], field[1], field[2], field[3]);
						
						babyNames.Add(recent); 
					}
				}
			}
			
			
			for (int i=0; i<babyNames.Count; i++)
			{
				if (babyNames[i].Name.StartsWith('E'))
				{
					WriteLine(babyNames[i].Name);
				}
			}
					
            
            
            
            WriteLine( $"babyNames.Count = {babyNames.Count}" );
        }
    }
}
