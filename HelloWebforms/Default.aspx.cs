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
        public IDefaultController Controller;

        public void Page_Load(object sender, EventArgs e)
        {
            InitController();

            Label1.Text = Controller.OnLoad();
        }

        public void InitController(IDefaultController controller = null)
        {
            if (Controller == null)
            {
                Controller = controller ?? new DefaultController(this);
            }
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            InitController();

            Label1.Text = Controller.GetDebugInfo().ToString();
        }



    }
}