using ShoppingCartLibrary.Models;
using ShoppingCartLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.MAUI.ViewModels
{
    public class ShopViewModel
    {
        public ShoppingCart? Cart;

    

        public ShopViewModel() 
        {
            Cart = new ShoppingCart();
        }

        public ShopViewModel(ShoppingCart c)
        {
            Cart = c;
        }

        public decimal? Total
        {
            get
            {
                return Cart?.Total ?? 0;
            }
        }

        
    }
}
