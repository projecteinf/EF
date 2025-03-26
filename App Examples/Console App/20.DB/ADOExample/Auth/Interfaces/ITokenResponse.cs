namespace BoscComa.ADO
{
    public interface ITokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}