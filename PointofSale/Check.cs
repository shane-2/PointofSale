using System;
namespace PointofSale
{
	public class Check
	{
        public string Name { get; set; }
        public int BankInfo { get; set; }
        public decimal Price { get; set; }

        //constructor
        public Check(string _name, int _bankinfo, decimal _price)
        {
            Name = _name;
            BankInfo = _bankinfo;
            Price = _price;
        }

    }
}

