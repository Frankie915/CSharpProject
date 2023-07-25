using Newtonsoft.Json;
using PP.Library.Utilities;
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

        private List<EmployeeDTO> employees;

        public List<EmployeeDTO> Employees
        {
            get { return employees ?? new List<EmployeeDTO>(); }
        }

        public void ResetEmployeeList()
        {
            var response = new WebRequestHandler().Get("/Employee").Result;
            employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(response) ?? new List<EmployeeDTO>();
        }

        private EmployeeService()
        {
            var response = new WebRequestHandler().Get("/Employee").Result;
            employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(response) ?? new List<EmployeeDTO>();
        }

        public void AddOrUpdate(EmployeeDTO c)
        {
            var response = new WebRequestHandler().Post("/Employee", c).Result;
            var myUpdatedEmployee = JsonConvert.DeserializeObject<EmployeeDTO>(response);
            if (myUpdatedEmployee != null)
            {
                var existingEmployee = employees.FirstOrDefault(c => c.Id == myUpdatedEmployee.Id);
                if (existingEmployee == null)
                {
                    employees.Add(myUpdatedEmployee);
                }
                else
                {
                    var index = employees.IndexOf(existingEmployee);
                    employees.RemoveAt(index);
                    employees.Insert(index, myUpdatedEmployee);
                }

            }

        }

        private int LastId
        {
            get
            {
                return Employees.Any() ? Employees.Select(e => e.Id).Max() : 0;
            }
        }

        public EmployeeDTO? Get(int id)
        {
            return Employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<EmployeeDTO> Search(string query)
        {
            return Employees
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }

        public void Delete(int id)
        {
            var response = new WebRequestHandler().Delete($"/Employee/Delete/{id}").Result;

            var EmployeeToDelete = Employees.FirstOrDefault(c => c.Id == id);
            if (EmployeeToDelete != null)
            {
                Employees.Remove(EmployeeToDelete);
            }
        }
    }
}
