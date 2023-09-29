namespace Robofight;

public class BrassKnuckles : Weapon
{
    public override int CalculateDamage(Robot owner)
    {
        if (CantUseWeapon)
            return owner.Damage;
        var num = Game.CreateRandomNumber(10);
        if (num == 1)
        {
            return (owner.Damage + Damage) * 3;
        }

        return owner.Damage + Damage;
    }
}