using Robofight.Skills.ActiveSkills;

namespace Robofight;

public interface IModifyHealth : ITakeDamage, IHeal, IDealDamage
{
}