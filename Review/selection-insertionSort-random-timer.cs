using System;
using static System.Console;
using System.Diagnostics;

namespace Bme121
{
    static class Program
    {
        static Random rGen = new Random( );
        
        // Create an integer array filled with random values.
        
        static int[ ] NewRandomArray( int size )
        {
            if( size < 1 ) return new int[ 0 ];
            
            int[ ] result = new int[ size ];
            
            for( int i = 0; i < result.Length; i ++ )
            {
                result[ i ] = rGen.Next( 0, size );
            }
            
            return result;
        }
        
        // Write up to 10 elements of an integer array.
        
        static void WriteArray( int[ ] a )
        {
            for(int i= 0; i< a.Length-1; i++){
                Write($"{a[i]}, ");
            }
            WriteLine($"{a[a.Length-1]}");
        }
        
        // Selection sort - sorts integers into increasing order.
        
        static void SelectionSort( int[ ] a )
        {
            if (a==null) return;
            if (a.Length<2) return;
            for (int firstUnsorted = 0; firstUnsorted<a.Length-1; firstUnsorted++)
            {
				int min=firstUnsorted;
				for (int i = firstUnsorted+1; i<a.Length; i++)
				{
					if (Compare(a[i], a[min])<0) min =i;
				}
				int temp = a[min];
				a[min]=a[firstUnsorted];
				a[firstUnsorted]=temp;
				
            }
        }
        
        static int Compare(int a, int b)
        {
			if (a<b) return -1;
			if (a>b) return 1;
			return 0; 
		}

        // Insertion sort - sorts integers into increasing order.
        
        static void InsertionSort( int[ ] a ) 
        {
            if (a == null) return;
            if (a.Length<2) return;
            for (int firstUnsorted =1; firstUnsorted <a.Length; firstUnsorted ++)
            {
				int hole = firstUnsorted;
				int temp = a[hole];
				while (hole>0 && Compare(temp, a[hole-1])<0)
				{
					a[hole] = a[hole-1];
					hole =hole-1;
				}
				a[hole]=temp;
			}
			
        }
        
        // Comparison method - returns -1, 0, +1 if 'a' is <, =, > 'b', respectively.
        
       
        // Test sorting.
        
        static void Main( )
        {
            int[ ] data1 = NewRandomArray( size: 50 );
            int[ ] data2= NewRandomArray(size:50);
            
            WriteLine( "Unsorted" );
            WriteArray( data1 );
            
            Stopwatch timer1 = new Stopwatch( );
            Stopwatch timer2 = new Stopwatch( );
            // use the timers to time the sorts
            
            timer1.Start();
            SelectionSort(data1);
            timer1.Stop();
            
            timer2.Start();
            InsertionSort(data2);
            timer2.Stop();
            
            WriteLine( "Sorted" );
            WriteArray(data1);
            WriteLine("Time: "+ timer1.Elapsed);
            
            WriteLine( "Sorted" );
            WriteArray(data2);
            WriteLine("Time: "+ timer2.Elapsed);

            // print the sorted array (either one)
            // print out the times
        }
    }
}
