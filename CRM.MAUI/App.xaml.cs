using CRM.MAUI.ViewModels;
using CRM.MAUI.Views;

namespace CRM.MAUI
{
    public partial class App : Application
    {
        public static InventoryManagementViewModel inventoryManagementViewModel;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            inventoryManagementViewModel = new InventoryManagementViewModel();
        }
    }
}
