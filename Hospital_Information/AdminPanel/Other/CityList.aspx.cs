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

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillCityGridview();
            ViewState["CityEditActive"] = false;
        }
    }
    #endregion Page Load

    #region Fill City GridView
    public void fillCityGridview()
    {
        CityBAL balCity = new CityBAL();
        DataTable dt = new DataTable();

        dt = balCity.SelectAll();

        if (dt != null && dt.Rows.Count > 0)
        {
            gvCity.DataSource = dt;
            gvCity.DataBind();
        }
    }
    #endregion Fill City GridView

    #region gvCity : RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                ViewState["CityEditActive"] = true;
                ViewState["CityID"] = Convert.ToInt32(e.CommandArgument.ToString());
                lblModalTitle.Text = "City Edit";

                FillControls(Convert.ToInt32(e.CommandArgument.ToString()));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "cityAddEditModal();", true);
            }
        }
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CityBAL balCity = new CityBAL();

                if (balCity.Delete(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    fillCityGridview();
                    ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'City Deleted Successfully', showConfirmButton: false, timer: 2000});", true);
                }
                else
                {
                    lblErrorMessage.Text = balCity.Message;
                }
            }
        }
    }
    #endregion gvCity : RowCommand

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region server side validation
        String strErrorMessage = "";

        if (txtCity.Text.Trim() == "")
        {
            strErrorMessage += "- Enter City <br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        #endregion server side validation

        #region Collect Form Data
        CityENT entCity = new CityENT();

        if (txtCity.Text.Trim() != "")
        {
            entCity.CityName = txtCity.Text.Trim();
        }
        #endregion Collect Form Data

        CityBAL balCity = new CityBAL();

        if (Convert.ToBoolean(ViewState["CityEditActive"]) == false)
        {
            if (balCity.Insert(entCity))
            {
                fillCityGridview();
                ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'City Inserted Successfully', showConfirmButton: false, timer: 2000});", true);
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
            }
        }
        else
        {
            entCity.CityID = Convert.ToInt32(ViewState["CityID"]);
            if (balCity.Update(entCity))
            {
                fillCityGridview();
                ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'City Edited Successfully', showConfirmButton: false, timer: 2000});", true);
                ClearControls();
                ViewState["CityEditActive"] = false;
                lblModalTitle.Text = "City Add";
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
            }
        }
        
    }
    #endregion Button : Save

    #region FillControls
    private void FillControls(SqlInt32 CityID)
    {
        CityBAL balCity = new CityBAL();
        CityENT entCity = new CityENT();

        entCity = balCity.SelectByPK(CityID);

        if (!entCity.CityName.IsNull)
        {
            txtCity.Text = entCity.CityName.Value.ToString();
        }
    }
    #endregion FillControl

    #region Clear Controls

    private void ClearControls()
    {
        txtCity.Text = "";
    }

    #endregion Clear Controls
}