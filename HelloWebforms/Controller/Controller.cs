using System.Collections.Generic;
using System.Linq;
using System.Web.Providers.Entities;
using System.Web.UI;

namespace HelloWebforms
{
    public class Controller
    {
        internal Page Page;
        internal UserControl Control;
        internal SessionWrapper Session;
        internal ApplicationWrapper Application;
        internal RequestWrapper Request;
        internal ResponseWrapper Response;



        public Controller(UserControl control)
        {
            Control = control;
            Session = new SessionWrapper(Control.Session);
            Application = new ApplicationWrapper(Control.Application);
            Request = new RequestWrapper(Control.Request);
            Response = new ResponseWrapper(Control.Response);

        }
        public Controller(Page page)
        {
            Page = page;
            Session = new SessionWrapper(Page.Session);
            Application = new ApplicationWrapper(Page.Application);
            Request = new RequestWrapper(Page.Request);
            Response = new ResponseWrapper(Page.Response);

        }

        public virtual string OnLoad()
        {
            return null;
        }

        public virtual string SessionInfo()
        {
            return null;

        }
    }
}