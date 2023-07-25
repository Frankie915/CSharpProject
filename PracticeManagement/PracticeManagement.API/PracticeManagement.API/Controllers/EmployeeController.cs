using Microsoft.AspNetCore.Mvc;
using PracticeManagement.API.EC;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Utilities;

namespace PracticeManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<EmployeeDTO> Get()
        {
            return new EmployeeEC().Search();
        }

        [HttpGet("/{id}")]

        public EmployeeDTO? GetId(int id)
        {
            return new EmployeeEC().Get(id);
        }

        [HttpDelete("Delete/{id}")]

        public EmployeeDTO? Delete(int id)
        {
            return new EmployeeEC().Delete(id);
        }

        [HttpPost]
        public EmployeeDTO AddOrUpdate([FromBody] EmployeeDTO employee)
        {
            return new EmployeeEC().AddOrUpdate(employee);
        }

        [HttpPost("Search")]
        public IEnumerable<EmployeeDTO> Search([FromBody] QueryMessage query)
        {
            return new EmployeeEC().Search(query.Query);
        }
    }
}

