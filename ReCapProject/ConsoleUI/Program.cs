using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemory());
            foreach(var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }

            Console.ReadKey();
        }
    }
}
