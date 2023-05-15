//alt + shift + f = Format Document
public class DeveloperRepository
{
    public DeveloperRepository()
    {
        Seed();
    }
    //We need a variable container that will hold the collection of Developers
    private List<Developer> _developerDb = new List<Developer>();

    //We need to auto increment the developer Id
    private int _count = 0;

    //C.R.U.D

    //Create
    public bool AddDeveloper(Developer developer)
    {
        if(developer is null)
        {
            return false;
        }
        else
        {
            //increment the _count
            _count++;

            //assign the developerId to _count
            developer.ID = _count;

            //save to the database
            _developerDb.Add(developer);

            return true;
        }
    }

    //Read All
    public List<Developer> GetDevelopers()
    {
        return _developerDb;
    }

    //Read by Id
    public Developer GetDeveloperById(int developerId)
    {
        //loop through the whole database
        foreach (Developer developer in _developerDb)
        {
            //check to see if the dev has a matching Id
            if(developer.ID == developerId)
            {
                return developer;
            }
        }
        return null;
    }

    //Update
    public bool UpdateDeveloper(int developer, Developer newDevData)
    {
        //check if developer exists
        Developer oldDevData = GetDeveloperById(developerId);

        // If we actually have data:
        if(oldDevData != null)
        {
            //This is where we update our values
            oldDevData.FirstName = newDevData.FirstName;
            oldDevData.LastName = newDevData.LastName;
            oldDevData.HasPluralSight = newDevData.HasPluralSight;
            // after values have been updated
            return true;        
        }
        //if oldDev data returns null
        return false;
    }

    //Delete
    public bool DeleteDeveloper(int developerId)
    {
        //let's check if the developer exists
        Developer oldDevData = GetDeveloperById(developerId);
        
        // if we actually have data:
        if (oldDevData != null)
        {
            //Remove the Developer
            return _developerDb.Remove(oldDevData);
        }

        //otherwise
        return false;
    }

    //Developers w/o PluralSight license
    public List<Developer> GetDevelopersWithoutPluralsight()
    {
        //1. We need an empty list
        List<Developer> devsWithOutPS = new List<Developer>();
        // 2. We need to loop through the database
        foreach (Developer developer in _developerDb)
        {
            //3. Check and see if the developer doesn't have PluralSight
            if(developer.HasPluralSight == false)
            {
                // 4. If true, we  will add the dev to the database
                devsWithOutPS.Add(developer);
            }
        }
        // 5. When all is done we will...
        return devsWithOutPS;
    }

    //Seed Developers
    private void Seed()
    {
        //Create developers to add to the database
        Developer george = new Developer
            {
                FirstName = "George"
                LastName = "Carlin"
                HasPluralSight = true
            };
        Developer richard = new Developer
            {
                FirstName = "Richard"
                LastName = "Pryor"
                HasPluralSight = false
            };
        Developer damon = new Developer
            {
                FirstName = "Damon"
                LastName = "Wayans"
                HasPluralSight = true
            };
    
    //add developers to database
    AddDeveloper(george);
    AddDeveloper(richard);
    AddDeveloper(damon);

    }
}
