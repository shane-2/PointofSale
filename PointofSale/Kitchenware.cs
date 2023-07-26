using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSale
{
    internal class Kitchenware : Merchandise
    {
        //properties
        public string Substance { get; set; }
        public int Quantity { get; set; }

        //constructors
        public Kitchenware(decimal _price, string _size, string _type, string _substance, int _quantity) : base (_price, _size, _type)
        { 
            Substance = _substance;
            Quantity = _quantity;
        }

        //methods

        public override string ToString()
        {
            return base.ToString() + $"{Substance}{Quantity}.";
        }

    }
}
