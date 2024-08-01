namespace CRM.MAUI
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void InvClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Management");
        }

        private void ShopClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Shop");
        }
    }

}
