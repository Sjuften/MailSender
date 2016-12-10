namespace mail.app.Models.UserAuthentications
{
    public interface IUserAuthentication
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}