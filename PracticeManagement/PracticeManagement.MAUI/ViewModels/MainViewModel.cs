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
    public class MainViewModel: INotifyPropertyChanged
    {
        public List<Client> Clients
        {
            get
            {
                return ClientService.Current.Customers;
            }
        }
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
        }
    }

}
