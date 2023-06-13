using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace PracticeManagement.MAUI.ViewModels
{
	public class EmployeeViewViewModel: INotifyPropertyChanged
	{
		public EmployeeViewViewModel()
		{
			IsProjectsVisible = false;
			IsClientsVisible = true;
			IsTeamVisible = false;
			
		}

        public ObservableCollection<Client> Client
        {
            get
            {

                var filteredList = ClientService
                    .Current
                    .Customers
                    .Where(
                    s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));
                return new ObservableCollection<Client>(filteredList);

            }
        }

        public ObservableCollection<Project> Projects
		{

			get
			{
				return new ObservableCollection<Project>(ProjectService.Current.Projects);
			}
		}
        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(Client));
            }
        }

        public Project SelectedProject { get; set; }
       
        public bool IsProjectsVisible { get; set; }

		public bool IsClientsVisible { get; set; }

		public bool IsTeamVisible { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShowClients()
        {
            IsClientsVisible = true;
            IsProjectsVisible = false;
            IsTeamVisible = false;

            NotifyPropertyChanged("IsClientsVisible");
            NotifyPropertyChanged("IsProjectsVisible");
            NotifyPropertyChanged("IsTeamVisible");

        }

        public void ShowProjects()
        {
            IsClientsVisible = false;
            IsProjectsVisible = true;
            IsTeamVisible = false;
            
            NotifyPropertyChanged("IsClientsVisible");
            NotifyPropertyChanged("IsProjectsVisible");
            NotifyPropertyChanged("IsTeamVisible");
        }

        public void ShowTeam()
        {
            IsClientsVisible = false;
            IsProjectsVisible = false;
            IsTeamVisible = true;

            NotifyPropertyChanged("IsClientsVisible");
            NotifyPropertyChanged("IsProjectsVisible");
            NotifyPropertyChanged("IsTeamVisible");
        }

        public void ResetView()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
        }

        public void RefreshView()
		{
			NotifyPropertyChanged(nameof(Projects));
		}
	}
}

