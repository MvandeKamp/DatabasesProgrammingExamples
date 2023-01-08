using DatabasesProgrammingExampleSocialNetwork.Database;
using DatabasesProgrammingExampleSocialNetwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabasesProgrammingExampleSocialNetwork.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EfCoreSocialNetworkRepository _repository;

        public UserController(EfCoreSocialNetworkContext context)
        {
            _repository = new EfCoreSocialNetworkRepository(context);
        }

        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            _repository.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}