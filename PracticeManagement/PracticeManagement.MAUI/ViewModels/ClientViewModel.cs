using PracticeManagement.CLI.Models;
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
    public class ClientViewModel : INotifyPropertyChanged
    {
        public Client Model { get; set; }

        private void SetupCommands()
        {
            DeleteCommand = new Command((c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command((c) => ExecuteEdit((c as ClientViewModel).Model.Id));
            AddCommand = new Command(
                (c) => ExecuteAdd());
        }
        public ClientViewModel()
        {

            Model = new Client();
            Model.Id = 0;
            SetupCommands();
            IsProjectsVisible = false;
            IsClientsVisible = true;

        }

        public ClientViewModel(Client client)
        {
            Model = client;
            SetupCommands();
        }

        public ClientViewModel(int clientId)
        {
            Model = ClientService.Current.Get(clientId);
            SetupCommands();
        }

        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public ICommand AddCommand { get; private set; }
        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//PersonDetail?clientId={id}");
        }

        public void ExecuteAdd()
        {
            Shell.Current.GoToAsync($"//PersonDetail?clientId=0");
        }

        public ObservableCollection<Project> Projects
        {

            get
            {
                return new ObservableCollection<Project>(ProjectService.Current.Projects);
            }
        }

        public Client SelectedClient { get; set; }

        public Project SelectedProject { get; set; }


        public bool IsProjectsVisible { get; set; }

        public bool IsClientsVisible { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void ShowClients()
        {
            IsClientsVisible = true;
            IsProjectsVisible = false;
            

            NotifyPropertyChanged("IsClientsVisible");
            NotifyPropertyChanged("IsProjectsVisible");

        }

        public void ShowProjects()
        {
            IsClientsVisible = false;
            IsProjectsVisible = true;

            NotifyPropertyChanged("IsClientsVisible");
            NotifyPropertyChanged("IsProjectsVisible");
        }

        public void ShowTeam()
        {
            IsClientsVisible = false;
            IsProjectsVisible = false;

            NotifyPropertyChanged("IsClientsVisible");
            NotifyPropertyChanged("IsProjectsVisible");
        }

        public void AddOrUpdate()
        {
            ClientService.Current.AddOrUpdate(Model);
        }


    }
}
