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

    }

    private void Toolbar_ClientsClicked(object sender, EventArgs e)
    {

    }

    private void Toolbar_ProjectsClicked(object sender, EventArgs e)
    {

    }

    private void Toolbar_TeamClicked(object sender, EventArgs e)
    {

    }
}