using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio
{
    public partial class deslogueado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTN_IRLOGIN_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}