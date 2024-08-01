using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary.Models
{
    public class Item
    {
        private string? name;
        public string? Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value ?? "Unnamed Item";
            }
        }
        private string? description;
        public string? Description
        {
            get { return description; }
            set { description = value ?? string.Empty; }
        }

        public int Id { get; set; }

        private decimal? price;

        public decimal? Price
        {
            get => price;
            set
            {
                if (value < 0) { price = 0; }
                else { price = value ?? 0; }
            }

        }

        private int? amount;
        public int? Amount
        {

            get
            {
                return amount ?? 0;
            }

            set
            {
                if (value < 0)
                {
                    amount = 0;
                }
                else
                {
                    amount = value ?? 0;
                }
            }
        }

        public Item()
        {
        }

        public Item(Item i)
        {
            Name = i.Name;
            Description = i.Description;
            Price = i.Price;
            Amount = i.Amount;
            Id = i.Id;
        }
    }
}
