using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalWiseDoctorENT
/// </summary>
namespace Hospital_Information.ENT
{
    public class HospitalWiseDoctorENT
    {
        #region Constructor

        public HospitalWiseDoctorENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region HospitalWiseDoctorID

        protected SqlInt32 _HospitalWiseDoctorID;

        public SqlInt32 HospitalWiseDoctorID
        {
            get
            {
                return _HospitalWiseDoctorID;
            }
            set
            {
                _HospitalWiseDoctorID = value;
            }
        }

        #endregion HospitalWiseDoctorID

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
    }
}