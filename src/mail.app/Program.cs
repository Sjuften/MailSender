using System.IO;
using mail.app.Entities.ServerSettings;
using mail.app.Entities.UserAuthentications;
using mail.app.Services.Mail.MimeService;
using Microsoft.Extensions.Configuration;

namespace mail.app
{
    public class Program
    {
        public static IConfiguration Configuration()
            =>
            new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        public static void Main(string[] args)
        {
            var emailsPath = Path.Combine(Directory.GetCurrentDirectory(), "emails");
            var emails = File.OpenText(emailsPath);
//            foreach (var email in emails)
//            {
//
//            }
            var user = new UserAuthentication();
            var settings = new ServerSetting();
            var service = new MimeService(settings, user);
            service.Send(Dummy.Mail());
        }
    }
}