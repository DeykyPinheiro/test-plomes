using Microsoft.AspNetCore.Mvc;
using PlomesApi.Models;
using PlomesApi.Repositories.Interfaces;
using PlomesApi.Services.Interfaces;

namespace PlomesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> FindAll()
        {
            List<User> users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            User user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Save([FromBody] User user)
        {
            User userSaved = await _userService.Save(user);
            return CreatedAtAction(nameof(GetById), new { id = userSaved.Id }, userSaved);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(int id, [FromBody] User user)
        {
            User userSaved = await _userService.Update(id, user);
            return Ok(userSaved);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.delete(id);
            return NoContent();
        }
    }
}
