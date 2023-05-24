using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.PracticeManagement.Models
{
    public class Project : IEquatable<Project>
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

        public Boolean IsActive { get; set; }

        

        public string? ShortName { get; set; }
        
        public string? LongName { get; set; }
        public int ClientId { get; set; }
    }
}
