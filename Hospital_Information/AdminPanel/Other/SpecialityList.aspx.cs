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

public partial class AdminPanel_Other_SpecialityList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            fillGridviewSpeciality();
            ViewState["SpecialityEditActive"] = false;
        }
    }
    #endregion Page Load

    #region fill Gridview Speciality
    public void fillGridviewSpeciality()
    {
        SpecialityBAL balSpeciality = new SpecialityBAL();
        DataTable dt = new DataTable();

        dt = balSpeciality.SelectAll();

        gvSpeciality.DataSource = dt;
        gvSpeciality.DataBind();
    }
    #endregion fill Gridview Speciality

    #region gvSpeciality : RowCommand
    protected void gvSpeciality_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                ViewState["SpecialityEditActive"] = true;
                ViewState["SpecialityID"] = Convert.ToInt32(e.CommandArgument.ToString());
                lblModalTitle.Text = "Speciality Edit";

                FillControls(Convert.ToInt32(e.CommandArgument.ToString()));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "specialityAddEditModal();", true);
            }
        }
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                SpecialityBAL balSpeciality = new SpecialityBAL();

                if (balSpeciality.Delete(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    fillGridviewSpeciality();
                    ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Speciality Deleted Successfully', showConfirmButton: false, timer: 2000});", true);
                }
                else
                {
                    lblErrorMessage.Text = balSpeciality.Message;
                }
            }
        }
    }
    #endregion gvSpeciality : RowCommand

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region server side validation
        String strErrorMessage = "";

        if (txtSpeciality.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Speciality <br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        #endregion server side validation

        #region Collect Form Data
        SpecialityENT entSpeciality = new SpecialityENT();

        if (txtSpeciality.Text.Trim() != "")
        {
            entSpeciality.SpecialityName = txtSpeciality.Text.Trim();
        }
        #endregion Collect Form Data

        SpecialityBAL balSpeciality = new SpecialityBAL();

        if (Convert.ToBoolean(ViewState["SpecialityEditActive"]) == false)
        {
            if (balSpeciality.Insert(entSpeciality))
            {
                fillGridviewSpeciality();
                ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Speciality Inserted Successfully', showConfirmButton: false, timer: 2000});", true);
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balSpeciality.Message;
            }
        }
        else
        {
            entSpeciality.SpecialityID = Convert.ToInt32(ViewState["SpecialityID"]);
            if (balSpeciality.Update(entSpeciality))
            {
                fillGridviewSpeciality();
                ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Speciality Edited Successfully', showConfirmButton: false, timer: 2000});", true);
                ClearControls();
                ViewState["SpecialityEditActive"] = false;
                lblModalTitle.Text = "Speciality Add";
            }
            else
            {
                lblErrorMessage.Text = balSpeciality.Message;
            }
        }

    }
    #endregion Button : Save

    #region FillControls
    private void FillControls(SqlInt32 SpecialityID)
    {
        SpecialityBAL balSpeciality = new SpecialityBAL();
        SpecialityENT entSpeciality = new SpecialityENT();

        entSpeciality = balSpeciality.SelectByPK(SpecialityID);

        if (!entSpeciality.SpecialityName.IsNull)
        {
            txtSpeciality.Text = entSpeciality.SpecialityName.Value.ToString();
        }
    }
    #endregion FillControl

    #region Clear Controls

    private void ClearControls()
    {
        txtSpeciality.Text = "";
    }

    #endregion Clear Controls
}