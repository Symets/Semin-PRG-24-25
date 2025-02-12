using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassIntro
{
    internal class Program
    {
        static void Duel(Player player, Enemy enemy)
        {
            player.ShowState();
            enemy.ShowState();
            //ukáže nám to status postav po/před každém duelem
            while (player.IsAlive() && enemy.IsAlive())
            {
                enemy.Hurt(player.Attack());
                if (enemy.IsAlive())
                {
                    player.Hurt(enemy.Attack());
                }
            }
        }
        static void Main(string[] args)
        {
            Player player = new Player("Řehoř", 100, 10);
            int enemiesKilled = 0;
            Random rng = new Random();
            while (player.IsAlive()) //generování enemáků whil hráč žije
            {
                Enemy enemy = new Enemy(
                    "Enemy" + (enemiesKilled + 1),
                    20 + enemiesKilled * rng.Next(5, 10),
                    5 + enemiesKilled * rng.Next(2, 5),
                    1 + enemiesKilled
                    );
                // + enemiesKilled zvyšuje obtížnost podle "zkušeností"
                Duel(player, enemy);

            }
           
            //Enemy enemy1 = new Enemy("Bandit", 20, 3, 1);          
            //Duel(player, enemy1);           
            //Enemy enemy2 = new Enemy("Ghost", 30, 7, 3);
            //Duel(player, enemy2);
            //Console.ReadKey();
        }
    }
}
