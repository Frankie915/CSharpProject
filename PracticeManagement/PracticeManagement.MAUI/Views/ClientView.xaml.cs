using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class ClientView : ContentPage
{
	public ClientView()
	{
		InitializeComponent();
		BindingContext = new ClientViewViewModel();
	}

private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }
}