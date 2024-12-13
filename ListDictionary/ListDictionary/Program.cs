using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDictionary
{
    internal class Program
    {
        static void PrintList(myList<string>myList) //tady je něco špatně cuz nepamatuju si co jde místo toho myList
        {
            foreach(string name in myList)
            {
                Console.WriteLine(name);
            }
        }

        static void Main(string[] args)
        {
            List<string> myList = new List<string>();
            myList.Add("Škoda");
            myList.Add("Lada");
            myList.Add("Koenigsagg");
            myList.Add("Smart");
            myList.Add("McMurtry");

            PrintList(myList);
            myList.remove("Lada");
            PrintList(myList);
            myList.RemoveAt(2); 
            PrintList(myList);
            if(myList.Exists(carMaker => carMaker.StartsWith("M")))
            {
                Console.WriteLine("V listu je automobil na M");
            } else
            {
                Console.WriteLine("V listu není automobil na M");
            }
            Dictionary<string, string> germanToCzech = new Dictionary<string, string>();
            germanToCzech["Wasser"] = "Voda";
            germanToCzech["Krankenhaus"] = "Nemocnice";
            germanToCzech["Natuwissenschaft"] = "Věda";
            germanToCzech["Bundersprasidentenstischwahlwiederholungsverschiebung"] = "Odložení konání voleb s polkového prezidenta";

            foreach(KeyValuePair<string, string> translation in germanToCzech)
            {
                string germanWord = translation.Key;
                string czechWord = translation.Value;
                Console.WriteLine("Překlad slova" + germanWord + " je " + czechWord);
            }
            if (germanToCzech.ContainsKey("Wasser")) ;
            {
                Console.WriteLine("Slovník obsahuje překlad slova Wasser");
            }
            else
            {
                Console.WriteLine("Slovník neobsahuje překlad slova Wasser");
            }
            Console.ReadKey();
            //na doma je optional domácí úkol, na známky to je pouze pokud chceme lol
        }
    }
}
