using PracticeManagement.Library.Models;
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
    public class TimeViewModel : INotifyPropertyChanged
    {
        public Time Model { get; set; }
        private Employee employee;
        public Employee Employee {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                if(employee != null)
                {
                    Model.EmployeeId = employee.Id;
                }
            }
        }

        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public void SetupCommands()
        {
            DeleteCommand = new Command((c) => ExecuteDelete((c as TimeViewModel).Model.Id));
            EditCommand = new Command((c) => ExecuteEdit((c as TimeViewModel).Model.Id));

        }

        public void ExecuteDelete(int id)
        {
            TimeService.Current.Delete(id);
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync("//TimeDetail");
        }

        public string EmployeeDisplay => Employee?.Name ?? string.Empty;
        private Project project;

        public string HoursDisplay
        {
            get
            {
                return Model.Hours.ToString();

            }
            set
            {
                if(Decimal.TryParse(value, out decimal v))
                {
                    Model.Hours = v;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Project Project {
        
            get
            {
                return project;
            }
            set 
            {
                project = value;
                if(project != null)
                {
                    Model.ProjectId = project.Id;
                }
            }

        }
        public string ProjectDisplay => Project?.Name ?? string.Empty;

        public ObservableCollection<Employee> Employees
        {
            get
            {
                return new ObservableCollection<Employee>(EmployeeService.Current.Employees);
            }
        }

        public ObservableCollection<Project> Projects
        {
            get
            {
                return new ObservableCollection<Project>(ProjectService.Current.Projects);
            }
        }

        public TimeViewModel()
        {
            Model = new Time();
            SetupCommands();
        }

        public TimeViewModel(Time t)
        {
            Model = t;
            var employee = EmployeeService.Current.Get(t.EmployeeId);
            if(employee != null )
            {
                Employee = employee;
            }

            var project = ProjectService.Current.Get(t.ProjectId);
            if(project != null )
            {
                Project = project;
            }
            SetupCommands();
        }

        public void AddOrUpdate()
        {
            TimeService.Current.AddOrUpdate(Model);
        }
    }
}
