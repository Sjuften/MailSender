namespace mail.app.Entities.ServerSettings
{
    public interface IServerSetting
    {
        string Url { get; set; }
        int Port { get; set; }
    }
}