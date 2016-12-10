namespace mail.app.ServerSettings
{
    public interface IServerSetting
    {
        string Url { get; set; }
        int Port { get; set; }
    }
}