using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalWiseReportENT
/// </summary>
namespace Hospital_Information.ENT
{
    public class HospitalWiseReportENT
    {
        #region Constructor

        public HospitalWiseReportENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region HospitalWiseReportID

        protected SqlInt32 _HospitalWiseReportID;

        public SqlInt32 HospitalWiseReportID
        {
            get
            {
                return _HospitalWiseReportID;
            }
            set
            {
                _HospitalWiseReportID = value;
            }
        }

        #endregion HospitalWiseReportID

        #region HospitalID

        protected SqlInt32 _HospitalID;

        public SqlInt32 HospitalID
        {
            get
            {
                return _HospitalID;
            }
            set
            {
                _HospitalID = value;
            }
        }

        #endregion HospitalID

        #region ReportID

        protected SqlInt32 _ReportID;

        public SqlInt32 ReportID
        {
            get
            {
                return _ReportID;
            }
            set
            {
                _ReportID = value;
            }
        }

        #endregion ReportID
    }
}