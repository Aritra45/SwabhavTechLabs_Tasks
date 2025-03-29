using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDesignPattern
{
    internal class PastaRecipe : Recipe
    {
        protected override void PrepareIngredients()
        {
            Console.WriteLine("Preparing pasta, sauce, and spices.");
        }

        protected override void Cook()
        {
            Console.WriteLine("Cooking the pasta and mixing it with sauce.");
        }
        protected override void Serve()
        {
            Console.WriteLine("Serving the Pasta.");
        }

    }
}
