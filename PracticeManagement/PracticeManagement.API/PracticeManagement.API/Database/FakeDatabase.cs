using Microsoft.AspNetCore.SignalR;
using PracticeManagement.CLI.Models;

namespace PracticeManagement.API.Database
{
    public static class FakeDatabase
    {
        public static List<Client> Clients = new List<Client>
        {
            new Client{Id = 1, Name = "Christian", Notes = "Unstable" },
            new Client{Id = 2, Name = "Poox", Notes = "Smoll" },
            new Client{Id = 3, Name = "Ness", Notes = "Autistic" }
        };

        public static int LastClientId => Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
        
    }
}


