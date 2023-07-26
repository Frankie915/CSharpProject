using PracticeManagement.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.Library.Models
{
    public class Time
    {

        public Time()
        {
            Narrative = string.Empty;
        }

        public Time(TimeDTO dto)
        {
            this.Id = dto.Id;
            this.Narrative = dto.Narrative;
            this.Hours = dto.Hours;
            this.EmployeeId = dto.EmployeeId;
            this.ProjectId = dto.ProjectId;
        }
        public DateTime Date { get; set; }

        public string? Narrative { get; set; }

        public decimal Hours { get; set; }

        public int Id { get; set; }
        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }
    }
}
