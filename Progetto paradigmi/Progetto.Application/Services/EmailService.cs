using Azure.Identity;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.Security;
using Microsoft.Graph.Users.Item.SendMail;
using Progetto_paradigmi.Progetto.Application.Interfaces;
using Progetto_paradigmi.Progetto.Application.Options;
using Progetto_paradigmi.Progetto.Models.Entities;
using Progetto_paradigmi.Progetto.Models.Repositories;

namespace Progetto_paradigmi.Progetto.Application.Services
{
    public class EmailService : IEmailService
    {

        private readonly EmailOption _emailOption;

        private DistributionList distributionList;
        private List<DistributionList> _list;
        private DistributionListRepository _distributionListRepository;
        private RecipientsListRepository _recipientsListRepository;
        private RecipientsRepository _recipientsRepository;

        public EmailService(IOptions<EmailOption> emailOptions, DistributionListRepository distributionListRepository, RecipientsListRepository recipientsListRepository, RecipientsRepository recipientsRepository)
        {
            _emailOption = emailOptions.Value;
            _list = new List<DistributionList>();
            _distributionListRepository = distributionListRepository;
            _recipientsListRepository = recipientsListRepository;
            _recipientsRepository = recipientsRepository;
        }



        public async Task SendEmailAsync(string subject, string body, int DistributionId, int userId)
        {
            var clientCredential = new ClientSecretCredential(_emailOption.TenantId
        , _emailOption.ClientId
        , _emailOption.ClientSecret
        );

            var client = new GraphServiceClient(clientCredential);


            var distributionList = _distributionListRepository.GetAll().FirstOrDefault(dl => dl.Id == DistributionId);
            if (distributionList == null)
            {
                throw new Exception("Distribution list not found.");
            }
            if (distributionList.OwnerId != userId)
            {
                throw new UnauthorizedAccessException("You are not authorized to send emails to this distribution list.");
            }

            var recipients = (from rl in _recipientsListRepository.GetAll()
                              join r in _recipientsRepository.GetAll() on rl.RecipientId equals r.Id
                              where rl.DistributionListId == DistributionId
                              select r.Email);

            var message = new Message
            {
                Subject = subject,
                Body = new ItemBody
                {
                    ContentType = BodyType.Text,
                    Content = body
                },
                ToRecipients = recipients.Select(email => new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = email
                    }
                }).ToList()
            };

            var postRequestBody = new SendMailPostRequestBody();
            postRequestBody.Message = message;
            postRequestBody.SaveToSentItems = true;

            await client.Users[_emailOption.From]
                .SendMail.PostAsync(postRequestBody);
        }
    }
}

