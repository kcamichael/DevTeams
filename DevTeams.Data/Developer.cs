
//P.O.C.O -> Plain old cSharp object
//Domain Object
public class Developer
{
    public Developer()
    {
        
    }

    public Developer(string firstName,string LastName,bool hasPluralSight)
    {
        FirstName = firstName;
        this.LastName = LastName;
        HasPluralSight = hasPluralSight;
    }

    //We need a Primary key
    public int ID {get; set; }
    public string FirstName { get; set; } =string.Empty;
    public string LastName { get; set; } =string.Empty;
    public string FullName 
    { 
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
public bool HasPluralSight { get; set; }

//Is every time I do: Developer.ToString() I want to be able to populate the Developer's Name and whether or not they have PluralSight
    public override string ToString()
    {
        var str = $"ID: {ID}\n"+
                    $"Full Name: {FullName}" +
                    $"Has PluralSight Access: {HasPluralSight}\n" +
                    "===================\n";
        return str;
    }
}