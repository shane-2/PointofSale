using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSale
{

    internal class Clothing : Merchandise
    {  

    
    
        //properties

        public string Color { get; set; }
        public string Measurements { get; set; }
        public string Season { get; set; }

        // Clothing(type,season, Measurement, color)

        //constructors


        public Clothing(decimal _price, string _size, string _type, string _category, string _season, string _measurements, string _color) : base(_price, _size, _type, _category)

        

        {
            Color = _color;
            Measurements = _measurements;
            Season = _season;
        }

        //methods

        public override string ToString()
        {
            return base.ToString() + $"{Color} {Measurements} {Season}";
        }



    }
}
