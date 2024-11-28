namespace BaseLibrary.Entities
{
    public class RefreshTokenInfo
    {
        //In this classe we gonna make that when client make a refresh of the token we 
        //make sure to authenticate the new token by following the step or metods as we write here
        public int Id { get; set; }
        public string? Token { get; set; }
        public int UserId { get; set; }
    }
}
