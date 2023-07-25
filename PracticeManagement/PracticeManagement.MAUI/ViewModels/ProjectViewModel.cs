using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
    public class ProjectViewModel
    {
        public Project Model { get; set; }

        public ICommand AddCommand { get; private set; }
        public ICommand EditProjectCommand { get; private set; }
        public ICommand DeleteProjectCommand { get; private set; }
        public ICommand TimerCommand { get; private set; }

        public string Display
        {
            get
            {
                return Model.ToString();
            }
        }

        private void ExecuteAdd()
        {
            ProjectService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//PersonDetail?clientId={Model.ClientId}");
        }

        public void ExecuteEdit()
        {
            ProjectService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//PersonDetail?clientId={Model.ClientId}");
        }

        

        public void ExecuteDelete()
        {
            ProjectService.Current.Delete(Model.Id);
        }

        private void ExecuteTimer()
        {
            var window = new Window()
            {
                Width = 275,
                Height = 350,
                X = 0,
                Y = 0
            };
            var view = new TimerView(Model.Id, window);
            window.Page = view;
            Application.Current.OpenWindow(window);
        }


        public void SetupCommands()
        {
            AddCommand = new Command(ExecuteAdd);
            TimerCommand = new Command(ExecuteTimer);
            EditProjectCommand = new Command(ExecuteEdit);
            DeleteProjectCommand = new Command(ExecuteDelete);
        }

        public ProjectViewModel()
        {
            Model = new Project();
            SetupCommands();
        }

        public ProjectViewModel(int clientId)
        {

            Model = new Project { ClientId = clientId };
            SetupCommands();
        }

        public ProjectViewModel(Project model)
        {
            Model = model;
            SetupCommands();
        }
    }
}
