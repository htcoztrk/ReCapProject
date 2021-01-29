using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    class GameManager
    {
        public void Add(Game game)
        {
            Console.WriteLine("Game added.");     
        }
        public void Update(Game game)
        {
            Console.WriteLine("Game info updated");
        }
        public void Delete()
        {
            Console.WriteLine("Game deleted.");
        }
        public void SaleGame(Game game,Customer customer)
        {

        }
        
    }
}
