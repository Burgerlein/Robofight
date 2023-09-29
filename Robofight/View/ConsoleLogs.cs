namespace Robofight.View;

public class ConsoleLogs
{
    public void PrintLineSeparator()
    {
        Console.WriteLine("____________________________________________________________");
    }

    public void ClearCurrentConsoleLines(int lines)
    {
        for (var line = 0; line < lines; line++)
        {
            if (Console.CursorTop == 0)
                return;
            Console.SetCursorPosition(0, Console.CursorTop - 1);

            ClearCurrenLine();
        }
    }
    public void ClearSpecificLine(int line)
    {
        if (Console.CursorTop == 0)
            return;
        Console.SetCursorPosition(0, Console.CursorTop - line);
        ClearCurrenLine();
    }
    public void GoToSpeficLine(int line)
    {
        if (Console.CursorTop == 0)
            return;
        Console.SetCursorPosition(0, Console.CursorTop + line);
    }
    private static void ClearCurrenLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    public void ResetSetColor(ConsoleColor color)
    {
        Console.ResetColor();
        Console.ForegroundColor = color;
    }

    public void PrintWinner(string winner)
    {
        Console.WriteLine("\n"); // \n = neue zeile
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(winner + " hat gewonnen");
        Console.ResetColor();
    }

    public void RoundMenu()
    {
        Console.WriteLine("[N] für nexte Runde");
        Console.WriteLine("[F] um die nächsten Fünf runden zu skippen");
        Console.WriteLine("[A] um zum ende zu springen");
    }

    public void HealthBar(int robotHealth, int robotMaxHealth, string robotName, int robotActive, int? kills = 0)
    {
        switch (robotActive)
        {
            case 2:
                WriteWithColor(ConsoleColor.Green, $"{robotName,-13} {kills,7}");
                break;
            case 3:
                WriteWithColor(ConsoleColor.Yellow, $"{robotName,-13} {kills,7}");
                break;
            default:
            {
                if (robotHealth <= 0) WriteWithColor(ConsoleColor.Red, $"{robotName,-13} {kills,7}");
                else Console.Write($"{robotName,-13} {kills,7}");

                break;
            }
        }

        Console.Write($"({robotHealth,5}) : ");
        ValueBar(robotHealth, robotMaxHealth, "<", "3");
    }

    public void WriteWithColor(ConsoleColor color, string textValue)
    {
        ResetSetColor(color);
        Console.Write(textValue);
        Console.ResetColor();
    }
    public void WriteLineWithColor(ConsoleColor color, string textValue)
    {
        ResetSetColor(color);
        Console.WriteLine(textValue);
        Console.ResetColor();
    }
    public void DurabilityBar(int weaponDurability, int weaponMaxDurability, string weaponName)
    {
        Console.Write($"Waffe: {weaponName,10}{"L ",13}");
        ValueBar(weaponDurability, weaponMaxDurability, "-", "}");
    }

    public void ValueBar(int value, int maxValue, string leftCharakter, string rightCharakter)
    {
        float relativeValue = (float)value / maxValue * 10;
        int i = 1;
        ResetSetColor(ConsoleColor.Green);
        for (; i <= relativeValue; i++)
        {
            Console.Write(leftCharakter + rightCharakter + " ");
        }

        if (relativeValue - (i - 1) >= 0.5)
        {
            Console.Write(leftCharakter);
            ResetSetColor(ConsoleColor.Red);
            Console.Write(rightCharakter + " ");
            i++;
        }

        ResetSetColor(ConsoleColor.Red);
        while (i <= 10)
        {
            Console.Write(leftCharakter + rightCharakter + " ");
            i++;
        }

        Console.ResetColor();
        Console.WriteLine();
    }

    public void WriteRoundNumber(int roundNumber)
    {
        PrintLineSeparator();
        Console.WriteLine("Runde " + roundNumber + ":");
    }

    public void PrintWithLineSeparator(string text)
    {
        PrintLineSeparator();
        Console.WriteLine(text);
    }

    public void PrintLeftRightColoredText(string textValueLeft, ConsoleColor colorLeft, string separator ,ConsoleColor colorRight,
        string? textValueRight)
    {
        WriteWithColor(colorLeft, textValueLeft);
        Console.Write(separator);
        if (textValueRight != null) WriteWithColor(colorRight, textValueRight);
        Console.WriteLine();
    }
}