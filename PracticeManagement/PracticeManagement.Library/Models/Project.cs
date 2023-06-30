using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.CLI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

        public Boolean IsActive { get; set; }

        public Client? Client { get; set; }
        public string? Name { get; set; }
        public int ClientId { get; set; }

        public override string ToString()
        {
            return $"Project Id:{Id}\nClient Id:{ClientId};
        }
    }
}
