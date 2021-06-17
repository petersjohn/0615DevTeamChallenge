using KomodoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsConsole
{
    class ProgramUI
    {
        private bool _isRunning = true;
        private readonly DeveloperRepo _devRepo = new DeveloperRepo();
        private readonly TeamRepo _teamRepo = new TeamRepo();
        public void Start()
        {


            SeedTeamList();
            SeedDevList();
            //add Run method here
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Dev Team CMS\n" +
                "Please select a menu option below:\n" +
                "1. Display All Teams\n" +
                "2. Display All Developers\n" +
                "3. Add a New Development Team\n" +
                "4. Get Team Details by Team ID\n" +
                "5. Delete a Team\n" +
                "6.  Add a Developer to a Team\n" +
                "7. Remove a Developer from a Team");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    //show all Teams
                    DisplayTeamList();
                    break;
                case "2":
                    DisplayDevList();
                    break;
                case "3":
                    AddNewTeam();
                    break;
                case "4":
                    DisplayTeamByListId();
                    break;
                case "5":
                    DeleteTeamFromList();
                    break;
                case "6":
                    AddDevToDevTeam();
                    break;
                case "7":
                    RemoveDevFromDevTeam();
                    break;
                case "8":
                    Console.WriteLine("Goodbye!");
                    _isRunning = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid integer response between 1 and 8.");
                    break;
            }//switch case
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }



        private void DisplayTeamList()
        {
            List<Team> listOfTeams = _teamRepo.GetTeamList();
            foreach (Team content in listOfTeams)
            {
                DisplayTeamContent(content);

                ReturnToMenu();
            }
        }

        private void DisplayTeamContent(Team content)
        {
            Console.WriteLine($"Team Name: {content.TeamName}\n" +
                $"Team ID {content.TeamId}\n" +
                $"Team Member IDs{content.DevId}\n");

        }

        private void DisplayDevList()
        {
            List<Developer> listOfDevs = _devRepo.GetDevList();
            foreach (Developer content in listOfDevs)
            {
                DisplayDevContent(content);

                ReturnToMenu();
            }


        }
        private void DisplayDevContent(Developer content)
        {
            Console.WriteLine($"Dev Name: {content.FirstName} + {content.LastName}\n" +
            $"Employee ID {content.DevID}\n" +
            $"Pluralsight Access: {content.HasPluralSight}\n");

        }

        private void AddNewTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter a Team Name:");
            string teamName = Console.ReadLine();
            Console.WriteLine("Enter a Team ID");
            int teamId = int.Parse(Console.ReadLine());
            List<int> userInput = new List<int>();
            Console.WriteLine("Please enter Employee ID: ");
            int devId = int.Parse(Console.ReadLine());
            userInput.Add(devId);

            while (devId != 0)
            {
                Console.Clear();
                Console.WriteLine("Enter another Employee ID or just enter 0 to end list:");
                devId = int.Parse(Console.ReadLine());
                userInput.Add(devId);
            }

            Team content = new Team(teamId, teamName, userInput);
            content.TeamId = teamId;
            content.TeamName = teamName;
            content.DevId = userInput;
            _teamRepo.AddTeamToList(content);
            Console.Clear();
            _teamRepo.GetTeamById(teamId);

            ReturnToMenu();



        }

        public void DisplayTeamByListId()
        {
            Console.WriteLine("Enter a team ID:");
            int teamId = int.Parse(Console.ReadLine());
            if (CheckTeam(teamId) == false)
            {
                Console.WriteLine("Invalid Selection, please press any key to return to menu.");
                ReturnToMenu();
            }
            else
            {
                Team content = _teamRepo.GetTeamById(teamId);
                DisplayTeamContent(content);
                ReturnToMenu();
            }
        }

        public void DeleteTeamFromList()
        {
            Console.Clear();
            Console.WriteLine("Enter the team ID of the team that you wish to delete:");
            int teamId = int.Parse(Console.ReadLine());

            if (CheckTeam(teamId) == false)
            {
                Console.WriteLine("Team could not be deleted, check Team ID and try again.");
                ReturnToMenu();
            }
            else
            {
                Team content = _teamRepo.GetTeamById(teamId);
                _teamRepo.DeleteTeam(teamId);
                ReturnToMenu();
            }
        }

        public void AddDevToDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter the Employee ID of the developer that you wish to add:");
            int devID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Team ID that you wish to add the Developer to: ");
            int teamID = int.Parse(Console.ReadLine());

            if (CheckTeam(teamID) == false || CheckDev(devID) == false)
            {
                Console.WriteLine("Cannot complete request, please Check IDs and try again");
                ReturnToMenu();
            }
            Team teamContent = _teamRepo.GetTeamById(teamID);
            if (teamContent.DevId.Contains(devID))
            {

                Console.WriteLine("Developer is already a member of this team.");
                ReturnToMenu();
            }

            bool wasAdded = _teamRepo.AddDevToTeam(devID, teamID);
            if (wasAdded == false)
            {
                Console.WriteLine("The add to team failed.");
                ReturnToMenu();
            }
            else
            {
                Console.WriteLine("Dev successfully added to team");
                ReturnToMenu();
            }

        }

        public void RemoveDevFromDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter the team ID: ");
            int teamID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Dev ID");
            int devID = int.Parse(Console.ReadLine());
            Team content = _teamRepo.GetTeamById(teamID);
            if(CheckTeam(teamID) == false || CheckDev(devID) == false || CheckListForInt(content.DevId,devID) == false)
            {
                Console.WriteLine("Cannot complete request, either IDs are incorrect or user is not a member.");
                ReturnToMenu();
            }
           if (_teamRepo.RemoveDevFromTeam(devID, teamID))
            {
                Console.WriteLine("Developer removed successfully.");
                ReturnToMenu();
            }
            else
            {
                Console.WriteLine("Could not remove developer from team.");
                ReturnToMenu();
            }




            
        }

        //generic shit
        private void ReturnToMenu()
        {
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
            RunMenu();
        }

        private bool CheckTeam(int teamID)
        {

            Team teamContent = _teamRepo.GetTeamById(teamID);
            if (teamContent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckDev(int devID)
        {
            Developer devContent = _devRepo.GetDevByID(devID);
            if (devContent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckListForInt(List<int> passedList, int listVal)
        {
            if (passedList.Contains(listVal))
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        private void SeedTeamList()
        {
            List<int> DevIDs = new List<int>();
            int[] devIds = { 2001, 2002, 2003, 2004, 2005 };
            DevIDs.AddRange(devIds);
            Team Dev1 = new Team(1001, "Dev1", DevIDs); //All Ids
            DevIDs.Remove(2001);
            DevIDs.Remove(2002);
            Team Dev2 = new Team(1002, "Dev2", DevIDs);//2003, 2004, 2005
            DevIDs.Remove(2003);
            DevIDs.Remove(2004);
            DevIDs.Remove(2005);
            DevIDs.Add(2001);
            DevIDs.Add(2002);
            Team Dev3 = new Team(1003, "Dev3", DevIDs); // 2001, 2002
        }



        private void SeedDevList()
        {
            Developer Dev1 = new Developer(2001, "James", "Smith", true);
            Developer Dev2 = new Developer(2002, "Naresh", "Pokagula", false);
            Developer Dev3 = new Developer(2003, "Samantha", "Codesalot", true);
            Developer Dev4 = new Developer(2004, "David", "FNG", true);
            Developer Dev5 = new Developer(2005, "Tracy", "Whadideymakesominny", false);

        }

    }
}


