using System.Collections.Generic;
using System.Web;
using HelloWebforms.Helpers;
using Newtonsoft.Json;

namespace HelloWebforms
{
    public class ApplicationWrapper : IApplicationWrapper
    {
        private readonly HttpApplicationState _application;

        public ApplicationWrapper(HttpApplicationState application)
        {
            _application = application;

        }

        public void IncrementPageLoadCounter()
        {
            _application.Lock();
            _application["PageRequestCount"] =
                ((int)_application["PageRequestCount"]) + 1;
            _application.UnLock();
        }


        public NestedDictionary<string, string> GetDebugInfo()
        {


            var retval = new NestedDictionary<string, string>();
            retval["Contents"] = _application.GetDebugInfo();
            return retval;
        }
    
    }
}