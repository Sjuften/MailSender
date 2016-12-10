namespace mail.app.UserAuthentications
{
    public interface IUserAuthentication
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}