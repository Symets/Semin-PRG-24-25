using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Dnes bude vasim ukolem vytvorit formularovou reprezentaci kalkulacky. Priblizny vzhled si nakreslime na tabuli
 * (Pokud jsem to nenakreslil, pripomente mi to prosim!)
 * Inspirujte se kalkulackou ve Windows.
 * Pozadovane prvky/funkcionality:
 * - Tlacitka pro kazde z cisel 0-9
 * - Tlacitka pro operace +, -, *, a /
 * - Tlacitko pro = (vypsani vysledku)
 * - Textbox, do ktereho se propisou cisla/operace pri stisku jejich tlacitek
 * - Textbox s vysledkem operace (mozne sloucit s predeslym, nechavam na vas)
 * - Tlacitko pro vymazani textu v textboxu s cisly a operaci
 * 
 * Volitelne prvky/funkcionality:
 * - Tlacitko pro mazani cisel a operaci v textboxu zprava vzdy po jednom znaku
 * - Pokud mam vypsany vysledek a hned po tom stisknu tlacitko nejake operace, vysledek se vezme jako prvni cislo a
 *   rovnou mohu po zadani operace zadat druhe cislo
 * - Moznost ulozeni vysledku do nekolika preddefinovanych labelu/neinteraktivnich textboxu (treba kombinaci comboboxu a tlacitka, kde
 *   v comboboxu vyberu do ktereho labelu/textboxu se mi to ulozi a tlacitkem provedu ulozeni)
 *   + pridat tlacitko pro kazdy label/neint. textbox, kterym ulozeny vysledek pouziju jako cislo do vypoctu
 * - Pridani mocnin/odmocnin atd. (napr. pomoci dalsich tlacitek, ktere rovnou misto daneho cisla daji jeho (popr. zaokrouhlenou) odmocninu apod.)
 * - Cokoliv dalsiho vas napadne! :)
 * 
 * Snazte se o to, aby byla kalkulacka v ramci moznosti hezka, a aby bylo jeji ovladani intuitivni a aby mel kazdy prvek v okne dobre vyuziti
 */

namespace CalculatorRevisited
{
    public partial class CalculatorRevisited : Form
    {
        Graphics panelGraphics;
        Graphics formGraphics;
        public CalculatorRevisited()
        {
            InitializeComponent(); //ten crazy dlouhej list všech 
            //panelGraphics = panel1.CreateGraphics(); - takhle kreslím jenom v rámci toho panelu
            //formGraphics = this.CreatGraphics(); - tak můzu kreslit na celým okně
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Clicked";
            /* jestli bych chtěl, tak si můžu klidně přejmenovat, název tlačítka přes ten Designer
             *  v ProjectNameRevisite.Designer se nastavují všechny vlastnosti komponentů.
             *  je to useful, když např. chci smazat něco v kódu
             *  jelikož když odstraním kód na tlačítko, tak v to m designeru stále je kód pro hledání eventu click
             *  stačí jenom odstranit ten řádek kde se hledá event, větši takových problému by se mužou maunáalně opravit tam
             *  (event je =+, přirovnání, v televizi se neustále vysílají programy, to =+ je když se připojím jako divák
             */

        }

        private void MouseDown_Paint(object sender, PaintEventArgs e)
        {
            //paint co tak chápu automaticky vytvoří Graphics třídu?
            //e.Graphics.DrawLine();
        }

        private void MouseDown_MouseDown(object sender, MouseEventArgs e)
        {
            //kategorizace kódu podle eventu
        }

    }
}
