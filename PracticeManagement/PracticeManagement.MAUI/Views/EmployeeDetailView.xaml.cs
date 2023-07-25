using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]
public partial class EmployeeDetailView : ContentPage
{
	public EmployeeDetailView()
	{
		InitializeComponent();
	}

    public int EmployeeId
    {
        set; get;
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Employee");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employee");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        if (EmployeeId == 0)
            BindingContext = new EmployeeViewModel();
        else
            BindingContext = new EmployeeViewModel(EmployeeId);
    }
}