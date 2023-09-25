namespace Robofight;

public class Robot
{
    public string Name { get; set; }
    
    public int HealthPoints { get; set; }
    
    public int Damage { get; set; }
    
    public Weapon Weapon { get; set; }

    public int Attack(Robot opponent)
    {
        if (IsAlive)
        {
            if (this.Weapon.Name == "Schwert" && opponent.Weapon.Name == "Schwert")
            {
                Random rnd = new Random();
                int num = rnd.Next(6);
                if (num == 1)
                {
                    Console.WriteLine("schlag abgewehrt");
                    Weapon.Disintegrate();
                    return 0;
                }
            }
            
            var totalDamage = Weapon.CalculateDamage(this);

            if (this.Weapon.Name == "Bogen" && totalDamage == 0)
            {
                Console.WriteLine(this.Name + " hat nicht getroffen");
                Weapon.Disintegrate();
                return 0;
            }
            opponent.HealthPoints -= totalDamage;
            Weapon.Disintegrate();
            Console.WriteLine("Dabei macht er: "+ totalDamage + " Schaden");
            return totalDamage;

        }
        return 0;
    }
    public bool IsDead => HealthPoints <= 0;
    public bool IsAlive => !IsDead;

}
