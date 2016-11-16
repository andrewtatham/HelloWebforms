namespace HelloWebforms
{
    public interface IApplicationWrapper : IGetDebugInfo
    {
        void IncrementPageLoadCounter();
    }
}