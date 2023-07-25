using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
    public class EmployeeViewViewModel : INotifyPropertyChanged
    {

        public EmployeeViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }

        public Client SelectedEmployee { get; set; }

        public ICommand SearchCommand { get; private set; }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Employees));
        }

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get
            {
                return
                    new ObservableCollection<EmployeeViewModel>
                    (EmployeeService
                        .Current.Search(Query ?? string.Empty).OrderBy(e => e.Id)
                        .Select(e => new EmployeeViewModel(e)).ToList());
            }
        }

        public string Query { get; set; }

        public void ResetEmployeeList()
        {
            ClientService.Current.ResetClientList();
            NotifyPropertyChanged(nameof(Employees));
        }

        public void RefreshEmployeeList()
        {
            NotifyPropertyChanged(nameof(Employees));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
