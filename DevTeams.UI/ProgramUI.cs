

public class ProgramUI
{
    //Globally scoped variable container with the Developer Repository Data
    private DeveloperRepository _dRepo;
    private DevTeamRepository _dTRepo;

    public ProgramUI()
    {
        _dTRepo = new DevTeamRepository(_dRepo);
        _dTRepo.Seed();
    }

    private bool _isRunning = true;

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to Komodo DevTeams\n" +
                "===========Developer Management==========\n" +
                "1. View All Developers\n" +
                "2. View Developer by Id\n" +
                "3. Add Developer\n" +
                "4. Update Existing Developer\n" +
                "5. Delete Existing Developer\n" +
                "===========Dev Team Management============\n" +
                "6. View All DevTeams\n" +
                "7. View DevTeam by Id\n" +
                "8. Add DevTeam\n" +
                "9. Update Existing DevTeam\n" +
                "10. Delete Existing Devteam\n" +
                "====================Bonus================\n" +
                "11. Developers with PluralSight Account\n" +
                "12. Add Multiple Developers to a team\n" +
                "====================Exit App================\n" +
                "00. Exit Application");

            string userInput = Console.ReadLine()!;

            switch (userInput)
            {
                case "1":
                    ViewAllDevelopers();
                    break;
                case "2":
                    ViewDeveloperByID();
                    break;
                case "3":
                    AddDeveloper();
                    break;
                case "4":
                    UpdateDeveloper();
                    break;
                case "5":
                    DeleteDeveloper();
                    break;
                case "6":
                    ViewAllDevTeams();
                    break;
                case "7":
                    ViewDeveloperByID();
                    break;
                case "8":
                    AddDevTeam();
                    break;
                case "9":
                    UpdateExistingDevTeam();
                    break;
                case "10":
                    DeleteExistingDevTeam();
                    break;
                case "11":
                    DevelopersWithPluralSightAccount();
                    break;
                case "12":
                    AddMultipleDevelopersToATeam();
                    break;
                case "00":
                    _isRunning = ExitApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid key entry!");
                    PressAnyKey();
                    break;
            }
        }
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press Any Key To Continue.");
        Console.ReadKey();
    }

    private bool ExitApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thanks!");
        PressAnyKey();
        Console.Clear();
        return false;
    }

    private void AddMultipleDevelopersToATeam()
    {
        try
        {
            Console.Clear();
            System.Console.WriteLine("== Developer Team Listing ==");
            GetDevTeamData();
            List<DeveloperTeam> dTeam = _dTRepo.GetDeveloperTeam();

            if (dTeam.Count() > 0)
            {
                System.Console.WriteLine("Select a Dev Team by ID");
                int userInputDevTeamId = int.Parse(Console.ReadLine()!);
                DeveloperTeam team = _dTRepo.GetDeveloperTeam(userInputDevTeamId);

                List<Developer> auxDevsInDb = _dRepo.GetDevelopers();

                List<Developer> devsToAdd = new List<Developer>();

                if (team != null)
                {
                    bool hasFilledPositions = false;
                    while (!hasFilledPositions)
                    {
                        if (auxDevsInDb.Count() > 0)
                        {
                            DisplayDevelopersInDb(auxDevsInDb);
                            Console.WriteLine("Do you want to add a Developer? y/n");
                            string userInputAnyDev = Console.ReadLine()!.ToLower()!;

                            if (userInputAnyDev == "y")
                            {
                                System.Console.WriteLine("Input Developer ID");
                                int userInputDevId = int.Parse(Console.ReadLine()!);
                                Developer dev = _dRepo.GetDeveloperById(userInputDevId);
                                if (dev != null)
                                {
                                    devsToAdd.Add(dev);
                                    auxDevsInDb.Remove(dev);
                                }
                                else
                                {
                                    System.Console.WriteLine("The Developer doesn't exist!");
                                    PressAnyKey();
                                }
                            }
                            else
                            {
                                hasFilledPositions = true;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("There are no Developers in the Database!");
                            PressAnyKey();
                            break;
                        }
                    }

                    if (_dTRepo.AddMultipleDevelopers(team.ID, devsToAdd))
                    {
                        System.Console.WriteLine("Success!");
                    }
                    else
                    {
                        System.Console.WriteLine("Fail!");
                    }
                }
                else
                {
                    System.Console.WriteLine("Sorry, invalid DevTeam ID.");
                }
            }

            PressAnyKey();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            SomethingWentWrong();
        }
    }

    private void DeleteExistingDevTeam()
    {
        try
        {
            try
            {
                Console.Clear();
                System.Console.WriteLine("== Developer Team Listing ==");
                GetDevTeamData();
                System.Console.WriteLine("Please enter Dev Team by ID.");
                DeveloperTeam dTeam = _dTRepo.GetDeveloperTeam(int.Parse(Console.ReadLine()!));

                if (dTeam != null)
                {
                    if (_dTRepo.DeleteDevTeam(dTeam.ID))
                    {
                        System.Console.WriteLine("Success!");
                    }
                    else
                    {
                        System.Console.WriteLine("Fail!");
                    }
                }
                else
                {
                    System.Console.WriteLine("There aren't any available Developer Teams");
                }
            }
            catch
            {

                System.Console.WriteLine("There aren't any available Developer Teams.");

            }

            PressAnyKey();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            SomethingWentWrong();
        }
    }

    private void UpdateExistingDevTeam()
    {
        try
        {
            Console.Clear();
            System.Console.WriteLine("== Developer Team Listing ==");
            GetDevTeamData();
            List<DeveloperTeam> dTeam = _dTRepo.GetDeveloperTeam();
            if (dTeam.Count() > 0)
            {
                System.Console.WriteLine("Please select a DevTeamId for Update.");
                int userInputDevTeamId = int.Parse(Console.ReadLine()!);
                DeveloperTeam team = _dTRepo.GetDeveloperTeam(userInputDevTeamId);

                if (team != null)
                {
                    DeveloperTeam updatedTeamData = InitializeDTeamCreation();
                    if (_dTRepo.UpdateDevTeam(team.ID, updatedTeamData))
                    {
                        System.Console.WriteLine("Success!");
                    }
                    else
                    {
                        System.Console.WriteLine("fail");
                    }
                }
                else
                {
                    System.Console.WriteLine("Sorry you used an invalid ID.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            SomethingWentWrong();
        }
    }

    private void AddDevTeam()
    {
        Console.Clear();
        DeveloperTeam dTeam = InitializeDTeamCreation();

        if (_dTRepo.AddDevTeam(dTeam))
        {
            System.Console.WriteLine("Success!");
        }
        else
        {
            System.Console.WriteLine("Fail!");
        }
        PressAnyKey();
    }

    private DeveloperTeam InitializeDTeamCreation()
    {
        DeveloperTeam team = new DeveloperTeam();
        try
        {
            System.Console.WriteLine("Please enter the team name");
            team.TeamName = Console.ReadLine()!;

            // We nee a bool that allows us to add members to our team
            bool hasFilledPositions = false;

            //Create a List for dynamic display
            List<Developer> auxDevelopers = _dRepo.GetDevelopers();

            while (hasFilledPositions == false)
            {
                System.Console.WriteLine("Does this team have any developers y/n?");
                string userInputAnyDevs = Console.ReadLine()!.ToLower();
                if (userInputAnyDevs == "y")
                {
                    if (auxDevelopers.Count() > 0)
                    {
                        DisplayDevelopersInDb(auxDevelopers);

                        System.Console.WriteLine("Select a developer by ID");
                        int userInputDevId = int.Parse(Console.ReadLine()!);

                        Developer selectedDeveloper = _dRepo.GetDeveloperById(userInputDevId);

                        if (selectedDeveloper != null)
                        {
                            team.Developers.Add(selectedDeveloper);
                            auxDevelopers.Remove(selectedDeveloper);
                        }
                        else
                        {
                            System.Console.WriteLine("Sorry, the developer doesn't exist!");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("There are no Developer's in the Database");
                        PressAnyKey();
                        break;
                    }
                }
                else
                {
                    hasFilledPositions = true;
                }
            }
            return team;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            SomethingWentWrong();
        }
        return null; //! What is it complaining about?
    }

    private void DisplayDevelopersInDb(List<Developer> auxDevelopers)
    {
        if (auxDevelopers.Count() > 0)
        {
            foreach (Developer dev in auxDevelopers)
            {
                System.Console.WriteLine(dev);
            }
        }
    }

    private void ViewDevTeamByID()
    {
        Console.Clear();
        System.Console.WriteLine("== Developer Team Listing ==");
        GetDevTeamData();
        List<DeveloperTeam> devTeam = _dTRepo.GetDeveloperTeam();
        if (devTeam.Count > 0)
        {
            System.Console.WriteLine("Select Dev Team by ID");
            int userInputDevTeamId = int.Parse(Console.ReadLine()!);
            ValidateDevTeamData(userInputDevTeamId);
        }
        PressAnyKey();
    }

    private void ValidateDevTeamData(int userInputDevTeamId)
    {
        DeveloperTeam team = _dTRepo.GetDeveloperTeam(userInputDevTeamId);
        if (team != null)
        {
            DisplayDeveloperTeamData(team);
        }
        else
        {
            System.Console.WriteLine("Sorry Team doesn't Exist!");
        }
    }

    private void ViewAllDevTeams()
    {
        Console.Clear();
        System.Console.WriteLine("== Developer Team Listing ==");
        GetDevTeamData();
        PressAnyKey();
    }

    private void GetDevTeamData()
    {
        List<DeveloperTeam> dTeams = _dTRepo.GetDeveloperTeam();
        if (dTeams.Count > 0)
        {
            foreach (DeveloperTeam team in dTeams)
            {
                DisplayDeveloperTeamData(team);
            }
        }
        else
        {
            System.Console.WriteLine("There are no available Developer Teams!");
        }
    }

    private void DisplayDeveloperTeamData(DeveloperTeam team)
    {
        System.Console.WriteLine(team);
    }

    private void DevelopersWithPluralSightAccount()
    {
        List<Developer> devsWoPS = _dRepo.GetDevelopersWithoutPluralsight();

        if (devsWoPS.Count() > 0)
            foreach (Developer dev in devsWoPS)
            {
                DisplayDevData(dev);
            }
        else
        {
            System.Console.WriteLine("Every Developer has PluralSight");
        }

        PressAnyKey();
    }

    private void DeleteDeveloper()
    {
        Console.Clear();
        try
        {
            Console.Clear();
            System.Console.WriteLine("== Delete Developer ==");

            foreach (var dev in _dRepo.GetDevelopers())
            {
                System.Console.WriteLine($"{dev.ID} - {dev.FullName}");
            }
            System.Console.WriteLine("=============================\n");

            System.Console.WriteLine("Please input a Developer Id");
            int userInputDevId = int.Parse(Console.ReadLine()!);

            Developer selectedDev = _dRepo.GetDeveloperById(userInputDevId);

            if (selectedDev != null)
            {
                Console.Clear();
                if (_dRepo.DeleteDeveloper(selectedDev.ID))
                {
                    System.Console.WriteLine("SUCCESS!");
                }
                else
                {
                    System.Console.WriteLine("FAIL!");
                }
            }
            else
            {
                System.Console.WriteLine($"The Developer with the id: {userInputDevId} doesn't Exist!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }

        PressAnyKey();
    }

    private void UpdateDeveloper()
    {
        Console.Clear();
        try
        {
            System.Console.WriteLine("== Update Developer ==");

            foreach (var dev in _dRepo.GetDevelopers())
            {
                System.Console.WriteLine($"{dev.ID} - {dev.FullName}");
            }
            System.Console.WriteLine("=============================\n");

            System.Console.WriteLine("Please input a Developer Id");
            int userInputDevId = int.Parse(Console.ReadLine()!);

            Developer selectedDev = _dRepo.GetDeveloperById(userInputDevId);

            if (selectedDev != null)
            {
                Console.Clear();

                //create an empty form 
                Developer developerForm = new Developer();

                System.Console.WriteLine("Please enter a First Name:");
                developerForm.FirstName = Console.ReadLine()!;

                System.Console.WriteLine("Please enter a Last Name:");
                developerForm.LastName = Console.ReadLine()!;

                System.Console.WriteLine("Does this Developer have Ps? y/n");

                string userInput = Console.ReadLine()!.ToLower();

                if (userInput == "y")
                {
                    developerForm.HasPluralSight = true;
                }
                else
                {
                    developerForm.HasPluralSight = false;
                }

                if (_dRepo.UpdateDeveloper(selectedDev.ID, developerForm))
                {
                    System.Console.WriteLine("SUCCESS!");
                }
                else
                {
                    System.Console.WriteLine("FAIL!");
                }
            }
            else
            {
                System.Console.WriteLine($"The Developer with the id: {userInputDevId} doesn't Exist!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }

        PressAnyKey();
    }

    private void AddDeveloper()
    {
        try
        {
            Console.Clear();

            System.Console.WriteLine("== Add Developer Menu ==");

            //create an empty form 
            Developer developerForm = new Developer();

            System.Console.WriteLine("Please enter a First Name:");
            developerForm.FirstName = Console.ReadLine()!;

            System.Console.WriteLine("Please enter a Last Name:");
            developerForm.LastName = Console.ReadLine()!;

            System.Console.WriteLine("Does this Developer have Ps? y/n");

            string userInput = Console.ReadLine()!.ToLower();

            if (userInput == "y")
            {
                developerForm.HasPluralSight = true;
            }
            else
            {
                developerForm.HasPluralSight = false;
            }

            if (_dRepo.AddDeveloper(developerForm))
            {
                System.Console.WriteLine("SUCCESS!");
            }
            else
            {
                System.Console.WriteLine("FAIL!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }

        PressAnyKey();
    }

    private void ViewDeveloperByID()
    {
        try
        {
            Console.Clear();
            System.Console.WriteLine("Please input a Developer Id");
            int userInputDevId = int.Parse(Console.ReadLine()!);
            ValidateDeveloperInDatabaseData(userInputDevId);
        }
        catch (Exception ex)
        {
            SomethingWentWrong();
            // if it doesn't work display the error, swallow the error and continue running the application.
            System.Console.WriteLine(ex.Message);
        }
        PressAnyKey();
    }

    private bool ValidateDeveloperInDatabaseData(int userInputDevId)
    {
        Developer dev = GetDeveloperDataFromDv(userInputDevId);
        if (dev != null)
        {
            Console.Clear();
            DisplayDevData(dev);
            return true;
        }
        else
        {
            Console.WriteLine($"The Developer with the id: {userInputDevId}doesn't Exist!");
            return false;
        }
    }

    private Developer GetDeveloperDataFromDv(int userInputDevId)
    {
        return _dRepo.GetDeveloperById(userInputDevId);
    }

    private void SomethingWentWrong()
    {
        System.Console.WriteLine("Something went wrong.\n" +
        "Please Try Again.\n" +
        "Returning to Developer Menu.\n");
    }

    private void ViewAllDevelopers()
    {
        Console.Clear();

        System.Console.WriteLine("== Dev Listing ==");

        foreach (var dev in _dRepo.GetDevelopers())
        {
            System.Console.WriteLine(dev);
        }

        PressAnyKey();
    }

    private void ShowEnlistedDevs()
    {
        Console.Clear();
        Console.WriteLine("=== Developer Listing ===");
        List<Developer> devsInDb = _dRepo.GetDevelopers();
        ValidateDeveloperDatabaseData(devsInDb);
    }

    private void ValidateDeveloperDatabaseData(List<Developer> devsInDb)
    {
        if (devsInDb.Count > 0)
        {
            Console.Clear();
            foreach (Developer dev in devsInDb)
            {
                DisplayDevData(dev);
            }
        }
        else
        {
            System.Console.WriteLine("There are no Developers in ThreadExceptionEventArgs Database.");
        }
    }

    private void DisplayDevData(Developer dev)
    {
        System.Console.WriteLine(dev);
    }
}
