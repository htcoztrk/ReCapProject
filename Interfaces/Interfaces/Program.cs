using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //can't use 'new' keyword for interfaces!!!
            IPersonManager customerManager = new CustomerManager();

            IPersonManager employeeManager = new EmployeeManager();

            IPersonManager internManager = new InternManager();

            ProjectManager projectManager = new ProjectManager();
            projectManager.Add(customerManager);
            projectManager.Add(employeeManager);



            Console.ReadKey();
        }
    }
    interface IPersonManager
    {
        void Add();
        void Update();
    }
    // inherits classes implements interface
    class CustomerManager : IPersonManager
    {
        public void Add()
        {
            Console.WriteLine("Customer Added");
        }

        public void Update()
        {
            Console.WriteLine("Customer Updated");
        }
    }
    class EmployeeManager : IPersonManager
    {
        public void Add()
        {
            Console.WriteLine("Employee Added");
        }

        public void Update()
        {
            Console.WriteLine("Employee Updated");
        }
    }
    class InternManager : IPersonManager
    {
        public void Add()
        {
            Console.WriteLine("Intern Added");
        }

        public void Update()
        {
            Console.WriteLine("Intern Updated");
        }
    }

    class ProjectManager
    {
        public void Add(IPersonManager personManager)
        {
            personManager.Add();
        }
    }

}
