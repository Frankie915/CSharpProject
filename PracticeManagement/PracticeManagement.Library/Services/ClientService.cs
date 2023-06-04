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
            customers = new List<Client>();
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

        public void Read()
        {
            customers.ForEach(Console.WriteLine);
        }
    }
}
