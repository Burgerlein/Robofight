namespace Robofight;

public class Skills
{
    public bool UseAllSkills(Robot attacker, Robot opponent, int totalDamage)
    {
        if (SwordDefend(attacker, opponent)) return true;
        if (BowNotHit(attacker, totalDamage)) return true;
        if (BaseballDefend(attacker, opponent)) return true;
        if (GunNotHit(attacker, totalDamage)) return true;

        return false;
    }

    private bool SwordDefend(Robot attacker, Robot opponent)
    {
        if (attacker.Weapon is Sword && opponent.Weapon is Sword || opponent.Weapon is Knife)
        {
            var num = RandomNumberGenerator.Generate(6);
            if (num != 1) return false;
            Defend(attacker, opponent);
            return true;
        }

        return false;
    }

    private bool BowNotHit(Robot attacker, int totalDamage)
    {
        if (attacker.Weapon is Bow && totalDamage == 0)
        {
            Console.WriteLine(attacker.Name + " hat nicht getroffen");
            attacker.Weapon.Disintegrate();
            return true;
        }

        return false;
    }

    private bool GunNotHit(Robot attacker, int totalDamage)
    {
        if (attacker.Weapon is Gun && totalDamage == 0)
        {
            Console.WriteLine(attacker.Name + " hat nicht getroffen");
            attacker.Weapon.Disintegrate();
            return true;
        }

        return false;
    }

    private bool BaseballDefend(Robot attacker, Robot opponent)
    {
        if (attacker.Weapon is not Knife || opponent.Weapon is not BaseballBat) return false;

        var num = RandomNumberGenerator.Generate(6);
        if (num != 1) return false;

        Defend(attacker, opponent);
        return true;
    }

    private void Defend(Robot attacker, Robot opponent)
    {
        Console.WriteLine("schlag abgewehrt");
        attacker.Weapon.Disintegrate();
        opponent.Weapon.Disintegrate();
    }
}