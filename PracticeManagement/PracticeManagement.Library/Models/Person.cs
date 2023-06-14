using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Models
{
    public class Person
    {
        private static int lastId = 0;

        public int Id
        {
            get; private set;
        }

        public string Name { get; set; }

        public Person()
        {
            Name = string.Empty;
            Id = ++lastId;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }
}
