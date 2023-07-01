using Newtonsoft.Json;
using PP.Library.Utilities;
using PracticeManagement.CLI.Models;
using System;
using System.Collections.Generic;
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
            var response = new WebRequestHandler().Get("/Client/GetClients").Result;
            clients = JsonConvert.DeserializeObject<List<Client>>(response) ?? new List<Client>();
        }

        private List<Client> clients;

        public List<Client> Customers
        {
            get {
                return clients ?? new List<Client>(); 
            }   
        }
        /*
        public List<Client> Search(string query)
        {
            return Customers.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }
        */

        public void AddOrUpdate(Client c)
        {
            if (c.Id == 0)
            {
                //add
                c.Id = LastId + 1;
                Customers.Add(c);
            }

        }

        public Client? Get(int id)
        {
            /*
            var response = new WebRequestHandler().Get($"/Client/GetClients/{id}").Result;
            var client = JsonConvert.DeserializeObject<Client>(response);*/
            return Customers.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var clientToDelete = Customers.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                Customers.Remove(clientToDelete);
            }
        }


        public IEnumerable<Client> Search(string query)
        {
            return Customers
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }

        private int LastId
        {
            get
            {
                return Customers.Any() ? Customers.Select(c => c.Id).Max() : 0;
            }
        }
    }
}
