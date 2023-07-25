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
        private string _employeeRoot;
        private string _timeRoot;
        private string _billRoot;
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
            _employeeRoot = $"{_root}\\Employees";
            _timeRoot = $"{_root}\\Times";
            _billRoot = $"{_root}\\Bills";
            //todo add support for employees, times, and bills
        }

        //Clients

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
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

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

        public bool DeleteClient(int id)
        {
            var path = $"{_clientRoot}\\{id}.json";

            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }
            return true;
        }

        //Projects
        private int LastProjectId => Projects.Any() ? Projects.Select(c => c.Id).Max() : 0;

        public Project AddOrUpdate(Project p)
        {
            //set up a new Id if one doesn't already exist
            if (p.Id <= 0)
            {
                p.Id = LastProjectId + 1;
            }

            var path = $"{_projectRoot}\\{p.Id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //var path = $"{_clientRoot}\\{id}.json";

            //if (File.Exists(path))
            //{
            //    //blow it up
            //    File.Delete(path);
            //}

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(p));


            //return the item, which now has an id
            return p;
        }

        public List<Project> Projects
        {
            get
            {
                if (!Directory.Exists(_projectRoot))
                {
                    Directory.CreateDirectory(_projectRoot);
                }

                var root = new DirectoryInfo(_projectRoot);

                var _projects = new List<Project>();
                foreach (var projectFile in root.GetFiles())
                {
                    var project = JsonConvert.DeserializeObject<Project>(File.ReadAllText(projectFile.FullName));
                    if (project != null)
                    {
                        _projects.Add(project);
                    }

                }
                return _projects;
            }
        }

        public bool DeleteProject(int id)
        {
            var path = $"{_projectRoot}\\{id}.json";

            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }
            return true;
        }

        //Employees

        private int LastEmployeeId => Employees.Any() ? Employees.Select(e => e.Id).Max() : 0;

        public Employee AddOrUpdate(Employee e)
        {
            //set up a new Id if one doesn't already exist
            if (e.Id <= 0)
            {
                e.Id = LastEmployeeId + 1;
            }

            var path = $"{_employeeRoot}\\{e.Id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //var path = $"{_clientRoot}\\{id}.json";

            //if (File.Exists(path))
            //{
            //    //blow it up
            //    File.Delete(path);
            //}

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(e));


            //return the item, which now has an id
            return e;
        }

        public List<Employee> Employees
        {
            get
            {
                if (!Directory.Exists(_employeeRoot))
                {
                    Directory.CreateDirectory(_employeeRoot);
                }

                var root = new DirectoryInfo(_employeeRoot);

                var _employees = new List<Employee>();
                foreach (var employeeFile in root.GetFiles())
                {
                    var employee = JsonConvert.DeserializeObject<Employee>(File.ReadAllText(employeeFile.FullName));
                    if (employee != null)
                    {
                        _employees.Add(employee);
                    }

                }
                return _employees;
            }
        }

        public bool DeleteEmployee(int id)
        {
            var path = $"{_employeeRoot}\\{id}.json";

            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }
            return true;
        }

        //Times

        private int LastTimeId => Times.Any() ? Times.Select(t => t.Id).Max() : 0;

        public Time AddOrUpdate(Time t)
        {
            //set up a new Id if one doesn't already exist
            if (t.Id <= 0)
            {
                t.Id = LastTimeId + 1;
            }

            var path = $"{_timeRoot}\\{t.Id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //var path = $"{_clientRoot}\\{id}.json";

            //if (File.Exists(path))
            //{
            //    //blow it up
            //    File.Delete(path);
            //}

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(t));


            //return the item, which now has an id
            return t;
        }

        public List<Time> Times
        {
            get
            {
                if (!Directory.Exists(_timeRoot))
                {
                    Directory.CreateDirectory(_timeRoot);
                }

                var root = new DirectoryInfo(_timeRoot);

                var _times = new List<Time>();
                foreach (var timeFile in root.GetFiles())
                {
                    var time = JsonConvert.DeserializeObject<Time>(File.ReadAllText(timeFile.FullName));
                    if (time != null)
                    {
                        _times.Add(time);
                    }

                }
                return _times;
            }
        }

        public bool DeleteTime(int id)
        {
            var path = $"{_timeRoot}\\{id}.json";

            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }
            return true;
        }
    }

    

}
