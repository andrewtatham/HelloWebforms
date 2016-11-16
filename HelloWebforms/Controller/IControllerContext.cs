namespace HelloWebforms.Controller
{
    public interface IControllerContext : IGetDebugInfo
    {
        ISessionWrapper Session { get; set; }
        IApplicationWrapper Application { get; set; }
        IRequestWrapper Request { get; set; }
        IResponseWrapper Response { get; set; }
    }
}