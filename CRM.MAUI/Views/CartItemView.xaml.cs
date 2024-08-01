using CRM.MAUI.ViewModels;
using ShoppingCartLibrary.Models;

namespace CRM.MAUI.Views;

[QueryProperty(nameof(ItemId), "itemId")]
public partial class CartItemView : ContentPage
{
    public int ItemId { get; set; }
	public CartItemView()
	{
		InitializeComponent();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Shop");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ItemViewModel).AddToCart();
        Shell.Current.GoToAsync("//Shop");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ItemViewModel(ItemId);
    }
}