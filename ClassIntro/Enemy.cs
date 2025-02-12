using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassIntro
{
    internal class Enemy
    {
        string name;
        int health;
        int damage;
        int level;
        Random rng;

        public Enemy(string name, int health, int damage, int level)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.level = level;
            rng = new Random();
        }
        public void Hurt(int incomingDamage)
        {
            health -= incomingDamage;
            Console.WriteLine("Enemy " + name + " took " + incomingDamage + " damage!");
            Console.WriteLine("Enemy health remaining: " + health);

            if(health <= 0)
            {
                Console.WriteLine("     Enemy is dead!");
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
            Console.WriteLine("Enemy " + name + " has " + health + " health and deals " + damage + " damage");
        }
    }
}
