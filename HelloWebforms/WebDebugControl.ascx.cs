using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWebforms
{
    public partial class WebDebugControl : System.Web.UI.UserControl
    {
        public IWebDebugControlController Controller;

        public void InitController(IWebDebugControlController controller = null)
        {
            if (Controller == null)
            {
                Controller = controller ?? new WebDebugControlController(this);
            }
        }

        public void Page_Load(object sender, EventArgs e)
        {
            InitController();


            //var text = BaseController.GetDebugInfo().ToString();


            // ASP.NET code-behind
            var text = Controller.SessionID;
            codeBehindLabel.Text = text;
            codeBehindLiteral.Text = text;

            //ASP.NET Databinding 
            Page.DataBind();
        }
    }
}