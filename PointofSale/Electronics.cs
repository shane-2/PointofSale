using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSale
{
    internal class Electronics :Merchandise
    {
        //properties
        public int Year { get; set; }
        public string Brand { get; set; }

        // Electronics(type, year, brand),

        //constructors
        public Electronics(decimal _price, string _size, string _type, string _category, int _year, string _brand) : base ( _price, _size, _type, _category)
        {
            Year = _year; 
            Brand = _brand;
        }

        //methods

        public override string ToString()
        {
            return base.ToString() + String.Format("{0,-20} {1,-15}", Brand, Year);
        }
        //public void DisplayElectronics()
        //{
        //    for (int i = 0; i == )
        //}

    }
}
