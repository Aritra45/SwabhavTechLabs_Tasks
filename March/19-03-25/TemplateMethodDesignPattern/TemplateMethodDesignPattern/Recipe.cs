using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDesignPattern
{
    internal abstract class Recipe
    {
        public void PrepareDish()
        {
            PrepareIngredients();
            Cook();
            Serve();
        }
        protected abstract void PrepareIngredients();
        protected abstract void Cook();
        protected virtual void Serve()
        {
            Console.WriteLine("Serving the dish.");
        }

    }
}
