using Hospital_Information;
using Hospital_Information.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_HospitalList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["CityID"] = ""; 
            ViewState["SpecialityID"] = "";
            fillHospitalRepeater(1);
            CommonFillMethods.fillCheckBoxListCity(chklCity);
            CommonFillMethods.fillCheckBoxListSpeciality(chklSpeciality);
        }
    }
    #endregion Page Load

    #region Page Size

    protected Int32 _PageSize = 3;

    public Int32 PageSize
    {
        get
        {
            return _PageSize;
        }
    }

    #endregion  Page Size

    #region chklCity : SelectedIndexChanged
    protected void chklCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CityID"] = "";
        foreach (ListItem item in chklCity.Items)
        {
            if (item.Selected)
            {
                ViewState["CityID"] = ViewState["CityID"] + item.Value + ",";
            }
        }
        fillHospitalRepeater(Convert.ToInt32(ViewState["CurrentPageIndex"]));
    }
    #endregion  chklCity : SelectedIndexChanged

    #region chklSpeciality : SelectedIndexChanged
    protected void chklSpeciality_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["SpecialityID"] = "";
        foreach (ListItem item in chklSpeciality.Items)
        {
            if (item.Selected)
            {
                ViewState["SpecialityID"] = ViewState["SpecialityID"] + item.Value + ",";
            }
        }
        fillHospitalRepeater(Convert.ToInt32(ViewState["CurrentPageIndex"]));
    }
    #endregion chklSpeciality : SelectedIndexChanged

    #region fill Hospital Repeater
    public void fillHospitalRepeater(Int32 PageIndex)
    {
        HospitalBAL balHospital = new HospitalBAL();
        DataTable dt = new DataTable();
        SqlString CityID, SpecialityID;
        int recordCount = 0;

        if (ViewState["CityID"].ToString() == "")
        {
            CityID = "";
        }
        else
        {
            CityID = ViewState["CityID"].ToString();
        }
        if(ViewState["SpecialityID"].ToString() == "")
        {
            SpecialityID = "";
        }
        else
        {
            SpecialityID = ViewState["SpecialityID"].ToString();
        }
        if (ViewState["CityID"].ToString() == "" && ViewState["SpecialityID"].ToString() == "")
        {
            CityID = null;
            SpecialityID = null;
        }

        dt = balHospital.SelectByCityIDSpecialityID(CityID, SpecialityID, PageIndex, PageSize);
        recordCount = balHospital.SelectByCityIDSpecialityIDRecordCount(CityID, SpecialityID);

        if (dt != null && dt.Rows.Count > 0)
        {
            rptHospital.DataSource = dt;
            rptHospital.DataBind();
            pnlHospitalList.Visible = true;
            pnlHospitalEmpty.Visible = false;
        }
        else
        {
            if(recordCount > 0)
            {
                fillHospitalRepeater(1);
                return;
            }
            else
            {
                pnlHospitalList.Visible = false;
                pnlHospitalEmpty.Visible = true;
            }
        }

        ViewState["CurrentPageIndex"] = PageIndex;
        PopulatePager(recordCount, PageIndex);
    }
    #endregion fill Hospital Repeater

    #region Paging 
    private void PopulatePager(Int32 recordCount, Int32 currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
        Int32 pageCount = (int)Math.Ceiling(dblPageCount);

        ViewState["pageCount"] = pageCount;

        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            for (int i = 1; i <= pageCount; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();

        foreach (RepeaterItem item in rptPager.Items) // Add active to class to current page
        {
            LinkButton lbPageNumbers = (LinkButton)item.FindControl("lbPages");
            if (Convert.ToInt32(lbPageNumbers.Text.ToString().Trim()) == currentPage)
            {
                lbPageNumbers.Enabled = false;
                lbPageNumbers.CssClass = lbPageNumbers.CssClass + "pagination-active";
            }
            else
            {
                lbPageNumbers.Enabled = true;
                lbPageNumbers.Attributes["class"] = "";
            }
        }

        if (currentPage == 1)
        {
            lbFirst.Enabled = false;
            lbPrevious.Enabled = false;
        }
        else
        {
            lbFirst.Enabled = true;
            lbPrevious.Enabled = true;
        }
        if (currentPage == pageCount)
        {
            lbNext.Enabled = false;
            lbLast.Enabled = false;
        }
        else
        {
            lbNext.Enabled = true;
            lbLast.Enabled = true;
        }
    }

    protected void rptPager_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "ChangePage")
        {
            if (e.CommandArgument != null)
            {
                fillHospitalRepeater(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }

    protected void lbFirst_Click(object sender, EventArgs e)
    {
        fillHospitalRepeater(1);
    }

    protected void lbPrevious_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ViewState["CurrentPageIndex"]) > 1)
        {
            fillHospitalRepeater(Convert.ToInt32(ViewState["CurrentPageIndex"]) - 1);
        }
    }

    protected void lbNext_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ViewState["pageCount"]) > Convert.ToInt32(ViewState["CurrentPageIndex"]))
        {
            fillHospitalRepeater(Convert.ToInt32(ViewState["CurrentPageIndex"]) + 1);
        }
    }

    protected void lbLast_Click(object sender, EventArgs e)
    {
        fillHospitalRepeater(Convert.ToInt32(ViewState["pageCount"]));
    }
    #endregion Paging
}