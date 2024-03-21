using Microsoft.AspNetCore.Mvc;
using Progetto_paradigmi.Progetto.Application.DTO;
using Progetto_paradigmi.Progetto.Application.Interfaces;
using Progetto_paradigmi.Progetto.Application.Services;
using Progetto_paradigmi.Progetto.Application.Validators;
using Progetto_paradigmi.Progetto.Application.Responses;

namespace Progetto_paradigmi.Progetto.Web
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtentiController : ControllerBase
    {
        private readonly UtentiService _userService;
        private readonly TokenService _tokenService;

        public UtentiController(UtentiService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("new")]
        public IActionResult CreateUser([FromBody] UtentiDTO userDto)
        {
            var validator = new CreateUserValidator();
            var result = validator.Validate(userDto);
            if (result.IsValid)
            {
                try
                {
                    _userService.CreateUser(userDto);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            else
            {
                return BadRequest();
            }
        }




        /*
        
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
        }*/


        [HttpPost]
        [Route("login")]
        public IActionResult LogIn(CreateTokenRequest tokenRequest)
        {
            try
            {
                String token = _tokenService.CreateToken(tokenRequest);
                return Ok(new CreateTokenResponse(token));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        


    }

}
