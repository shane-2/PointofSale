using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSale
{
    internal class Furniture : Merchandise
    {
        public string Material { get; set; }

        public Furniture(decimal _price, string _size, string _type, string _material) :
         base(_price, _size, _type)
        {
            Material = _material;
        }
        public override string ToString()
        {
            return base.ToString() + $"{Material}.";
        }


    }
}
