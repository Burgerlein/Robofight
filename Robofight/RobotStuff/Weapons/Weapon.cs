namespace Robofight;

public abstract class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Durability { get; set; }
    public int MaxDurability { get; init; }

    public void Disintegrate()
    {
        Durability--;
    }

    public bool CantUseWeapon => Durability <= 0;
    public abstract int CalculateDamage(Robot owner);
}