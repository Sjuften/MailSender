﻿using System;
using System.IO;
using System.Linq;
using mail.app.Models.ServerSettings;
using mail.app.Models.UserAuthentications;
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
            var user = new UserAuthentication();
            var settings = new ServerSetting();
            var service = new MimeService(settings, user);
            service.Send(Dummy.Mail());
            Console.WriteLine("Email send to: " + Dummy.Mail().Recievers.FirstOrDefault());

        }
    }
}