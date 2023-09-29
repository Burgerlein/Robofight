namespace Robofight.RobotStuff.Skills.PassiveSkills;

public class Defend : IPassiveSkill
{
    public string Name { get; set; }
    public string Description { get; set; }

    public void Use(IModifyHealth modifyHealth) 
    {
        modifyHealth.Heal(10);
    }
}