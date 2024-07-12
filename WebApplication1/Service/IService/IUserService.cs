using WebApplication1.model;

namespace WebApplication1.Service.IService
{
    public interface IUserService
    {
        UserNew Authenticate(string username, string password);
        IEnumerable<UserNew> GetAll();
    }
}
