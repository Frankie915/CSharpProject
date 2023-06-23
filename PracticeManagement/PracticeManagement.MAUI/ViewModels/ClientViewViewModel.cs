
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

namespace PracticeManagement.MAUI.ViewModels
{
    public class ClientViewViewModel : INotifyPropertyChanged
    {
        public ClientViewViewModel()
        {
            IsClientsVisible = true;
            IsProjectsVisible = false;
        }
        public Client SelectedClient { get; set; }

        public bool IsProjectsVisible { get; set; }

        public bool IsClientsVisible { get; set; }

        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(Clients));
            }
        }
        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {

                return new ObservableCollection<ClientViewModel>
                    (ClientService.Current.Customers.Select(c => new ClientViewModel(c)).ToList());
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ResetClientList()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
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

        public void AddClient(Shell s)
        {
            s.GoToAsync($"//PersonDetail?clientId=0");
        }

        public void EditClient(Shell s)
        {
           /* 
            var idParam = SelectedClient?.Id ?? 0;
            s.GoToAsync($"//PersonDetail?clientId={idParam}");
            */
            NotifyPropertyChanged (nameof(Clients));
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
