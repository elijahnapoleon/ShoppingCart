using ShoppingCart.API.Database;
using ShoppingCartLibrary.Models;

namespace ShoppingCart.API.EC
{
    public class InventoryEC
    {
        
        public InventoryEC() 
        {
            
        }

        public async Task<IEnumerable<Item>> Get()
        {
        return FakeDatabase.Items.Take(100); 
        }

        public async Task<Item> AddOrUpdate(Item item)
        {
            bool isAdd = false;
            if (item.Id == 0)
            {
                isAdd = true;
                item.Id = FakeDatabase.NextProductId;
            }

            if (isAdd)
            {
                FakeDatabase.Items.Add(item);
            } else
            {
                var prodToUpdate = FakeDatabase.Items.FirstOrDefault(a => a.Id == item.Id);
                if(prodToUpdate != null)
                {
                    var index = FakeDatabase.Items.IndexOf(prodToUpdate);
                    FakeDatabase.Items.RemoveAt(index);
                    prodToUpdate = new Item(item);
                    FakeDatabase.Items.Insert(index, prodToUpdate);
                }
            }

            return item;
        }

        public async Task<Item?> Delete(int id)
        {
            var itemToDelete = FakeDatabase.Items.FirstOrDefault(p => p.Id == id);
            if (itemToDelete != null)
            {
                FakeDatabase.Items.Remove(itemToDelete);
            }
          
            return itemToDelete;
        }

        public async Task<IEnumerable<Item>> Search(string? query)
        {
            return FakeDatabase.Items.Where(p => p.Name.ToUpper().Contains(query.ToUpper()) 
            || p.Description.ToUpper().Contains(query.ToUpper())).Take(100);
        }
    }
}
