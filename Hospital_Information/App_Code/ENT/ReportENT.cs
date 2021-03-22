using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportENT
/// </summary>
namespace Hospital_Information.ENT
{
    public class ReportENT
    {
        #region Constructor

        public ReportENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

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

        #region ReportName

        protected SqlString _ReportName;

        public SqlString ReportName
        {
            get
            {
                return _ReportName;
            }
            set
            {
                _ReportName = value;
            }
        }

        #endregion ReportName
    }
}