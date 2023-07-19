using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.MAUI.ViewModels
{
    public class TimeViewViewModel
    {
        public ObservableCollection<Time> Times
        {
            get
            {
                return new ObservableCollection<Time>(TimeService.Current.Times);
            }
        }
         
    }
}
