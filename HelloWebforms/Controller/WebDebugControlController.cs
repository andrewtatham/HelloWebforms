using System.Collections.Generic;
using System.Threading;
using System.Web.UI;
using HelloWebforms.Controller;
using HelloWebforms.Helpers;

namespace HelloWebforms
{
    public class WebDebugControlController : BaseController, IWebDebugControlController
    {
        public WebDebugControlController(UserControl control) : base(control)
        {

        }
        public WebDebugControlController(IControllerContext context) : base(context)
        {
        }
    }
}