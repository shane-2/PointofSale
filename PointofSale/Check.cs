using System;
namespace PointofSale
{
	public class Check
	{
        public string Name { get; set; }
        public int BankInfo { get; set; }
        public int Price { get; set; }

        //constructor
        public Check(string _name, int _bankinfo, int _price)
        {
            Name = _name;
            BankInfo = _bankinfo;
            Price = _price;
        }

    }
}

