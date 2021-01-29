using GameProject.Concrete;
using GameProject.Entities;
using System;
using System.Collections.Generic;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //**********Customer Operations*****************//
            Customer customer = new Customer
            {
                BirthYear = new DateTime(1996, 07, 02),
                FirstName = "H",
                LastName = "O",
                IdNum = "1"
            };
            Customer customer2 = new Customer
            {
                BirthYear = new DateTime(1995, 08, 25),
                FirstName = "M",
                LastName = "O",
                IdNum = "2"
            };
            
            CustomerManager customerManager = new CustomerManager();
            
            //customer adding
            customerManager.Add(customer);
            customerManager.Add(customer2);
            
            //customer deleting
            customerManager.Delete(customer);
            customerManager.Delete(customer2);
            //customer updating
            customerManager.Update(customer);
            customerManager.Update(customer2);

            //*******************************Game Operations******************************************//
            Game game = new Game()
            {
                GameId=1, GameName="GTA", GamePrice=10
            };
            Game game2 = new Game()
            {
                GameId = 2, GameName="PUBG", GamePrice=20
            };
            GameManager gameManager = new GameManager();
            //game adding
            gameManager.Add(game);
            gameManager.Add(game2);
            //game deleting
            gameManager.Delete(game);
            gameManager.Delete(game2);
            //game updating
            gameManager.Update(game);
            gameManager.Update(game2);
            //game sale
            gameManager.SaleGame(game,customer);
            //game listing
            gameManager.List();
            //************************Campain Operations************************//

            Campain campain = new Campain()
            {
                CampainId = 1, CampainName = "Black Friday", Discount = 20
            };
            Campain campain2 = new Campain()
            {
                CampainId = 2, CampainName="June-July Months Campain", Discount=15
            };
            Campain campain3 = new Campain()
            {
                CampainId = 3, CampainName = "Birthday Discount", Discount = 25
            };
            
            CampainManager campainManager = new CampainManager();
            //campain adding, deleting and updating
            campainManager.Add(campain);
            campainManager.Add(campain2);
            campainManager.Add(campain3);
            campainManager.Delete(campain);
            campainManager.Delete(campain2);
            campainManager.Update(campain);
            campainManager.Update(campain2);
            //campain price calculate
            campainManager.CalculatePricewithCampain(game2,campain);
            campainManager.CalculatePricewithCampain(game, campain2);
            //used campain
            campainManager.List();
            Console.ReadKey();
        }
    }
}
