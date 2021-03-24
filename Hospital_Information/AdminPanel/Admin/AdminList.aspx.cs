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
        if(!Page.IsPostBack)
        {
            fillAdminGridview();
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

    protected void lbAdminAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Admin/AdminAddEdit.aspx");
    }
}