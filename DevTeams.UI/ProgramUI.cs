
public class ProgramUI
{
    //Globally scoped variable container with the Developer Repository Data
    private DeveloperRepository _dRepo = new DeveloperRepository();
    private DevTeamRepository _dTRepo;

    public ProgramUI()
    {
        _dTRepo = new DevTeamRepository(_dRepo);
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
            System.Console.WriteLine("Welcome to Komodo DevTeams\n"+
                "===========Developer Management==========\n"+
                "1. View All Developers\n"+
                "2. View Developer by Id\n"+
                "3. Add Developer\n"+
                "4. Update Existing Developer\n"+
                "5. Delete Existing Developer\n"+
                "===========Dev Team Management============\n"+
                "6. View All DevTeams\n"+
                "7. View DevTeam by Id\n"+
                "8. Add DevTeam\n"+
                "9. Update Existing DevTeam\n"+
                "10. Delete Existing Devteam\n"+
                "====================Bonus================\n"+
                "11. Developers with PluralSight Account\n"+
                "12. Add Multiple Developers to a team\n"+
                "====================Exit App================\n"+
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
                    CreateDeveloper();
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
                    DevelopersWithoutPluralSightAccount();
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
        throw new NotImplementedException();
    }


    private void DeleteExistingDevTeam()
    {
        throw new NotImplementedException();
    }

    private void UpdateExistingDevTeam()
    {
        throw new NotImplementedException();
    }

    private void ViewDevTeamByID()
    {
        throw new NotImplementedException();
    }

    private void ViewAllDevTeams()
    {
        throw new NotImplementedException();
    }

    private void AddDevTeam()
    {
        throw new NotImplementedException();
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

    private void CreateDeveloper()
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
        catch(Exception ex)
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
        if(dev != null)
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
        if(devsInDb.Count > 0)
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

    private void DevelopersWithoutPluralSightAccount()
    {
        throw new NotImplementedException();
    }
}
