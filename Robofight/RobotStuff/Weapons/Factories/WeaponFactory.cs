using Robofight.View;

namespace Robofight.Factories;

public static class WeaponFactory
{
    public static Weapon RoboWeapon(string robotName)
    {
        ConsoleLogs consoleLogs = new ConsoleLogs();

        string[] weapons =
        {
            "1: Sword          -> Damge: 15 | Durability:  5 | Kann andere Schwerter / Messer abwehren 1/6",
            "2: Bow            -> Damge: 45 | Durability:  3 | Treffer Quote liegt bei 1/3",
            "3: Knife          -> Damge: 10 | Durability:  9 | Chanche 1/6 das man doppelt trifft",
            "4: Brass Kuckles  -> Damge: 13 | Durability:  9 | Chanche 1/10 das man 3 Fach Schaden macht",
            "5: Baseball Bat   -> Damge:  5 | Durability: 20 | Kann Messer abwehren (1/6)",
            "6: Gun            -> Damge: 50 | Durability:  9 | Treffer Quote liegt bei 1/12"
        };
        foreach (var weapon in weapons)
        {
            Console.WriteLine(weapon);
        }

        int numberInput =
            ConsoleInteractions.GetNumberInput("Wählen sie eine Waffe aus für " + robotName + ":") - 1;


        int weaponLine = weapons.Length + 3 - numberInput;
        consoleLogs.ClearSpecificLine(weaponLine);
        consoleLogs.WriteLineWithColor(ConsoleColor.Green, weapons[numberInput]);
        consoleLogs.GoToSpecificLine(weapons.Length - numberInput + 2);


        return GetWeapon(numberInput);
    }

    public static Weapon GetWeapon(int number)
    {
        return number switch
        {
            0 => new Sword() { Name = "Schwert", Damage = 10, Durability = 5, MaxDurability = 5 },
            1 => new Bow() { Name = "Bogen", Damage = 10, Durability = 3, MaxDurability = 3 },
            2 => new Knife() { Name = "Messer", Damage = 5, Durability = 9, MaxDurability = 9 },
            3 => new BrassKnuckles() { Name = "Schlagring", Damage = 8, Durability = 10, MaxDurability = 10 },
            4 => new BaseballBat() { Name = "Schläger", Damage = 5, Durability = 20, MaxDurability = 20 },
            5 => new Gun() { Name = "Pistole", Damage = 45, Durability = 9, MaxDurability = 9 },
            _ => new Sword() { Name = "Schwert", Damage = 10, Durability = 5, MaxDurability = 5 }
        };
    }
}