namespace Robofight;

public class Robot
{
    private int _healthPoints;
    public string Name { get; set; }

    public int HealthPoints
    {
        get => _healthPoints;
        set
        {
            if (value < 0) _healthPoints = 0;
            else _healthPoints = value;
        }
    }

    public int RobotKillCount { get; set; }
    public int MaxHealthPoints { get; init; }
    public int IsActive { get; set; }
    public int Damage { get; set; }
    public Weapon Weapon { get; set; }

    public int Attack(Robot opponent)
    {
        Skills skills = new Skills();
        if (IsDead) return 0;

        var totalDamage = Weapon.CalculateDamage(this);

        if (skills.UseAllSkills(this, opponent, totalDamage))
        {
            return 0;
        }

        opponent.HealthPoints -= totalDamage;
        Weapon.Disintegrate();
        Console.WriteLine("Dabei macht er: " + totalDamage + " Schaden");
        return totalDamage;
    }

    public bool IsDead => HealthPoints <= 0;
    public bool IsAlive => !IsDead;
}