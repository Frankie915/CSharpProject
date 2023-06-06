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

        private List<Client> customers;
        private ClientService()
        {
            customers = new List<Client>
            {
                new Client{Id = 1, Name = "John Smith", Notes = "Cool" },
                new Client{Id = 2, Name = "Tony Stark", Notes = "Smart" },
                new Client{Id = 3, Name = "Jonas Wilson", Notes = "Too smart" }
            };
        }

        public List<Client> Customers
        {
            get { return customers; }   
        }

        public Client? Get(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Client? client)
        {
            if(client != null)
            {
                customers.Add(client);
            }
        }

        public void Delete(int id)
        {
            var clientToRemove = Get(id);
            if (clientToRemove != null)
            {
                customers.Remove(clientToRemove);
            }
        }

        public void Delete(Client c)
        {
            Delete(c.Id);
        }

        public void Read()
        {
            customers.ForEach(Console.WriteLine);
        }
    }
}
