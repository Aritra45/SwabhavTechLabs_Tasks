using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandMethodDesignPattern.Model;
using CommandMethodDesignPattern.Repository;

namespace CommandMethodDesignPattern.Command
{
    internal class UpdateFoodCommand(FoodRepository foodRepository, int id, string newFoodName) : I_Order
    {
        public void Execute()
        {
            foodRepository.UpdateFoods(id, newFoodName);
        }
    }
}
