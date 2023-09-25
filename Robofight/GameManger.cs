namespace Robofight;

public class GameManger
{
    private List<Robot> robots = new List<Robot>();

    public List<Robot> AddPlayer()
    {
        while (robots.Count < 2)
        {
            Console.Clear();
            var roboName = RoboName();
            var roboWeapon = RoboWeapon();
            Robot robot = new Robot(){ Name = roboName, HealthPoints = 100, Damage = 5, Weapon= roboWeapon};;
            robots.Add(robot);
        }
        return robots;
    }
    public string RoboName()
    {
        Console.WriteLine("Geben sie den Namen für Robot" + (robots.Count + 1) + " ein: ");
        string roboName= Console.ReadLine();
        return roboName;
    }

    public Weapon RoboWeapon()
    {
        string[] wepons = { 
            "1: Sword -> Damge: 15 | Durability: 5 | Kann andere Schwerter abwehren 1/6",
            "2: Bow   -> Damge: 45 | Durability: 3 | Treffer Quote liegt bei 1/3",
            "3: Nife  -> Damge: 10 | Durability: 9 | Chanche 1/6 das man doppelt trifft" };

        foreach (var wepon in wepons)
        {
            Console.WriteLine(wepon);
        }

        Console.WriteLine("Wählen sie eine Waffe aus für Robo" + (robots.Count + 1) + ":");
        string roboWeapon = Console.ReadLine();
        
        switch (Convert. ToInt32(roboWeapon))
        {
            case 1:
                return new Sword() { Name = "Schwert", Damage = 10, Durability = 5};
                break;
            case 2:
                return new Bow() { Name = "Bogen", Damage = 10, Durability = 3 };
                break;
            case 3:
                return new Nife() { Name = "Messer", Damage = 5 , Durability = 9};
                break;
            default:
                return new Sword() { Name = "Schwert", Damage = 10, Durability = 5};
                break;
        }
    }
}