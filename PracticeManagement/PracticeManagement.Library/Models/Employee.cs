using PracticeManagement.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Models
{
    public class Employee
    {
        public Employee() 
        { 
            Name = string.Empty;
        }

        public Employee(EmployeeDTO dto)
        {
            this.Name = dto.Name;
            this.Rate = dto.Rate;
            this.Id = dto.Id;
        }

        public string Name { get; set; }

        public decimal Rate { get; set; }

        public int Id { get; set; }

        public override string ToString() => Name ?? string.Empty;
    }
}
