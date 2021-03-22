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
        if(!Page.IsPostBack)
        {
            fillHospitalGridview();
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
}