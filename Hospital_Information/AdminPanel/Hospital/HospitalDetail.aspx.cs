using Hospital_Information.BAL;
using System;
using System.Collections.Generic;
using System.Data;
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
            fillHospitalDetail();
        }
    }
    #endregion Page Load

    #region fill Hospital Detail
    public void fillHospitalDetail()
    {
        DoctorBAL balDoctorBAL = new DoctorBAL();
        DataTable dtDoctor = new DataTable();

        dtDoctor = balDoctorBAL.SelectByHospitalID(Convert.ToInt32(Request.QueryString["HospitalID"]));

        if(dtDoctor != null && dtDoctor.Rows.Count > 0)
        {
            rptDoctors.DataSource = dtDoctor;
            rptDoctors.DataBind();
        }
    }
    #endregion fill Hospital Detail

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
                Response.Redirect("~/AdminPanel/Hospital/DoctorAddEdit.aspx?HospitalID=" + Request.QueryString["HospitalID"].ToString().Trim() + "&DoctorID=" + e.CommandArgument.ToString().Trim());
                //ViewState["CityEditActive"] = true;
                //ViewState["CityID"] = Convert.ToInt32(e.CommandArgument.ToString());
                //lblModalTitle.Text = "City Edit";

                //FillControls(Convert.ToInt32(e.CommandArgument.ToString()));

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "cityAddEditModal();", true);
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
}