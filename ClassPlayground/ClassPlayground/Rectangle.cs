using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Rectangle:Shape2D
    {
        public float width, height;
        public Rectangle(float height, float width)
        // tohle je konstrukor, tady není porpojený s nad třídou, neni nijak relvantí v tříde Shape2D
        {
            this.height = height;
            this.width = width;
        }
        public override float CalculateArea()
        // pomocí override propojuju nad třídu a tuhle třídu do jedný funkce, jenom tahle jakoby přepíše tu přechozí
        {
            return width * height;
            // return blabla je lwk jako prostě kratší způsob napsání výsledku, cuz yk místo definování nový hodnoty a pak její
            // vypočítání prostě flákneš return do tý jedný funkce a yippie yappa
        }

        public override float CalculateAspectRatio()
        {
            return width / height;
        }

        public override bool ContainsPoint(float x, float y)
        {
            return x >= 0 && y >= 0 && x <= width && y <= height;
        }

        //1) Vytvoř třídu Rectangle, kterou budeme reprezentovat obecný obdélník
        //Přidej třídě Rectangle dvě proměnné - width a height(datový typ nechám na tobě)
        //Přidej třídě Rectangle tři funkce - CalculateArea, která spočítá obsah plochy obdélníka
        //CalculateAspectRatio, která spočítá poměr stran.Využij spočítaný poměr k určení toho, jestli je obdélník široký, vysoký, nebo je to čtverec
        //ContainsPoint, která jako vstupní parametr přijme souřadnice x, y nějakého bodu a určí, jestli se daný bod nachází v obdélníku, nebo ne, a podle toho vrátí true/false
        //Přidej třídě Rectangle konstruktor, který bude přijímat dva parametry - šířku a výšku, a při jeho zavolání je správně nastaví
        
    }
}
