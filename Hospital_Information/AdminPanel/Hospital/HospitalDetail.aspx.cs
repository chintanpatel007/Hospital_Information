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

public partial class AdminPanel_Hospital_HospitalDetail : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            fillHospitalDetails(Convert.ToInt32(Request.QueryString["HospitalID"]));
        }
    }
    #endregion Page Load

    #region fill Hospital Doctors
    public void fillHospitalDetails(SqlInt32 HospitalID)
    {
        HospitalBAL balHospital = new HospitalBAL();
        HospitalENT entHospital = new HospitalENT();

        entHospital = balHospital.SelectByPK(HospitalID);

        if (!entHospital.HospitalName.IsNull)
        {
            lblHospitalName.Text = entHospital.HospitalName.Value;
        }
        if (!entHospital.SpecialityID.IsNull)
        {
            SpecialityBAL balSpeciality = new SpecialityBAL();
            SpecialityENT entSpeciality = new SpecialityENT();

            entSpeciality = balSpeciality.SelectByPK(Convert.ToInt32(entHospital.SpecialityID.Value));

            lblSpeciality.Text = entSpeciality.SpecialityName.Value;
        }
        if (!entHospital.Overview.IsNull)
        {
            lblOverview.Text = entHospital.Overview.Value;
        }
        if (!entHospital.Address.IsNull)
        {
            hlAddress.Text = entHospital.Address.Value;
        }
        if (!entHospital.Email.IsNull)
        {
            hlEmail.NavigateUrl = "mailto:" + entHospital.Email.Value;
            hlEmail.Text = entHospital.Email.Value;
        }
        if (!entHospital.Mobile.IsNull)
        {
            hlMobile.NavigateUrl = "tel:" + entHospital.Mobile.Value;
            hlMobile.Text = entHospital.Mobile.Value;
        }

        HospitalWiseReportBAL balHospitalWiseReport = new HospitalWiseReportBAL();
        DataTable dtReport = new DataTable();

        dtReport = balHospitalWiseReport.SelectByHospitalID(HospitalID);

        rptReport.DataSource = dtReport;
        rptReport.DataBind();

        DoctorBAL balDoctorBAL = new DoctorBAL();
        DataTable dtDoctor = new DataTable();

        dtDoctor = balDoctorBAL.SelectByHospitalID(HospitalID);

        if(dtDoctor != null && dtDoctor.Rows.Count > 0)
        {
            rptDoctors.DataSource = dtDoctor;
            rptDoctors.DataBind();

            pnlNoDoctorFound.Visible = false;
        }
        else
        {
            pnlNoDoctorFound.Visible = true;
        }
    }
    #endregion fill Hospital Doctors

    #region Button : Back
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Hospital/HospitalList.aspx");
    }
    #endregion Button : Back

    #region Button : Doctor Add Page
    protected void lbDoctorAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Hospital/DoctorAddEdit.aspx?HospitalID=" + Request.QueryString["HospitalID"]);
    }
    #endregion Button : Doctor Add Page

    #region rptDoctors : ItemCommand
    protected void rptDoctors_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "doctorEdit();", true);
                Application["DoctorID"] = e.CommandArgument.ToString().Trim();



                //Response.Redirect("~/AdminPanel/Hospital/DoctorAddEdit.aspx?HospitalID=" + Request.QueryString["HospitalID"].ToString().Trim() + "&DoctorID=" + e.CommandArgument.ToString().Trim());
                //ViewState["CityEditActive"] = true;
                //ViewState["CityID"] = Convert.ToInt32(e.CommandArgument.ToString());
                //lblModalTitle.Text = "City Edit";

                //FillControls(Convert.ToInt32(e.CommandArgument.ToString()));
                
            }
        }
        if (e.CommandName == "DeleteRecord")
        {
            //if (e.CommandArgument != null)
            //{
            //    CityBAL balCity = new CityBAL();

            //    if (balCity.Delete(Convert.ToInt32(e.CommandArgument.ToString())))
            //    {
            //        fillCityGridview();
            //        ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'City Deleted Successfully', showConfirmButton: false, timer: 2000});", true);
            //    }
            //    else
            //    {
            //        lblErrorMessage.Text = balCity.Message;
            //    }
            //}
        }
    }
    #endregion  rptDoctors : ItemCommand

    protected void lbEditProfile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Hospital/DoctorAddEdit.aspx?HospitalID=" + Request.QueryString["HospitalID"].ToString().Trim() + "&DoctorID=" + Application["DoctorID"].ToString().Trim());
    }

    protected void lbEditUserName_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "editUserNameDoctor();", true);
    }

    protected void lbEditPassword_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "editPasswordDoctor();", true);
    }
}