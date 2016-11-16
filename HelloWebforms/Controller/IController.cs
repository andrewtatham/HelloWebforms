namespace HelloWebforms
{
    public interface IController : IGetDebugInfo
    {
        string SessionID { get; }

        string OnLoad();

    }
}