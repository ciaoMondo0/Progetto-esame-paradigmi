using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Graph.Models;
using Progetto_paradigmi.Progetto.Application.DTO;
using Progetto_paradigmi.Progetto.Application.Interfaces;
using Progetto_paradigmi.Progetto.Models.Entities;
using Progetto_paradigmi.Progetto.Models.Repositories;

namespace Progetto_paradigmi.Progetto.Application.Services
{
    public class DistributionListService
    {
        private List<DistributionList> DistributionLists { get; set; }
        private readonly List<DistributionList> _list;
        private readonly DistributionListRepository _distributionListRepository;
        private readonly UtentiRepository _utentiRepository;
        private readonly RecipientsRepository _recipientsRepository;
        private readonly RecipientsListRepository _recipientsListRepository;

        public DistributionListService(DistributionListRepository _distributionListRepository, UtentiRepository _utentiRepository, RecipientsRepository _recipientsRepository,
            RecipientsListRepository _recipientsListRepository)
        {
            DistributionLists = new List<DistributionList>();
            _list = new List<DistributionList>();
            this._distributionListRepository = _distributionListRepository;
            this._utentiRepository = _utentiRepository;
            this._recipientsRepository = _recipientsRepository;
            this._recipientsListRepository = _recipientsListRepository;
        }


        
        public void createDistributionList(DistributionListDTO dto)

        {
            var owner = _utentiRepository.GetUserByEmail(dto.OwnerEmail); if (owner == null)
            {
                throw new Exception();
            }
            var newList = new DistributionList()
            {
                
                Name = dto.Name,
                OwnerId = owner.Id,
                
            };
            _distributionListRepository.Aggiungi(newList);
            _distributionListRepository.Save();
        }
       
        public void AddMemberToDistributionList(RecipientsDTO dto)
        {
            var distributionList = _distributionListRepository.GetAll().FirstOrDefault(dl => dl.Id == dto.DistributionListId);
            if (distributionList == null)
            {
                throw new Exception("Distribution list not found.");
            }

            foreach (var email in dto.EmailRecipients)
            {
                var existingRecipient = _recipientsRepository.GetAll().FirstOrDefault(r => r.Email == email);


                if (existingRecipient == null)
                {
                    var member = new Recipients
                    {
                        Email = email
                    };
                  
                    _recipientsRepository.Aggiungi(member);
                    _recipientsRepository.Save();
                    var listeDestinatari = new RecipientsList { DistributionListId = dto.DistributionListId, RecipientId = member.Id };
                    _recipientsListRepository.Aggiungi(listeDestinatari);
                    _recipientsListRepository.Save();
                }
                else
                {

                    var listeDestinatari = new RecipientsList { DistributionListId = dto.DistributionListId, RecipientId = existingRecipient.Id };
                    _recipientsListRepository.Aggiungi(listeDestinatari);
                    _recipientsListRepository.Save();
                }
                }
            }

         public void RemoveMemberFromDistributionList(RecipientsDTO dto)
            {
                foreach (var email in dto.EmailRecipients)
                {

                var distributionList = _distributionListRepository.GetAll().FirstOrDefault(dl => dl.Id == dto.DistributionListId);
                    var recipient = _recipientsRepository.GetAll().FirstOrDefault(r => r.Email == email);
                    if (recipient == null)
                    {
                        throw new Exception("Recipient not found.");
                    }
               
                var recipientListEntry = _recipientsListRepository.FindByIds(distributionList.Id, recipient.Id);

                if (recipientListEntry == null)
                {
                    throw new Exception($"Recipient with email {email} not found in the specified distribution list.");
                }

               
                _recipientsListRepository.Delete(recipientListEntry);
            }

            
            _recipientsListRepository.Save();

        }

            public List<string> GetRecipientLists(string recipientEmail, int ownerId)
            {
                var recipient = _recipientsRepository.GetAll()
                    .FirstOrDefault(r => r.Email == recipientEmail);

           
                     if (recipient == null)
            {
                throw new Exception("Recipient not found.");
            }

            var recipientLists = _recipientsListRepository.GetAll()
                .Where(rl => rl.RecipientId == recipient.Id)
                .Select(rl => rl.DistributionListId)
                .ToList();

            var distributionListNames = recipientLists.Select(id => _distributionListRepository.GetById(id).Name).ToList();

            return distributionListNames;

        }
    }
  }



    



