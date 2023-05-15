//ctrl + b -> hide explorer

public class DeveloperTeam
{
    //empty constructor
    public DeveloperTeam(){}

    //partial constructor
    public DeveloperTeam(string teamName)
    {
        TeamName = teamName;
        Developers = developers;
    }

    //full constructor
    public DeveloperTeam(string teamName, List<Developer> developers)
    {
        TeamName = teamName;
        Developers = developers;
    }
    
    //[Key]
    public int ID { get; set; }
    public string TeamName { get; set; }= string.Empty
    public List<Developer> Developers { get; set; } = new List<Developer>();

    public override string ToString()
    {
        var str =   $"ID: {ID}\n"+
                    $"Full Name: {FullName}" +
                    "===================\n";
        foreach (Developer dev in Developers)
            {
                str += decimal + "/n";
            }
            
        return str;
    }
}