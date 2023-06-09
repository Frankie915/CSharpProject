﻿using PracticeManagement.CLI.Models;
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
    public class MainViewModel
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        /*
        public ObservableCollection<Project> Projects
        {
            get
            {
                return new ObservableCollection<Project>(ProjectService.Current.Projects);
            }
        }

        public ObservableCollection<Client> Clients
        {
            get
            {
                if(string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Client>(ClientService.Current.Customers);
                }
                return new ObservableCollection<Client>(ClientService.Current.Search(Query));
            }
        }

        public string Query { get; set; }

        public void Search()
        {
            NotifyPropertyChanged("Clients");
        }

        public void Delete()
        {
            if(SelectedClient == null) return;
            ClientService.Current.Delete(SelectedClient);
            NotifyPropertyChanged("Clients");
        }

        public Client SelectedClient {  get; set; }

        //private string test1;
        //public string Test1
        //{
        //    get
        //    {
        //        return test1;
        //    }
        //    set
        //    {
        //        test1 = value;
        //    }
        //}

        //private string test2;

        //public string Test2
        //{
        //    get
        //    {
        //        return test2;
        //    }
        //    set
        //    {
        //        Test2 = value;      
        //    }
        //}

        //public string Test3
        //{
        //    get
        //    {
        //        return "Test3";
        //    }
        //}

        //public string Test4
        //{
        //    get
        //    {
        //        return "Test4";
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/
    }

}
