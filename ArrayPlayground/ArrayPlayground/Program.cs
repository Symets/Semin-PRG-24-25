using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti libovolnými čísly.
            int[] myArray = { 7, 69, 420, 42, 13 };
            Console.WriteLine("prvni clen je: " + myArray[1]); //pořadí se počítá od nuly takže v tomto případě 0=5 a 1=7 atd.
            // also existuje pole v poli O_o jako int[] my2DArray = {{2,1},{4,5},{7,8}}; - 2D představuje matici a 3D by přeedstavovalo pole matic.
            Console.WriteLine("vypsani pole pomoci for cyklu: ");
            for (int i = 0; i < myArray.Length; i++) 
            {
                Console.Write(myArray[i] + " "); //Console.WriteLine by každé čílso psala na nový řádek
            }
            Console.WriteLine();

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus jak klasický for, kde i využiješ jako index v poli, tak foreach.
            Console.WriteLine("vzpsani pole pomoci foreach: ");
            foreach (int number in myArray)  //(pro každý něco v něčem)
            {
                Console.Write(number + " ");
                //number je tady náhrada myArray[i]
            }
            Console.WriteLine();

            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0; //musime si nadefinovat sumu
            foreach (int number in myArray)
            {
                sum += number;
            }
            Console.WriteLine("Suma: " + sum);

            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            double avarage = (double)sum/myArray.Length;
            Console.WriteLine("Prumer: " + avarage);


            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = myArray[0];
            foreach (int number in myArray)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine("maximum: " + max);

            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min = myArray[0];
            for (int i = 1; i < myArray.Length; i++)
            {
                if (myArray[i] < min) //jednodušší metoda v případě když používáme člen pole jako porovnání
                {
                    min = myArray[i];
                }
            }
            Console.WriteLine("minimum: " + min);
            // existují jednoduché funkce jelikož pracujeme s chytrým polem, myArray.Min(); myArray.Max();

            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
           Console.Write("Vyhledat cislo: ");
            int numberToFind = int.Parse(Console.ReadLine());
            bool foundNumber = false; 
            //místo boolu můžu použít int, nastavij jeho hodnotu na -1, a když číslo najde tak stanovit ten int jako i (index)
            for (int i = 0; i < myArray.Length; i++)
            {
                if (numberToFind == myArray[i])
                {
                    Console.WriteLine("Cislo nalezeno na indexu " + i);
                    foundNumber = true;
                    break; //break je asi někde špatně cuz mi to nějak nefachá
                }
                else
                {
                    Console.WriteLine("Cislo nebylo nalezeno");
                }
            }

            //TODO 8: Přepiš pole na úplně nové tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9.
            Random rng = new Random();
            myArray = new int[100];//přepisuju tou 100 kolik členů bude pole mít
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rng.Next(0,10); // intervaly jsou <x,y) takže horní hodnota musí být akčuli větší než jakou chceme.
                Console.Write(myArray[i] + ", ");
            }
            Console.WriteLine();

            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach (int number in myArray)// ten foreach tady počíta kolik čeho kde je.
            {
                counts[number]++;
            }
            for (int i = 0; i < counts.Length; i++)// ten for jenom vypíše výsledky.
            {
                Console.WriteLine("Cetnost cislice " + i +": " + counts[i]);
            }

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] myArrayCopy = new int[100];
            for (int i = 0; i > myArrayCopy.Length; i++)
            {
                myArrayCopy[i] = myArray[(myArray.Length - 1) - i];
                Console.WriteLine(myArrayCopy[i]);
            }
            Console.WriteLine();
            //Zkus is dál hrát s polem dle své libosti. Můžeš třeba prohodit dva prvky, ukládat do pole prvky nějaké posloupnosti (a pak si je vyhledávat) nebo cokoliv dalšího tě napadne.

            Console.ReadKey();
        }
    }
}
