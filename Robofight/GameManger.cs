using Robofight.View;

namespace Robofight;

public class GameManger
{
    private List<Robot> robots = new List<Robot>();


    private int CreateBots(int amopuntOfBots = 1)
    {
        for (int i = 0; i < amopuntOfBots; i++)
        {
            var roboWeapon = GetWeapon(Game.CreateRandomNumber(7));
            Robot robot = new Robot
            {
                Name = $"RobotBot{robots.Count + 1}", HealthPoints = 100, Damage = 5, MaxHealthPoints = 100,
                Weapon = roboWeapon
            };
            robots.Add(robot);
        }

        return amopuntOfBots;
    }

    public List<Robot> AddPlayer() // Muss Refaktort werden
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();

        var botsShouldBeCreated = ConsoleInteractions.GetBoolInput("Möchten sie mit Bots Spielen?");
        int totalcount;
        int botCount = 0;
        if (botsShouldBeCreated)
        {
            int amopuntOfBots = ConsoleInteractions.GetNumberInput("Mit Wie vielen Bots wollen sie spielen ?");
            botCount = CreateBots(amopuntOfBots);
        }

        totalcount = ConsoleInteractions.GetNumberInput("Wie viele Spieler sind sie ?");
        totalcount += botCount;
        if (totalcount == 1) totalcount += CreateBots();

        while (robots.Count < totalcount)
        {
            string roboName =
                ConsoleInteractions.GetTextInput(
                    $"Robot{robots.Count + 1}", "Geben sie den Namen für Robot" + (robots.Count + 1) + " ein: ");

            var roboWeapon = RoboWeapon();
            Robot robot = new Robot()
                { Name = roboName, HealthPoints = 100, Damage = 5, MaxHealthPoints = 100, Weapon = roboWeapon };

            Console.WriteLine(roboName + " wurde erstellt");
            robots.Add(robot);
        }


        return robots;
    }


    public Weapon RoboWeapon()
    {
        string[] wepons =
        {
            "1: Sword          -> Damge: 15 | Durability:  5 | Kann andere Schwerter abwehren 1/6",
            "2: Bow            -> Damge: 45 | Durability:  3 | Treffer Quote liegt bei 1/3",
            "3: Knife          -> Damge: 10 | Durability:  9 | Chanche 1/6 das man doppelt trifft",
            "4: Brass Kuckles  -> Damge: 13 | Durability:  9 | Chanche 1/10 das man 3 Fach Schaden macht",
            "5: Baseball Bat   -> Damge:  5 | Durability: 20 | Kann Messer abwehren (1/6)",
            "6: Gun            -> Damge: 50 | Durability:  9 | Treffer Quote liegt bei 1/12"
        };

        foreach (var wepon in wepons)
        {
            Console.WriteLine(wepon);
        }

        int roboWeapon =
            ConsoleInteractions.GetNumberInput("Wählen sie eine Waffe aus für Robo" + (robots.Count + 1) + ":");
        return GetWeapon(roboWeapon);
    }

    private Weapon GetWeapon(int roboWeapon)
    {
        return roboWeapon switch
        {
            1 => new Sword() { Name = "Schwert", Damage = 10, Durability = 5, MaxDurability = 5 },
            2 => new Bow() { Name = "Bogen", Damage = 10, Durability = 3, MaxDurability = 3 },
            3 => new Knife() { Name = "Messer", Damage = 5, Durability = 9, MaxDurability = 9 },
            4 => new BrassKnuckles() { Name = "Schlagring", Damage = 8, Durability = 10, MaxDurability = 10 },
            5 => new BaseballBat() { Name = "Schläger", Damage = 5, Durability = 20, MaxDurability = 20 },
            6 => new Gun() { Name = "Pistole", Damage = 45, Durability = 9, MaxDurability = 9 },
            _ => new Sword() { Name = "Schwert", Damage = 10, Durability = 5, MaxDurability = 5 }
        };
    }
}