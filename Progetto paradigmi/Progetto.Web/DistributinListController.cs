
using Microsoft.AspNetCore.Mvc;
using Progetto_paradigmi.Progetto.Application.Factories;
using Progetto_paradigmi.Progetto.Application.Services;
using Progetto_paradigmi.Progetto.Application.Factories;
using Progetto_paradigmi.Progetto.Application.DTO;
using Progetto_paradigmi.Progetto.Models.Responses;
using Progetto_paradigmi.Progetto.Models.Entities;

namespace Progetto_paradigmi.Progetto.Web
{


    [ApiController]
    [Route("api/v1/[controller]")]
    public class DistributionListController : ControllerBase
    {

        private readonly DistributionListService _distributionListService;

        public DistributionListController(DistributionListService distributionListService)
        {
            _distributionListService = distributionListService;
        }

        [HttpPost("new")]
        public IActionResult CreateDistributionList([FromBody] DistributionListDTO distributionList)
        {
            try
            {
                _distributionListService.createDistributionList(distributionList);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("{id:int}/add")]
        public IActionResult AddMemberToDistributionList(int id, [FromBody] RecipientsDTO recipient)
        {
            try
            {
                recipient.DistributionListId = id;
                _distributionListService.AddMemberToDistributionList(recipient);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}/remove")]
        public IActionResult RemoveMemberFromDistributionList(int id, [FromBody] RecipientsDTO recipient)
        {
            try
            {
                recipient.DistributionListId = id;
                _distributionListService.RemoveMemberFromDistributionList(recipient);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("recipients")]
        public IActionResult GetRecipientLists([FromQuery] string recipientEmail, [FromQuery] int ownerId)
        {
            try
            {
                var recipientLists = _distributionListService.GetRecipientLists(recipientEmail, ownerId);
                return Ok(recipientLists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }


}

