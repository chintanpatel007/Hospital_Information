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

public partial class FrontPanel_HospitalDetail : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if (Request.QueryString["HospitalID"] == null)
            {
                Response.Redirect("~/FrontPanel/HospitalList.aspx");
            }
            else
            {
                fillHospitalDetails(Convert.ToInt32(Request.QueryString["HospitalID"]));
            }
        }
    }
    #endregion Page Load

    #region fill Hospital Detail
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

        if (dtDoctor != null && dtDoctor.Rows.Count > 0)
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
    #endregion fill Hospital Detail
}