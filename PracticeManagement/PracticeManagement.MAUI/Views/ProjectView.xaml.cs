using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectView : ContentPage
{
    public int ClientId { get; set; }
    public ProjectView()
    {
        InitializeComponent();
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewViewModel(ClientId);
        (BindingContext as EmployeeViewViewModel).ResetEmployeeList();
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }
}