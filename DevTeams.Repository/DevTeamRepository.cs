
public class DevTeamRepository
{
    //* private DeveloperRepository _devRepo = new DeveloperRepository();
    private readonly DeveloperRepository _devRepo;

    public DevTeamRepository(DeveloperRepository devRepo)
    {
        _devRepo = devRepo;
        Seed();
    }

    private List<DeveloperTeam> _devTeamDb = new List<DeveloperTeam>();
    private int _count = 0;

    //C.R.U.D

    //Create
    public bool AddDevTeam(DeveloperTeam devTeam)
    {
        if(devTeam is null)
        {
            return false;
        }
        else
        {
            _count++;
            devTeam.ID = _count;
            _devTeamDb.Add(devTeam);
            return true;
        }
    }
    
    //Read All
    public List<DeveloperTeam> GetDeveloperTeam()
    {
        return _devTeamDb;
    }

    //Read by ID (helper method(?))
    public bool DeveloperTeam 

    GetDeveloperTeam(int devTeamId)
    {
        foreach (DeveloperTeam team in collection)
        {
            if(team.ID == devTeamId)
            {
                return team;
            }
        }
        return null;

        //* return _devTeamDb.SingleOrDefault(team => team.ID == devTeamId);
    }
    
    //Update -> this is a COMPLETE overwrite of the data
    public bool UpdateDevTeam(int devTeamId, DeveloperTeam newDevTeamData)
    {
        DeveloperTeam oldDevTeamData = GetDeveloperTeam(devTeamId);

        if(oldDevTeamData != null)
        {
            oldDevTeamData.TeamName = newDevTeamData.TeamName;
            // oldDevTeamData.Developers = newDevTeamData.Developers; -> Commenting out because new code below allows user to just change the name 

            if(newDevTeamData.Developers.Count() > 0)
            {
                oldDevTeamData.Developers = newDevTeamData.Developers;
            }

            return true;
        }
        return false;
    }

    //Delete
    public bool DeleteDevTeam(int devTeamId)
    {
        DeveloperTeam oldDevTeamData = GetDeveloperTeam(devTeamId);

        if(oldDevTeamData != null)
        {
            return _devTeamDb.Remove(oldDevTeamData);
        }
        return false;
    }

    public bool AddMultipleDevelopers(int devTeamId, List<Developer> developersToAdd)
    {
        DeveloperTeam teamInDb = GetDeveloperTeam(devTeamId);

        if (teamInDb != null)
        {
            teamInDb.Developers.AddRange(developersToAdd);
            return true;
        }
        return false;
    }

    //Seed
    public void Seed()
    {
        DeveloperTeam fire = new DeveloperTeam()
        {
            TeamName = "Java Script Devs"
        };
        Js.Developers.Add(_devRepo.GetDeveloperById(3))

        DeveloperTeam ice = new DeveloperTeam()
        {
            TeamName = "C# Sharp Devs"
        };
        cSharp.Developers.Add(_devRepo.GetDeveloperById(1))
        cSharp.Developers.Add(_devRepo.GetDeveloperById(2))

        DeveloperTeam java = new DeveloperTeam()
        {
            TeamName = "Java Devs"
        };

    }
}
