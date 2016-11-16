using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using HelloWebforms.Helpers;

namespace HelloWebforms.Controller
{
    public class ControllerContext : IControllerContext
    {
        public ISessionWrapper Session { get; set; }
        public IApplicationWrapper Application { get; set; }
        public IRequestWrapper Request { get; set; }
        public IResponseWrapper Response { get; set; }


        public ControllerContext(
            ISessionWrapper session,
            IApplicationWrapper application,
            IRequestWrapper request,
            IResponseWrapper response)
        {
            Session = session;
            Application = application;
            Request = request;
            Response = response;
        }


        public ControllerContext(UserControl control)
        {

            Session = new SessionWrapper(control.Session);
            Application = new ApplicationWrapper(control.Application);
            Request = new RequestWrapper(control.Request);
            Response = new ResponseWrapper(control.Response);

        }
        public ControllerContext(Page page)
        {

            Session = new SessionWrapper(page.Session);
            Application = new ApplicationWrapper(page.Application);
            Request = new RequestWrapper(page.Request);
            Response = new ResponseWrapper(page.Response);

        }
        public NestedDictionary<string, string> GetDebugInfo()
        {
    

            var retval = new NestedDictionary<string, string>();
            retval["Application"] = Application.GetDebugInfo();
            retval["Session"] = Session.GetDebugInfo();
            retval["Request"] = Request.GetDebugInfo();
            retval["Response"] = Response.GetDebugInfo();
            return retval;
        }

    }

}