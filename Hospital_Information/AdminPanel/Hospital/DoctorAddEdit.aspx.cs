using Hospital_Information;
using Hospital_Information.BAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Hospital_DoctorAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            CommonFillMethods.fillDropDownListDepartment(ddlDepartment);

            if(Request.QueryString["HospitalID"] == null)
            {
                Response.Redirect("~/AdminPanel/Hospital/HospitalList.aspx");
            }
            else
            {
                if (Request.QueryString["DoctorID"] == null)
                {
                    pnlLoginDetail.Visible = true;
                }
                else
                {
                    pnlLoginDetail.Visible = false;
                }
            }
        }
    }

    #region Button : Cancel
    protected void lbCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Hospital/HospitalDetail.aspx?HospitalID=" + Request.QueryString["HospitalID"]);
    }
    #endregion Button : Cancel

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region server side validation
        String strErrorMessage = "";

        if (txtDoctorName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Doctor Name <br/>";
        }
        if (ddlDepartment.SelectedIndex <= 0)
        {
            strErrorMessage += "- Select Department <br/>";
        }
        if (txtExperince.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Experence (In year) <br/>";
        }
        if (Request.QueryString["DoctorID"] == null)
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
        DoctorENT entDoctor = new DoctorENT();
        String strLogicalPath = "~/UploadedData/Images/Doctors/";
        String strPhysicalPath = "";

        if (txtDoctorName.Text.Trim() != "")
        {
            entDoctor.DoctorName = txtDoctorName.Text.Trim();
        }
        if (txtExperince.Text.Trim() != "")
        {
            entDoctor.Experince = Convert.ToInt32(txtExperince.Text.ToString().Trim());
        }

        if (ddlDepartment.SelectedIndex > 0)
        {
            entDoctor.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue.ToString().Trim());
        }

        if (fuDoctorImage.HasFile)
        {
            strPhysicalPath = Server.MapPath(strLogicalPath) + fuDoctorImage.FileName;

            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }

            fuDoctorImage.SaveAs(strPhysicalPath);

            entDoctor.DoctorImage = strLogicalPath + fuDoctorImage.FileName;
        }
        else
        {
            entDoctor.DoctorImage = "~/UploadedData/Images/Doctors/avatar5.png";
        }

        if (txtUserName.Text.Trim() != "")
        {
            entDoctor.UserName = txtUserName.Text.Trim();
        }
        if (txtPassword.Text.Trim() != "")
        {
            entDoctor.Password = txtPassword.Text.Trim();
        }

        HospitalWiseDoctorENT entHospitalWiseDoctor = new HospitalWiseDoctorENT();

        entHospitalWiseDoctor.HospitalID = Convert.ToInt32(Request.QueryString["HospitalID"].ToString().Trim());

        #endregion Collect Form Data

        DoctorBAL balDoctor = new DoctorBAL();
        HospitalWiseDoctorBAL balHospitalWiseDoctor = new HospitalWiseDoctorBAL();

        if (Request.QueryString["DoctorID"] == null)
        {
            if(balDoctor.Insert(entDoctor))
            {
                entHospitalWiseDoctor.DoctorID = entDoctor.DoctorID;
                if(balHospitalWiseDoctor.Insert(entHospitalWiseDoctor))
                {
                    ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Doctor Inserted Successfully', showConfirmButton: false, timer: 2000});", true);
                    ClearControls();
                }
                else
                {
                    lblErrorMessage.Text = balHospitalWiseDoctor.Message;
                }
            }
            else
            {
                lblErrorMessage.Text = balDoctor.Message;
            }
        }

    }
    #endregion Button : Save

    #region Clear Controls
    private void ClearControls()
    {
        txtDoctorName.Text = "";
        txtExperince.Text = "";
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtReTypePassword.Text = "";
    }
    #endregion Clear Controls
}