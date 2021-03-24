using Hospital_Information.BAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Admin_AdminAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if (Request.QueryString["AdminID"] == null)
            {
                pnlLoginDetail.Visible = true;
            }
            else
            {
                pnlLoginDetail.Visible = false;
            }
        }
    }
    #endregion Page Load

    #region Button : Cancel
    protected void lbCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Admin/AdminList.aspx");
    }
    #endregion Button : Cancel

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region server side validation
        String strErrorMessage = "";

        if (txtAdminName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Admin Name <br/>";
        }
        if (txtAddress.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Address <br/>";
        }
        if (txtEmail.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Email <br/>";
        }
        if (txtMobile.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Mobile <br/>";
        }
        if (Request.QueryString["AdminID"] == null)
        {
            if (txtUserName.Text.Trim() == "")
            {
                strErrorMessage += "- Enter UserName <br/>";
            }
            if (txtPassword.Text.Trim() == "")
            {
                strErrorMessage += "- Enter Password <br/>";
            }
            if (txtReTypePassword.Text.Trim() == "")
            {
                strErrorMessage += "- Re-type Password <br/>";
            }

            if (txtPassword.Text.Trim() != txtReTypePassword.Text.Trim())
            {
                strErrorMessage += "- Password & Re-type Password must be Same.<br/>";
            }
        }
        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        else
        {
            lblErrorMessage.Text = "";
        }
        #endregion server side validation

        #region Collect Form Data
        AdminENT entAdmin = new AdminENT();
        String strLogicalPath = "~/UploadedData/Images/Admin/";
        String strPhysicalPath = "";

        if (txtAdminName.Text.Trim() != "")
        {
            entAdmin.AdminName = txtAdminName.Text.Trim();
        }
        if (txtAddress.Text.Trim() != "")
        {
            entAdmin.Address = txtAddress.Text.Trim();
        }
        if (txtEmail.Text.Trim() != "")
        {
            entAdmin.Email = txtEmail.Text.Trim();
        }
        if (txtMobile.Text.Trim() != "")
        {
            entAdmin.Mobile = txtMobile.Text.Trim();
        }

        if (fuAdminImage.HasFile)
        {
            strPhysicalPath = Server.MapPath(strLogicalPath) + fuAdminImage.FileName;

            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }

            fuAdminImage.SaveAs(strPhysicalPath);

            entAdmin.AdminImage = strLogicalPath + fuAdminImage.FileName;
        }
        else
        {
            entAdmin.AdminImage = "~/UploadedData/Images/Admin/avatar.png";
        }

        if (txtUserName.Text.Trim() != "")
        {
            entAdmin.UserName = txtUserName.Text.Trim();
        }
        if (txtPassword.Text.Trim() != "")
        {
            entAdmin.Password = txtPassword.Text.Trim();
        }
        #endregion Collect Form Data

        AdminBAL balAdmin = new AdminBAL();

        if(Request.QueryString["AdminID"] == null)
        {
            if(balAdmin.Insert(entAdmin))
            {
                ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Admin Inserted Successfully', showConfirmButton: false, timer: 2000});", true);
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balAdmin.Message;
            }
        }
        else
        {

        }
    }
    #endregion Button : Save

    #region Clear Controls
    private void ClearControls()
    {
        txtAdminName.Text = "";
        txtAddress.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtReTypePassword.Text = "";
    }
    #endregion Clear Controls
}