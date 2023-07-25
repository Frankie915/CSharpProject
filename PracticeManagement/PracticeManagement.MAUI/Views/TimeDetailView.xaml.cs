using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(TimeId), "timeId")]
public partial class TimeDetailView : ContentPage
{
	public TimeDetailView()
	{
		InitializeComponent();
	}

    public int TimeId
    {
        set; get;
    }

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Times");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        
            if (TimeId == 0)
                BindingContext = new TimeViewModel();
            else
                BindingContext = new TimeViewModel(TimeId);

            //(BindingContext as TimeViewViewModel).RefreshTimes();
        }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Times");
    }
}
