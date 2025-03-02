using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PotionGame
{
    internal class Program
    {
        //diagram/solution is located in DesignDocument/PotionGameSolution.pdf
        //character doodles are located in DesignDocument/potionGameCharacters.png

        static void Main(string[] args)
        {
            //definding classes
            Wallet wallet = new Wallet(50, 10);

            BrewingPot brewingPot = new BrewingPot();

            Customer customer1 = new Customer("Nurse Joy", new Potion("Medicine for a kid", new List<string> { "1,3", "1,1,3", "1,1,1,3", "1,1,3,3", "2,5", "2,2,5", "2,2,2,5", "1,1,2,5", "1,2,5", "1,2,2,5" }), "Hi there. I need some medicine for a kid, so could you make it so it's nice and tasty? Thank you.");
            Customer customer2 = new Customer("Kyle", new Potion("To become a furry", new List<string> { "6,6", "6,6,6", "6,6,6,6", "1,6,6", "1,1,6,6", "1,6,6,6", "3,6,6", "3,3,6,6", "3,6,6,6", "6,6,7", "6,6,7,7", "6,6,6,7" }), "Hewwo!OwO. I nwed a pwotion that cwould trun me into a wreal fuwwy!! U//w//U");
            // i don't get paid for this (._.), this better be funny, please laugh
            Customer customer3 = new Customer("Anonymous", new Potion("To kill someone", new List<string> { "1,2", "1,1,2", "1,1,1,2", "1,1,2,2", "3,5", "3,3,5", "3,3,3,5", "7,7,7,7" }), "Listen kid, i need something to kill someone with it, so make sure it isn't unnoticeable when i pour it into their drink.");
            Customer customer4 = new Customer("Prince Charming", new Potion("To defeat a dragon", new List<string> { "4,6", "3,4,6", "3,4,6,7", "4,6,7", "2,2,8", "1,2,2,8", "2,2,2,8", "4,4,6,6", "3,3,5,8", "4,5,8", "4,4,5,8" }), "Hello, hello my dear brewer~! I am on a quest to defeat an evil dragon, but i need something to help me defeat it. (*flicks his long golden luscious hair that he seem to care about very much*)");
            Customer customer5 = new Customer("P*ssed off mother", new Potion("Reverse the furry", new List<string> { "5,6,6", "5,6,6,6", "4,4", "4,4,4", "4,4,4,4", "1,4,4", "1,1,4,4", "1,4,4,4", "2,5,6,6", "2,5,6,7" }), "I leave him unattended for day or two AND HE TURNS HIMSELF INTO A TALKING DOG WHATEVERTHING?! Can you PLEASE, do something to fix this.");
            Customer customer6 = new Customer("Student", new Potion("Intelligence boost", new List<string> { "5,7", "5,7,7", "5,7,7,7", "2,5,7", "2,5,7,7" }), "I got a test tmrw, make me smarted.");
            Customer customer7 = new Customer("Army general", new Potion("Undefeatable army", new List<string> { "4,8", "4,4,8", "4,4,4,8", "6,6,8", "6,6,6,8", "3,4,8", "3,4,4,8", "3,3,4,8", "4,7,8", "4,4,7,8", "4,7,7,8", "3,4,7,8", "3,6,6,8", "6,6,7,8", "4,6,6,8" }), "I am going to lead my army to war. I need you to make something that would make my army undefeatable. I'll pay you well.");
            List<Customer> customers = new List<Customer> { customer1, customer2, customer3, customer4, customer5, customer6, customer7 };

            Ingredient ingredient1 = new Ingredient(1, "Flower petals", 10, "Neutralizes unappealing taste and odor, use equal amount as bad smelling/tasting ingredients");
            Ingredient ingredient2 = new Ingredient(2, "Frog", 10, "Poisonous, for larger creatures, higher amount is required. It also has a strong discusting smell.");
            Ingredient ingredient3 = new Ingredient(3, "Medicinal herbs", 10, "Has a healing factor, but it has a bitter taste.");
            Ingredient ingredient4 = new Ingredient(4, "Dragon's blood", 10, "Gives temporary strenght, but causes hair loss. 'The powerful are always bald.' -Sun Tzu");
            Ingredient ingredient5 = new Ingredient(5, "Liquid mirror", 10, "Reverses effects of every ingredient, except for the fart of a little elf.");
            Ingredient ingredient6 = new Ingredient(6, "Rosemary oil", 10, "Enchaces hair growth. Careful! In larger quantities, it turns the subject into a hairy beast!");
            Ingredient ingredient7 = new Ingredient(7, "Poppy", 10, "Increases bravery, but it has a negative effect on subject's intelligence. Careful!! If consumed in extreme quantities, the subject will die due to overdose!");
            Ingredient ingredient8 = new Ingredient(8, "Fart of a little elf", 10, "Transforms the potion from a liquid to gas. It is useful for remote aplication or affecting more than one subject at once.");
            List<Ingredient> ingredientList = new List<Ingredient> { ingredient1, ingredient2, ingredient3, ingredient4, ingredient5, ingredient6, ingredient7, ingredient8 };

            int dayCounter = 1;

            //jelikož to je absolutní stěna kódu, tak jsem kód na introduction screen šoupla do vlastní fuknce
            IntroductionScreen();

            foreach (Customer customer in customers)
            {
                Console.Clear();
                Console.WriteLine("Day: " + dayCounter);
                customer.Ordering();
            
                Console.WriteLine("->     Press 'Enter' to continue.");
                Console.ReadLine();

                string mixture = string.Empty;
                bool willMix = false;
                while (!willMix)
                {
                    bool validInput = false;
                    while (!validInput)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ingredient shop: ");
                        foreach (var ingredient in ingredientList)
                        {
                            ingredient.DisplayIngredient();
                        }
                        Console.WriteLine();
                        Console.WriteLine("->     Choose an ingredient by typing its number 1-" + ingredientList.Count + " (example: 2).");

                        if (int.TryParse(Console.ReadLine(), out int ingredientNumber) && ingredientNumber >= 1 && ingredientNumber <= ingredientList.Count)
                        {
                            Ingredient ingredient = ingredientList.Find(ing => ing.ingredientId == ingredientNumber);
                            if (ingredient != null)
                            {
                                brewingPot.AddtoPot(ingredient, wallet);
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("!    Invalid ingredient number.  !");
                            }
                        }
                        else
                        {
                            Console.WriteLine("!    Invalid input. Please enter a number between 1 and " + ingredientList.Count + "    !");
                        }
                    }
                    if (brewingPot.CheckIngredientList() > 1 && brewingPot.CheckIngredientList() < 4 && wallet.Check())
                    {
                        bool mixValidInput = false;
                        while (!mixValidInput)
                        {
                            Console.WriteLine("->     If you want to mix the pointion press 'M' if you want to add more ingredients press 'I' (example: m)");
                            string input = Console.ReadLine().ToUpper();
                            if (input == "M")
                            {
                                mixValidInput = true;
                                willMix = true;
                                mixture = brewingPot.Mix();
                            }
                            else if (input == "I")
                            {
                               mixValidInput = true;
                            }
                            else
                            {
                                Console.WriteLine("!    Invalid input. Please try again.    !");
                            }
                        }
                    }
                    else if (brewingPot.CheckIngredientList() == 1 && !wallet.Check())
                    {
                        Console.WriteLine("!!   You don´t have enough money to buy more ingredients.    !!");
                        willMix = true;
                        break;
                    }
                    else if (brewingPot.CheckIngredientList() == 1 && wallet.Check())
                    {
                        Console.WriteLine("->     Pick another ingredient to add.");
                    }
                    else
                    {
                        mixture = brewingPot.Mix();
                        willMix = true;
                    }
                
                }
                customer.Recieveing(mixture, wallet);
                if (wallet.Check())
                {
                    Console.WriteLine("->     No more customers will come, go to sleep, to start the next day (press 'Enter').");
                    Console.ReadLine();
                }
                else{
                    break;
                }
                dayCounter ++;
            }
            Console.WriteLine(new string('-', 40));
            if (wallet.Check())
            {
                Console.WriteLine("All customers have been served, you win.");
            }
            else
            {
                Console.WriteLine("You went bankrupt, you lost.");
            }
            Console.WriteLine(new string('-', 40));

            Console.ReadKey();
        }
        static void IntroductionScreen()
        {
            Console.WriteLine("\t _   _ \\\\//       _     ___              _ \r\n\t| | | |_\\/_ _   _| |__ /_/ | _______   _(_)\r\n\t| |_| | '__| | | | '_ \\| | |/ / _ \\ \\ / / |\r\n\t|  _  | |  | |_| | |_) | |   < (_) \\ V /| |\r\n\t|_| |_|_|   \\__,_|_.__/|_|_|\\_\\___/ \\_/ |_|\r\n\t                   \\\\//                    \r\n\t _ __   ___  _   _ _\\/ _ __  _   _         \r\n\t| '_ \\ / _ \\| | | / __| '_ \\| | | |        \r\n\t| |_) | (_) | |_| \\__ \\ | | | |_| |        \r\n\t| .__/ \\___/ \\__,_|___/_| |_|\\__, |        \r\n\t|_|                          |___/         \r\n");
            Console.WriteLine("->     Press 'Enter' to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Lore:");
            Console.WriteLine();
            Console.WriteLine("     Your uncle Shmoora, he owns a modest potion business, but he had to go on a 7-day trip expedition. Since the shop is small, Shmoora cannot afford not to work even one day, and therefore he asked you, his nephew Hrubik, to run his shop during his absence.\r\n\tEvery day, different customers visit the stand and are interested in buying some potion with specific effect. Therefore, according to the requirements, Hrubik must mix the potion from the correct ones ingredients and must keep the business afloat until Uncle Shmoora returns.");
            Console.WriteLine();
            Console.WriteLine("->     Press 'Enter' to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Instructions");
            Console.WriteLine();
            Console.WriteLine("     You need to mix a potion, according to the customers' requests. A potion contains 2 to 4 ingredients, each ingredient can be used multiple times in a potion. There are some ingredients with opposite effects to other ingredients, if the amount of the opposing ingredients is equal, some of their effects are neutralized.");
            Console.WriteLine();
            Console.WriteLine("     Read EVERY ingredient description CAREFULLY before brewing up a potion, who knows what details you might miss.");
            Console.WriteLine();
            Console.WriteLine("->     Press 'Enter' to continue.");
            Console.ReadLine();
        }
    }
}
