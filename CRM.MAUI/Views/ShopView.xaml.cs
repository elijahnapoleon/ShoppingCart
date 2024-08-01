using CRM.MAUI.ViewModels;

namespace CRM.MAUI.Views;


public partial class ShopView : ContentPage
{
	public ShopView()
	{
		InitializeComponent();
        BindingContext = App.inventoryManagementViewModel;
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void ViewClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel).ViewItem('s'); 
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel).AddCartItem();
    }
}