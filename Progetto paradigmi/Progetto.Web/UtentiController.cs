using Microsoft.AspNetCore.Mvc;
using Progetto_paradigmi.Progetto.Application.DTO;
using Progetto_paradigmi.Progetto.Application.Services;

namespace Progetto_paradigmi.Progetto.Web
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtentiController : ControllerBase
    {
        private readonly UtentiService _userService;

        public UtentiController(UtentiService userService)
        {
            _userService = userService;
        }

        [HttpPost("new")]
        public IActionResult CreateUser([FromBody] UtentiDTO userDto)
        {
            _userService.CreateUser(userDto);
            return Ok();
        }
        
        [HttpGet("{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{email}")]
        public IActionResult UpdateUser(string email, [FromBody] UtentiDTO userDto)
        {
            try
            {
                _userService.UpdateUser(email, userDto);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{email}")]
        public IActionResult DeleteUser(string email)
        {
            try
            {
                _userService.DeleteUser(email);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
        

    }

}
