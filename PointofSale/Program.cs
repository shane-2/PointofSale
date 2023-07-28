//Thrift store
// parent item - bool big or small (+ shipping)       decimal price
// 

// child classes : Clothes(color, size, type, season),
// furniture(type, material(wood, leather, cloth)),
// Kitchenware(type(cutlery, dinnerware, utensils, tupperware)),      //five items per class
// Electronics(type, year, brand),
// Instruments(type(percussion, string, woodwind, brass), brand(Gibson, Fender, Yamaha, Kawai)) 

using PointofSale;


using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime;
using System.Xml.Linq;
//List for checks
List<Check> allChecks = new List<Check>();
//List for shopping cart
List<Merchandise> shopCart = new List<Merchandise>();
//make List for items

List<Merchandise> inventory = new List<Merchandise>()
{
new Electronics( 64.95m, "Small",  "Xbox", "electronics", 2000, "Microsoft"),
new Electronics( 39.95m, "Small",  "Gameboy Color","electronics", 1998, "Nintendo"),
new Electronics( 89.95m, "Large",  "70 Inch T.V.","electronics", 2020, "Samsung"),
new Electronics( 119.95m, "Large",  "Refridgerator","electronics", 2019, "Samsung"),
new Electronics( 219.95m, "Small",  "Xbox X","electronics", 2021, "Microsoft"),
new Electronics( 34.95m, "Small",  "Toaster Oven","electronics", 2021, "Revolution"),

new Kitchenware( 9.95m, "Small", "Forks","kitchenware", "Stainless Steel", 10),
new Kitchenware( 1499.95m, "Small", "Spatula","kitchenware", "Pure Gold", 1),
new Kitchenware( 5.95m, " Small", "Dinner Plates","kitchenware", "Ceramic", 5),
new Kitchenware( 8.95m, " Small", "Steak Knives","kitchenware", "Stainless Steel", 5),
new Kitchenware( 2.95m, " Small", "Soup Bowl","kitchenware", "Ceramic", 1),

new Furniture(59.95m, " Large", "Desk", "furniture", "Wood"),
new Furniture(95.95m, " Large", "Couch","furniture","Leather"),
new Furniture(9.95m, " Medium", "Chair","furniture", "Wood"),
new Furniture(19.95m," Medium","Barstool","furniture", "Metal"),
new Furniture(29.95m," Medium","Nightstand","furniture", "Wood"),

new Instrument(65.95m," Medium","Guitar","instrument","Fender"),
new Instrument(2.95m," Small","Recorder","instrument", "Yamaha"),
new Instrument(139.95m," Medium","Saxophone","instrument", "Cannonball"),
new Instrument(99.95m, " Medium","Guitar","instrument", "Gibson"),
new Instrument(165.95m," Large","Drumset","instrument", "Pearl"),

new Clothing(2.95m,"Small","Tie Dye Tee","Clothing","All Season","XL","Tie Dye"),
new Clothing(79.95m,"Medium","Fur Coat","Clothing","Winter","M","Brown"),
new Clothing(4.95m,"Small","Tigers Hat","Clothing","Summer","L","Blue"),
new Clothing(14.95m,"Small","Morph Suit","Clothing","All Season","XXS","Neon Green"),
new Clothing(9.95m,"Medium","Snowpants","Clothing","Winter", "XXL","Camoflauge")
};

