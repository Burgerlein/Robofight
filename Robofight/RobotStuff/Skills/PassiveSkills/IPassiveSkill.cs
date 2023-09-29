namespace Robofight.RobotStuff.Skills.PassiveSkills;

public interface IPassiveSkill
{
    public string Name { get; set; }
    public string Description { get; set; }
    public void Use(IModifyHealth modifyHealth);
}