namespace Robofight;

public class CheckInputs
{
   
    public static bool CheckIfNumber(string? s)
    {
        if (string.IsNullOrEmpty(s)) return false;
        var isNumeric = int.TryParse(s, out _);
        return isNumeric;
    }

    public static string ReadLine(string? number)
    {
        number = Console.ReadLine();
        return number;
    }
}