using System.Collections.Generic;
using System.Linq;
using System.Web.Providers.Entities;
using System.Web.UI;
using HelloWebforms.Controller;
using HelloWebforms.Helpers;

namespace HelloWebforms.Controller
{
    public class BaseController : IController
    {

        internal IControllerContext Context;


        public BaseController(IControllerContext context)
        {
            Context = context;
        }

        public BaseController(UserControl control)
        {
            Context = new ControllerContext(control);
        }
        public BaseController(Page page)
        {
            Context = new ControllerContext(page);
        }

        public NestedDictionary<string, string> GetDebugInfo()
        {
   
            return Context.GetDebugInfo(); ;
        }

        public string SessionID {
            get { return Context.Session.SessionId; }
        }

        public string OnLoad()
        {
            Context.Application.IncrementPageLoadCounter();
            Context.Session.SetUpdated();

            return Context?.GetDebugInfo()?.ToString(); 
        }
    }
}