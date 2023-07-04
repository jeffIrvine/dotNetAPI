using Microsoft.AspNetCore.Mvc;
using dotNetAPI.Models;

namespace dotNetAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/v1/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/v1/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(Guid id)
        {
            var user = await _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/v1/Users/5
        [HttpPut("{id}")]
public async Task<IActionResult> PutUser(Guid id, UserModel userRequest)
{
    var user = await _userService.GetUser(id);

    if (user == null || user.Id != userRequest.Id)
    {
        return BadRequest();
    }

    // Copy the fields from userRequest to user
    user.TrailName = userRequest.TrailName;
    user.Email = userRequest.Email;
    // and so on for other fields...

    try
    {
        await _userService.UpdateUser(user);
    }
    catch
    {
        if (!await _userService.UserExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

    return NoContent();
}

        // POST: api/v1/Users
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel user)
        {
            await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // DELETE: api/v1/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}