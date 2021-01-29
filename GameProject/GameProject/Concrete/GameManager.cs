using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    class GameManager
    {
        List<Game> saledGames = new List<Game>();
        public void Add(Game game)
        {
            Console.WriteLine("Game added.");     
        }
        public void Update(Game game)
        {
            Console.WriteLine("Game info updated");
        }
        public void Delete(Game game)
        {
            Console.WriteLine("Game deleted.");
        }
        public void SaleGame(Game game,Customer customer)
        {
            Console.WriteLine(game.GameName + "is saled to " + customer.FirstName + " " + customer.LastName);
            foreach ( var g in saledGames)
            {
                if (g.GameName==game.GameName)
                {
                    break;
                }
                else
                {
                    saledGames.Add(game);
                }
            }
        }
        public void List()
        {
            foreach(var saledGame in saledGames)
            {
                Console.WriteLine(saledGame.GameName);
            }
        }
        
    }
}
