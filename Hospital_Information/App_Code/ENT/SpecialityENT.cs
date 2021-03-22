using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SpecialityENT
/// </summary>
namespace Hospital_Information.ENT
{
    public class SpecialityENT
    {
        #region Constructor

        public SpecialityENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

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

        #region SpecialityName

        protected SqlString _SpecialityName;
        
        public SqlString SpecialityName
        {
            get
            {
                return _SpecialityName;
            }
            set
            {
                _SpecialityName = value;
            }
        }

        #endregion SpecialityName
    }
}