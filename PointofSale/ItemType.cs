using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSale
{
    internal class ItemType
    {
        //properties
        public decimal Price { get; set; }
        //Small, Medium, Large
        public string Size { get; set; }
        //public bool Shipped { get; set; }

        //constructors
        public ItemType(decimal _price, string _size)
        {
            Price = _price;
            //Shipped = _shipped;
            Size = _size;
        }

        //methods
        public override string ToString()
        {
            return $"{Price}";
        }

        public string Shipped(string size)
        {
            if (size == "Large")
            {
                return "Do you want this item shipped?";
            }
            else
            {
                return "";
            }
        }

    }
}
