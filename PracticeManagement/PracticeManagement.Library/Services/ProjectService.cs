using PracticeManagement.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;
        private static object _lock = new object();
        public static ProjectService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectService();
                    }
                }
                return instance;
            }
        }

        private List<Project> projects;
        private ProjectService()
        {
            projects = new List<Project>();
        }

        public List<Project> Projects
        {
            get { return projects; }
        }

        public Project? Get(int id)
        {
            return projects.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Project? project)
        {
            if (project != null)
            {
                projects.Add(project);
            }
        }

        public void Delete(int id)
        {
            var projectToRemove = Get(id);
            if (projectToRemove != null)
            {
                projects.Remove(projectToRemove);
            }
        }

        public void Read()
        {
            projects.ForEach(Console.WriteLine);
        }
    }
}

