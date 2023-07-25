using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.Library.DTO
{
    public class TimeDTO
    {
        public TimeDTO()
        {
            Narrative = string.Empty;
            //Id = ++incrementId;
        }

        public TimeDTO(Time c)
        {
            this.Id = c.Id;
            this.Hours = c.Hours;
            this.ProjectId = c.ProjectId;
            this.EmployeeId = c.EmployeeId;
            this.Narrative = c.Narrative;
        }
        public DateTime Date { get; set; }

        public string? Narrative { get; set; }

        public decimal Hours { get; set; }

        public int Id { get; set; }
        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }
    }
}
