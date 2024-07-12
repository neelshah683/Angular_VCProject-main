using WebApplication1.model;
using WebApplication1.Service.IService;

namespace WebApplication1.Service
{
    public class UserService : IUserService
    {

        private readonly List<UserNew> _users = new()
        {
            new UserNew { Username = "admin", Password = "password", Role = "Admin" },
            new UserNew { Username = "user", Password = "password", Role = "User" }
        };

        public UserNew Authenticate(string username, string password)
        {
            return _users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public IEnumerable<UserNew> GetAll()
        {
            return _users;
        }

    }
}
