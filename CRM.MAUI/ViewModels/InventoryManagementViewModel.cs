using ShoppingCartLibrary.DTO;
using ShoppingCartLibrary.Models;
using ShoppingCartLibrary.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRM.MAUI.ViewModels
{
    public class InventoryManagementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Query { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<ItemViewModel> Items
            { 
                get
                {
                    return ItemServiceProxy.Current?.Items?.Where(c=>c!=null).Select(c => new ItemViewModel(c)).ToList() 
                    ?? new List<ItemViewModel>();
                }
            }

        public List<ShopViewModel> Cart
        {
            get
            {
                return ShoppingCartService.Current.Carts?.Select(c => new ShopViewModel(c)).ToList() ?? new List<ShopViewModel>();
            }
        }

        public ItemViewModel? SelectedProduct { get; set; }

        public InventoryManagementViewModel() { 
            
        }

        public async void RefreshInventory()
        {
            await ItemServiceProxy.Current.Search(new Query(Query));
            NotifyPropertyChanged("Items");
        }

        public async void Search()
        {
            await ItemServiceProxy.Current.Search(new Query(Query));
        }
        public void UpdateItem()
        {
            if(SelectedProduct?.Item == null)
            {
                return;
            }
            Shell.Current.GoToAsync($"//AddItem?itemId={SelectedProduct.Item.Id}");

            ItemServiceProxy.Current.AddOrUpdate(SelectedProduct.Item); 
        }

        public void AddCartItem()
        {
            if(SelectedProduct == null)
            {
                return;
            }

            Shell.Current.GoToAsync($"//CartItem?itemId={SelectedProduct.Item.Id}");

            ShoppingCartService.Current.AddToCart(SelectedProduct.Item);
        }

        public async void Delete()
        {
            await ItemServiceProxy.Current.Delete(SelectedProduct.Item.Id);
            RefreshInventory();
        }

        public void ViewItem(char nav)
        {
            if( SelectedProduct?.Item == null)
            {
                return;
            }

            var navigationParameter = new Dictionary<string, object>
                {
                    { "itemId", SelectedProduct.Item.Id },
                    {"page", nav }
                };
            Shell.Current.GoToAsync("//ReadItem", navigationParameter);
        }
    }
}
