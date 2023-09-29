namespace Robofight;

public class Robot : ICanChangeStatus, ICanTakeDamage
{
    public string Name { get; set; }
    public int HealthPoints { get; set; }

    public int RobotKillCount { get; set; }
    public int MaxHealthPoints { get; init; }
    public Status Status { get; private set; }
    public int Damage { get; set; }
    public Weapon Weapon { get; set; }

    public int Attack(Robot opponent)
    {
        Skills skills = new Skills();
        if (Status == Status.Dead) return 0;

        var totalDamage = Weapon.CalculateDamage(this);

        if (skills.UseAllSkills(this, opponent, totalDamage))
        {
            return 0;
        }

        opponent.TakeDamage(totalDamage);
        Weapon.Disintegrate();
        Console.WriteLine("Dabei macht er: " + totalDamage + " Schaden");
        return totalDamage;
    }

    public bool IsAlive => Status != Status.Dead;

    public void ChangeStatus(Status status)
    {
        if (Status == Status.Dead) return;
        Status = status;
    }

    public void TakeDamage(int damage)
    {
        HealthPoints -= damage;
        if (HealthPoints < 0)
        {
            HealthPoints = 0;
        }
        if (HealthPoints == 0)
        {
            Status = Status.Dead;
        }
    }
}