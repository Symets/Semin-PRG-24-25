using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionGame
{
    internal class Ingredient
    {
        public int ingredientId;
        public string ingredientName;
        public int ingredientPrice;
        public string description;
        public Ingredient(int ingredientId, string ingredientName, int ingredientPrice, string description)
        {
            this.ingredientId = ingredientId;
            this.ingredientName = ingredientName;
            this.ingredientPrice = ingredientPrice;
            this.description = description;
        }

        public void DisplayIngredient()
        {
            Console.WriteLine(ingredientId + ". " + ingredientName + ", Price:" + ingredientPrice + "$");
            Console.WriteLine(description);
            Console.WriteLine(new string('-', 40));
        }

    }
}

