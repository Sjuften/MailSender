using System;

namespace mail.app.Models.ServerSettings
{
    public class ServerSetting :IServerSetting
    {
        public string Url { get; set; }
        public int Port { get; set; }

        public ServerSetting()
        {
            var config = Program.Configuration();
            Url = config["serverSettings:url"];
            Port = Convert.ToInt32(config["serverSettings:port"]);
        }
    }
}