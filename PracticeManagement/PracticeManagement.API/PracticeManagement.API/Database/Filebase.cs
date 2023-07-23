using Newtonsoft.Json;
using PracticeManagement.API.EC;
using PracticeManagement.Library.Models;
using System.IO;

namespace PracticeManagement.API.Database
{
    public class Filebase
    {
        private string _root;
        private string _clientRoot;
        private string _projectRoot;
        private static Filebase? _instance;


        public static Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = @"C:\temp";
            _clientRoot = $"{_root}\\Clients";
            _projectRoot = $"{_root}\\Projects";
            //todo add support for employees, times, and bills
        }

        private int LastClientId => Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
        public Client AddOrUpdate(Client c)
        {
            //set up a new Id if one doesn't already exist
            if(c.Id <= 0)
            {
                c.Id = LastClientId + 1;
            }

            var path = $"{_clientRoot}\\{c.Id}.json";

            //if the item has been previously persisted
            Delete(c.Id);

            //var path = $"{_clientRoot}\\{id}.json";

            //if (File.Exists(path))
            //{
            //    //blow it up
            //    File.Delete(path);
            //}

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(c));


                //return the item, which now has an id
                return c;
        }

        public List<Client> Clients
        {
            get
            {
                if (!Directory.Exists(_clientRoot))
                {
                    Directory.CreateDirectory(_clientRoot);
                }
                
                var root = new DirectoryInfo(_clientRoot);
                
                var _clients = new List<Client>();
                foreach (var clientFile in root.GetFiles())
                {
                    var client = JsonConvert.DeserializeObject<Client>(File.ReadAllText(clientFile.FullName));
                    if(client != null)
                    {
                        _clients.Add(client);
                    }

                }
                return _clients;
            }
        }

        public bool Delete(int id)
        {
            var path = $"{_clientRoot}\\{id}.json";

            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }
            return true;
        }
    }

}
