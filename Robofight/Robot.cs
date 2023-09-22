namespace Robofight;

public class Robot
{
    public string Name { get; set; }
    
    public int HealthPoints { get; set; }
    
    public int Damage { get; set; }
    

    public void Attack(Robot opponent)
    {
        if (IsAlive)
        {
            opponent.HealthPoints -= Damage;
        }
    }
    public bool IsDead => HealthPoints <= 0;
    public bool IsAlive => !IsDead;

}
