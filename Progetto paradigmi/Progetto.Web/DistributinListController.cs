
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Progetto_paradigmi.Progetto.Application.Factories;
using Progetto_paradigmi.Progetto.Application.Services;
using Progetto_paradigmi.Progetto.Application.Factories;
using Progetto_paradigmi.Progetto.Application.DTO;
using Progetto_paradigmi.Progetto.Models.Responses;
using Progetto_paradigmi.Progetto.Models.Entities;
using System.Security.Claims;
using Microsoft.Graph.Education.Classes.Item.Assignments.Item.Submissions.Item.Return;
using Progetto_paradigmi.Progetto.Models.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Graph.Models;

namespace Progetto_paradigmi.Progetto.Web
{


    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DistributionListController : ControllerBase
    {

        private readonly DistributionListService _distributionListService;
        private readonly UtentiRepository _utentiRepository;
        private readonly DistributionListRepository _distributionListRepository;

        public DistributionListController(DistributionListService distributionListService, UtentiRepository utentiRepository, DistributionListRepository distributionListRepository)
        {
            _distributionListService = distributionListService;
            _distributionListRepository = distributionListRepository;
            _utentiRepository = utentiRepository;
        }

        [HttpPost("new")]
        public IActionResult CreateDistributionList([FromBody] DistributionListDTO distributionList)
        {
            try
            {
                int id = getTokenId();
                var utenti = _utentiRepository.GetById(id);   
                distributionList.OwnerEmail = utenti.Email;
                _distributionListService.createDistributionList(distributionList);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("{DistributionListId:int}/addToList")]
        public IActionResult AddMemberToDistributionList(int DistributionListId, [FromBody] RecipientsDTO recipient)
        {
            try
            {
                int userId = getTokenId();
                var distributionList = _distributionListRepository.GetById(DistributionListId);

                if (distributionList.OwnerId != userId)
                {
                    return Unauthorized("You are not authorized to perform this action.");
                }
               
                _distributionListService.AddMemberToDistributionList(recipient, DistributionListId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{DistributionListId:int}/removeByList")]
        public IActionResult RemoveMemberFromDistributionList(int DistributionListId, [FromBody] RecipientsDTO recipient)
        {
            try
            {
                int userId = getTokenId();
                var distributionList = _distributionListRepository.GetById(DistributionListId);

                if (distributionList.OwnerId != userId)
                {
                    return Unauthorized("You are not authorized to perform this action.");
                }
                
                _distributionListService.RemoveMemberFromDistributionList(recipient, DistributionListId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("GetListsWithRecipients")]
        public IActionResult GetRecipientLists([FromQuery] string recipientEmail)
        {
            try
            {
                int id = getTokenId();
                var recipientLists = _distributionListService.GetRecipientLists(recipientEmail, id);
                return Ok(recipientLists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("DistributionListByOwner")]
        public IActionResult GetDistributionListsByOwnerId()
        {
            try
            {
                int id = getTokenId();
                var distributionLists = _distributionListService.GetDistributionListsByOwnerId(id);
                return Ok(distributionLists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("RecipientsByOwner")]
        public IActionResult GetRecipientsByOwnerId()
        {
            try
            {
                int id = getTokenId();
                var recipientEmails = _distributionListService.GetRecipientsByOwnerId(id);
                return Ok(recipientEmails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        private int getTokenId()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            string idUtente = claimsIdentity.Claims
                .Where(w => w.Type == "Id").First().Value;
            if(idUtente != null)
            {
                return int.Parse(idUtente);
            }
            throw new Exception("");
        }
        
    }


}

