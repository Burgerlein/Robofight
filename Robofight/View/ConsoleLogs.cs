﻿namespace Robofight.View;

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

    public void GoToSpecificLine(int line)
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

    public void PrintWinner(string name)
    {
        Console.WriteLine("\n"); // \n = neue zeile
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(name + " hat gewonnen");
        Console.ResetColor();
    }

    public void RoundMenu()
    {
        Console.WriteLine("[N] für nexte Runde");
        Console.WriteLine("[F] um die nächsten Fünf runden zu skippen");
        Console.WriteLine("[A] um zum ende zu springen");
    }

    public void HealthBar(int health, int maxHealth, string name, Status status, int? kills = 0)
    {
        switch (status)
        {
            case Status.Attacking:
                WriteWithColor(ConsoleColor.Green, $"{name,-13} {kills,7}");
                break;
            case Status.Defending:
                WriteWithColor(ConsoleColor.Yellow, $"{name,-13} {kills,7}");
                break;
            case Status.Dead:
                WriteWithColor(ConsoleColor.Red, $"{name,-13} {kills,7}");
                break;
            default:
                Console.Write($"{name,-13} {kills,7}");
                break;
        }

        Console.Write($"({health,5}) : ");
        ValueBar(health, maxHealth, "<", "3");
    }

    public void WriteWithColor(ConsoleColor color, string text)
    {
        ResetSetColor(color);
        Console.Write(text);
        Console.ResetColor();
    }

    public void WriteLineWithColor(ConsoleColor color, string text)
    {
        ResetSetColor(color);
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public void DurabilityBar(int durability, int maxDurability, string name)
    {
        Console.Write($"Waffe: {name,10}{"L ",13}");
        ValueBar(durability, maxDurability, "-", "}");
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

    public void WriteRoundNumber(int number)
    {
        PrintLineSeparator();
        Console.WriteLine("Runde " + number + ":");
    }

    public void PrintWithLineSeparator(string text)
    {
        PrintLineSeparator();
        Console.WriteLine(text);
    }

    public void PrintLeftRightColoredText(string textLeft, ConsoleColor colorLeft, string separator,
        ConsoleColor colorRight,
        string? textRight)
    {
        WriteWithColor(colorLeft, textLeft);
        Console.Write(separator);
        if (textRight != null) WriteWithColor(colorRight, textRight);
        Console.WriteLine();
    }
}