using System.Collections.Generic;
using System.Threading.Tasks;
using DatabasesProgrammingExample01.Models;
using DatabasesProgrammingExample01.Database.EFCoreUserWithFriends;
using Microsoft.AspNetCore.Mvc;

namespace DatabasesProgrammingExample01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserWithFriendsController : ControllerBase
    {
        private readonly IUserWithFriendsRepository _repository;

        public UserWithFriendsController(IUserWithFriendsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserWithFriends>>> GetAllUsersWithFriends()
        {
            return Ok(await _repository.GetAllUsersWithFriends());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserWithFriends>> GetUserWithFriendsById(int id)
        {
            var user = await _repository.GetUserWithFriendsById(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("{id}/friends")]
        public async Task<ActionResult<ICollection<UserWithFriends>>> GetFriendsOfUser(int id)
        {
            var friends = await _repository.GetFriendsOfUser(id);
            if (friends == null)
            {
                return NotFound();
            }
            return Ok(friends);
        }

        [HttpPost]
        public async Task<ActionResult<UserWithFriends>> AddUserWithFriends(UserWithFriends userWithFriends)
        {
            await _repository.AddUserWithFriends(userWithFriends);
            return CreatedAtAction(nameof(GetUserWithFriendsById), new { id = userWithFriends.Id }, userWithFriends);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserWithFriends(int id, UserWithFriends userWithFriends)
        {
            if (id != userWithFriends.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateUserWithFriends(userWithFriends);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserWithFriends(int id)
        {
            var userWithFriends = await _repository.GetUserWithFriendsById(id);
            if (userWithFriends == null)
            {
                return NotFound();
            }
            await _repository.DeleteUserWithFriends(userWithFriends);
            return NoContent();
        }
    }
}