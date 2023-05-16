
public class ProgramUI
{
    //Globally scoped variable container with the Developer Repository Data
    private DeveloperRepository _dRepo = new DeveloperRepository();
    private DevTeamRepository _dTRepo;

    public ProgramUI()
    {
        _dTRepo = new DevTeamRepository(_dRepo);
    }

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

            switch (userInput);

        }
    }
}
