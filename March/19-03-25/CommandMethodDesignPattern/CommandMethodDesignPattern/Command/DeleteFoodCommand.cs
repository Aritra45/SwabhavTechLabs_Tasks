using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandMethodDesignPattern.Repository;

namespace CommandMethodDesignPattern.Command
{
    internal class DeleteFoodCommand (FoodRepository foodRepository, int id) : I_Order
    {
        public void Execute()
        {
            foodRepository.DeleteFoods(id);
        }
    }
}
