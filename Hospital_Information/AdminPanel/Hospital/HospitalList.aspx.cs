using Hospital_Information.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Hospital_HospitalList : System.Web.UI.Page
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
            fillHospitalGridview();

            if (Convert.ToBoolean(Application["CheckAdmin"]) == false && Convert.ToBoolean(Application["CheckDoctor"]) == true)
            {
                divHospitalAddButton.Visible = false;
            }
            else
            {
                divHospitalAddButton.Visible = true;
            }
        }
    }
    #endregion Page Load

    #region fill Hospital Grid View 
    public void fillHospitalGridview()
    {
        HospitalBAL balHospital = new HospitalBAL();
        DataTable dt = new DataTable();

        dt = balHospital.SelectAll();

        gvHospital.DataSource = dt;
        gvHospital.DataBind();
    }
    #endregion fill Hospital Grid View

    #region gvHospital : RowCommand
    protected void gvHospital_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    #endregion gvHospital : RowCommand

    #region gvHospital : RowDataBound
    protected void gvHospital_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if(Convert.ToBoolean(Application["CheckAdmin"]) == false && Convert.ToBoolean(Application["CheckDoctor"]) == true)
            {
                LinkButton lbDelete = e.Row.FindControl("lbDelete") as LinkButton;
                HyperLink hlEdit = e.Row.FindControl("hlEdit") as HyperLink;
                lbDelete.Visible = false;
                hlEdit.Visible = false;
            }
        }
    }
    #endregion gvHospital : RowDataBound
}