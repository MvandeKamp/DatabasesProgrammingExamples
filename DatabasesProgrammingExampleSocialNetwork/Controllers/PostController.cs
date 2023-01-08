using DatabasesProgrammingExampleSocialNetwork.Database;
using DatabasesProgrammingExampleSocialNetwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabasesProgrammingExampleSocialNetwork.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly EfCoreSocialNetworkRepository _repository;

        public PostController(EfCoreSocialNetworkContext context)
        {
            _repository = new EfCoreSocialNetworkRepository(context);
        }

        [HttpPost]
        public ActionResult<Post> AddPost(Post post)
        {
            _repository.AddPost(post);
            return CreatedAtAction(nameof(GetPostById), new { id = post.PostId }, post);
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetPostById(int id)
        {
            var post = _repository.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return post;
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, Post updatedPost)
        {
            // Get the existing post from the database
            var post = _repository.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            
            post.Content = updatedPost.Content;
            post.Reactions = updatedPost.Reactions;
            // Save the updated post to the database
            _repository.UpdatePost(post);
            return NoContent();
        }
    }
}
