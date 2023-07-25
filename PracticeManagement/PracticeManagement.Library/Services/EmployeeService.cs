using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;
        public static EmployeeService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeService();
                }
                return instance;
            }
        }

        private List<Employee> employees;

        public List<Employee> Employees
        {
            get { return employees; }
        }
        private EmployeeService()
        {
            employees = new List<Employee>
            {
                new Employee{Id = 1, Name = "Frank Marino", Rate = 725M},
                new Employee{Id = 2, Name = "Jonas Wilson", Rate = 293M}
            };
        }

        public Employee AddOrUpdate(Employee e)
        {

            if (e.Id == 0)
            {
                e.Id = LastId + 1;
                employees.Add(e);
            }

            return e;
        }

        private int LastId
        {
            get
            {
                return Employees.Any() ? Employees.Select(e => e.Id).Max() : 0;
            }
        }

        public Employee? Get(int id)
        {
            return Employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> Search(string query)
        {
            return Employees
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }

        public void Delete(int id)
        {
            var TimeToDelete = Employees.FirstOrDefault(e => e.Id == id);
            if (Employees != null)
            {
                Employees.Remove(TimeToDelete);
            }
        }
    }
}
