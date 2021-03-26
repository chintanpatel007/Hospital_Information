using Hospital_Information.BAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_DepartmentList : System.Web.UI.Page
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
            fillDepartmentGridview();
            ViewState["DepartmentEditActive"] = false;
        }
    }
    #endregion Page Load

    #region Fill Department GridView
    public void fillDepartmentGridview()
    {
        DepartmentBAL balDepartment = new DepartmentBAL();
        DataTable dt = new DataTable();

        dt = balDepartment.SelectAll();

        if (dt != null && dt.Rows.Count > 0)
        {
            gvDepartment.DataSource = dt;
            gvDepartment.DataBind();
        }
    }
    #endregion Fill Department GridView

    #region gvDepartment : RowCommand
    protected void gvDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                ViewState["DepartmentEditActive"] = true;
                ViewState["DepartmentID"] = Convert.ToInt32(e.CommandArgument.ToString());
                lblModalTitle.Text = "Department Edit";

                FillControls(Convert.ToInt32(e.CommandArgument.ToString()));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "departmentAddEditModal();", true);
            }
        }
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DepartmentBAL balDepartment = new DepartmentBAL();

                if (balDepartment.Delete(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    fillDepartmentGridview();
                    ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Department Deleted Successfully', showConfirmButton: false, timer: 2000});", true);
                }
                else
                {
                    lblErrorMessage.Text = balDepartment.Message;
                }
            }
        }
    }
    #endregion gvDepartment : RowCommand

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region server side validation
        String strErrorMessage = "";

        if (txtDepartment.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Department <br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        #endregion server side validation

        #region Collect Form Data
        DepartmentENT entDepartment = new DepartmentENT();

        if (txtDepartment.Text.Trim() != "")
        {
            entDepartment.DepartmentName = txtDepartment.Text.Trim();
        }
        #endregion Collect Form Data

        DepartmentBAL balDepartment = new DepartmentBAL();

        if (Convert.ToBoolean(ViewState["DepartmentEditActive"]) == false)
        {
            if (balDepartment.Insert(entDepartment))
            {
                fillDepartmentGridview();
                ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Department Inserted Successfully', showConfirmButton: false, timer: 2000});", true);
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balDepartment.Message;
            }
        }
        else
        {
            entDepartment.DepartmentID = Convert.ToInt32(ViewState["DepartmentID"]);
            if (balDepartment.Update(entDepartment))
            {
                fillDepartmentGridview();
                ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Department Edited Successfully', showConfirmButton: false, timer: 2000});", true);
                ClearControls();
                ViewState["DepartmentEditActive"] = false;
                lblModalTitle.Text = "Department Add";
            }
            else
            {
                lblErrorMessage.Text = balDepartment.Message;
            }
        }

    }
    #endregion Button : Save

    #region FillControls
    private void FillControls(SqlInt32 DepartmentID)
    {
        DepartmentBAL balDepartment = new DepartmentBAL();
        DepartmentENT entDepartment = new DepartmentENT();

        entDepartment = balDepartment.SelectByPK(DepartmentID);

        if (!entDepartment.DepartmentName.IsNull)
        {
            txtDepartment.Text = entDepartment.DepartmentName.Value.ToString();
        }
    }
    #endregion FillControl

    #region Clear Controls

    private void ClearControls()
    {
        txtDepartment.Text = "";
    }

    #endregion Clear Controls
}