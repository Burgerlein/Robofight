using Robofight.Extensions;
using Robofight.GameTypes;
using Robofight.View;


namespace Robofight;

// Setup
public class OneVsOne : IRoundMode
{
    public void Round(List<Robot> robots, int roundNumber)
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();
        consoleLogs.ClearCurrentConsoleLines(5 + robots.Count * 2);


        var robotsCount = robots.Count;

        consoleLogs.WriteRoundNumber(roundNumber);
        var num1 = RandomNumberGenerator.Generate(robotsCount);
        while (robots[num1].Status == Status.Dead)
        {
            num1 = RandomNumberGenerator.Generate(robotsCount);
        }

        var num2 = RandomNumberGenerator.Generate(robotsCount);
        while (num2 == num1 || robots[num2].Status == Status.Dead)
        {
            num2 = RandomNumberGenerator.Generate(robotsCount);
        }

        robots[num1].ChangeStatus(Status.Attacking);
        robots[num2].ChangeStatus(Status.Defending);
        Console.WriteLine(robots[num1].Name + " greift " + robots[num2].Name + " an");
        robots[num1].Attack(robots[num2]);
        if (robots[num2].Status == Status.Dead)
        {
            robots[num1].RobotKillCount++;
        }

        foreach (var robot in robots)
        {
            consoleLogs.HealthBar(robot.HealthPoints, robot.MaxHealthPoints, robot.Name, robot.Status,
                robot.RobotKillCount);
            consoleLogs.DurabilityBar(robot.Weapon.Durability, robot.Weapon.MaxDurability, robot.Weapon.Name);
        }

        robots[num1].ChangeStatus(Status.None);
        robots[num2].ChangeStatus(Status.None);
        consoleLogs.PrintLineSeparator();
    }
}