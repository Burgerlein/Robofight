namespace Robofight.View;

public class ConsoleInteractions
{
    private static readonly ConsoleLogs _consoleLogs = new ConsoleLogs();

    public static int GetNumberInput(string text)
    {
        _consoleLogs.PrintWithLineSeparator(text);

        while (true)
        {
            try
            {
                return int.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception e)
            {
                _consoleLogs.ClearCurrentConsoleLines(1);
            }
        }
    }

    public static string GetTextInput(string? defaultValue = null, string? textValue = null)
    {
        if (textValue != null)
        {
            _consoleLogs.PrintWithLineSeparator(textValue);
        }

        string textInput = Console.ReadLine() ?? defaultValue ?? string.Empty;
        return textInput;
    }

    public static bool GetBoolInput(string question)
    {
        _consoleLogs.PrintWithLineSeparator(question);
        string yes = "[Y/J] Ja";
        string separator = " | ";
        string no = "[N] Nein";
        Console.WriteLine(yes + separator + no);

        var consoleKeyInfo = Console.ReadKey(true);
        _consoleLogs.ClearCurrentConsoleLines(1);
        switch (consoleKeyInfo.KeyChar.ToString().ToLower())
        {
            case "y":
            case "j":
                _consoleLogs.PrintLeftRightColoredText(yes, ConsoleColor.Green, separator, ConsoleColor.Gray, no);
                return true;
            default:
                _consoleLogs.PrintLeftRightColoredText(yes, ConsoleColor.Gray, separator, ConsoleColor.Red, no);
                return false;
        }
    }
}