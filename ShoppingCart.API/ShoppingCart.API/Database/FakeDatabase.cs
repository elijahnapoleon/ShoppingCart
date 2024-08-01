using ShoppingCartLibrary.Models;

namespace ShoppingCart.API.Database
{
    public static class FakeDatabase
    {
        public static int NextProductId
        {
            get
            {
                if (!Items.Any())
                {
                    return 1;
                }

                return Items.Select(p => p.Id).Max() + 1;
            }
        }
        public static List<Item> Items { get;} = Items = new List<Item>
            {
                new Item{Id = 1, Name = "Item 1", Price = 10, Amount = 11 }
                ,new Item{Id = 2, Name = "Item 2", Price = 10, Amount = 11 }
                ,new Item{Id = 3, Name = "Item 3", Price = 10, Amount = 11 }
            };
    }
}
