using Microsoft.AspNetCore.Mvc;
using PracticeManagement.API.Database;
using PracticeManagement.CLI.Models;

namespace PracticeManagement.API.Controllers
{ 
    [ApiController]
    [Route("[controller]")]

    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetClients")]
        public IEnumerable<Client> Get()
        {
            return FakeDatabase.Clients;
        }

        [HttpGet("GetClients/{id}")]

        public Client GetId(int id)
        {
            return FakeDatabase.Clients.FirstOrDefault(c => c.Id == id) ?? new Client();
        }
    }
}
