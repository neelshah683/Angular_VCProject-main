using WebApplication1.Data.Repositories.IRepository;
using WebApplication1.model;

namespace WebApplication1.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<UserModel> GetAllUsersInMemory()
        {
            var users = _context.Users.ToList(); // Load data into memory
            return users.Where(u => u.isActive.Equals(true)).ToList(); // Filter in memory
        }

        public List<UserModel> GetAllUsersFromDatabase()
        {
            var usersQuery = _context.Users.Where(u => u.isActive.Equals(true)); // Create query
            return usersQuery.ToList(); // Execute query on the database
        }

        public UserModel GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.UserId == id);
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.SingleOrDefault(u => u.RoleId == id);
        }

        public void AddUser(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(UserModel user)
        {
            // Locate the user to delete based on ID
            var userToDelete = _context.Users.Find(user.UserId);

            // Check if the user exists before deleting
            if (userToDelete != null)
            {
                userToDelete.isActive = false;
                // Remove the user from the database context
                /*_context.Users.Remove(userToDelete);*/

                // Save the changes to the database
                _context.SaveChanges();
            }
            else
            {
                // Handle the case where the user to delete is not found (optional: throw an exception)
                throw new Exception("User with ID " + user.UserId + " not found for deletion.");
            }
        }

        public void UpdateUser(UserModel user)
        {
            // Locate the user to update based on ID (assuming unique identifier)
            var existingUser = _context.Users.Find(user.UserId);

            // Check if the user exists before updating
            if (existingUser != null)
            {
                // Update the properties of the existing user object with new values
                existingUser.Username = user.Username;
                existingUser.EmailAddress = user.EmailAddress;
                existingUser.Password = user.Password;
                existingUser.RoleId = user.RoleId;
                existingUser.isActive = user.isActive;
                // Update other relevant properties as needed

                // Save the changes to the database
                _context.SaveChanges();
            }
            else
            {
                // Handle the case where the user to update is not found (optional: throw an exception)
                throw new Exception("User with ID " + user.UserId + " not found for update.");
            }
        }


        // New Methods
        public List<UserModel> GetUsersOrderedByUsername()
        {
            return _context.Users.OrderBy(u => u.Username).ToList();
        }

        public List<IGrouping<string, UserModel>> GetUsersGroupedByRole()
        {
            return _context.Users.GroupBy(u => u.Role.RoleName).ToList();
        }

        public List<UserRoleDto> GetUsersWithRoles()
        {
            var usersWithRoles = from user in _context.Users
                                 join role in _context.Roles
                                 on user.RoleId equals role.RoleId
                                 select new UserRoleDto
                                 {
                                     Username = user.Username,
                                     RoleName = role.RoleName
                                 };
            return usersWithRoles.ToList();
        }
    }
}
