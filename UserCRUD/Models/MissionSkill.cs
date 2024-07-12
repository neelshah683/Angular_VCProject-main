namespace WebApplication2.Models
{
    public class MissionSkill
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public int MissionId { get; set; }
        public Mission Mission { get; set; }
    }

}
