using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.PracticeManagement.Models
{
    public class Client : IEquatable<Client>
    {
        public int Id { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

        public Boolean IsActive { get; set; }

        public bool Equals(Client other)
        {
            if (other == null) return false;
            return (this.Id.Equals(other.Id));
        }

        public string? Name { get; set; }

        public string? Notes { get; set; }
    }
}
