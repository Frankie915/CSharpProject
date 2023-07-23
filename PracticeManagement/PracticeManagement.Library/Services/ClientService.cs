using Newtonsoft.Json;
using PP.Library.Utilities;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance;
        private static object _lock = new object();
        public static ClientService Current
        {
            get
            {
                lock(_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientService();
                    }
                }
                
                return instance;
            }
        }

        //private List<Client> customers;
        private ClientService()
        {
            var response = new WebRequestHandler().Get("/Client").Result;
            clients = JsonConvert.DeserializeObject<List<ClientDTO>>(response) ?? new List<ClientDTO>();
        }

        private List<ClientDTO> clients;

        public List<ClientDTO> Clients
        {
            get {
                return clients ?? new List<ClientDTO>(); 
            }   
        }
        

        public void AddOrUpdate(ClientDTO c)
        {
            var response = new WebRequestHandler().Post("/Client", c).Result;
            var myUpdatedClient = JsonConvert.DeserializeObject<ClientDTO>(response);
            if(myUpdatedClient != null)
            {
                var existingClient = clients.FirstOrDefault(c => c.Id == myUpdatedClient.Id);
                if(existingClient == null)
                {
                    clients.Add(myUpdatedClient);
                }
                else
                {
                    var index = clients.IndexOf(existingClient);
                    clients.RemoveAt(index);
                    clients.Insert(index, myUpdatedClient);
                }
            }

        }

        public ClientDTO? Get(int id)
        {
            /*
            var response = new WebRequestHandler().Get($"/Client/GetClients/{id}").Result;
            var client = JsonConvert.DeserializeObject<Client>(response);*/
            return Clients.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var clientToDelete = Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                Clients.Remove(clientToDelete);
            }
        }


        public IEnumerable<ClientDTO> Search(string query)
        {
            return Clients
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }
    }
}
