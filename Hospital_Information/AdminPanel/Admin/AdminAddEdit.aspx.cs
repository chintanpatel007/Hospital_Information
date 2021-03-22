using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Admin_AdminAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Page Load

    #region Button : Cancel
    protected void lbCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Admin/AdminList.aspx");
    }
    #endregion Button : Cancel
}