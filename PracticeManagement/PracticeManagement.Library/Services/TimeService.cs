using Newtonsoft.Json;
using PP.Library.Utilities;
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
        private List<TimeDTO> times;

        public List<TimeDTO> Times
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
            //times = new List<Time> {
            //    new Time{Id = 1, EmployeeId = 1, ProjectId = 1, Hours = 1.75M, Narrative = "TEST TIME ENTRY" },
            //    new Time{Id = 2, EmployeeId = 1, ProjectId = 1, Hours = 1.25M, Narrative = "Another TIME ENTRY" } 
            //};
            var response = new WebRequestHandler().Get("/Time").Result;
            times = JsonConvert.DeserializeObject<List<TimeDTO>>(response) ?? new List<TimeDTO>();
        }

        public void AddOrUpdate(TimeDTO t)
        {

            var response = new WebRequestHandler().Post("/Time", t).Result;
            var myUpdatedTime = JsonConvert.DeserializeObject<TimeDTO>(response);
            if (myUpdatedTime != null)
            {
                var existingTime = times.FirstOrDefault(t => t.Id == myUpdatedTime.Id);
                if (existingTime == null)
                {
                    times.Add(myUpdatedTime);
                }
                else
                {
                    var index = times.IndexOf(existingTime);
                    times.RemoveAt(index);
                    times.Insert(index, myUpdatedTime);
                }

            }
        }

        public TimeDTO? Get(int id)
        {
            /*
            var response = new WebRequestHandler().Get($"/Client/GetClients/{id}").Result;
            var client = JsonConvert.DeserializeObject<Client>(response);*/

            return Times.FirstOrDefault(t => t.Id == id);
        }

        public void ResetTimeList()
        {
            var response = new WebRequestHandler().Get("/Time").Result;
            times = JsonConvert.DeserializeObject<List<TimeDTO>>(response) ?? new List<TimeDTO>();
        }

        public void Delete(int id)
        {
            var response = new WebRequestHandler().Delete($"/Time/Delete/{id}").Result;

            var timeToDelete = Times.FirstOrDefault(t => t.Id == id);
            if (timeToDelete != null)
            {
                Times.Remove(timeToDelete);
            }
        }

        public IEnumerable<TimeDTO> Search(string query)
        {
            return Times
                .Where(t => t.Narrative.ToUpper()
                    .Contains(query.ToUpper()));
        }
    }
}
