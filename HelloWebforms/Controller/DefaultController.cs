using System.Web.UI;
using HelloWebforms.Controller;

namespace HelloWebforms
{
    public class DefaultController : BaseController, IDefaultController
    {
        public DefaultController(_Default page) : base(page)
        {
        }
        public DefaultController(IControllerContext context) : base(context)
        {
        }
    }
}