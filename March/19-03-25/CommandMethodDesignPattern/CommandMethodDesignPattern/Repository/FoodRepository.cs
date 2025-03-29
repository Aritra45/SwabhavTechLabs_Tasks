using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommandMethodDesignPattern.Model;

namespace CommandMethodDesignPattern.Repository
{
    internal class FoodRepository
    {
        private List<Foods> foods= new List<Foods>();

        public void AddFoods(Foods food)
        {
            foods.Add(food);
            Console.WriteLine($"Food {food.FoodName} added...");
        }
        
        public void UpdateFoods(int id, string newFood)
        {
            bool isIDFound = false;
            foreach (Foods food in foods)
            {
                
                if (food.Id == id)
                {
                    isIDFound = true;
                    food.FoodName = newFood;
                    Console.WriteLine($"Food {id} updated to {food.FoodName}");
                    break;
                }
               
                
            }
            if (!isIDFound)
            {
                Console.WriteLine($"Food {id} not found");
            }
        }

        public void DeleteFoods(int id)
        {
            foreach (Foods food in foods)
            {
                if (food.Id == id)
                {
                    foods.Remove(food);
                    Console.WriteLine($"Food {id} deleted");
                    break;
                }

            }
            Console.WriteLine($"Food {id} not found");
        }
    }
}
