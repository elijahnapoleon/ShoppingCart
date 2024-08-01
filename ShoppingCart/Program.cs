using Microsoft.VisualBasic.FileIO;
using ShoppingCartLibrary.Models;
using ShoppingCartLibrary.Services;
using System.Diagnostics;

var inventory = ItemServiceProxy.Current;
var cart = ItemServiceProxy.Current;
bool checkout = false;
int choice = 0;
int choice2 = 0;

while (!checkout)
{
    do
    {
        Console.WriteLine("1) Inventory Management");
        Console.WriteLine("2) Shop");

        int.TryParse(Console.ReadLine(), out choice);

        switch (choice)
        {
            case 1:
                
                do
                {
                    Console.WriteLine("1) Add Item");
                    Console.WriteLine("2) Read Item");
                    Console.WriteLine("3) Update Item");
                    Console.WriteLine("4) Delete Item");
                    Console.WriteLine("5) Back");

                    int.TryParse (Console.ReadLine(), out choice2);

                    switch(choice2)
                    {
                        case 1:
                            Item? t1 = new Item();

                            Console.WriteLine("Enter name of new item");
                            var name = Console.ReadLine();
                            Console.WriteLine("Enter description of new item");
                            var desc = Console.ReadLine();
                            Console.WriteLine("Enter price of new item");
                            decimal.TryParse(Console.ReadLine(), out decimal price);
                            Console.WriteLine("Enter amount of new item");
                            int.TryParse(Console.ReadLine(), out int count);

                            inventory.AddOrUpdate(
                                new Item
                                {
                                    Name = name,
                                    Description = desc,
                                    Price = price,
                                    Amount = count,
                                });
                             break;

                        case 2:
                            inventory.Items?.ToList().ForEach(Console.WriteLine);

                            break;

                        case 3:
                            Console.WriteLine("Enter ID of item you wish to update");
                            int selection = -1;
                            int.TryParse(Console.ReadLine(), out selection);

                            var currentItem = inventory.Items.FirstOrDefault(c=> c.Id == selection);

                                if(currentItem!=null)
                                {
                                    Console.WriteLine(currentItem);
                                    
                                    Console.WriteLine("Enter new name of item");
                                    currentItem.Name = Console.ReadLine();
                                    Console.WriteLine("Enter new description of item");
                                    currentItem.Description = Console.ReadLine();
                                    Console.WriteLine("Enter new price of item");
                                    decimal.TryParse(Console.ReadLine(), out decimal p);
                                    currentItem.Price = p;
                                    Console.WriteLine("Enter new amount of item");
                                    int.TryParse(Console.ReadLine(), out int amount);
                                    currentItem.Amount = amount;

                                    inventory.AddOrUpdate(currentItem);
                                    break;
                                }

                            break;

                        case 4:
                            Console.WriteLine("Enter Id of item you wish to remove");
                            int.TryParse(Console.ReadLine(), out int rId);
                            
                            inventory.Delete(rId);

                            break;

                        case 5:
                            break;

                        default:
                            break;

                    }
                } while (choice2 != 5);
                break;

            case 2:

                do
                {
                    Console.WriteLine("Inventory\n");
                    inventory.Items?.ToList().ForEach(Console.WriteLine);

                    Console.WriteLine("1) Add item to cart");
                    Console.WriteLine("2) Remove item from cart");
                    Console.WriteLine("3) Checkout");
                    int.TryParse(Console.ReadLine(), out choice2);
                    switch (choice2)
                    {
                        case 1:
                            Console.WriteLine("Enter Id of item of you wish to add to your cart");
                            int.TryParse(Console.ReadLine(), out int cId);

                            var itemToAdd = inventory.Items?.FirstOrDefault(c => c.Id == cId);

                            cart.AddOrUpdate(itemToAdd);

                            break;
                        case 2:

                            Console.WriteLine("Cart\n");
                            cart.Items?.ToList().ForEach(Console.WriteLine);

                            Console.WriteLine("Select an item to remove");
                            int.TryParse(Console.ReadLine(), out int remInt);
                            
                            cart.Delete(remInt);

                            break;

                        case 3:
                            Console.WriteLine("Reciept\n");
                            decimal? subtotal = 0;
                            
                            foreach(var item in cart.Items)
                            {
                                subtotal += item.Price;
                            }

                            Console.WriteLine("Subtotal       $" + subtotal);
                            Console.WriteLine("Tax            7%");
                            Console.WriteLine($"Total          ${Decimal.Multiply((decimal)subtotal, (decimal)1.07)}");
                            checkout = true;
                            break;
                    }

                }while (choice2 != 3);
                break;

            default:

                break;

        }
    } while (choice != 1 && choice != 2);
}


