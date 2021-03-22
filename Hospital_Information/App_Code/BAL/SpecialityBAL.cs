using Hospital_Information.DAL;
using Hospital_Information.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SpecialityBAL
/// </summary>
namespace Hospital_Information.BAL
{
    public class SpecialityBAL
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

        public SpecialityBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region Insert Opertaion
        public Boolean Insert(SpecialityENT entSpeciality)
        {
            SpecialityDAL dalSpeciality = new SpecialityDAL();

            if(dalSpeciality.Insert(entSpeciality))
            {
                return true;
            }
            else
            {
                Message = dalSpeciality.Message;
                return false;
            }
        }
        #endregion Insert Opertaion

        #region Update Opertaion
        public Boolean Update(SpecialityENT entSpeciality)
        {
            SpecialityDAL dalSpeciality = new SpecialityDAL();

            if (dalSpeciality.Update(entSpeciality))
            {
                return true;
            }
            else
            {
                Message = dalSpeciality.Message;
                return false;
            }
        }
        #endregion Update Opertaion

        #region Delete Opertaion
        public Boolean Delete(SqlInt32 SpecialityID)
        {
            SpecialityDAL dalSpeciality = new SpecialityDAL();

            if (dalSpeciality.Delete(SpecialityID))
            {
                return true;
            }
            else
            {
                Message = dalSpeciality.Message;
                return false;
            }
        }
        #endregion Delete Opertaion

        #region Select Opertaion

        #region SelectAll
        public DataTable SelectAll()
        {
            SpecialityDAL dalSpeciality = new SpecialityDAL();
            return dalSpeciality.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            SpecialityDAL dalSpeciality = new SpecialityDAL();
            return dalSpeciality.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public SpecialityENT SelectByPK(SqlInt32 SpecialityID)
        {
            SpecialityDAL dalSpeciality = new SpecialityDAL();
            return dalSpeciality.SelectByPK(SpecialityID);
        }
        #endregion SelectByPK

        #endregion Select Opertaion

    }
}