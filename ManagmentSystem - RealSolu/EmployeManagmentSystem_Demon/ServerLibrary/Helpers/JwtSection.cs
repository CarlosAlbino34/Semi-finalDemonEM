
namespace ServerLibrary.Helpers
{
    public class JwtSection
    {
        // We use this to mapped app once is runnig from  the (appsetting.json)
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
