using HelloWebforms.Helpers;

namespace HelloWebforms
{
    public interface IGetDebugInfo
    {
        NestedDictionary<string, string> GetDebugInfo();
    }
}