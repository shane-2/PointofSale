//Thrift store
// parent item - bool big or small (+ shipping)       decimal price
// 

// child classes : Clothes(color, size, type, season),
// furniture(type, material(wood, leather, cloth)),
// Kitchenware(type(cutlery, dinnerware, utensils, tupperware)),      //five items per class
// Electronics(type, year, brand),
// Instruments(type(percussion, string, woodwind, brass), brand(Gibson, Fender, Yamaha, Kawai)) 

//make List for items
//have user choose child via number
//have user choose ttem via number and quantity
//provide total
//re display menu and complete purchase or purchase more
//subtotal, sales tax, grand total

//ask for payent type cash, credit, or check
//For cash, ask for amount tendered and provide change.
//For check, get the check number.
//For credit, get the credit card number, expiration, and CVV.

//display receipt, items, totals, 
using PointofSale;


List<Merchandise> inventory = new List<Merchandise>()
{
new Electronics( 64.95m, "Small",  "Xbox", 2000, "Microsoft"),
new Electronics( 39.95m, "Small",  "Gameboy Color", 1998, "Nintendo"),
new Electronics( 89.95m, "Large",  "70 Inch T.V.", 2020, "Samsung"),
new Electronics( 119.95m, "Large",  "Refridgerator", 2019, "Samsung"),
new Electronics( 219.95m, "Small",  "Xbox X", 2000, "Microsoft"),
new Electronics( 34.95m, "Small",  "Toaster Oven", 2021, "Revolution"),

new Kitchenware( 9.95m, "Small", "Forks", "Stainless Steel", 10),
new Kitchenware( 1500.00m, "Small", "Spatula", "Pure Gold", 1),
new Kitchenware( 5.95m, "Small", "Amazon Dinner Plates", "Ceramic", 5),
new Kitchenware( 8.95m, "Small", "Steak Knives", "Stainless Steel", 5),
new Kitchenware( 2.95m, "Small", "Soup Bowl", "Ceramic", 1)

new Furniture(59.95m, "Large", "Desk", "Wood"),
new Furniture(95.95m, "Large", "Couch","Leather"),
new Furniture(9.95m, "Medium", "Chair","Wood"),
new Furniture(19.95m,"Medium","Barstool","Metal"),
new Furniture(29.95m,"Medium","Nightstand","Wood"),

new Instrument(65.95m,"Medium","Guitar","Fender"),
new Instrument(2.95m,"Small","Recorder","Yamaha"),
new Instrument(139.95m,"Medium","Saxophone","Cannonball"),
new Instrument(99.95m, "Medium","Guitar","Gibson"),
new Instrument(165.95m,"Large","Drumset","Pearl")






};






//if time try storing in file
//(Moderate) Store your list of products in a text file and then include an option to add to the product list, which then outputs to the product file.
