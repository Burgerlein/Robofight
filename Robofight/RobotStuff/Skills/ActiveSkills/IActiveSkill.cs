namespace Robofight.Skills.ActiveSkills;

public interface IActiveSkill
{
    public string Name { get; set; }
    public string Description { get; set; }
    public void Use();
}