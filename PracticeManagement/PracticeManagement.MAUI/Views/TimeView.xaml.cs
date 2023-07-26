using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class TimeView : ContentPage
{
	public TimeView()
	{
		InitializeComponent();
        BindingContext = new TimeViewViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewViewModel();
        (BindingContext as TimeViewViewModel).ResetTimeList();
        (BindingContext as TimeViewViewModel).RefreshTimes();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TimeDetail");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewViewModel).RefreshTimes();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewViewModel).RefreshTimes();
    }
}