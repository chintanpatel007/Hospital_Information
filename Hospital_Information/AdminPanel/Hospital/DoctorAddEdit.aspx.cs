using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Hospital_DoctorAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Button : Cancel
    protected void lbCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Hospital/HospitalDetail.aspx?HospitalID=" + Request.QueryString["HospitalID"]);
    }
    #endregion Button : Cancel
}