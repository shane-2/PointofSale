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

        public Furniture(decimal _price, string _size, string _type, string _category, string _material) :
         base(_price, _size, _type, _category)
        {
            Material = _material;
        }
        public override string ToString()
        {
            return base.ToString() + String.Format("{0,-20}", Material);
        }


    }
}
