using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.MAUI.ViewModels
{
    public class PersonDetailViewModel : INotifyPropertyChanged
    {
        public Client Status { get; set; }
        public string Name { get; set; }

        public string Notes { get; set; }

        public int Id { get; set; }

        public PersonDetailViewModel(int id=0)
        {
            if(id>0)
            {
                Load(id);
            }
        }

        public void Load(int id)
        {
            if (id == 0) { return; }
            var client = ClientService.Current.GetById(id) as Client;
            if (client != null)
            {
                Status = client;
            }
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Notes));
        }

        public void AddClient()
        {

            if (Id <= 0)
            {
                ClientService.Current.Add(new Client { Name = Name, Notes = Notes });
            }
            else
            {
                var refToUpdate = ClientService.Current.GetById(Id) as Client;
                refToUpdate.Name = Name;
                refToUpdate.Notes = Notes;
            }
            Shell.Current.GoToAsync("//Client");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
