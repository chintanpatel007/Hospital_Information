using Hospital_Information;
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

public partial class AdminPanel_Hospital_HospitalAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            CommonFillMethods.fillDropDownListCity(ddlCity);
            CommonFillMethods.fillDropDownListSpeciality(ddlSpeciality);
            CommonFillMethods.fillCheckBoxListReport(chlReport);

            if(Request.QueryString["HospitalID"] == null)
            {

            }
            else
            {
                FillControls(Convert.ToInt32(Request.QueryString["HospitalID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load

    #region Button : Cancel
    protected void lbCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Hospital/HospitalList.aspx");
    }
    #endregion Button : Cancel

    #region FillControls
    private void FillControls(SqlInt32 HospitalID)
    {
        HospitalENT entHospital = new HospitalENT();
        HospitalBAL balHospital = new HospitalBAL();

        entHospital = balHospital.SelectByPK(HospitalID);

        if (!entHospital.HospitalName.IsNull)
        {
            txtHospitalName.Text = entHospital.HospitalName.Value.ToString();
        }
        if (!entHospital.Overview.IsNull)
        {
            txtOverview.Text = entHospital.Overview.Value.ToString();
        }
        if (!entHospital.Address.IsNull)
        {
            txtAddress.Text = entHospital.Address.Value.ToString();
        }
        if (!entHospital.Mobile.IsNull)
        {
            txtMobile.Text = entHospital.Mobile.Value.ToString();
        }
        if (!entHospital.Email.IsNull)
        {
            txtEmail.Text = entHospital.Email.Value.ToString();
        }

        if (!entHospital.CityID.IsNull)
        {
            ddlCity.SelectedValue = entHospital.CityID.Value.ToString();
        }
        if (!entHospital.SpecialityID.IsNull)
        {
            ddlSpeciality.SelectedValue = entHospital.SpecialityID.Value.ToString();
        }

        HospitalWiseReportBAL balHospitalWiseReportBAL = new HospitalWiseReportBAL();
        DataTable dtReport = new DataTable();

        dtReport = balHospitalWiseReportBAL.SelectByHospitalID(HospitalID);

        foreach (DataRow row in dtReport.Rows)
        {
            foreach (ListItem item in chlReport.Items)
            {
                if (item.Value == row["ReportID"].ToString().Trim())
                {
                    item.Selected = true;
                }
            }
        }
    }
    #endregion FillControls

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region server side validation
        String strErrorMessage = "";
        Int32 Count = 0;

        if (txtHospitalName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Hospital Name <br/>";
        }
        if (txtOverview.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Overview <br/>";
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
        if (ddlCity.SelectedIndex <= 0)
        {
            strErrorMessage += "- Select City <br/>";
        }
        if (ddlSpeciality.SelectedIndex <= 0)
        {
            strErrorMessage += "- Select Speciality <br/>";
        }

        foreach (ListItem item in chlReport.Items)
        {
            if (item.Selected == true)
            {
                Count++;
            }
        }

        if (Count == 0)
        {
            strErrorMessage = strErrorMessage + "- Please select at least one Report. <br/>";
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
        HospitalENT entHospital = new HospitalENT();

        if (txtHospitalName.Text.Trim() != "")
        {
            entHospital.HospitalName = txtHospitalName.Text.Trim();
        }
        if (txtOverview.Text.Trim() != "")
        {
            entHospital.Overview = txtOverview.Text.Trim();
        }
        if (txtAddress.Text.Trim() != "")
        {
            entHospital.Address = txtAddress.Text.Trim();
        }
        if (txtEmail.Text.Trim() != "")
        {
            entHospital.Email = txtEmail.Text.Trim();
        }
        if (txtMobile.Text.Trim() != "")
        {
            entHospital.Mobile = txtMobile.Text.Trim();
        }

        if (ddlCity.SelectedIndex > 0)
        {
            entHospital.CityID = Convert.ToInt32(ddlCity.SelectedValue.ToString().Trim());
        }
        if (ddlSpeciality.SelectedIndex > 0)
        {
            entHospital.SpecialityID = Convert.ToInt32(ddlSpeciality.SelectedValue.ToString().Trim());
        }

        #endregion Collect Form Data

        HospitalBAL balHospital = new HospitalBAL();
        HospitalWiseReportBAL balHospitalWiseReport = new HospitalWiseReportBAL();
        HospitalWiseReportENT entHospitalWiseReport = new HospitalWiseReportENT();

        if (Request.QueryString["HospitalID"] == null)
        {
            if(balHospital.Insert(entHospital))
            {
                entHospitalWiseReport.HospitalID = Convert.ToInt32(entHospital.HospitalID.Value);
                foreach (ListItem item in chlReport.Items)
                {
                    if (item.Selected == true)
                    {
                        entHospitalWiseReport.ReportID = Convert.ToInt32(item.Value.ToString().Trim());
                        if (!balHospitalWiseReport.Insert(entHospitalWiseReport))
                        {
                            lblErrorMessage.Text = balHospitalWiseReport.Message;
                        }
                    }
                }
                foreach (ListItem item in chlReport.Items) // uncheck Image category list
                {
                    if (item.Selected == true)
                    {
                        item.Selected = false;
                    }
                }
                
                ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Hospital Information inserted Successfully', showConfirmButton: false, timer: 2000});", true);

            }
            else
            {
                lblErrorMessage.Text = balHospital.Message;
            }
        }
        else
        {
            entHospital.HospitalID = Convert.ToInt32(Request.QueryString["HospitalID"]);

            if (balHospital.Update(entHospital))
            {
                if(balHospitalWiseReport.DeleteByHospitalID(Convert.ToInt32(Request.QueryString["HospitalID"])))
                {
                    entHospitalWiseReport.HospitalID = Convert.ToInt32(entHospital.HospitalID.Value);
                    foreach (ListItem item in chlReport.Items)
                    {
                        if (item.Selected == true)
                        {
                            entHospitalWiseReport.ReportID = Convert.ToInt32(item.Value.ToString().Trim());
                            if (!balHospitalWiseReport.Insert(entHospitalWiseReport))
                            {
                                lblErrorMessage.Text = balHospitalWiseReport.Message;
                            }
                        }
                    }
                    foreach (ListItem item in chlReport.Items) // uncheck Image category list
                    {
                        if (item.Selected == true)
                        {
                            item.Selected = false;
                        }
                    }

                    Response.Redirect("~/AdminPanel/Hospital/HospitalList.aspx");
                }
                else
                {
                    lblErrorMessage.Text = balHospitalWiseReport.Message;
                }
            }
            else
            {
                lblErrorMessage.Text = balHospital.Message;
            }
        }
    }
    #endregion Button : Save
}