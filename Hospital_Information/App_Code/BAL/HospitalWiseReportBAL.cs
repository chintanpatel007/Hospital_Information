using Hospital_Information.DAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalWiseReportBAL
/// </summary>
namespace Hospital_Information.BAL
{
    public class HospitalWiseReportBAL
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

        public HospitalWiseReportBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(HospitalWiseReportENT entHospitalWiseReport)
        {
            HospitalWiseReportDAL dalHospitalWiseReport = new HospitalWiseReportDAL();

            if(dalHospitalWiseReport.Insert(entHospitalWiseReport))
            {
                return true;
            }
            else
            {
                Message = dalHospitalWiseReport.Message;
                return false;
            }
        }
        #endregion Insert Opertaion

        #region DeleteByHospitalID
        public Boolean DeleteByHospitalID(SqlInt32 HospitalID)
        {
            HospitalWiseReportDAL dalHospitalWiseReport = new HospitalWiseReportDAL();

            if (dalHospitalWiseReport.DeleteByHospitalID(HospitalID))
            {
                return true;
            }
            else
            {
                Message = dalHospitalWiseReport.Message;
                return false;
            }
        }
        #endregion DeleteByHospitalID

        #region Select Opertaion

        #region SelectByHospitalID
        public DataTable SelectByHospitalID(SqlInt32 HospitalID)
        {
            HospitalWiseReportDAL dalHospitalWiseReport = new HospitalWiseReportDAL();
            return dalHospitalWiseReport.SelectByHospitalID(HospitalID);
        }
        #endregion SelectByHospitalID

        #endregion Select Opertaion
    }
}