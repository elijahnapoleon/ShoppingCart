using Microsoft.VisualBasic;
using ShoppingCartLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary.Services
{
    public class ShoppingCartService
    {
        private ShoppingCartService()
        {
     
        }

        private static ShoppingCartService instance;
        private static object instanceLock = new object();

        private List<ShoppingCart>? carts;
        public ReadOnlyCollection<ShoppingCart>? Carts 
        {
            get
            {
                return carts?.AsReadOnly();
            }
        }

        public ShoppingCart Cart
        {
            get
            {
                if(Carts== null || !Carts.Any())
                {
                    return new ShoppingCart();
                }
                return Carts?.FirstOrDefault() ?? new ShoppingCart();
            }
        }
        public static ShoppingCartService Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ShoppingCartService();
                    }
                    
                    return instance;
                }
            }
        }

        public int LastId
        {
            get
            {
                if (carts?.Any() ?? false)
                {
                    return carts?.Select(c => c.Id)?.Max() ?? 0;
                }
                return 0;
            }
        }

        public ShoppingCart? AddOrUpdate(ShoppingCart cart)
        {
            if (Carts == null) { return null; }

            var isAdd = false;

            if (cart.Id == 0)
            {
                cart.Id = LastId + 1;
                isAdd = true;
            }

            if (isAdd)
            {
                carts.Add(cart);
            }
            return cart;
        }
        public void AddToCart(Item item)
        {
            if(Cart == null || Cart.Contents==null)
            {
                return;
            }

            var existingProduct = Cart?.Contents?.FirstOrDefault(oldItem => oldItem.Id == item.Id);

            var inventoryItem = ItemServiceProxy.Current?.Items?.FirstOrDefault(invProd => invProd.Id == item.Id);
            if(inventoryItem == null)
            {
                return;
            }

            if(inventoryItem.Amount >= item.Amount)
            {
                inventoryItem.Amount -= item.Amount;
            }
            else
            {
                inventoryItem.Amount = 0;
            }
            


            if(existingProduct != null)
            {
                existingProduct.Amount += item.Amount;
            }
            else
            {
                Cart.Contents.Add(item);
            }

        }

        public decimal? calculateTotal()
        {
            if (Cart.Contents == null)
            {
                return 0;
            }
            foreach (var item in Cart.Contents)
            {
                Cart.Total += item.Price;
            }

            return Cart.Total;
        }

    }
}
