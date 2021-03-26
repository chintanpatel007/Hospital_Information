using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Authentication_CheckUser : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Application["CheckAdmin"] = false;
            Application["CheckDoctor"] = false;
        }
    }
    #endregion Page Load

    #region LinkButton : Admin
    protected void lbAdmin_Click(object sender, EventArgs e)
    {
        Application["CheckAdmin"] = true;
        Application["CheckDoctor"] = false;
        if(Request.QueryString["url"] == null)
        {
            Response.Redirect("~/AdminPanel/Authentication/Login.aspx?user=admin");
        }
        else
        {
            Response.Redirect("~/AdminPanel/Authentication/Login.aspx?user=admin&url=" + Server.UrlEncode(Request.QueryString["url"]));
        }
    }
    #endregion LinkButton : Admin

    #region LinkButton : Doctor
    protected void lbDoctor_Click(object sender, EventArgs e)
    {
        Application["CheckAdmin"] = false;
        Application["CheckDoctor"] = true;
        if (Request.QueryString["url"] == null)
        {
            Response.Redirect("~/AdminPanel/Authentication/Login.aspx?user=doctor");
        }
        else
        {
            Response.Redirect("~/AdminPanel/Authentication/Login.aspx?user=doctor&url=" + Server.UrlEncode(Request.QueryString["url"]));
        }
    }
    #endregion LinkButton : Doctor
}