using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class EmployeeView : ContentPage
{
	public EmployeeView()
	{
		InitializeComponent();
		BindingContext = new EmployeeViewViewModel();
	}

    void CancelClicked(System.Object sender, System.EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).ResetView();
        (BindingContext as EmployeeViewViewModel).RefreshView();
    }

    private void Toolbar_ClientsClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).ShowClients();
    }

    private void Toolbar_ProjectsClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).ShowProjects();
    }

    private void Toolbar_TeamClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).ShowTeam();
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
}