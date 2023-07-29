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
//list for cards
List<CreditCard> credit = new List<CreditCard>();
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
            Console.WriteLine($"Enter an item number to add to your Shopping cart or {options.Count + 1} to return. ");
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
                Console.WriteLine($"Incorrect Format, please enter a number 1 - {options.Count + 1}");
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
            Console.Clear();
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
                Console.Clear();
                runProgram = false;
                runProgram2 = false;
                menuChoice = 1;
            }
            else if (yesno == "n")
            {
                Console.Clear();
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
Console.WriteLine("Please enter the your name.");
string name = Console.ReadLine();

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

        CheckPay(name, grandtotal, allChecks);



        runPayment = false;
        break;
    }

    else if (input == 3)
    {
        Total(subtotal, salestax, grandtotal, shipping);
    
        CardPay(name, grandtotal, credit);
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

static void CardPay(string name, decimal total, List<CreditCard> list)
{
    long card1 = 0;
    int exp1 = 0;
    int cvv1 = 0;
    string filePathcc = "../../../CreditCard.txt";
    int x = 0;
    while (x == 0)
    {
    Console.WriteLine("What is your card number?");
    string card = Console.ReadLine().Trim();
    
    Console.WriteLine("What is the expiration date?");
    string exp = Console.ReadLine().Trim();
    Console.WriteLine("What is your CVV number?");
    string cvv = Console.ReadLine().Trim();
        if (card.Length == 16 && exp.Length == 4 && cvv.Length == 3  )
        {
            try
            {

             card1 = long.Parse(card);
             exp1 = int.Parse(exp);
             cvv1 = int.Parse(cvv);
            x++;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid card info. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid card info. Please try again.");
        }
    }

    if (File.Exists(filePathcc) == false)
    {
        StreamWriter tempWriter = new StreamWriter(filePathcc);
        tempWriter.WriteLine("Name|Card Number|Expiration|CVV|Amount");

        tempWriter.Close();
    }
    
    StreamReader reader = new StreamReader(filePathcc);
    while (true)
    {
        //name||long number||int exp|| cvv ||decimal price
        string line = reader.ReadLine();
        if (line == null)
        {
            break;
        }
        else
        {
            string[] parts = line.Split("|");
            CreditCard newCard = new CreditCard(parts[0], long.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), decimal.Parse(parts[4]));
            list.Add(newCard);
        }
    }
    reader.Close();

    CreditCard s = new CreditCard(name, card1, exp1, cvv1, total);
    list.Add(s);
    StreamWriter writer = new StreamWriter(filePathcc);
    foreach (CreditCard t in list)
    {
        writer.WriteLine($"{t.Name}|{t.Number}|{t.Expiration}|{t.CVV}|{t.Price}");
    }

    writer.Close();
}
static void CheckPay(string name, decimal total, List<Check> list)
{
    string filePath = "../../../Checks.txt";
    int check1 = 0;
    int x = 0;
    while (x == 0)
    {
    Console.WriteLine("What is your 8 digit check number?");
    string check = Console.ReadLine();
        if (check.Length == 8)
        {
            try
            {

           check1 = int.Parse(check);
            x++;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid check number");
            }

            
        }
        else
        {
            Console.WriteLine("Invalid check number");
        }

    }
    if (File.Exists(filePath) == false)
    {
        StreamWriter tempWriter = new StreamWriter(filePath);
        tempWriter.WriteLine("Name|Check Number|Amount");
       
        tempWriter.Close();
    }

    StreamReader reader = new StreamReader(filePath);
    while (true)
    {
        //name|| number|| price
        string line = reader.ReadLine();
        if (line == null)
        {
            break;
        }
        else
        {
            string[] parts = line.Split("|");
            Check newcheck = new Check(parts[0], int.Parse(parts[1]), decimal.Parse(parts[2]));
            list.Add(newcheck);
        }
    }
    reader.Close();

    //List<Check> allChecks = new List<Check>();
    Check s = new Check(name, check1, total);
        list.Add(s);
        StreamWriter writer = new StreamWriter(filePath);
        foreach (Check t in list)
        {
            writer.WriteLine($"{t.Name}|{t.BankInfo}|{t.Price}");
        }
        
        writer.Close();
    
    
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
    Console.WriteLine("Thank you for shopping with us! Here is your Receipt!");
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
    decimal s = 9.99m;
    foreach(Merchandise c in cart)
        if (c.Size.ToLower().Trim().Contains("large"))
        {
            s += 2.78m;
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