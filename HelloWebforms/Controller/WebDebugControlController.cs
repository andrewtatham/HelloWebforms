using System.Collections.Generic;
using System.Threading;
using System.Web.UI;
using HelloWebforms.Helpers;

namespace HelloWebforms
{
    public class WebDebugControlController : Controller
    {
        public WebDebugControlController(UserControl control) : base(control)
        {

        }

        public NestedDictionary<string, string> GetDebugInfo()
        {
            Application.IncrementPageLoadCounter();
            Session.SetUpdated();

            var retval = new NestedDictionary<string, string>();
            retval["Application"] = Application.GetDebugInfo();
            retval["Session"] = Session.GetDebugInfo();
            retval["Request"] = Request.GetDebugInfo();
            retval["Response"] = Response.GetDebugInfo();
            return retval;
        }

    }
}