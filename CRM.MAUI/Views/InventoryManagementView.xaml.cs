using CRM.MAUI.ViewModels;

namespace CRM.MAUI.Views;

public partial class InventoryManagementView : ContentPage
{
    public InventoryManagementViewModel t {  get; set; }
	public InventoryManagementView()
	{
		InitializeComponent();
        BindingContext = App.inventoryManagementViewModel;
	}

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel).UpdateItem();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddItem");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InventoryManagementViewModel).RefreshInventory();
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {

    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel).Delete();
    }

    private void InlineViewClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel).ViewItem('i');
    }
}