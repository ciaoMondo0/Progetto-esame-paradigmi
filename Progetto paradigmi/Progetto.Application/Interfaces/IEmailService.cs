namespace Progetto_paradigmi.Progetto.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, int DistributionId);
    }
}
