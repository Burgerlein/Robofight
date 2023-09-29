using Robofight.View;


namespace Robofight;

// Setup
public class Game
{
    public int RoundNumber { get; set; }

    public void GameLoop()
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();

        CreatePlayers createPlayers = new CreatePlayers();
        var robots = createPlayers.AddPlayer();

        bool startRound = ConsoleInteractions.GetBoolInput("Möchten sie das Spiel Starten?");
        if (startRound)
        {
            consoleLogs.ClearCurrentConsoleLines(2);
            NextRound(robots);
            while (!IsOnlyOneAlive(robots))
            {
                consoleLogs.RoundMenu();
                string roundManger = ConsoleInteractions.GetTextInput();
                consoleLogs.ClearCurrentConsoleLines(4);
                switch (roundManger.ToLower())
                {
                    case "f":
                    {
                        for (int i = 1; i <= 5 && !IsOnlyOneAlive(robots); i++)
                        {
                            NextRound(robots);
                        }

                        break;
                    }
                    case "a":
                    {
                        while (!IsOnlyOneAlive(robots))
                        {
                            NextRound(robots);
                        }

                        break;
                    }
                    default:
                        NextRound(robots);
                        break;
                }
            }

            consoleLogs.PrintWinner(GetFirstRobotAlive(robots)!);
        }
        else
        {
            consoleLogs.WriteLineWithColor(ConsoleColor.Red, "Das Spiel wurde abgebrochen!");
        }

        Console.ReadLine();
    }

    public void NextRound(List<Robot> robots)
    {
        RoundNumber++;
        ConsoleLogs consoleLogs = new ConsoleLogs();
        consoleLogs.ClearCurrentConsoleLines(5 + robots.Count * 2);


        var robotsCount = robots.Count;

        consoleLogs.WriteRoundNumber(RoundNumber);
        var num1 = CreateRandomNumber(robotsCount);
        while (robots[num1].IsDead)
        {
            num1 = CreateRandomNumber(robotsCount);
        }

        var num2 = CreateRandomNumber(robotsCount);
        while (num2 == num1 || robots[num2].IsDead)
        {
            num2 = CreateRandomNumber(robotsCount);
        }

        robots[num1].IsActive = 2;
        robots[num2].IsActive = 3;
        Console.WriteLine(robots[num1].Name + " greift " + robots[num2].Name + " an");
        robots[num1].Attack(robots[num2]);
        if (robots[num2].IsDead)
        {
            robots[num1].RobotKillCount++;
        }

        foreach (var robot in robots)
        {
            consoleLogs.HealthBar(robot.HealthPoints, robot.MaxHealthPoints, robot.Name, robot.IsActive,
                robot.RobotKillCount);
            consoleLogs.DurabilityBar(robot.Weapon.Durability, robot.Weapon.MaxDurability, robot.Weapon.Name);
        }

        robots[num1].IsActive = 1;
        robots[num2].IsActive = 1;
        consoleLogs.PrintLineSeparator();
    }

    public string? GetFirstRobotAlive(List<Robot> robots)
    {
        foreach (var robot in robots)
        {
            if (robot.IsAlive)
            {
                return robot.Name;
            }
        }

        return null;
    }

    public bool IsOnlyOneAlive(List<Robot> robots)
    {
        var deadRobots = 0;
        foreach (var robot in robots)
        {
            if (robot.IsDead)
            {
                deadRobots++;
                if (robots.Count - 1 == deadRobots)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static int CreateRandomNumber(int maxValue, int minValue = 0)
    {
        Random rnd = new Random();
        return rnd.Next(minValue, maxValue);
    }
}