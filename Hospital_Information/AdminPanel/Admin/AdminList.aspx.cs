using Hospital_Information.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Admin_AdminList : System.Web.UI.Page
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

        if (!Page.IsPostBack)
        {
            fillAdminGridview();

            if (Convert.ToBoolean(Application["CheckAdmin"]) == false && Convert.ToBoolean(Application["CheckDoctor"]) == true)
            {
                divAdminAddButton.Visible = false;
            }
            else
            {
                divAdminAddButton.Visible = true;
            }
        }
    }
    #endregion Page Load

    #region Fill Admin GridView
    public void fillAdminGridview()
    {
        AdminBAL balAdmin = new AdminBAL();
        DataTable dt = new DataTable();

        dt = balAdmin.SelectAll();

        if (dt != null && dt.Rows.Count > 0)
        {
            gvAdmin.DataSource = dt;
            gvAdmin.DataBind();
        }
    }
    #endregion Fill City GridView

    #region LinkButton : Admin ADD
    protected void lbAdminAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Admin/AdminAddEdit.aspx");
    }
    #endregion  LinkButton : Admin ADD

    #region gvAdmin RowDataBound
    protected void gvAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Convert.ToBoolean(Application["CheckAdmin"]) == false && Convert.ToBoolean(Application["CheckDoctor"]) == true)
        {
            e.Row.Cells[5].Visible = false;
        }
        else
        {
            e.Row.Cells[5].Visible = true;
        }
    }
    #endregion gvAdmin RowDataBound
}