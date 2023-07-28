using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSale
{
    internal class Instrument : Merchandise
    {


        public string Brand { get; set; }

        public Instrument(decimal _price, string _size, string _type, string _category, string _brand) :
         base(_price, _size, _type, _category)
        {
            Brand = _brand;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("{0,-20}", Brand);


        }
    }
}
