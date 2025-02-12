using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Cricle: Shape2D
    //neumim psát Circle tvl, nejde nic no
    {
        public float radius;
        public Cricle(float radius)
        {
            this.radius = radius;
        }
        public override float CalculateArea()
        {
            return (float)Math.PI*radius*radius;
            //jinak jelikož PI je Double = což je přestnější desetinné číslo tak nám nebude fugovat funkce která vrací pouze float
        }

        /*public override float CalculateAspectRatio()
         * {return width / height;}
         *  jelikož uhlopříčku v kruhu udělat nejde tak to tady nejde takže tuto funkci prostě odstraníme a Shape2D přebere tuto funkci sám
         */

        public override bool ContainsPoint(float x, float y)
        {
            return Math.Sqrt(x*x + y*y) <= radius; //<= radius tam musí být cuz tady checkujeme true/false, takžče to s něčí musíš porovnat lol
        }
    }
}
