using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSale
{
    internal class CreditCard 
    {
        public string Name { get; set; }
        public long Number { get; set; }
        public int Expiration { get; set; }
        public int CVV { get; set; }
        public decimal Price { get; set; }

        //constructor
        public CreditCard(string _name, long _number, int _expiration, int _cvv, decimal _price)
        {
            Name = _name;
            Number = _number;
            Expiration = _expiration;
            CVV = _cvv;
            Price = _price;
        }
    }
}
