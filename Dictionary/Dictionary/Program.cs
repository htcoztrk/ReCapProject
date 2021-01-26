using System;
using System.Collections.Generic;

namespace MyDictionary
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

            Console.ReadKey();
        }
    }
}
