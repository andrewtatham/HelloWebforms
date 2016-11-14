using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWebforms
{
    public partial class _Default : Page
    {
        private DefaultController _controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            _controller = new DefaultController(this);
            Label1.Text = _controller.OnLoad();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = _controller.SessionInfo();
        }



    }
}