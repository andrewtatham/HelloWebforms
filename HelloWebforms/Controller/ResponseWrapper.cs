using System.Web;
using HelloWebforms.Helpers;

namespace HelloWebforms
{
    public class ResponseWrapper : IResponseWrapper
    {
        private readonly HttpResponse _response;

        public ResponseWrapper(HttpResponse response)
        {
            _response = response;
        }

        public NestedDictionary<string, string> GetDebugInfo()
        {
            var retval = new NestedDictionary<string, string>();
            retval["Status"].Value = _response.Status;
            retval["StatusCode"].Value = _response.StatusCode.ToString();
            retval["StatusDescription"].Value = _response.StatusDescription;
            retval["ContentType"].Value = _response.ContentType;
            retval["RedirectLocation"].Value = _response.RedirectLocation;
            return retval;
        }
    }
}