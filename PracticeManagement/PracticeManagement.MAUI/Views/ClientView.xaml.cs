using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class ClientView : ContentPage
{
    public ClientView()
    {
        InitializeComponent();
        BindingContext = new ClientViewViewModel();
    }

    void CancelClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    /*
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewModel).ResetView();
        (BindingContext as ClientViewModel).RefreshView();
    }
    */
    private void Toolbar_ClientsClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).ShowClients();
    }

    private void Toolbar_ProjectsClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).ShowProjects();
    }

    private void AddProjectClicked(object sender, EventArgs e)
    {

    }

    private void EditProjectClicked(object sender, EventArgs e)
    {

    }

    private void RemoveProjectClicked(object sender, EventArgs e)
    {

    }

    void AddClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync($"//PersonDetail?clientId=0");
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    void DeleteClicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewViewModel).ResetClientList();
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    private void ProjectsClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }
}