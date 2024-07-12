namespace WebApplication1.model
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserModel> Users { get; set; }
    }
}
