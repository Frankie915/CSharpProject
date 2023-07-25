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
    public class ClientViewViewModel : INotifyPropertyChanged
    {
        public ClientViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
            IsClientsVisible = true;
            IsProjectsVisible = false;
        }
        public Client SelectedClient { get; set; }

        public ICommand SearchCommand { get; private set; }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

        public bool IsProjectsVisible { get; set; }

        public bool IsClientsVisible { get; set; }

        //private string query;
        public string Query { get; set; }
        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                return
                    new ObservableCollection<ClientViewModel>
                    (ClientService
                        .Current.Search(Query ?? string.Empty).OrderBy(c => c.Id)
                        .Select(c => new ClientViewModel(c)).ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ResetClientList()
        {
            ClientService.Current.ResetClientList();
            NotifyPropertyChanged(nameof(Clients));
        }

        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Clients));
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


        public void RemoveClientClick()
        {
            if (SelectedClient != null)
            {
                ClientService.Current.Delete(SelectedClient.Id);
                SelectedClient = null;
                NotifyPropertyChanged(nameof(Clients));
                NotifyPropertyChanged(nameof(SelectedClient));
            }
        }
    }
}
