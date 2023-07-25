using PracticeManagement.Library.DTO;
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
                new Time{Id = 1, EmployeeId = 1, ProjectId = 1, Hours = 1.75M, Narrative = "TEST TIME ENTRY" },
                new Time{Id = 2, EmployeeId = 1, ProjectId = 1, Hours = 1.25M, Narrative = "Another TIME ENTRY" } 
            };
        }

        public Time AddOrUpdate(Time t)
        {

            if (t.Id == 0)
            {
                t.Id = LastId + 1;
                times.Add(t);
            }

            return t;
        }

        private int LastId
        {
            get
            {
                return Times.Any() ? Times.Select(t => t.Id).Max() : 0;
            }
        }

        public Time Get(int id)
        {
            /*
            var response = new WebRequestHandler().Get($"/Client/GetClients/{id}").Result;
            var client = JsonConvert.DeserializeObject<Client>(response);*/

            return Times.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(int id)
        {
            var TimeToDelete = Times.FirstOrDefault(c => c.Id == id);
            if (Times != null)
            {
                Times.Remove(TimeToDelete);
            }
        }
    }
}
