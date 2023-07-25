using PracticeManagement.API.Database;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;

namespace PracticeManagement.API.EC
{
    public class EmployeeEC
    {
        public EmployeeDTO AddOrUpdate(EmployeeDTO dto)
        {
            Filebase.Current.AddOrUpdate(new Employee(dto));
            return dto;
        }

        public EmployeeDTO? Get(int id)
        {
            var returnVal = Filebase.Current.Employees.FirstOrDefault(e => e.Id == id) ?? new Employee();
            return new EmployeeDTO(returnVal);
        }

        public EmployeeDTO? Delete(int id)
        {
            var employeeToDelete = Filebase.Current.Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                Filebase.Current.DeleteEmployee(employeeToDelete.Id);
            }
            return employeeToDelete != null ? new EmployeeDTO(employeeToDelete) : null;
        }

        public IEnumerable<EmployeeDTO> Search(string query = "")
        {
            return Filebase.Current.Employees.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).Take(1000).Select(c => new EmployeeDTO(c));
        }
    }
}
