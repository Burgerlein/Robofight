namespace Robofight;

public class BaseballBat : Weapon
{

    public override int CalculateDamage(Robot owner)
    {
        if (CantUseWeapon)
            return owner.Damage;
        return Damage;
    }
}