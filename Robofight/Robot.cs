namespace Robofight;

public class Robot
{
    public string Name { get; set; }
    
    public int HealthPoints { get; set; }
    
    public int Damge { get; set; }

    public void Attack(Robot opponent)
    {
        opponent.HealthPoints -= Damge;
    }
}
