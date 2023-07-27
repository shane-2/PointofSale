using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSale
    
{
    internal class Merchandise
    {
        //properties
        public decimal Price { get; set; }
        //Small, Medium, Large
        public string Size { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        //public bool Shipped { get; set; }

        //constructors
        public Merchandise(decimal _price, string _size, string _type, string _category)
        {
            Price = _price;
            //Shipped = _shipped;
            Size = _size;
            Type = _type;
            Category = _category;
        }

        //methods
        public override string ToString()
        {
            return $"${Price} {Type}";
        }

        public string Shipped(string size)
        {
            if (Size == "Large")
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
