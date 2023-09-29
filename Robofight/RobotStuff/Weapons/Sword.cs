namespace Robofight;

public class Sword : Weapon
{
    public override int CalculateDamage(Robot owner)
    {
        if (CantUseWeapon)
            return owner.Damage;
        return owner.Damage + Damage;
    }
}