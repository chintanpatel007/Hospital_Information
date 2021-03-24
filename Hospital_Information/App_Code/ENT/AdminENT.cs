using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminENT
/// </summary>
namespace Hospital_Information.ENT
{
    public class AdminENT
    {
        #region Constructor

        public AdminENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region AdminID

        protected SqlInt32 _AdminID;

        public SqlInt32 AdminID
        {
            get
            {
                return _AdminID;
            }
            set
            {
                _AdminID = value;
            }
        }

        #endregion AdminID

        #region AdminName

        protected SqlString _AdminName;

        public SqlString AdminName
        {
            get
            {
                return _AdminName;
            }
            set
            {
                _AdminName = value;
            }
        }

        #endregion AdminName

        #region AdminImage

        protected SqlString _AdminImage;

        public SqlString AdminImage
        {
            get
            {
                return _AdminImage;
            }
            set
            {
                _AdminImage = value;
            }
        }

        #endregion AdminImage

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