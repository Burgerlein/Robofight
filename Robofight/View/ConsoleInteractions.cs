namespace Robofight.View;

public class ConsoleInteractions
{
    private static readonly ConsoleLogs _consoleLogs = new ConsoleLogs();

    public static int GetNumberInput(string textValue)
    {
        int? value = null;
        while (true)
        {
            _consoleLogs.PrintWithLineSeparator(textValue);
            try
            {
                return int.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception e)
            {
                // ignored}
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