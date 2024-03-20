namespace Progetto_paradigmi.Progetto.Application.Interfaces
{
    public class CreateTokenRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
