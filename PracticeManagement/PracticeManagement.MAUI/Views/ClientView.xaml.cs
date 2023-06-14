using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class ClientView : ContentPage
{
    public ClientView()
    {
        InitializeComponent();
        BindingContext = new ClientViewModel();
    }

    void CancelClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewModel).ResetView();
        (BindingContext as ClientViewModel).RefreshView();
    }

    private void Toolbar_ClientsClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).ShowClients();
    }

    private void Toolbar_ProjectsClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).ShowProjects();
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

    void AddClientClicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as ClientViewModel).AddClientClick(Shell.Current);
    }

    void EditClientClicked(System.Object sender, System.EventArgs e)
    {
    }

    void RemoveClientClicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as ClientViewModel).RemoveClientClick();
    }
}