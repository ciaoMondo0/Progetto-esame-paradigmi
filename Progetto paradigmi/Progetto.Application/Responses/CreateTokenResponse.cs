namespace Progetto_paradigmi.Progetto.Application.Responses
{
    public class CreateTokenResponse
    {
        public CreateTokenResponse(string token)
        {
            Token = token;
        }
        public string Token { get; set; } = string.Empty;
    }
}
