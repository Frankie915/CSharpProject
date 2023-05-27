using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Services;
using System;
using System.Runtime.CompilerServices;

namespace PracticeManagement // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            var projects = new List<Project>();
            var customers = new List<Client>();
            while (true)
            {
                Console.WriteLine("P. Projects");
                Console.WriteLine("C. Clients");
                Console.WriteLine("Q. Quit");

                var choice = Console.ReadLine() ?? string.Empty;

                if (choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectMenu(customers, projects);
                }
                else if(choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientMenu(customers, projects);
                }
                else if(choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
            }
        }

        static void ProjectMenu(List<Client> customers, List<Project> projects)
        {

            while(true)
            {
                Console.WriteLine("C. Create a Project");
                Console.WriteLine("R. Read List of Projects");
                Console.WriteLine("U. Update a Project");
                Console.WriteLine("D. Delete a Project");
                Console.WriteLine("M. Main Menu");

                var choice = Console.ReadLine() ?? string.Empty;
                int ClientId;
                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {//create client
                    Console.WriteLine("Id: ");
                    var Id = int.Parse(Console.ReadLine() ?? "0");

                    
                    if(customers.Count == 0)
                    {
                        Console.WriteLine("No existing clients... Please add a client, then update this project's client ID");
                        ClientId = 0;
                    }
                    else
                    {
                        Console.WriteLine("Client ID: ");
                        ClientId = int.Parse(Console.ReadLine() ?? "0");
                    }

                    projects.Add(new Project { Id = Id, OpenDate = DateTime.Today, ClientId = ClientId });

                }
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {// Read clients

                    projects.ForEach(Console.WriteLine);

                }
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                   
                    if (projects.Count == 0)
                    {
                        Console.WriteLine("Project list is empty...");
                        continue;
                    }

                    Console.WriteLine("Which project should be updated?");
                    projects.ForEach(Console.WriteLine);
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var projectToUpdate = projects.FirstOrDefault(s => s.Id == updateChoice);
                    if (projectToUpdate != null)
                    {
                        Console.WriteLine("What is the project's updated Client Id?");
                        projectToUpdate.ClientId = int.Parse(Console.ReadLine() ?? "0");

                    }
                }
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine(projects.Count <= 0);
                    if(projects.Count == 0)
                    {
                        Console.WriteLine("Project list is empty...");
                        continue;
                    }
                    Console.WriteLine("Which project should be deleted?");
                    projects.ForEach(Console.WriteLine);
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var projectToRemove = projects.FirstOrDefault(s => s.Id == deleteChoice);
                    if (projectToRemove != null)
                    {
                        projects.Remove(projectToRemove);
                    }


                }
                else if (choice.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                {
                    break; //returns to main menu
                }
            }
            

        }
        static void ClientMenu(List<Client> customers, List<Project> projects)
        {
            while (true)
            {
                Console.WriteLine("C. Create a Client");
                Console.WriteLine("R. Read List of Clients");
                Console.WriteLine("U. Update a Client");
                Console.WriteLine("D. Delete a Client");
                Console.WriteLine("M. Main Menu");

                var choice = Console.ReadLine() ?? string.Empty;

                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {//create client
                    Console.WriteLine("Id: ");
                    var Id = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();

                    Console.WriteLine("Notes: ");
                    var notes = Console.ReadLine();

                    customers.Add(new Client { Id = Id, Name = name ?? "Unknown", Notes = notes ?? string.Empty });

                } else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {// Read clients

                    customers.ForEach(Console.WriteLine);

                } else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {

                    if (customers.Count == 0)
                    {
                        Console.WriteLine("Client list is empty...");
                        continue;
                    }

                    Console.WriteLine("Which client should be updated?");
                    customers.ForEach(Console.WriteLine);
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToUpdate = customers.FirstOrDefault(s => s.Id == updateChoice);
                    if (clientToUpdate != null)
                    {
                        Console.WriteLine("What is the client's updated name?");
                        clientToUpdate.Name = Console.ReadLine() ?? "Unknown";
                    }

                } else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    
                    if (customers.Count == 0)
                    {
                        Console.WriteLine("Client list is empty...");
                        continue;
                    }

                        Console.WriteLine("Which client should be deleted?");
                    customers.ForEach(Console.WriteLine);
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToRemove = customers.FirstOrDefault(s => s.Id == deleteChoice);
                    if(clientToRemove != null)
                    {
                        customers.Remove(clientToRemove);
                    }


                } else if(choice.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                {
                    break; //returns to main menu
                }


            }
            
        }
    }

    
}
