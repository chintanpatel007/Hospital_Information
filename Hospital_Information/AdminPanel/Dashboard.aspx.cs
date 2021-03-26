using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Dashboard : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Authentication/CheckUser.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
        #endregion Check Valid User
    }
    #endregion Page Load
}