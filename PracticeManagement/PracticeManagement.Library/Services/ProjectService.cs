using PracticeManagement.Library.Models;
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
            projects = new List<Project> { new Project { Id = 1, Name = "Test Project", ClientId = 1 } };
        }

        public List<Project> Projects
        {
            get { return projects; }
        }

        public Project? Get(int id)
        {
            return projects.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Project? project)
        {
            if (project.Id == 0)
            {
                project.Id = LastId + 1;
            }
            projects.Add(project);
        }

        private int LastId
        {
            get
            {
                return Projects.Any() ? Projects.Select(c => c.Id).Max() : 0;
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

