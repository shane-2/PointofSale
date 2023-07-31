using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSale
{
    internal class StoreOrder
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; }

        //constructor
        public StoreOrder(string _name, decimal _total, string _paymentmethod)
        {
            Name = _name;
            Total = _total;
            PaymentMethod = _paymentmethod;
        }
    }
}
