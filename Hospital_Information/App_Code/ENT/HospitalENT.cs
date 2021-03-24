using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalENT
/// </summary>
namespace Hospital_Information.ENT
{
    public class HospitalENT
    {
        #region Constructor

        public HospitalENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

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

        #region HospitalName

        protected SqlString _HospitalName;

        public SqlString HospitalName
        {
            get
            {
                return _HospitalName;
            }
            set
            {
                _HospitalName = value;
            }
        }

        #endregion HospitalName

        #region Overview

        protected SqlString _Overview;

        public SqlString Overview
        {
            get
            {
                return _Overview;
            }
            set
            {
                _Overview = value;
            }
        }

        #endregion Overview

        #region SpecialityID

        protected SqlInt32 _SpecialityID;

        public SqlInt32 SpecialityID
        {
            get
            {
                return _SpecialityID;
            }
            set
            {
                _SpecialityID = value;
            }
        }

        #endregion SpecialityID

        #region Address

        protected SqlString _Address;

        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        #endregion Address

        #region CityID

        protected SqlInt32 _CityID;

        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }

        #endregion CityID

        #region Mobile

        protected SqlString _Mobile;

        public SqlString Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                _Mobile = value;
            }
        }

        #endregion Mobile

        #region Email

        protected SqlString _Email;

        public SqlString Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        #endregion Email
    }
}