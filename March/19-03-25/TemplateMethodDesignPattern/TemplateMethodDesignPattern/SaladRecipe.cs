using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDesignPattern
{
    internal class SaladRecipe : Recipe
    {
        protected override void PrepareIngredients()
        {
            Console.WriteLine("Chopping vegetables and preparing dressing.");
        }

        protected override void Cook()
        {
            Console.WriteLine("Tossing the vegetables with the dressing.");
        }

    }
}
