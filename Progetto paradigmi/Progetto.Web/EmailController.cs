using Microsoft.AspNetCore.Mvc;
using Progetto_paradigmi.Progetto.Application.DTO;
using Progetto_paradigmi.Progetto.Application.Interfaces;
using Progetto_paradigmi.Progetto.Application.Options;
using Progetto_paradigmi.Progetto.Application.Services;

namespace Progetto_paradigmi.Progetto.Web
{
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
                await _emailService.SendEmailAsync(
                    
                    email.Subject,
                    email.Body,
                    email.DistributionListId);

                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }



    }
}
