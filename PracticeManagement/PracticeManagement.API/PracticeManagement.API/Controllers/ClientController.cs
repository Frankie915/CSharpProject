using Microsoft.AspNetCore.Mvc;
using PracticeManagement.API.Database;
using PracticeManagement.API.EC;
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

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return FakeDatabase.Clients;
        }

        [HttpGet("/{id}")]

        public Client GetId(int id)
        {
            return FakeDatabase.Clients.FirstOrDefault(c => c.Id == id) ?? new Client();
        }

        [HttpDelete("Delete/{id}")]

        public Client? Delete(int id)
        {
            var clientToDelete = FakeDatabase.Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                FakeDatabase.Clients.Remove(clientToDelete);
            }
            return clientToDelete;
        }

        [HttpPost]
        public Client AddOrUpdate([FromBody]Client client)
        {
            return new ClientEC().AddOrUpdate(client);
        }
    }
}