bool runProgram = true;
while (runProgram)
{
    int menuChoice = 0;
    while (menuChoice <= 0 || menuChoice >= 5)
    {
        Console.WriteLine($"Please select the Category you are looking for!");
        Console.WriteLine("1. Electronics");
        Console.WriteLine("2. KitchenWare");
        Console.WriteLine("3. Furniture");
        Console.WriteLine("4. Instruments");
        Console.WriteLine("5. Clothes and Apparel");
        while (int.TryParse(Console.ReadLine(), out menuChoice) == false)
        {
            Console.WriteLine("Incorrect Format");
        }
        
        List<Merchandise> options = MenuCategory(menuChoice, inventory);
        int itemChoice = 0;
        int count = 0;
        while (itemChoice <= 0 || itemChoice >= count + 1)
        {
            Console.WriteLine("");
            Console.WriteLine($"Enter an item number to add to Cart or {options.Count + 1} to return. ");
            foreach (Merchandise o in options)
            {
                count++;
                Console.WriteLine($"{count}. {o}");
            }
            count = 0;
            Console.WriteLine("");
            Console.WriteLine($"{options.Count + 1}. Return to Menu.");
            while (int.TryParse(Console.ReadLine(), out menuChoice) == false)
            {
                Console.WriteLine("Incorrect Format");
            }
            if(menuChoice < options.Count + 1)
            {
                shopCart.Add(options[menuChoice -1]);
            }
            else if(menuChoice == options.Count + 1)
            {
                itemChoice = menuChoice;
                break;

            }
            Console.WriteLine("");
            Console.WriteLine("Shopping Cart");
            DisplayMenu(shopCart);

            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }

        bool runProgram2 = true;
        while (runProgram2)
        {
            Console.WriteLine("Are you ready to check out? Enter y/n");
            string yesno = Console.ReadLine().ToLower().Trim();
            if (yesno == "y")
            {
                runProgram = false;
                runProgram2 = false;
                menuChoice = 1;
            }
            else if (yesno == "n")
            {
                runProgram = true;
                runProgram2 = false;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            Console.WriteLine();
        }
        
    }
    //have user choose item via number
    //have user choose ttem via number and quantity
    //provide total
    //re display menu and complete purchase or purchase more
    //subtotal, sales tax, grand total

    //ask for payent type cash, credit, or check
    //For cash, ask for amount tendered and provide change.
    //For check, get the check number.
    //For credit, get the credit card number, expiration, and CVV.

    //display receipt, items, totals, 
}
decimal shipping = 0;
    if(Ship(shopCart) == true)
{
    bool ship = true;
    while (ship)
    {
        Console.WriteLine("We noticed you have some bigger items in your order.");
        Console.WriteLine(" Would you like these items shipped? Enter y/n");
        string yesno = Console.ReadLine().ToLower().Trim();
        if (yesno == "y")
        {
           shipping = ShippingPrice(shopCart);
            Console.WriteLine($"Shipping price: ${shipping}");
            //add up shipping total on large items
            ship = false;
        }
        else if (yesno == "n")
        {
            ship = false;    
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
        Console.WriteLine();
    }
}

Console.WriteLine("How would you like to pay? Enter:");
Console.WriteLine("1 for Cash");
Console.WriteLine("2 for Check");
Console.WriteLine("3 for Credit");

    int input = int.Parse(Console.ReadLine());

decimal subtotal = 0;
foreach (Merchandise t in shopCart)
{
    subtotal += t.Price;
}
decimal math = Math.Round(subtotal, 2) * 0.06m;
decimal salestax = Math.Round(math, 2);
decimal grandtotal = Math.Round(subtotal + salestax + shipping, 2);

bool runPayment = true;
while (runPayment)
{
    if (input == 1 )
    {
        Total(subtotal, salestax, grandtotal, shipping);
        Console.WriteLine("Enter the amount of cash tendered");
        decimal cash = decimal.Parse(Console.ReadLine());
        decimal change = cash - grandtotal;
        Console.WriteLine($"${change} is your change!");
        runPayment = false;
        break;
    }

    else if (input == 2)
    {
        Total(subtotal, salestax, grandtotal, shipping);
        Console.WriteLine("Please enter your name.");
        string name = Console.ReadLine();
        Console.WriteLine("Please enter your check number");
        int check = int.Parse(Console.ReadLine());
        CheckPay(name, check, grandtotal, allChecks);


        runPayment = false;
        break;
    }

    else if (input == 3)
    {
        Total(subtotal, salestax, grandtotal, shipping);
        Console.WriteLine("Please enter your card number, expiration date, and CVV");
        Console.ReadLine();
        
        runPayment = false;
        break;
    }
    else
    {
        Console.WriteLine("Not a valid choice. Try again.");
    }
}

Console.WriteLine("Thank you for shopping with us! Here is your Receipt!");
Receipt(subtotal, salestax, grandtotal, shipping, shopCart);
Console.WriteLine($"Payment Method: {GetPay(input)}");

Console.ReadLine();




//-------------------------------------------------------------------
//methods

static void CheckPay(string name, int bank, decimal total, List<Check> list)
{
    string filePath = "../../../Checks.txt";

    if (File.Exists(filePath) == false)
    {
        StreamWriter tempWriter = new StreamWriter(filePath);
        tempWriter.WriteLine("Name|Check Number|Amount");
       
        tempWriter.Close();
    }

    
        
        //List<Check> allChecks = new List<Check>();
        Check s = new Check(name, bank, total);
        list.Add(s);
        StreamWriter writer = new StreamWriter(filePath);
        foreach (Check t in list)
        {
            writer.WriteLine($"{t.Name}|{t.BankInfo}|{t.Price}");
        }
        
        writer.Close();
    
    
}
static void CardPay()
{
    //needs class and same logic as check 

    //verification for length of numbers

    //could also add verification that card is not expired
}
static void Total(decimal sub, decimal tax, decimal tot, decimal ship)
{
    Console.WriteLine("");
    Console.WriteLine(String.Format("{0,-20}${1,-15}","Subtotal:", sub));
    Console.WriteLine(String.Format("{0,-20}${1,-15}","Sales Tax:", tax));
    Console.WriteLine(String.Format("{0,-20}${1,-15}","Shipping:", ship));
    Console.WriteLine(String.Format("{0,-20}${1,-15}","Grand Total:", tot));
    Console.WriteLine("");
}
static void Receipt(decimal sub, decimal tax, decimal tot, decimal ship, List<Merchandise> cart )
{
    DisplayMenu(cart);
    
    Total(sub, tax, tot, ship);
}
    static void DisplayMenu(List<Merchandise> inventory)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i]}");
        }

    }

    static List<Merchandise> MenuCategory(int choice, List<Merchandise> list)
    {
        List<Merchandise> options = new List<Merchandise>();
        //int count = 0;
        if (choice == 1)
        {
            foreach (Merchandise i in list)
            {
                if (i.Category.Contains("electronics"))
                {
                    //count++;
                    //Console.WriteLine($"{count}. {i}");
                    options.Add(i);
                }
            }
        }
        if (choice == 2)
        {

            foreach (Merchandise i in list)
            {
                if (i.Category.Contains("kitchenware"))
                {
                    //count++;
                    //Console.WriteLine($"{count}. {i}");
                    options.Add(i);
                }
            }

        }
        if (choice == 3)
        {

            foreach (Merchandise i in list)
            {
                if (i.Category.Contains("furniture"))
                {
                    //count++;
                    //Console.WriteLine($"{count}. {i}");
                    options.Add(i);
                }
            }
        }
        if (choice == 4)
        {

            foreach (Merchandise i in list)
            {
                if (i.Category.Contains("instrument"))
                {
                    //count++;
                    //Console.WriteLine($"{count}. {i}");
                    options.Add(i);
                }
            }
        }
        if (choice == 5)
        {
            Console.WriteLine(" ");
            foreach (Merchandise i in list)
            {
                if (i.Category.Contains("Clothing"))
                {
                    //count++;
                    //Console.WriteLine($"{count}. {i}");
                    options.Add(i);
                }
            }
        }
        else
        {

        }
        return options;
        //int menuChoice = 0;
        //while (menuChoice <= 0 || menuChoice >= count + 1)
        //{
        //    Console.WriteLine($"Choose a menu option. 1-{count}");
        //    Console.WriteLine($"{count + 1} I'm not interested in any of these.");
        //    while (int.TryParse(Console.ReadLine(), out menuChoice) == false)
        //    {
        //        Console.WriteLine("Incorrect Format");
        //    }


        //}
    }
    static bool Buyitem(Merchandise c)
    {
        Console.WriteLine("Would you like to buy this item? y/n");
        Console.WriteLine(c);
        string buyChoice = Console.ReadLine();
        if (buyChoice == "y")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //not done
    static bool Ship(List<Merchandise> list)
{
    foreach(Merchandise i in list)
    {
        if (i.Size.ToLower().Trim() == "large")
        {
            return true;
        }
    }
    return false;
}
static decimal ShippingPrice(List<Merchandise> cart)
{
    decimal s = 0;
    foreach(Merchandise c in cart)
        if (c.Size.ToLower().Trim().Contains("large"))
        {
            s += 15.99m;
        }
            return s;
}

static string GetPay(int input)
{
    if (input == 1)
    {
       return "Cash";
    }

    else if (input == 2)
    {
        return"Check";
    }

    else if (input == 3)
    {
        return"Credit";
    }
    else
    {
        return"";
    }
}