using Robofight.Factories;
using Robofight.View;

namespace Robofight;

public class RobotFactory
{
    private static List<Robot> robots = new List<Robot>();


    private static int CreateBots(int amountOfBots = 1)
    {
        for (int i = 0; i < amountOfBots; i++)
        {
            var robotWeaponNumber = WeaponFactory.GetWeapon(RandomNumberGenerator.Generate(7));
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

            var robotWeapon = WeaponFactory.RoboWeapon(robotName);
            Robot robot = new Robot()
                { Name = robotName, HealthPoints = 100, Damage = 5, MaxHealthPoints = 100, Weapon = robotWeapon };

            consoleLogs.PrintLineSeparator();
            consoleLogs.PrintLeftRightColoredText(robotName, ConsoleColor.Green, null, ConsoleColor.Gray,
                " wurde erstellt");
            robots.Add(robot);
        }

        return robots;
    }

    
}