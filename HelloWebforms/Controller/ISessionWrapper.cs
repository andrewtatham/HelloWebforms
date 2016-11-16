namespace HelloWebforms
{
    public interface ISessionWrapper : IGetDebugInfo
    {
        void SetUpdated();
        string SessionId { get; }
    }
}