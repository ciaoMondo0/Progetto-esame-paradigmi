using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Progetto_paradigmi.Progetto.Application.DTO;
using Progetto_paradigmi.Progetto.Application.Interfaces;
using Progetto_paradigmi.Progetto.Application.Options;
using Progetto_paradigmi.Progetto.Application.Services;
using System.Security.Claims;

namespace Progetto_paradigmi.Progetto.Web
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmailController : Controller
    {
        
       
        private List<string> to;
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailDTO email)
        {
            try
            {
                int userId = this.getTokenId();
                await _emailService.SendEmailAsync(
                    
                    email.Subject,
                    email.Body,
                    email.DistributionListId,
                    userId);

                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        private int getTokenId()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            string idUtente = claimsIdentity.Claims
                .Where(w => w.Type == "Id").First().Value;
            if (idUtente != null)
            {
                return int.Parse(idUtente);
            }
            throw new Exception("");
        }



    }
}
