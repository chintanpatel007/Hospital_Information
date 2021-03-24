using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DoctorENT
/// </summary>
namespace Hospital_Information.ENT
{
    public class DoctorENT
    {
        #region Constructor

        public DoctorENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region DoctorID

        protected SqlInt32 _DoctorID;

        public SqlInt32 DoctorID
        {
            get
            {
                return _DoctorID;
            }
            set
            {
                _DoctorID = value;
            }
        }

        #endregion DoctorID

        #region DoctorName

        protected SqlString _DoctorName;

        public SqlString DoctorName
        {
            get
            {
                return _DoctorName;
            }
            set
            {
                _DoctorName = value;
            }
        }

        #endregion DoctorName

        #region DoctorImage

        protected SqlString _DoctorImage;

        public SqlString DoctorImage
        {
            get
            {
                return _DoctorImage;
            }
            set
            {
                _DoctorImage = value;
            }
        }

        #endregion DoctorImage

        #region DepartmentID

        protected SqlInt32 _DepartmentID;

        public SqlInt32 DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                _DepartmentID = value;
            }
        }

        #endregion DepartmentID

        #region Experince

        protected SqlInt32 _Experince;

        public SqlInt32 Experince
        {
            get
            {
                return _Experince;
            }
            set
            {
                _Experince = value;
            }
        }

        #endregion Experince

        #region UserName

        protected SqlString _UserName;

        public SqlString UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        #endregion UserName

        #region Password

        protected SqlString _Password;

        public SqlString Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        #endregion Password
    }
}