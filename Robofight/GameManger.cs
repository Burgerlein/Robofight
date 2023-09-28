using Robofight.View;

namespace Robofight;

public class GameManger
{
    private List<Robot> robots = new List<Robot>();

    public bool PlayerCreateOptions() // Muss Refaktort werden
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();

        consoleLogs.PrintMenuToChooseBotsActiveOrFalse();
        string botOptionValue = Console.ReadLine();

        while (!CheckInputs.CheckIfNumber(botOptionValue))
        {
            consoleLogs.PrintMenuToChooseBotsActiveOrFalse();
            botOptionValue = CheckInputs.ReadLine(botOptionValue);
        }

        if (Convert.ToInt32(botOptionValue) == 1) return true;
        return false;
    }

    public int ChooseHowManyBotsMenu() // Muss Refaktort werden
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();
        consoleLogs.PrintWithLineSeparator("Mit Wie vielen Bots wollen sie spielen ?");
        string botAmountOptionValue = Console.ReadLine();
        while (!CheckInputs.CheckIfNumber(botAmountOptionValue))
        {
            consoleLogs.PrintWithLineSeparator("Mit Wie vielen Bots wollen sie spielen ?");
            botAmountOptionValue = CheckInputs.ReadLine(botAmountOptionValue);
        }

        return Convert.ToInt32(botAmountOptionValue);
    }

    public int CreatePlayers()
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();

        int? playerCount = null;
        while (playerCount == null)
        {
            consoleLogs.PrintWithLineSeparator("Wie viele Spieler sind sie ?");
            try
            {
                playerCount = int.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception e)
            {
                // ignored}
            }
        }

        return (int)playerCount;
    }

    private int CreateBots(int playerCount, int amopuntOfBots = 1)
    {
        while (amopuntOfBots > 0)
        {
            var roboWeapon = GetWeapon(Game.CreateRandomNumber(5));
            Robot robot = new Robot
            {
                Name = $"RobotBot{robots.Count + 1}", HealthPoints = 100, Damage = 5, MaxHealthPoints = 100,
                Weapon = roboWeapon
            };
            ;
            robots.Add(robot);
            playerCount++;
            amopuntOfBots--;
        }

        return playerCount;
    }

    public List<Robot> AddPlayer() // Muss Refaktort werden
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();
        
        var botOptionValue = PlayerCreateOptions();
        var playerCount = 0;
        if (Convert.ToInt32(botOptionValue) == 1)
        {
            int amopuntOfBots = ChooseHowManyBotsMenu();
            playerCount = CreateBots(playerCount, amopuntOfBots);
        }
        else if (Convert.ToInt32(botOptionValue) == 2)
        {
            consoleLogs.PrintMenuOptionFromBefore("[1] Ja |", ConsoleColor.Gray, ConsoleColor.Red, " [2] Nein");
        }

        playerCount += CreatePlayers();
        if (playerCount == 1) playerCount = CreateBots(playerCount);

        while (robots.Count < playerCount)
        {
            var roboName = RoboName();
            var roboWeapon = RoboWeapon();
            Robot robot = new Robot()
                { Name = roboName, HealthPoints = 100, Damage = 5, MaxHealthPoints = 100, Weapon = roboWeapon };

            Console.WriteLine(roboName + " wurde erstellt");
            robots.Add(robot);
        }


        return robots;
    }

    public string RoboName()
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();
        consoleLogs.PrintLineSeparator();
        Console.WriteLine("Geben sie den Namen für Robot" + (robots.Count + 1) + " ein: ");
        string roboName = Console.ReadLine() ?? $"Robot{robots.Count + 1}";
        return roboName;
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

        ConsoleLogs consoleLogs = new ConsoleLogs();
        consoleLogs.PrintLineSeparator();

        Console.WriteLine("Wählen sie eine Waffe aus für Robo" + (robots.Count + 1) + ":");
        string roboWeapon = Console.ReadLine();


        return GetWeapon(Convert.ToInt32(roboWeapon));
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