using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Repositories.IRepository;
using WebApplication1.model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewUserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public NewUserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("all-in-memory")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<UserModel>> GetAllUsersInMemory()
        {
            return _userRepository.GetAllUsersInMemory();
        }

        [HttpGet("all-from-database")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<UserModel>> GetAllUsersFromDatabase()
        {
            return _userRepository.GetAllUsersFromDatabase();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserModel> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddUser([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // Ensure the role exists before adding the user
            var role = _userRepository.GetRoleById(user.RoleId);
            if (role == null)
            {
                return BadRequest("Invalid role ID.");
            }

            user.Role = role;

            _userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(user);
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel updatedUser)
        {
            if (updatedUser == null || updatedUser.UserId != id)
            {
                return BadRequest();
            }

            // Ensure the role exists before updating the user
            var role = _userRepository.GetRoleById(updatedUser.RoleId);
            if (role == null)
            {
                return BadRequest("Invalid role ID.");
            }

            var existingUser = _userRepository.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = updatedUser.Username;
            existingUser.Password = updatedUser.Password;
            existingUser.EmailAddress = updatedUser.EmailAddress;
            existingUser.RoleId = updatedUser.RoleId;
            existingUser.Role = role;

            _userRepository.UpdateUser(existingUser);
            return NoContent();
        }



        [HttpGet("ordered-by-username")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<UserModel>> GetUsersOrderedByUsername()
        {
            return _userRepository.GetUsersOrderedByUsername();
        }

        [HttpGet("grouped-by-role")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<IGrouping<string, UserModel>>> GetUsersGroupedByRole()
        {
            return _userRepository.GetUsersGroupedByRole();
        }

        [HttpGet("users-with-roles")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<UserRoleDto>> GetUsersWithRoles()
        {
            var usersWithRoles = _userRepository.GetUsersWithRoles();
            return Ok(usersWithRoles);
        }

    }
}
