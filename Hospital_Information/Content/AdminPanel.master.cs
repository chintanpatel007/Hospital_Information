using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_AdminPanel : System.Web.UI.MasterPage
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if (Session["UserName"] != null)
            {
                lblUserName.Text = "Hi  " + Session["UserName"].ToString().Trim() + ",";
            }

            if (Session["UserImage"] != null)
            {
                imgUserImageOne.ImageUrl = Session["UserImage"].ToString().Trim();
                imgUserImageTwo.ImageUrl = Session["UserImage"].ToString().Trim();
            }

            if (Convert.ToBoolean(Application["CheckAdmin"]) == true && (Convert.ToBoolean(Application["CheckDoctor"]) == false))
            {
                lblUserTitle.Text = "Admin";
                hospitalAddLink.Visible = true;
            }
            else
            {
                lblUserTitle.Text = Session["DepartmentName"].ToString().Trim();
                hospitalAddLink.Visible = false;
            }
        }
    }
    #endregion Page Load

    #region LinkButton : Logout
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Application["CheckAdmin"] = false;
        Application["CheckDoctor"] = false;
        Session.Clear();
        Response.Redirect("~/AdminPanel/Authentication/CheckUser.aspx");
    }
    #endregion LinkButton : Logout
}
