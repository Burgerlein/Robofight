namespace Robofight;

public class Bow : Weapon
{

    public Bow() : base()
    {
    }
    public override int CalculateDamage(Robot owner)
    {
        if (CantUseWeapon)
            return owner.Damage;
        Random rnd = new Random();
        int num = rnd.Next(3);
        if (num == 1)
        {
            return (owner.Damage + Damage) * 3;
        }
        return 0;
    }
}