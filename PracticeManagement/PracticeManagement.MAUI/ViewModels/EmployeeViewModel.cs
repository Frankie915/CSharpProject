using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
	public class EmployeeViewModel: INotifyPropertyChanged
	{

        public Employee Model { get; set; }
        public EmployeeViewModel()
		{
            Model = new Employee();
            Model.Id = 0;
            SetupCommands();
        }

        public EmployeeViewModel(Employee employee)
        {
            Model = employee;
            SetupCommands();
        }

        public EmployeeViewModel(int employeeId)
        {
            Model = EmployeeService.Current.Get(employeeId);
            SetupCommands();
        }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command((c) => ExecuteDelete((c as EmployeeViewModel).Model.Id));
            EditCommand = new Command((c) => ExecuteEdit((c as EmployeeViewModel).Model.Id));
            AddCommand = new Command((c) => ExecuteAdd((c as EmployeeViewModel).Model.Id));
        }

        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }

        public void ExecuteDelete(int id)
        {
            EmployeeService.Current.Delete(id);
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//EmployeeDetail?employeeId={id}");
        }

        public void ExecuteAdd(int id)
        {
            Shell.Current.GoToAsync($"//EmployeeDetail?employeeId=0");
        }


        public void AddOrUpdate()
        {
            EmployeeService.Current.AddOrUpdate(Model);
            //NotifyPropertyChanged
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

