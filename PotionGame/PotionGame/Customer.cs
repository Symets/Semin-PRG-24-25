using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PotionGame
{
    internal class Customer
    {
        public string nameCustomer;
        public Potion favouritePotion;
        public string story;

        public Customer(string nameCustomer, Potion favouritePotion, string story) 
        {
            this.nameCustomer = nameCustomer;
            this.favouritePotion = favouritePotion;
            this.story = story;
        }

        public void Ordering()
        {
            Console.WriteLine(nameCustomer + ": " + story);
        }

        public void Recieveing(string potMix, Wallet wallet)
        {
            //figuring out the games economy took at leat 3 years of my life
            int amountIngredients = ((potMix.Length + 1)/2)*15;
            bool recipeFound = false;
            Console.WriteLine();
            //Console.WriteLine(potMix);
            foreach (var recipe in favouritePotion.recipes)
            {
                if (potMix == recipe)
                {
                    wallet.Receive(amountIngredients);
                    Console.WriteLine("Customer is pleased and pays you the full price.");
                    recipeFound = true;
                    break;
                }
            }
            if (!recipeFound)
            {
                Console.WriteLine("Customer is dissapointed and leaves the store.");
            }
            wallet.DisplayAmount();
            Console.WriteLine();
        }
    }
}
