namespace WebApplication2.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MissionSkill> MissionSkills { get; set; }
        public ICollection<MissionTheme> MissionThemes { get; set; }
    }

}
