using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassIntro
{
    internal class Player
    {
        public string name;
        public int health;
        private int damage; //private je default i think
        Random rng;
        public Player(string name, int health, int damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            rng = new Random();
        }
        //umožní nám to rovnou nastavit hodnoty v jednom řádku

        public void SetDamage(int value)
        {
            damage = value;
            if (damage > 0)
            {
                damage = 1;
            }
        }
        public int GetDamage()
        {
            return damage;
        }
        public void Hurt(int incomingDamage)
        {
            health -= incomingDamage;
            Console.WriteLine("Player " + name + " took " + incomingDamage + " damage!");
            Console.WriteLine("Enemy health remaining: " + health);
            if (health <= 0)
            {
                Console.WriteLine("     Player is dead!");
            }
        }
        public int Attack()
        {
            return rng.Next(damage / 2, damage + damage / 2 + 1);
        }
        public bool IsAlive() 
        {
            return health > 0;
        }
        public void ShowState()
        {
            Console.WriteLine("Player " + name + " has " + health + " health and deals " + damage + " damage");
        }
    }
}
