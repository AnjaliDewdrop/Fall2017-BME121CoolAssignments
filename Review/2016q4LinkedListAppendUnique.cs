using System;
using static System.Console;
using System.IO;

namespace Bme121.Q4
{
    class LinkedList
    {
        class Node
        {
            Node next;
            string data;
            
            public Node Next { get { return next; } set { next = value; } }
            public string Data { get { return data; } }
            
            public Node( string data ) { this.data = data; }
        }
        
        Node tail;
        Node head;
        int count;
        
        public int Count { get { return count; } }
        
        public LinkedList( ) { tail = null; head = null; count = 0; }
        
        public void AppendUnique( string data )
        {
			if( data == null ) throw new Exception( "Can't store null string in list." );
			///
			bool exists = false;
			// Using Forward Brute Force Search
			Node current = head;
			
			while(current != null)
			{
				// if the search value exists in the linked list, return a reference to the node that holds the value
				if(current.Data.Equals(data))
				{
					exists=true;
				}
				
				current = current.Next;
			}
			
			// If we've looped through the list and no nodes store the search value, then return null
			//return null;
			///
            if (!exists)
            {
				Node n = new Node( data );
				if( tail == null ) { tail = n; head = n; count = 1; }
				else { tail.Next = n; tail = n; count ++; }
			}
        }
        
        public string RemoveFirst( )
        {
            if( head == null ) throw new Exception( "Can't remove from empty list." );
            Node removed = head;
            head = head.Next; 
            count --;
            if( head == null ) { tail = null; }
            return removed.Data;
        }
    }
    
    static class Program
    {
        static void Main( )
        {
            LinkedList wordList = new LinkedList( );
            
            // Extract words from "The Canterville Ghost" and append to the list.
            // Words are all converted to upper case.
            // Words with non-ASCII characters are ignored.
            string path = "14522-8.txt";
            using( FileStream file = new FileStream( path, FileMode.Open, FileAccess.Read ) )
            using( StreamReader reader = new StreamReader( file ) )
            {
                string line = null;
                while( line != "THE CANTERVILLE GHOST" ) line = reader.ReadLine( );
                while( ! reader.EndOfStream )
                {
                    string[ ] words = line.Split( " -".ToCharArray( ) );
                    foreach( string word in words )
                    {
                        string trimmedWord = word.Trim( " ,.?!;:\'\"[]()+-|_".ToCharArray( ) ).ToUpper( );
                        bool keep = ! string.IsNullOrEmpty( trimmedWord );
                        foreach( char c in trimmedWord ) if( (int) c > 127 ) keep = false;
                        if( keep ) 
                        {
                            wordList.AppendUnique( trimmedWord );
                        }
                    }
                    if( line == "Virginia blushed." ) break;
                    line = reader.ReadLine( );
                }
            }
            
            // Remove the extracted words from the list and display them.
            int wordListCount = wordList.Count;
            int columnsUsed = 0;
            for( int i = 0; i < wordListCount; i ++ )
            {
                string removedWord = wordList.RemoveFirst( );
                Write( $"{removedWord} " );
                columnsUsed = columnsUsed + removedWord.Length + 1;
                if( columnsUsed > 70 ) { WriteLine( ); columnsUsed = 0; }
            }
            if( columnsUsed != 0 ) { WriteLine( ); }
            WriteLine( $"Extracted {wordListCount} words." );
        }
    }
}
