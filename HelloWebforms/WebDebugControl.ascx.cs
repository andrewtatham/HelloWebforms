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
        private WebDebugControlController _controller;



        protected void Page_Load(object sender, EventArgs e)
        {
            _controller = new WebDebugControlController(this);
           Label1.Text = _controller.GetDebugInfo().ToString();

        
        }
    }
}