using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionGame
{
    internal class Potion
    {
        public string namePotion;
        public List<string> recipes;

       public Potion (string namePotion, List<string> recipes)
        {
            this.namePotion = namePotion;
            this.recipes = recipes;
        }
    }
}
