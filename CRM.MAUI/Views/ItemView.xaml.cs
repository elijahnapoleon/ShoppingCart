using CRM.MAUI.ViewModels;

namespace CRM.MAUI.Views;


[QueryProperty(nameof(ItemId), "itemId")]
public partial class ItemView : ContentPage
{
    public int ItemId {  get; set; }
    
	public ItemView()
	{
		InitializeComponent();
	}

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ItemViewModel).Add();
        Shell.Current.GoToAsync("//Management");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Management");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ItemViewModel(ItemId);
    }
}