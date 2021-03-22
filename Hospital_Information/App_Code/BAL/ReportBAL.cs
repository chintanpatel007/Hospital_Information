using Hospital_Information.DAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportBAL
/// </summary>
namespace Hospital_Information.BAL
{
    public class ReportBAL
    {
        #region Local Variables

        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Local Variables

        #region Constructor

        public ReportBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(ReportENT entReport)
        {
            ReportDAL dalReport = new ReportDAL();

            if(dalReport.Insert(entReport))
            {
                return true;
            }
            else
            {
                Message = dalReport.Message;
                return false;
            }
        }
        #endregion Insert Opertaion

        #region Update Opertaion
        public Boolean Update(ReportENT entReport)
        {
            ReportDAL dalReport = new ReportDAL();

            if (dalReport.Update(entReport))
            {
                return true;
            }
            else
            {
                Message = dalReport.Message;
                return false;
            }
        }
        #endregion Update Opertaion

        #region Delete Opertaion
        public Boolean Delete(SqlInt32 ReportID)
        {
            ReportDAL dalReport = new ReportDAL();

            if (dalReport.Delete(ReportID))
            {
                return true;
            }
            else
            {
                Message = dalReport.Message;
                return false;
            }
        }
        #endregion Delete Opertaion

        #region Select Opertaion

        #region SelectAll
        public DataTable SelectAll()
        {
            ReportDAL dalReport = new ReportDAL();
            return dalReport.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectSelectForDropDownList()
        {
            ReportDAL dalReport = new ReportDAL();
            return dalReport.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public ReportENT SelectByPK(SqlInt32 ReportID)
        {
            ReportDAL dalReport = new ReportDAL();
            return dalReport.SelectByPK(ReportID);
        }
        #endregion SelectByPK

        #endregion Select Opertaion

    }
}