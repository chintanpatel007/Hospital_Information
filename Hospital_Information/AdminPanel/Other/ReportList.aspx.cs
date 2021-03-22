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

public partial class AdminPanel_Other_ReportList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            fillGridViewReport();
            ViewState["ReportEditActive"] = false;
        }
    }
    #endregion Page Load

    #region fill Gridview Report
    public void fillGridViewReport()
    {
        ReportBAL balReport = new ReportBAL();
        DataTable dt = new DataTable();

        dt = balReport.SelectAll();

        gvReport.DataSource = dt;
        gvReport.DataBind();
    }
    #endregion fill Gridview Report

    #region gvReport : RowCommand
    protected void gvReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                ViewState["ReportEditActive"] = true;
                ViewState["ReportID"] = Convert.ToInt32(e.CommandArgument.ToString());
                lblModalTitle.Text = "Report Edit";

                FillControls(Convert.ToInt32(e.CommandArgument.ToString()));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "reportAddEditModal();", true);
            }
        }
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ReportBAL balReport = new ReportBAL();

                if (balReport.Delete(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    fillGridViewReport();
                    ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Report Deleted Successfully', showConfirmButton: false, timer: 2000});", true);
                }
                else
                {
                    lblErrorMessage.Text = balReport.Message;
                }
            }
        }
    }
    #endregion gvReport : RowCommand

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region server side validation
        String strErrorMessage = "";

        if (txtReport.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Report <br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        #endregion server side validation

        #region Collect Form Data
        ReportENT entReport = new ReportENT();

        if (txtReport.Text.Trim() != "")
        {
            entReport.ReportName = txtReport.Text.Trim();
        }
        #endregion Collect Form Data

        ReportBAL balReport = new ReportBAL();

        if (Convert.ToBoolean(ViewState["ReportEditActive"]) == false)
        {
            if (balReport.Insert(entReport))
            {
                fillGridViewReport();
                ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'City Inserted Successfully', showConfirmButton: false, timer: 2000});", true);
                ClearControls();
            }
            else
            {
                lblErrorMessage.Text = balReport.Message;
            }
        }
        else
        {
            entReport.ReportID = Convert.ToInt32(ViewState["ReportID"]);
            if (balReport.Update(entReport))
            {
                fillGridViewReport();
                ClientScript.RegisterStartupScript(GetType(), "SweetAlert", "swal({ type: 'success', title: 'Report Edited Successfully', showConfirmButton: false, timer: 2000});", true);
                ClearControls();
                ViewState["ReportEditActive"] = false;
                lblModalTitle.Text = "Report Add";
            }
            else
            {
                lblErrorMessage.Text = balReport.Message;
            }
        }
    }
    #endregion Button : Save

    #region FillControls
    private void FillControls(SqlInt32 ReportID)
    {
        ReportBAL balReport = new ReportBAL();
        ReportENT entReport = new ReportENT();

        entReport = balReport.SelectByPK(ReportID);

        if (!entReport.ReportName.IsNull)
        {
            txtReport.Text = entReport.ReportName.Value.ToString();
        }
    }
    #endregion FillControl

    #region Clear Controls

    private void ClearControls()
    {
        txtReport.Text = "";
    }

    #endregion Clear Controls
}