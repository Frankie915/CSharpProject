using PracticeManagement.CLI.Models;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
	}

	public int ClientId
	{
		set; get;
	}

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Client");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        if(ClientId == 0)
            BindingContext = new ClientViewModel();
        else
            BindingContext = new ClientViewModel(ClientId);

        (BindingContext as ClientViewModel).RefreshProjects();
    }

}