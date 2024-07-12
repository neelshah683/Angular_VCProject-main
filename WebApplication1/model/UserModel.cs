using System.ComponentModel.DataAnnotations;

namespace WebApplication1.model
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public Boolean isActive { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
