namespace mail.app.Entities.ServerSettings
{
    public class ServerSetting :IServerSetting
    {
        public string Url { get; set; }
        public int Port { get; set; }
    }
}