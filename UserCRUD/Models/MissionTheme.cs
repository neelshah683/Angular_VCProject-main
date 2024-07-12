namespace WebApplication2.Models
{
    public class MissionTheme
    {
        public int Id { get; set; }
        public string ThemeName { get; set; }
        public int MissionId { get; set; }
        public Mission Mission { get; set; }
    }

}
