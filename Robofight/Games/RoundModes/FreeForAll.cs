using Robofight.Extensions;
using Robofight.View;

namespace Robofight.GameTypes;

public class FreeForAll : IRoundMode
{
    public void Round(List<Robot> robots, int roundNumber)
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();
        consoleLogs.ClearCurrentConsoleLines(3 + robots.Count * 4);

        var robotsCount = robots.Count;

        consoleLogs.WriteRoundNumber(roundNumber);


        foreach (var robot in robots)
        {
            if (robot.Status is Status.Dead) continue; // Muss noch anders gelöst werden -> IsActive !!!!!
            var num2 = RandomNumberGenerator.Generate(robotsCount);
            while (robots[num2] == robot || robots[num2].Status == Status.Dead)
            {
                num2 = RandomNumberGenerator.Generate(robotsCount);
            }

            Console.WriteLine(robot.Name + " greift " + robots[num2].Name + " an");
            robot.Attack(robots[num2]);
            if (robots[num2].Status == Status.Dead)
            {
                robot.RobotKillCount++;
            }
        }


        foreach (var robot in robots)
        {
            robot.ChangeStatus(Status.None);
            consoleLogs.HealthBar(robot.HealthPoints, robot.MaxHealthPoints, robot.Name, robot.Status,
                robot.RobotKillCount);
            consoleLogs.DurabilityBar(robot.Weapon.Durability, robot.Weapon.MaxDurability, robot.Weapon.Name);
        }

        consoleLogs.PrintLineSeparator();
    }
}