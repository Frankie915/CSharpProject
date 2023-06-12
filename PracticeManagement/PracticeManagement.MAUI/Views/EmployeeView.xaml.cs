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
}