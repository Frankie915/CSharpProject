using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class TimeService
    {
        private static TimeService? instance;
        private List<Time> times;

        public List<Time> Times
        { get { return times; } }

        public static TimeService Current
        {
            get
            {
                if(instance == null)
                {
                    instance = new TimeService();
                }
                return instance;
            }
        }
        private TimeService()
        {
            times = new List<Time> {
                new Time{Id = 1, EmployeeId = 0, ProjectId = 1, Hours = 1.75M, Narrative = "TEST TIME ENTRY" },
                new Time{Id = 2, EmployeeId = 0, ProjectId = 1, Hours = 1.25M, Narrative = "TEST TIME ENTRY" } 
            };
        }


    }
}
