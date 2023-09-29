using Robofight.GameTypes;
using Robofight.Skills.ActiveSkills;

namespace Robofight;

public class Robot : IRobotAbilities
{
    public string Name { get; set; }
    public int HealthPoints { get; set; }

    public int RobotKillCount { get; set; }
    public int MaxHealthPoints { get; init; }
    public Status Status { get; private set; }
    public int Damage { get; set; }
    public Weapon Weapon { get; set; }

    public int Attack(ITakeDamage opponent)
    {
        if (Status == Status.Dead) return 0;

        var totalDamage = Weapon.CalculateDamage(this);
        Weapon.Disintegrate();
        if (totalDamage == 0)
        {
            Console.WriteLine("Hat keinen Schaden gemacht");
            return 0;
        }
        opponent.TakeDamage(totalDamage);
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

    public void Heal(int amount)
    {
        HealthPoints += amount;
        if (HealthPoints > MaxHealthPoints)
            HealthPoints = MaxHealthPoints;
    }

    void IDealDamage.Damage(int amount)
    {
        throw new NotImplementedException();
    }

    public void Repair(int amount)
    {
        throw new NotImplementedException();
    }

    public void Disintegrate(int amount)
    {
        throw new NotImplementedException();
    }
}