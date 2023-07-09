using Microsoft.AspNetCore.Mvc;
using PracticeManagement.API.Database;
using PracticeManagement.CLI.Models;
using PracticeManagement.Library.DTO;

namespace PracticeManagement.API.EC
{
    public class ClientEC
    {
        public ClientDTO AddOrUpdate(ClientDTO dto)
        {
            if (dto.Id > 0)
            {
                var clientToUpdate = FakeDatabase.Clients.FirstOrDefault(c => c.Id == dto.Id);
                if (clientToUpdate != null)
                {
                    FakeDatabase.Clients.Remove(clientToUpdate);
                }
                FakeDatabase.Clients.Add(new Client(dto));
            }
            else
            {
                dto.Id = FakeDatabase.LastClientId + 1;
                FakeDatabase.Clients.Add(new Client(dto));   
            }
            return dto;
        }

        public ClientDTO? Get(int id)
        {
            var returnVal = FakeDatabase.Clients.FirstOrDefault(c => c.Id == id) ?? new Client();
            return new ClientDTO(returnVal);
        }

        public ClientDTO? Delete(int id)
        {
            var clientToDelete = FakeDatabase.Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                FakeDatabase.Clients.Remove(clientToDelete);
            }
            return clientToDelete != null ? new ClientDTO(clientToDelete) : null;
        }

        public IEnumerable<ClientDTO> Search(string query ="")
        {
            return FakeDatabase.Clients.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).Take(1000).Select(c => new ClientDTO(c));
        }
    }
}
