using System.Web;
using System.Web.Providers.Entities;
using HelloWebforms.Helpers;

namespace HelloWebforms
{
    public class RequestWrapper
    {
        private readonly HttpRequest _request;

        public RequestWrapper(HttpRequest request)
        {
            _request = request;
        }



        public NestedDictionary<string, string> GetDebugInfo()
        {
            var retval = new NestedDictionary<string, string>();
            retval["QueryString"].Value = _request.QueryString.ToString();
            retval["Browser"].Value = _request.Browser.Browser;
            retval["Request"].Value = _request.RequestType;
            return retval;
        }

    }
}