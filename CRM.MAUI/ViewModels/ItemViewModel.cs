using ShoppingCartLibrary.Models;
using ShoppingCartLibrary.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CRM.MAUI.ViewModels
{
    public class ItemViewModel
    {

        public override string ToString()
        {
            if (Item == null)
            {
                return string.Empty;
            }
            return $"{Item.Id} - {Item.Name} - {Item.Price:C}\n{Item.Description}";
        }

        public string Display
        {
            get
            { 
                return ToString() ; 
            }
        }


        public Item? Item { get; set; }

        public string? Name
        {
            get
            {
                return Item?.Name ?? string.Empty;
            }

            set
            {
                if(Item != null)
                {
                    if(value == string.Empty)
                    {
                        Item.Name = "Unnamed Item";
                    }
                    else
                    {
                        Item.Name = value ?? "Unnamed Item";
                    }
                }
            }
        }

        public string? Description
        {
            get
            {
                return Item?.Description ?? string.Empty;
            }

            set
            {
                if(Item != null)
                {
                    Item.Description = value;
                }
            }
        }

        public string DisplayPrice
        {
            get
            {
                if(Item == null)
                {
                    return string.Empty;
                }
                return $"{Item.Price:C}";
            }

            
        }

        public string PriceAsString
        {
            set
            {
                if (Item  == null)
                {
                    return;
                }
                if(decimal.TryParse(value, out var price))
                {
                    Item.Price = price;
                }
                else
                {

                }
            }
        }

        public int? Amount
        {
            get
            {
                return Item?.Amount ?? 0;
            }

            set
            {
                Item.Amount = value;
            }
        }
        private int? cartAmount;

        public int? CartAmount
        {
            get
            {
                return cartAmount;
            }

            set
            {
                if (value != null)
                {
                    cartAmount = value;
                    Amount -= cartAmount;
                }
            }
        }

        private void ExecuteEdit(ItemViewModel? c)
        {
            if(c?.Item == null)
            {
                return;
            }

            Shell.Current.GoToAsync("//Item?itemId={c.Item.Id}");
        }

      

        public async void Add()
        {
            if(Item != null)
            {
                Item = await ItemServiceProxy.Current.AddOrUpdate(Item);
            }
        }

        public void AddToCart()
        {
            var temp = new Item();
            temp.Id = Item.Id;
            temp.Description = Item.Description;
            temp.Price = Item.Price;
            temp.Name = Item.Name;
            temp.Amount = cartAmount;
            ShoppingCartService.Current.AddToCart(temp);
        }

       


        public ItemViewModel() 
        {
            Item = new Item();
            
        }

        public ItemViewModel(Item i)
        {
            Item = i;
            
        }

        public ItemViewModel(int id)
        {
            Item = ItemServiceProxy.Current?.Items?.FirstOrDefault(x => x.Id == id);
            if(Item == null)
            {
                Item = new Item();
            }
            
        }

        
    }
}
