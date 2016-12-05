using mail.app.Entities.UserAuthentications;
using Xunit;

namespace mail.test
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dotnet-core.html
    public class TestUserAuth
    {
        [Fact]
        public void PasswordNotEqualTest()
        {
            var password = "Passwordtest".ToLower();
            var userAuth = new UserAuthentication();
            Assert.NotEqual(password, userAuth.Password);
        }

        [Fact]
        public void USerNameNotEqualTest()
        {

            var username = "example@example".ToLower();
            var userAuth = new UserAuthentication();

            Assert.NotEqual(userAuth.Username.ToLower(), username);
        }
    }
}