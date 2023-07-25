using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class EmployeeView : ContentPage
{
	public EmployeeView()
	{
		InitializeComponent();
		BindingContext = new EmployeeViewViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    void AddClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync($"//EmployeeDetail?employeeId=0");
        //(BindingContext as EmployeeViewViewModel).ResetEmployeeList();
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    void EditClicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    void DeleteClicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).ResetEmployeeList();
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

}