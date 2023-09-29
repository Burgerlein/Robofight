using Robofight.Extensions;
using Robofight.View;

namespace Robofight.GameTypes;

public class DefaultGame : IGame
{
    public int RoundNumber { get; private set; }
    public IRoundMode RoundMode { get; set; }
    public void GameLoop()
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();

        var robots = PlayerFactory.CreatePlayers();

        bool startRound = ConsoleInteractions.GetBoolInput("Möchten sie das Spiel Starten?");
        Console.Clear();
        if (startRound)
        {
            consoleLogs.ClearCurrentConsoleLines(2);
            NextRound(robots);
            while (!RobotExtensions.IsOnlyOneAlive(robots))
            {
                consoleLogs.RoundMenu();
                string roundManger = ConsoleInteractions.GetTextInput();
                consoleLogs.ClearCurrentConsoleLines(4);
                switch (roundManger.ToLower())
                {
                    case "f":
                    {
                        for (int i = 1; i <= 5 && !RobotExtensions.IsOnlyOneAlive(robots); i++)
                        {
                            NextRound(robots);
                        }

                        break;
                    }
                    case "a":
                    {
                        while (!RobotExtensions.IsOnlyOneAlive(robots))
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

            consoleLogs.PrintWinner(RobotExtensions.GetFirstRobotAlive(robots)!);
        }
        else
        {
            consoleLogs.WriteLineWithColor(ConsoleColor.Red, "Das Spiel wurde abgebrochen!");
        }

        Console.ReadLine();
    }

    private void NextRound(List<Robot> robots)
    {
        RoundNumber++;
        RoundMode.Round(robots, RoundNumber);
    }
}