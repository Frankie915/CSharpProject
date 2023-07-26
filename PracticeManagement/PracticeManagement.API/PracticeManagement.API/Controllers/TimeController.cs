using Microsoft.AspNetCore.Mvc;
using PracticeManagement.API.EC;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Utilities;

namespace PracticeManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;

        public TimeController(ILogger<TimeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TimeDTO> Get()
        {
            return new TimeEC().Search();
        }

        [HttpGet("/{id}")]

        public TimeDTO? GetId(int id)
        {
            return new TimeEC().Get(id);
        }

        [HttpDelete("Delete/{id}")]

        public TimeDTO? Delete(int id)
        {
            return new TimeEC().Delete(id);
        }

        [HttpPost]
        public TimeDTO AddOrUpdate([FromBody] TimeDTO time)
        {
            return new TimeEC().AddOrUpdate(time);
        }

        [HttpPost("Search")]
        public IEnumerable<TimeDTO> Search([FromBody] QueryMessage query)
        {
            return new TimeEC().Search(query.Query);
        }
    }
}
