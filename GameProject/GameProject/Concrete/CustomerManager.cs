using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    class CustomerManager
    {
        public void Add(Customer customer)
        {
          Console.WriteLine(customer.FirstName+" "+customer.LastName+"added sucesfully");
        }
        public void Update(Customer customer)
        {
            Console.WriteLine("User information with Id number "+customer.IdNum+"has been updated.");
        }
        public void Delete(Customer customer)
        {
            Console.WriteLine("User deleted.");
        }


    }
}
