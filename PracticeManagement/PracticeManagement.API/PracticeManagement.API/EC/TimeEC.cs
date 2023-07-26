using Microsoft.AspNetCore.Mvc;
using PracticeManagement.API.Database;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.DTO;

namespace PracticeManagement.API.EC
{
    public class TimeEC
    {
        public TimeDTO AddOrUpdate(TimeDTO dto)
        {
            Filebase.Current.AddOrUpdate(new Time(dto));
            return dto;
        }

        public TimeDTO? Get(int id)
        {
            var returnVal = Filebase.Current.Times.FirstOrDefault(t => t.Id == id) ?? new Time();
            return new TimeDTO(returnVal);
        }

        public TimeDTO? Delete(int id)
        {
            var TimeToDelete = Filebase.Current.Times.FirstOrDefault(t => t.Id == id);
            if (TimeToDelete != null)
            {
                Filebase.Current.DeleteTime(TimeToDelete.Id);
            }
            return TimeToDelete != null ? new TimeDTO(TimeToDelete) : null;
        }

        public IEnumerable<TimeDTO> Search(string query = "")
        {
            return Filebase.Current.Times.Where(t => t.Narrative.ToUpper().Contains(query.ToUpper())).Take(1000).Select(t => new TimeDTO(t));
        }
    }
}