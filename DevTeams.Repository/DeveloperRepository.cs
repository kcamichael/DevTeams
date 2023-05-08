//alt + shift + f = Format Document
public class DeveloperRepository
{
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
        return _developerDb
    }

    //Read by Id

    //Update

    //Delete
}
