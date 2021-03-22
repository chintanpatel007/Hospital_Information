﻿using Hospital_Information.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
namespace Hospital_Information
{
    public class CommonFillMethods
    {
        #region Constructor

        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Fill DropDownList City -- Hospital Add/Edit
        public static void fillDropDownListCity(DropDownList ddl)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectForDropDownList();
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        #endregion Fill DropDownList City

        #region Fill DropDownList Speciality -- Hospital Add/Edit
        public static void fillDropDownListSpeciality(DropDownList ddl)
        {
            SpecialityBAL balSpeciality = new SpecialityBAL();
            ddl.DataSource = balSpeciality.SelectForDropDownList();
            ddl.DataValueField = "SpecialityID";
            ddl.DataTextField = "SpecialityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Speciality", "-1"));
        }
        #endregion Fill DropDownList Speciality

        #region Fill CheckBoxList Report -- Hospital Add/Edit
        public static void fillCheckBoxListReport(CheckBoxList Report)
        {
            ReportBAL balReport = new ReportBAL();
            Report.DataSource = balReport.SelectSelectForDropDownList();
            Report.DataValueField = "ReportID";
            Report.DataTextField = "ReportName";
            Report.DataBind();
        }
        #endregion Fill DropDownList Speciality
    }
}