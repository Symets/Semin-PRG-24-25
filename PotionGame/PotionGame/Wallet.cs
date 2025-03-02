using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PotionGame
{
    public class Wallet
    {
        public int Amount;
        private int Minimum;
        
        public Wallet(int Amount, int Minimum) 
        {
            this.Amount = Amount;
            this.Minimum =Minimum;
        }
        public bool Spend(int price)
        {
            if (Amount >= price)
            {
                Amount -= price;
                DisplayAmount();
                return true;
            }
            return false;
        }

        public void Receive(int pricePotion)
        {
            Amount += pricePotion;
        }

        public void DisplayAmount()
        {
            Console.WriteLine("Amount in wallet: " + Amount);
        }

        public bool Check()
        {
            return Amount >= Minimum;
        }
    }

}

