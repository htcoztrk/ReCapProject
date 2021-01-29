using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    class CampainManager
    {
        List<Campain> usedCampains = new List<Campain>();
        public void Add(Campain campain)
        {
            Console.WriteLine(campain.CampainName+" added.");
        }
        public void Update(Campain campain)
        {
            Console.WriteLine(campain.CampainName + " updated.");
        }
        public void Delete(Campain campain)
        {
            Console.WriteLine(campain.CampainName + " deleted.");
        }
        public void CalculatePricewithCampain(Game game, Campain campain)
        {
           
            int NewPrice = game.GamePrice - (game.GamePrice * campain.Discount) / 100;
            Console.WriteLine(game.GameName + " " + "game price calculated with " + campain.CampainName+". New price is: "+NewPrice);
            foreach(var i in usedCampains)
            {
                if (i.CampainName == campain.CampainName)
                {
                    break;
                }
                else
                {
                    usedCampains.Add(campain);
                }
            }
        }
        public void List()
        {
            foreach(var u in usedCampains)
            {
                Console.WriteLine(u.CampainName);
            }
        }

    }
}
