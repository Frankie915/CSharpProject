using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.CLI.Models
{
    public class Client
    {
        //private static int incrementId = 0;
        
        public Client()
        {
            Name = string.Empty;
            Notes= string.Empty;
            //Id = ++incrementId;
        }

        public Client(ClientDTO dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.Notes = dto.Notes;
        }

        public int Id { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

        public Boolean IsActive { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
        public string Property5 { get; set; }
        public string Property6 { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name} - Notes: {Notes}";
        }

    }
}
