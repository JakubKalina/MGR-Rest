using mgrapi.Dtos.Post;
using mgrapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mgrapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private IPostsService _postsService;

    public PostsController(IPostsService postsService)
    {
      _postsService = postsService;
    }

    [HttpGet("")]
    [Produces(typeof(GetAllPostsDto))]
    public IActionResult GetPosts()
    {
      var posts = _postsService.GetAll();

      return Ok(posts);
    }

    [HttpGet("{id:int}")]
    [Produces(typeof(GetPostByIdDto))]
    public IActionResult GetPostById([FromRoute] int id)
    {
      var post = _postsService.Get(id);

      if(post == null)
        return NotFound();

      return Ok(post);
    }

    [HttpPost("")]
    public IActionResult CreatePost([FromBody] CreatePostDto post)
    {
      var id = _postsService.Create(post);

      return Created($"api/posts/{id}", id);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdatePost([FromRoute] int id, [FromBody] UpdatePostDto post)
    {
      bool isUpdated = _postsService.Update(id, post);

      if (isUpdated)
        return NoContent();

      return NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeletePost([FromRoute] int id)
    {
      bool isDeleted = _postsService.Delete(id);

      if (isDeleted)
        return NoContent();

      return NotFound();
    }
  }
}