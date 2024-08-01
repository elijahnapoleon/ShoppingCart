using CRM.MAUI.ViewModels;
using ShoppingCartLibrary.Models;
namespace CRM.MAUI.Views;

[QueryProperty(nameof(ItemId), "itemId")]
[QueryProperty(nameof(nav), "page")]
public partial class ReadItemView : ContentPage
{
    public int ItemId { get; set; }
    public char nav { get; set; }
    public ReadItemView()
	{
		InitializeComponent();
	}

    private void BackClicked(object sender, EventArgs e)
    {
        if(nav == 'i')
        {
            Shell.Current.GoToAsync("//Management");
        }
        else
        {
            Shell.Current.GoToAsync("//Shop");
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ItemViewModel(ItemId);
    }
}