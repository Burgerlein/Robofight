namespace Robofight.View;

public class ConsoleInteractions
{
    private static readonly ConsoleLogs _consoleLogs = new ConsoleLogs();

    public static int GetNumberInput(string textValue)
    {
        _consoleLogs.PrintWithLineSeparator(textValue);

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
        string robotName = Console.ReadLine() ?? defaultValue ?? string.Empty;
        return robotName;  
    }
}