using CommandMethodDesignPattern.Command;
using CommandMethodDesignPattern.Model;
using CommandMethodDesignPattern.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        FoodRepository foodRepository = new FoodRepository();

        var invoker = new CommandInvoker();
        invoker.AddOrderCommand(new AddFoodCommand(foodRepository, new Foods { Id = 1, FoodName = "Biriyani" }));
        invoker.AddOrderCommand(new AddFoodCommand(foodRepository, new Foods { Id = 2, FoodName = "Roll" }));
        invoker.AddOrderCommand(new UpdateFoodCommand(foodRepository, 2, "VegRoll"));

        invoker.ExecuteCommand();
    }
}