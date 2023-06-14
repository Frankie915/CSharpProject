using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();

        }
        /*
        private void Add(object sender, EventArgs e)
        {

        }

        private void Edit(object sender, EventArgs e)
        {

        }

        private void DeleteClick(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Delete();
        }

        private void SearchClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Search();
        }
        */

        private void ClientProjectClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Client");
        }
    }
}   