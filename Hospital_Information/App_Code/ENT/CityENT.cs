using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityENT
/// </summary>
namespace Hospital_Information.ENT
{
    public class CityENT
    {
        #region Constructor

        public CityENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

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

        #region CityName

        protected SqlString _CityName;

        public SqlString CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                _CityName = value;
            }
        }

        #endregion CityName
    }
}