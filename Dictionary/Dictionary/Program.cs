using System;
using System.Collections.Generic;

namespace Dictionaryy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> myList = new Dictionary<int,string>();
            myList.Add(1, "H");
            myList.Add(2, "M");
           
            foreach(KeyValuePair<int,string> person in myList)
            {
                Console.WriteLine("{0}.person is {1}",person.Key,person.Value);
            }
            Console.WriteLine("Count is: " + myList.Count);

            MyDictionary<int,string> myDictionary = new MyDictionary<int,string>();
            myDictionary.Add(1, "X.O");
            myDictionary.Add(2,"Y.O");
            myDictionary.Add(3, "Z.O");

            //Listing
            myDictionary.List();          
            Console.WriteLine("MyDictionary's Count: "+myDictionary.Count);

            Console.ReadKey();
        }
    }
}
