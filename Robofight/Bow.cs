namespace Robofight;

public class Bow : Weapon
{
    public override int CalculateDamage(Robot owner)
    {
        if (CantUseWeapon)
            return owner.Damage;
        Random rnd = new Random();
        int num = rnd.Next(2);
        if (num == 1) 
            return (owner.Damage + Damage) * 2;
        return 0;
    }
}