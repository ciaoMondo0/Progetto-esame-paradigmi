
using Microsoft.Graph;
using Progetto_paradigmi.Progetto.Application.Services;
using Progetto_paradigmi.Progetto.Application.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using Progetto_paradigmi.Progetto.Models.Entities;
using Progetto_paradigmi.Progetto.Application.Services;
namespace Progetto_paradigmi.Progetto.Application.Test
{
    
    public class EmailTest
    {
        

        public async Task SendEmailAsync_WithValidInputs_ShouldSendEmail()
        {
            // Arrange
            var emailOption = new EmailOption
            {
                TenantId = "your_tenant_id",
                ClientId = "your_client_id",
                ClientSecret = "your_client_secret",
                From = "from_email@example.com"
            };

            
           
        }
    }
}

