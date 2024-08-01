using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }


        public List<Item>? Contents { get; set; }

        public decimal? Total { get; set; }

        public ShoppingCart()
        {
        }

        
    }
}
