using KomodoDevTeamManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProgram
{
    class ProgramUI
    {
        protected readonly DevelopersRepository _developersContentDirectory = new DevelopersRepository();
        protected readonly DevelopTeamRepository _teamContentDirectory = new DevelopTeamRepository();

        //This is the Method that runs our User Interface
        public void Run()
        {
            //Putting in seed data to have some starting data.
            SeedContentList();

            DisplayMenu();
        }

        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine(
                    "Enter the number of the option you would like to select: \n" +
                    "1. Add new Developer\n" +
                    "2. Show all Developers \n" +
                    "3. Update a Developer \n" +
                    "4. Remove a Developer \n" +
                    "5. Add a new Team \n" +
                    "6. Show all Teams \n" +
                    "7. Pluralsight Report \n" +
                    "8. Exit\n");


                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateNewDevelopers();
                        //Add new developers
                        break;
                    case "2":
                        ShowAllDevelopers();
                        //Show all developers
                        break;
                    case "3":
                        //Update existing developer content
                        UpdateDevelopers();
                        break;
                    case "4":
                        //Remove developer content
                        DeleteDevelopers();
                        break;
                    case "5":
                        CreateNewTeam();
                        //Add new Team
                        break;
                    case "6":
                        ShowAllTeams();
                        //Show all Teams
                        break;
                    case "7":
                        PluralSightReport();
                        //Pluralsight Report
                        break;
                    case "8":
                        //Exit
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 7 \n" +
                            "Press Enter to continue.");
                        Console.ReadKey();
                        break;
                }

            }
        }

        //Add a New Developer
        private void CreateNewDevelopers()
        {
            //new up
            // Developers content = new Developers();

            //int DeveloperID
            Console.Write("Please enter a DeveloperID: (1-1000)");
            int devid = int.Parse(Console.ReadLine());

            //string Developer First Name
            Console.Write("Please enter the Developer's First Name.");
            string devfn = Console.ReadLine();

            //string Developer Last Name
            Console.Write("Please enter the Developer's Last Name.");
            string devln = Console.ReadLine();

            //string Pluralsight
            Console.WriteLine("Does this Developer have access to Pluralsight? (Y/N)  ");
            string pluralSightAsString = Console.ReadLine();
            bool devpluralsightasbool;
            if (pluralSightAsString == "Y")
            {
                devpluralsightasbool = true;
            }
            else

                devpluralsightasbool = false;

            //string TeamAssignment
            Console.Write("Enter the Team Assignment.");
            string teamassignment = Console.ReadLine();

            Developers developer = new Developers(devid, devln, devfn, devpluralsightasbool, teamassignment);
            _developersContentDirectory.AddContentToDirectory(developer);
        }
        //Show All Developers
        private void ShowAllDevelopers()
        {
            Console.Clear();

            // Get Content
            List<Developers> listOfContent = _developersContentDirectory.GetContents();
            //Loop through Contents
            foreach (Developers content in listOfContent)
            {
                //Console Write (Dispaly Content)
                DisplayContent(content);
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        //Find Developers By DevID
        private void GetDevelopersByDevID()  //Search functionality
        {
            Console.Clear();
            //Which Developer do you want?
            Console.WriteLine("Which Developer are you looking for?");
            //Getting user input
            int DevID = int.Parse(Console.ReadLine());

            //Get Content
            Developers content = _developersContentDirectory.GetContentByDevID(DevID);
            //if we have it
            if (content != null)
            {
                //Display Content
                DisplayContent(content);
            }
            else
            {
                Console.WriteLine("Failed to find the Developer");
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        //Update
        private void UpdateDevelopers()
        {
            //Ask the user what to update
            
            Console.WriteLine("Which Developer would you like to update?");
            int userInput = int.Parse(Console.ReadLine());
            //New Content (Updated content)
            Developers updatedcontent = new Developers();

            Console.Write("New ID?");
            updatedcontent.DevID = int.Parse(Console.ReadLine());

            Console.Write("What is the new First Name?");
            updatedcontent.DevFN = Console.ReadLine();

            Console.WriteLine("What is the new Last Name");
            updatedcontent.DevLN = Console.ReadLine();

            Console.WriteLine("Update Pluralsight access here.");
            string pluralSightAsString = Console.ReadLine();
            bool devPluralsightAsBool;
            if (pluralSightAsString == "Y")
            {
                devPluralsightAsBool = true;
            }
            else
                devPluralsightAsBool = false;
            updatedcontent.Pluralsight = devPluralsightAsBool ;

            Console.Write("Which Team is this Developer assigned to?");
            updatedcontent.TeamAssignment = Console.ReadLine();

            _developersContentDirectory.UpdateExistingContent(userInput,updatedcontent);
        }

        //Delete Content
        private void DeleteDevelopers()
        {
            Console.Clear();
            Console.WriteLine("Which Developer would you like to remove?");

            //setting up a counter for future use
            int count = 0;

            //DisplayAllContent
            List<Developers> contentList = _developersContentDirectory.GetContents();
            foreach (Developers content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.DevID}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            //Did I get valid input
            if (targetIndex >= 0 && targetIndex <= contentList.Count)
            {
                //Delete the content
                //Selecting object to be deleted
                Developers targetContent = contentList[targetIndex];
                _developersContentDirectory.DeleteExistingContent(targetContent);

                //check to see if deleted
                if (_developersContentDirectory.DeleteExistingContent(targetContent))
                {
                    //success Message
                    Console.WriteLine($"{targetContent.DevID} removed from repo:");
                }
                else
                {
                    //fail message
                    Console.WriteLine("Sorry, someting went wrong");
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
        }

        //Add a New Team
        private void CreateNewTeam()
        {
            //int Team ID
            Console.Write("Please enter a TeamID: (1-2000)");
            int devteamid = int.Parse(Console.ReadLine());

            //string Team Name
            Console.Write("Please enter the Team Name.");
            string devteamname = Console.ReadLine();

            DeveloperTeams teamname = new DeveloperTeams(devteamid, devteamname);
            _teamContentDirectory.AddContentToDirectory(teamname);
        }

        //Show All Teams
        private void ShowAllTeams()
        {
            Console.Clear();

            // Get Content
            List<DeveloperTeams> listOfContent = _teamContentDirectory.GetContents();
            //Loop through Contents
            foreach (DeveloperTeams content in listOfContent)
            {
                //Console Write (Dispaly Content)
                DisplayContent(content);
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        //Pluralsight
        private void PluralSightReport()  //Search functionality
        {
            Console.Clear();
        List<Developers> listOfContent = _developersContentDirectory.GetContents();
            foreach (Developers dev in listOfContent)
            {
                if (dev.Pluralsight != true)
                {
                    DisplayContent(dev);
                }
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

    //Display Developer Content
    private void DisplayContent(Developers content)
        {
            Console.WriteLine($"Developer ID: {content.DevID}\n" +
                   $"Last Name: {content.DevLN}\n" +
                   $"First Name: {content.DevFN}\n" +
                   $"Access to Pluralsight: {content.Pluralsight}\n" +
                   $"TeamAssignment: {content.TeamAssignment}\n");
        }

        //Display Team Content
        private void DisplayContent(DeveloperTeams content)
        {
            Console.WriteLine($"Team ID: {content.DevTeamID}\n" +
                   $"Team Name: {content.DevTeamName}\n");
        }

        private void WriteAndRead()
        {
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        //Seed Method
        private void SeedContentList()
        {
            Developers dev1 = new Developers(1111, "Adams", "Abigail", false, "TeamA");
            Developers dev2 = new Developers(2222, "Beans", "Robert", true, "TeamB");
            Developers dev3 = new Developers(3333, "Carr", "Catharine", true, "TeamC");
            DeveloperTeams team1 = new DeveloperTeams(1234, "TeamA");
            DeveloperTeams team2 = new DeveloperTeams(5678, "TeamB");
            DeveloperTeams team3 = new DeveloperTeams(9012, "TeamC");

            _developersContentDirectory.AddContentToDirectory(dev1);
            _developersContentDirectory.AddContentToDirectory(dev2);
            _developersContentDirectory.AddContentToDirectory(dev3);
            _teamContentDirectory.AddContentToDirectory(team1);
            _teamContentDirectory.AddContentToDirectory(team2);
            _teamContentDirectory.AddContentToDirectory(team3);

        }
    }
}