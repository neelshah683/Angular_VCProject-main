using WebApplication1.model;

namespace WebApplication1.Data.Repositories.IRepository
{
        public interface IUserRepository
        {
            List<UserModel> GetAllUsersInMemory();
            List<UserModel> GetAllUsersFromDatabase();
            UserModel GetUserById(int id);
            Role GetRoleById(int id);
            void AddUser(UserModel user);
            void UpdateUser(UserModel user);
            void DeleteUser(UserModel user);
            List<UserModel> GetUsersOrderedByUsername();
            List<IGrouping<string, UserModel>> GetUsersGroupedByRole();
            List<UserRoleDto> GetUsersWithRoles();
        }
    }
