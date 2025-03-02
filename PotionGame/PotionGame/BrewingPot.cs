using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PotionGame
{
    internal class BrewingPot
    {
        public List<Ingredient> ingredients;
        public BrewingPot()
        {
            ingredients = new List<Ingredient>();
        }
        public void AddtoPot(Ingredient ingredient, Wallet wallet)
        {
            if (wallet.Spend(ingredient.ingredientPrice))
            {
                ingredients.Add(ingredient);
                Console.WriteLine(ingredient.ingredientName + " was added to the potion.");
                Console.WriteLine();
                Console.WriteLine("->     Press 'Enter' to continue.");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("!!   You don´t have enough money.    !!");
            }

        }
        public int CheckIngredientList()
        {
            return ingredients.Count;
        }

        public string Mix()
        {
            ingredients.Sort((x, y) => x.ingredientId.CompareTo(y.ingredientId));
            string ingredientsString = string.Join(",", ingredients.ConvertAll(i => i.ingredientId));
            ingredients.Clear();
            return ingredientsString;
        }
    }
}
