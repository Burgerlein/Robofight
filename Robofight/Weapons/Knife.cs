namespace Robofight;

public class Knife : Weapon
{
    public override int CalculateDamage(Robot owner)
    {
        if (CantUseWeapon)
            return owner.Damage;
        var num = Game.CreateRandomNumber(6);
        if (num == 1)
        {
            return (owner.Damage + Damage) * 2;
        }
        return owner.Damage + Damage;
    }
}