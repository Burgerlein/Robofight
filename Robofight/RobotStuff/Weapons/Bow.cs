﻿namespace Robofight;

public class Bow : Weapon
{
    public override int CalculateDamage(Robot owner)
    {
        if (CantUseWeapon)
            return owner.Damage;
        var num = RandomNumberGenerator.Generate(3);
        if (num == 1)
        {
            return (owner.Damage + Damage) * 3;
        }

        return 0;
    }
}