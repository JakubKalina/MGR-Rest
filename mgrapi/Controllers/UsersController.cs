using mgrapi.Dtos.User;
using mgrapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mgrapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
      _usersService = usersService;
    }

    [HttpGet("")]
    [Produces(typeof(GetAllUsersDto))]
    public IActionResult GetUsers()
    {
      var users = _usersService.GetAll();

      return Ok(users);
    }

    [HttpGet("{id:int}")]
    [Produces(typeof(GetUserByIdDto))]
    public IActionResult GetUserById([FromRoute] int id)
    {
      var user = _usersService.Get(id);

      if(user == null)
        return NotFound();

      return Ok(user);
    }

    [HttpPost("")]
    public IActionResult CreateUser([FromBody] CreateUserDto user)
    {
      var id = _usersService.Create(user);

      return Created($"api/users/{id}", id);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateUser([FromRoute] int id, [FromBody] UpdateUserDto user)
    {
      bool isUpdated = _usersService.Update(id, user);

      if (isUpdated)
        return NoContent();

      return NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteUser([FromRoute] int id)
    {
      bool isDeleted = _usersService.Delete(id);

      if (isDeleted)
        return NoContent();

      return NotFound();
    }
  }
}