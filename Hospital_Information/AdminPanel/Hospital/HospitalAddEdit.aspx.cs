using Hospital_Information;
using System;
using System.Collections.Generic;
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
        }
    }
    #endregion Page Load

    #region Button : Cancel
    protected void lbCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Hospital/HospitalList.aspx");
    }
    #endregion Button : Cancel
}