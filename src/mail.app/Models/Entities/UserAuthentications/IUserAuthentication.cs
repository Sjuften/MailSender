namespace mail.app.Models.Entities.UserAuthentications
{
    public interface IUserAuthentication
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}