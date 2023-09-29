namespace Robofight.Extensions;

public static class RobotExtensions
{
    public static string? GetFirstRobotAlive(List<Robot> robots)
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

    public static bool IsOnlyOneAlive(List<Robot> robots)
    {
        var deadRobots = 0;
        foreach (var robot in robots)
        {
            if (robot.Status == Status.Dead)
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

    public static int GetNumberOfAliveRobots(List<Robot> robots)
    {
        var alive = 0;
        foreach (var robot in robots)
        {
            if (robot.IsAlive)
            {
                alive++;
            }
        }
        return alive;
    }
}