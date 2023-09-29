namespace Robofight;

public static class RandomNumberGenerator
{
    public static int Generate(int maxValue, int minValue = 0)
    {
        Random rnd = new Random();
        return rnd.Next(minValue, maxValue);
    }

}