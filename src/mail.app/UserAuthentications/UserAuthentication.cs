namespace mail.app.UserAuthentications
{
    public class UserAuthentication : IUserAuthentication
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserAuthentication()
        {
            var config = Program.Configuration();
            Username = config["userAuth:username"];
            Password = config["userAuth:password"];
        }
    }
}