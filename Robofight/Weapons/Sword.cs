namespace Robofight;

public class Sword : Weapon
{
    public Sword() : base()
    {
    }
    public override int CalculateDamage(Robot owner)
    {
        if (CantUseWeapon)
            return owner.Damage;
        return owner.Damage + Damage;
    }
}