using Robofight.View;

namespace Robofight;

public class PlayerFactory
{
    private static List<Robot> robots = new List<Robot>();


    private static int CreateBots(int amountOfBots = 1)
    {
        for (int i = 0; i < amountOfBots; i++)
        {
            var robotWeaponNumber = GetWeapon(RandomNumberGenerator.Generate(7));
            Robot robot = new Robot
            {
                Name = $"RobotBot{robots.Count + 1}", HealthPoints = 100, Damage = 5, MaxHealthPoints = 100,
                Weapon = robotWeaponNumber
            };
            robots.Add(robot);
        }

        return amountOfBots;
    }

    public static List<Robot> CreatePlayers() // Muss Refaktort werden
    {
        robots.Clear();
        ConsoleLogs consoleLogs = new ConsoleLogs();

        var botsShouldBeCreated = ConsoleInteractions.GetBoolInput("Möchten sie mit Bots Spielen?");
        int totalcount;
        var botCount = 0;
        if (botsShouldBeCreated)
        {
            int amountOfBots = ConsoleInteractions.GetNumberInput("Mit Wie vielen Bots wollen sie spielen ?");
            botCount = CreateBots(amountOfBots);
        }

        totalcount = ConsoleInteractions.GetNumberInput("Wie viele Spieler sind sie ?");
        totalcount += botCount;
        if (totalcount == 1) totalcount += CreateBots();

        while (robots.Count < totalcount)
        {
            string robotName =
                ConsoleInteractions.GetTextInput(
                    $"Robot{robots.Count + 1}", "Geben sie den Namen für Robot" + (robots.Count + 1) + " ein: ");

            var robotWeapon = RoboWeapon(robotName);
            Robot robot = new Robot()
                { Name = robotName, HealthPoints = 100, Damage = 5, MaxHealthPoints = 100, Weapon = robotWeapon };

            consoleLogs.PrintLineSeparator();
            consoleLogs.PrintLeftRightColoredText(robotName, ConsoleColor.Green, null, ConsoleColor.Gray,
                " wurde erstellt");
            robots.Add(robot);
        }

        return robots;
    }

    private static Weapon RoboWeapon(string robotName)
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();

        string[] weapons =
        {
            "1: Sword          -> Damge: 15 | Durability:  5 | Kann andere Schwerter / Messer abwehren 1/6",
            "2: Bow            -> Damge: 45 | Durability:  3 | Treffer Quote liegt bei 1/3",
            "3: Knife          -> Damge: 10 | Durability:  9 | Chanche 1/6 das man doppelt trifft",
            "4: Brass Kuckles  -> Damge: 13 | Durability:  9 | Chanche 1/10 das man 3 Fach Schaden macht",
            "5: Baseball Bat   -> Damge:  5 | Durability: 20 | Kann Messer abwehren (1/6)",
            "6: Gun            -> Damge: 50 | Durability:  9 | Treffer Quote liegt bei 1/12"
        };
        foreach (var weapon in weapons)
        {
            Console.WriteLine(weapon);
        }

        int numberInput =
            ConsoleInteractions.GetNumberInput("Wählen sie eine Waffe aus für " + robotName + ":") - 1;


        int weaponLine = weapons.Length + 3 - numberInput;
        consoleLogs.ClearSpecificLine(weaponLine);
        consoleLogs.WriteLineWithColor(ConsoleColor.Green, weapons[numberInput]);
        consoleLogs.GoToSpecificLine(weapons.Length - numberInput + 2);


        return GetWeapon(numberInput);
    }

    private static Weapon GetWeapon(int number)
    {
        return number switch
        {
            0 => new Sword() { Name = "Schwert", Damage = 10, Durability = 5, MaxDurability = 5 },
            1 => new Bow() { Name = "Bogen", Damage = 10, Durability = 3, MaxDurability = 3 },
            2 => new Knife() { Name = "Messer", Damage = 5, Durability = 9, MaxDurability = 9 },
            3 => new BrassKnuckles() { Name = "Schlagring", Damage = 8, Durability = 10, MaxDurability = 10 },
            4 => new BaseballBat() { Name = "Schläger", Damage = 5, Durability = 20, MaxDurability = 20 },
            5 => new Gun() { Name = "Pistole", Damage = 45, Durability = 9, MaxDurability = 9 },
            _ => new Sword() { Name = "Schwert", Damage = 10, Durability = 5, MaxDurability = 5 }
        };
    }
}