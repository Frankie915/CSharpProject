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
            while (true)
            {
                Console.WriteLine("P. Projects");
                Console.WriteLine("C. Clients");
                Console.WriteLine("Q. Quit");

                var choice = Console.ReadLine() ?? string.Empty;

                if (choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectMenu();
                }
                else if(choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientMenu();
                }
                else if(choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
            }
        }

        static void ProjectMenu()
        {
            var clientService = ClientService.Current;
            var projectService = ProjectService.Current;
            while(true)
            {
                Console.WriteLine("C. Create a Project");
                Console.WriteLine("R. Read List of Projects");
                Console.WriteLine("U. Update a Project");
                Console.WriteLine("D. Delete a Project");
                Console.WriteLine("M. Main Menu");

                var choice = Console.ReadLine() ?? string.Empty;
                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {//create client
                    Console.WriteLine("Id: ");
                    var Id = int.Parse(Console.ReadLine() ?? "0");
                    clientService.Read();
                    Console.WriteLine("Client ID: ");

                    var ClientId = int.Parse(Console.ReadLine() ?? "0");
                    if(clientService.Get(ClientId) == null)
                    {
                        Console.WriteLine("Client does not exist... please update project with an existing client, or make the client first");
                        ClientId = 0;
                    }
                    projectService.Add(new Project { Id = Id, OpenDate = DateTime.Today, ClientId = ClientId });

                }
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {// Read clients

                    projectService.Read();

                }
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                   /*
                    if (projects.Count == 0)
                    {
                        Console.WriteLine("Project list is empty...");
                        continue;
                    }
                   */
                    Console.WriteLine("Which project should be updated?");
                    projectService.Read();
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var projectToUpdate = projectService.Get(updateChoice);
                    if (projectToUpdate != null)
                    {
                        Console.WriteLine("What is the project's updated Client Id?");
                        projectToUpdate.ClientId = int.Parse(Console.ReadLine() ?? "0");

                    }
                }
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Console.WriteLine(projects.Count <= 0);
                    /*if(projects.Count == 0)
                    {
                        Console.WriteLine("Project list is empty...");
                        continue;
                    }
                    */
                    Console.WriteLine("Which project should be deleted?");
                    projectService.Read();
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    projectService.Delete(deleteChoice);


                }
                else if (choice.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                {
                    break; //returns to main menu
                }
            }
            

        }
        static void ClientMenu()
        {
            var clientService = ClientService.Current;
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

                    clientService.Add(new Client { Id = Id, Name = name ?? "Unknown", Notes = notes ?? string.Empty });

                } else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {// Read clients

                    clientService.Read();

                } else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    /*
                    if (customers.Count == 0)
                    {
                        Console.WriteLine("Client list is empty...");
                        continue;
                    }
                    */
                    Console.WriteLine("Which client should be updated?");
                    clientService.Read();
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToUpdate = clientService.Get(updateChoice);
                    if (clientToUpdate != null)
                    {
                        Console.WriteLine("What is the client's updated name?");
                        clientToUpdate.Name = Console.ReadLine() ?? "Unknown";
                    }

                } else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    /*
                    if (customers.Count == 0)
                    {
                        Console.WriteLine("Client list is empty...");
                        continue;
                    }
                    */
                    Console.WriteLine("Which client should be deleted?");
                    clientService.Read();
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    clientService.Delete(deleteChoice);


                } else if(choice.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                {
                    break; //returns to main menu
                }


            }
            
        }
    }

    
}
