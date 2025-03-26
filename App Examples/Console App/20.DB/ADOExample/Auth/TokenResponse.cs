namespace BoscComa.ADO
{
    public class TokenResponse : ITokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}