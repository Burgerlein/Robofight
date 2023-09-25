namespace Robofight;

public class Nife : Weapon
{
    public Nife() : base()
    {
    }
    public override int CalculateDamage(Robot owner)
    {
        if (CantUseWeapon)
            return owner.Damage;
        Random rnd = new Random();
        int num = rnd.Next(6);
        if (num == 1)
        {
            return (owner.Damage + Damage) * 2;
        }
        return owner.Damage + Damage;
    }
}