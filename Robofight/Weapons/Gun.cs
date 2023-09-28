namespace Robofight;

public class Gun : Weapon
{
    public override int CalculateDamage(Robot owner)
    {
        if (CantUseWeapon)
            return owner.Damage;
        var num =Game.CreateRandomNumber(12);
        if (num == 1)
        {
            return owner.Damage + Damage;
        }
        return 0;
    }
}